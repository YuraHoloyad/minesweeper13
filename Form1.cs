using Minesweeper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace menesweeper
{
    public partial class menesweeper : Form
    {
        public menesweeper()
        {

            InitializeComponent();
        }
         static int sizeRow = 10;
         static int sizeCol = 10;
         static int mines = 3;
         int sizeStep = ((sizeCol * sizeRow) - mines);
        Board board = new Board(sizeRow, sizeCol, mines);

        private void NewGame_Click(object sender, EventArgs e)
        {
            removeTable();
            createTable(sizeCol,sizeRow);
            board = new Board(sizeRow, sizeCol, mines);
            gameIsOver = false;
            
        }

        private bool gameIsOver;

        private void game(bool command, int row, int col)
        {
            if (command)
            {
                if (!board.Open(row, col))
                {
                    gameOver();
                    gameIsOver = true;
                }     
            }
            else
               board.Flag(row, col);

            if (updateButton()== sizeStep && gameIsOver==false)
                gameWin();

        }
       private void gameWin()
        {
            MessageBox.Show("WIN!!!!");
        }
        private void gameOver()
        {
            for (int i = 0; i < sizeRow; i++)
                for (int j = 0; j < sizeCol; j++)
                    board.Open(i, j);
            updateButton();
            MessageBox.Show("GAME OVER");
        }

        public int updateButton()
        {
            int winCount = 0;
            for (int i=0;i<sizeRow;i++)
            {
                for (int j = 0; j < sizeCol; j++)
                {
                    string NameButton = "button_" + i + "_" + j;
                    Button tbx = this.Controls.Find(NameButton, true).FirstOrDefault() as Button;
                    string status = board.GetStatus(i, j);

                    if (status == "FLAG")
                        tbx.BackColor = System.Drawing.SystemColors.HotTrack;

                    else if (status == "CLOSE")
                    {
                        tbx.Text = "";
                        tbx.BackColor = System.Drawing.SystemColors.ControlLight;
                    }

                    else if (status == "0")
                    {
                        tbx.BackColor = SystemColors.ButtonFace;
                        winCount++;
                    }
                    else
                    {
                        tbx.Text = status;
                        winCount++;
                    }
                        
                }
            }

            return winCount;
        }


        public void button_MouseDown(object sender, MouseEventArgs e)
        {
            var button = (Button)sender;
            bool command=true;
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                command = false;
            var input = button.Name.Split('_');
            int row = int.Parse(input[1].Trim());
            int col = int.Parse(input[2].Trim());
            game(command, row, col);
        }

    }
}

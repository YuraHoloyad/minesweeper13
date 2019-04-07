using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace menesweeper
{
    partial class menesweeper
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.NewGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NewGame
            // 
            this.NewGame.Location = new System.Drawing.Point(168, 41);
            this.NewGame.Name = "NewGame";
            this.NewGame.Size = new System.Drawing.Size(103, 43);
            this.NewGame.TabIndex = 0;
            this.NewGame.Text = "New game";
            this.NewGame.UseVisualStyleBackColor = true;
            this.NewGame.Click += new System.EventHandler(this.NewGame_Click);
            // 
            // menesweeper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 415);
            this.Controls.Add(this.NewGame);
            this.Name = "menesweeper";
            this.Text = " ";
            this.ResumeLayout(false);

        }
        public void createTable(int sizeCol,int sizeRow)/////can be parameters
        {
            tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            Controls.Add(tableLayoutPanel);
            tableLayoutPanel.ColumnCount = sizeCol;
            tableLayoutPanel.RowCount = sizeRow;
            tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel.Padding = new System.Windows.Forms.Padding(0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.Location = new System.Drawing.Point(122, 154);
            tableLayoutPanel.Size = new System.Drawing.Size(500, 1000);

            for (int i = 0; i < sizeRow; i++)
            {
                tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
                for (int j = 0; j < sizeCol; j++)
                {
                    tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
                    tableLayoutPanel.Controls.Add(btnCreate(i, j));
                }
            }
        }

        private Button btnCreate(int i, int j)
        {
            Button button = new Button();
            button.Name = "button_" + i.ToString() + "_" + j.ToString();
            button.Width = 20;
            button.Height = 20;
            button.Text = "";
            button.Margin = new System.Windows.Forms.Padding(0);
            button.Padding = new System.Windows.Forms.Padding(0);
            button.MouseDown += new System.Windows.Forms.MouseEventHandler(button_MouseDown);
            return button;
        }

        public void removeTable()
        {
            for (int i = 0; i < sizeRow; i++)
            {
                
                for (int j = 0; j < sizeCol; j++)
                {
                    Controls.Remove(btnCreate(i, j));
                }
            }
            Controls.Remove(tableLayoutPanel);
        }

        public void updateButton(int sizeRow,int sizeCol)
        {
            for (int i = 0; i < sizeRow; i++)
            {
                for (int j = 0; j < sizeCol; j++)
                {
                    string NameButton = "button_" + i + "_" + j;
                    Button tbx = this.Controls.Find(NameButton, true).FirstOrDefault() as Button;
                    string status = board.GetStatus(i, j);
                    if (status == "MINE")
                        tbx.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
                    else if (status == "FLAG")
                        tbx.BackColor = System.Drawing.SystemColors.HotTrack;
                    else if (status == "CLOSE")
                        tbx.Text = "";
                    else if (status == "0")
                    {
                        tbx.BackColor = SystemColors.ButtonFace;
                    }
                    else
                        tbx.Text = status;
                }
            }
        }
        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button NewGame;
    }
}


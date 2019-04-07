using Minesweeper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace menesweeper
{
    static class Program
    {

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new menesweeper());

                try
                {
                    
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return ;
                }
            
        }
    }
}

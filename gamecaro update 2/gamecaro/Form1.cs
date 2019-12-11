using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gamecaro
{
    public partial class Form1 : System.Windows.Forms.Form
    {
       
        #region Properties
        banco bancaro;
        #endregion
        public Form1()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            
            DialogResult dialogResult = MessageBox.Show("Bạn muốn chơi trước không", "Lượt chơi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
             
                bancaro = new banco(pnl);
                bancaro.chedochoi = 1;
                bancaro.Luotchoi = 0;
                bancaro.vebanco();
            }
            else if (dialogResult == DialogResult.No)
            {
                
                bancaro = new banco(pnl);
                bancaro.chedochoi = 1;
                bancaro.Luotchoi = 1;
                bancaro.vebanco();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            bancaro.Undo();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Do you want exits ?", "EXITS",
                         MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (ret == DialogResult.Yes)
            {
                Close();
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            bancaro = new banco(pnl);
            bancaro.chedochoi = 2;
            bancaro.vebanco();
        }
    }
    
}

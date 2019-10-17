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
            bancaro = new banco(pnl);           
            bancaro.vebanco();

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
    }
    
}

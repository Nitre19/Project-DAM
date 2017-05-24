using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KamsWf
{
    public partial class FrmAccesosDirectos : Form
    {
        public FrmAccesosDirectos()
        {
            InitializeComponent();
        }

        private void redireccionar(object sender, EventArgs e)
        {
            if (((PictureBox)sender).Tag.Equals("salir"))
            {
                this.Close();
            }else
            {
                Process.Start(((PictureBox)sender).Tag.ToString());
            }
        }

        private void pbFacebook_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pbFacebook_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
    }
}

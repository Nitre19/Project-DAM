using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KamsWf
{
    public partial class FrmMain : Form
    {
        private Boolean KamsActivo;
        public FrmMain()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Cerrar y detener todo
            this.Close();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            tmSimulaPosMouse.Start();
            //tmSimulaPosMouse.Tick +=
        }

        private void acercaDeKAMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Abrir web 
            System.Diagnostics.Process.Start("http://www.google.com");
        }

        private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void desactivarKAMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KamsActivo = false;
            //Cambiar los checked del menu
        }

        private void holaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KamsActivo = true;
            //Cambiar los checked del menu
        }
    }
}

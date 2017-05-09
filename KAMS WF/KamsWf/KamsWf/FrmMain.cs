using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace KamsWf
{
    public partial class FrmMain : Form
    {
        private Boolean KamsActivo; //Creo que esta variable no va a utilizar-se
        public FrmMain()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Cerrar y detener todo
            this.Close();
            pararKinect();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            tmSimulaPosMouse.Start();
            tmSimulaPosMouse.Tick += ticktest;
            tmDesplegable.Tick += tickDesplegarTest;
            enchegarKinect();
        }

        private void tickDesplegarTest(object sender, EventArgs e)
        {
            //ESto no funciona
            Thread.Sleep(100);
            this.Height = this.Height + 1;
            this.Refresh();
        }

        private void ticktest(object sender, EventArgs e)
        {
            //cogerPosMouse();
            //comparar con pos anterior
            //anterior igual a pos
            tmDesplegable.Start();

            //this.WindowState = FormWindowState.Maximized;
            this.Height = 0;
        }

        private void acercaDeKAMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Abrir web 
            Process.Start("http://www.google.com");
            

        }

        private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //abrir FrmConfig

        }

        private void desactivarKAMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KamsActivo = false;
            desactivarKAMSToolStripMenuItem.Checked = true;
            ActivarToolStripMenuItem.Checked = false;
            pararKinect();
        }

        private void holaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KamsActivo = true;
            desactivarKAMSToolStripMenuItem.Checked = false;
            ActivarToolStripMenuItem.Checked = true;
            enchegarKinect();
        }

        private void descargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Abrir web aparado descargas 
            System.Diagnostics.Process.Start("http://www.google.com");
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //muestra uuna lista con las app's instaladas y te permite eliminarlas, es muy parecido 
        }

        //esto se puede pasar a la clase KinectControls;
        private void enchegarKinect()
        {
            pararKinect();
            Process.Start("C:\\Users\\marc\\Desktop\\Xavi DAM\\DAM2\\M13 - Projecte\\KinectV2MouseControl\\KinectV2MouseControl.exe");
        }

        private void pararKinect()
        {
            Process[] KinectProcess = Process.GetProcessesByName("KinectV2MouseControl");
            foreach (Process currentProc in KinectProcess)
            {
                currentProc.Kill();
            }
        }
    }
}

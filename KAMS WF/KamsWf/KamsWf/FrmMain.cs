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
using KamsWf.CLAS;


namespace KamsWf
{
    public partial class FrmMain : Form
    {
        private Boolean KamsActivo; //Creo que esta variable no va a utilizar-se
        ClMouse.PUNT posAnt = new ClMouse.PUNT();
        ClMouse.PUNT posActu = new ClMouse.PUNT();
        private int anchoMax;
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            posAnt.X = -99;
            posAnt.Y = -99;
            ClMouse.GetCursorPos(ref posActu);
            tmPosMouse.Tick += openPanel;
            tmMirarPosMouse.Tick += compararPosMouse;
            tmDesplegar.Tick += desplegarForm;
            tmMirarPosMouse.Start();
            enchegarKinect();
        }

        private void desplegarForm(object sender, EventArgs e)
        {            
            Height += 1;
            Refresh();

        }

        private void compararPosMouse(object sender, EventArgs e)
        {
            if (ClMouse.GetCursorPos(ref posActu))
            {
                if (posActu.Y == 0)
                {
                    tmPosMouse.Start();
                }
                else
                {
                    tmPosMouse.Stop();
                }
            }
            posAnt = posActu;
        }

        private void openPanel(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            anchoMax = this.Bounds.Width;
            this.WindowState = FormWindowState.Normal;
            Height = 0;
            Width = anchoMax;
            if (posAnt.X >= 0 && posAnt.X <= this.Bounds.Width / 2)
            {
                //abrimos el panel de modulos
                abrirModulos();
                //MessageBox.Show("Modulos");
            }
            else
            {
                if (posAnt.X > this.Bounds.Width / 2 && posAnt.X<=this.Bounds.Width)
                {
                    //abrimos el panel de perfiles
                    abrirPerfiles();
                    //MessageBox.Show("Perfiles");
                }
            }
            tmPosMouse.Stop();
        }

        private void abrirModulos()
        {
            tmDesplegar.Start();
        }

        private void abrirPerfiles()
        {
            tmDesplegar.Start();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Cerrar y detener todo            
            notifyIcon1.Visible = false;
            pararKinect();
            this.Close();
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

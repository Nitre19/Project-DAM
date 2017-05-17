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
        Screen pantalla = Screen.PrimaryScreen;
        private int anchoMax;
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            anchoMax = this.Bounds.Width;
            Height = 0;
            Refresh();
            this.WindowState = FormWindowState.Minimized;
            //MessageBox.Show(pantalla.Bounds.Height.ToString()+","+ pantalla.Bounds.Width.ToString());
            posAnt.X = -99;
            posAnt.Y = -99;
            ClMouse.GetCursorPos(ref posActu);
            tmPosMouse.Tick += openPanel;
            tmMirarPosMouse.Tick += compararPosMouse;
            tmDesplegar.Tick += desplegarForm;
            tmMirarPosMouse.Start();
<<<<<<< HEAD
            encenderProcess("C:\\Users\\marc\\Desktop\\Xavi DAM\\DAM2\\M13 - Projecte\\KinectV2MouseControl-master\\src\\KinectV2MouseControl\\bin\\Release\\KinectV2MouseControl.exe", "KinectV2MouseControl");
=======
            //encenderProcess("C:\\Users\\marc\\Desktop\\Xavi DAM\\DAM2\\M13 - Projecte\\KinectV2MouseControl\\KinectV2MouseControl.exe", "KinectV2MouseControl");
>>>>>>> origin/master
        }

        private void desplegarForm(object sender, EventArgs e)
        {
            Visible = true;
            Height += 5;
            Refresh();

        }

        private void compararPosMouse(object sender, EventArgs e)
        {
            if (ClMouse.GetCursorPos(ref posActu))
            {
                if (posActu.Y == 0)
                {
                    tmPosMouse.Start();
                    tmMirarPosMouse.Stop();
                }
                else
                {
                    if (posActu.Y >= pantalla.Bounds.Height - 5)
                    {
                        tmPosMouse.Start();
                        tmMirarPosMouse.Stop();
                    }
                    else
                    {
                        tmPosMouse.Stop();
                    }
                }
            }
            posAnt = posActu;
        }

        private void openPanel(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            //anchoMax = this.Bounds.Width;
            this.WindowState = FormWindowState.Normal;
            this.Location = new Point(0, 0);
            Height = 0;
            Width = anchoMax;
            this.Focus();
            //Visible = false;
            Refresh();
            if (posAnt.Y <= 0)
            {


                if (posAnt.X >= 0 && posAnt.X <= this.Bounds.Width / 2)
                {
                    //abrimos el panel de modulos
                    tmPosMouse.Stop();
                    abrirModulos();
                    //MessageBox.Show("Modulos");
                }
                else
                {
                    if (posAnt.X > this.Bounds.Width / 2 && posAnt.X <= this.Bounds.Width)
                    {
                        //abrimos el panel de perfiles
                        abrirPerfiles();
                        //MessageBox.Show("Perfiles");
                    }
                }
            }else
            {
                if (obtenerQttDeUnProcess("osk") < 1)
                {
                    //encenderProcess("osk.exe", "osk"); //Preguntar si tengo que poner toda la ruta
                }
                tmMirarPosMouse.Start();
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
            pararProcess("KinectV2MouseControl");
            pararProcess("osk");
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
            abrirConfig();
        }

        private void desactivarKAMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KamsActivo = false;
            desactivarKAMSToolStripMenuItem.Checked = true;
            ActivarToolStripMenuItem.Checked = false;
            pararProcess("KinectV2MouseControl");
        }

        private void holaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KamsActivo = true;
            desactivarKAMSToolStripMenuItem.Checked = false;
            ActivarToolStripMenuItem.Checked = true;
            encenderProcess("C:\\Users\\marc\\Desktop\\Xavi DAM\\DAM2\\M13 - Projecte\\KinectV2MouseControl-master\\src\\KinectV2MouseControl\bin\\Release\\KinectV2MouseControl.exe", "KinectV2MouseControl");
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
        
        private void encenderProcess(String process, String processName)
        {
            pararProcess(processName);
            Process.Start(process);
        }

        private void pararProcess(String processName)
        {
            Process[] Process = System.Diagnostics.Process.GetProcessesByName(processName);
            foreach (Process currentProc in Process)
            {
                currentProc.Kill();
            }
        }

        private int obtenerQttDeUnProcess(String processName)
        {
            Process[] Process = System.Diagnostics.Process.GetProcessesByName(processName);
            return Process.Count();
        }

        private void FrmMain_MouseLeave(object sender, EventArgs e)
        {
            tmDesplegar.Stop();
            tmMirarPosMouse.Start();
            Height = 0;
            this.WindowState = FormWindowState.Minimized;
        }

        public void abrirConfig()
        {
            FrmConfig fConfig = new FrmConfig();
            fConfig.ShowDialog();
        }
    }
}

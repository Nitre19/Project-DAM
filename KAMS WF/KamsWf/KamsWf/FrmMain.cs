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
            encenderProcess("C:\\Users\\marc\\Desktop\\Xavi DAM\\DAM2\\M13 - Projecte\\KinectV2MouseControl\\KinectV2MouseControl.exe", "KinectV2MouseControl");
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
                }
                else
                {
                    if (posActu.Y >= pantalla.Bounds.Height - 5)
                    {
                        tmPosMouse.Start();
                    }
                    else
                    {
                        if (posActu.X >= pantalla.Bounds.Width - 5)
                        {
                            tmPosMouse.Start();
                        }
                        else
                        {
                            tmPosMouse.Stop();
                        }
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
            ClMouse.GetCursorPos(ref posActu);
            if (posActu.Y <= 0)
            {
                if (posActu.X >= 0 && posActu.X <= this.Bounds.Width / 2)
                {
                    //abrimos el panel de modulos
                    tmPosMouse.Stop();
                    abrirModulos();
                    //MessageBox.Show("Modulos");
                }
                else
                {
                    if (posActu.X > this.Bounds.Width / 2 && posActu.X <= this.Bounds.Width)
                    {
                        //abrimos el panel de perfiles
                        abrirPerfiles();
                        //MessageBox.Show("Perfiles");
                    }
                }
            }else
            {
                if (posActu.Y >= pantalla.Bounds.Height - 5)
                {
                    if (obtenerQttDeUnProcess("osk") < 1)
                    {
                        //encenderProcess("osk.exe", "osk"); //Preguntar si tengo que poner toda la ruta
                    }
                }else
                {
                    if (posActu.X >= pantalla.Bounds.Width - 5)
                    {
                        abrirConfig();
                    }
                }                
            }
            tmPosMouse.Stop();
        }

        private void abrirModulos()
        {
            int i = 0;
            List<String> archivosEncontrados = new List<string>();
            archivosEncontrados = ClBuscador.RecuperaEXES("C:\\Users\\marc\\Desktop\\testSprint2\\modulos");
            foreach (var item in archivosEncontrados)
            {
                PictureBox pbModulo = new PictureBox();
                Label lblModulo = new Label();
                pbModulo.Tag = item;
                lblModulo.Tag = item;
                lblModulo.Font = new Font("Orbitron", 12, FontStyle.Bold);
                pbModulo.Size = new Size(100, 100);
                lblModulo.Size = new Size(100, 40);
                pbModulo.Image = new Bitmap("C:\\Users\\marc\\Desktop\\testSprint2\\img\\imgModulos\\"+item.Replace(".exe",".png"));
                pbModulo.Location = new Point((20+pbModulo.Width)*i+20, 20);
                lblModulo.Location = new Point((20 + pbModulo.Width) * i + 20, 20+pbModulo.Height);
                lblModulo.Text = item.Replace(".exe", "").ToUpper();
                lblModulo.TextAlign = ContentAlignment.MiddleCenter;
                pbModulo.SizeMode = PictureBoxSizeMode.StretchImage;
                pbModulo.Click += PbModulo_Click;
                this.Controls.Add(pbModulo);
                this.Controls.Add(lblModulo);
                i++;
            }
            tmDesplegar.Start();
        }

        private void PbModulo_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\Users\\marc\\Desktop\\testSprint2\\modulos\\" + ((PictureBox)sender).Tag);
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
            ClMouse.PUNT posMouse = new ClMouse.PUNT();
            ClMouse.GetCursorPos(ref posMouse);
            if (posMouse.Y>200)
            {
                tmDesplegar.Stop();
                tmMirarPosMouse.Start();
                Height = 0;
                this.WindowState = FormWindowState.Minimized;
            }            
        }

        public void abrirConfig()
        {
            FrmConfig fConfig = new FrmConfig();
            fConfig.ShowDialog();
        }
    }
}

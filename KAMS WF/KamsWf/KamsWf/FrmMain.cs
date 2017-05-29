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
using System.Xml;

namespace KamsWf
{
    public partial class FrmMain : Form
    {
        private Boolean KamsActivo; //Creo que esta variable no va a utilizar-se
        ClMouse.PUNT posAnt = new ClMouse.PUNT();
        ClMouse.PUNT posActu = new ClMouse.PUNT();
        Screen pantalla = Screen.PrimaryScreen;
        FrmPerfilUser frmUsers;
        FrmEliminarUser frmEliminarUser;
        ClControladorUser controladorUser = new ClControladorUser(Application.StartupPath);
        FrmEliminarModulo fEliminarModulo = new FrmEliminarModulo();
        FrmAccesosDirectos fAccDirec = new FrmAccesosDirectos();
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
            tmMouseLeave.Tick += minimizarForm;
            tmMirarPosMouse.Start();
            encenderProcess(Application.StartupPath + "\\KinectV2MouseControl.exe", "KinectV2MouseControl");
        }

        private void minimizarForm(object sender, EventArgs e)
        {
            ClMouse.PUNT posMouse = new ClMouse.PUNT();
            ClMouse.GetCursorPos(ref posMouse);
            if (posMouse.Y > 200 && (WindowState == FormWindowState.Maximized || WindowState == FormWindowState.Normal) )
            {
                if (!frmIsOpen("FrmPerfilUser") && !frmIsOpen("FrmAccesosDirectos") && !frmIsOpen("FrmEliminarUser") && !frmIsOpen("FrmEliminarModulo"))
                {
                    tmDesplegar.Stop();
                    tmMirarPosMouse.Start();
                    Height = 0;
                    this.WindowState = FormWindowState.Minimized;
                }                
            }
        }

        private void desplegarForm(object sender, EventArgs e)
        {
            Visible = true;
            Height += 20;
            Refresh();
        }

        private void compararPosMouse(object sender, EventArgs e)
        {
            if (ClMouse.GetCursorPos(ref posActu))
            {
                if (posActu.Y <= 5)
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
                        if (posActu.X <= 5)
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
            if (posActu.Y <= 5)
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
                    if (posActu.X <= 5)
                    {
                        abrirAccesosDirectos();
                    }
                }                
            }
            tmPosMouse.Stop();
        }

        private void abrirModulos()
        {
            borrarControles();
            int i = 0;
            List<String> archivosEncontrados = new List<string>();
            archivosEncontrados = ClBuscador.RecuperaEXES(Application.StartupPath+"\\modulos");
            foreach (var item in archivosEncontrados)
            {
                PictureBox pbModulo = new PictureBox();
                pbModulo.Tag = item;
                pbModulo.Size = new Size(100, 100);
                pbModulo.Image = new Bitmap(Application.StartupPath+"\\img\\imgModulos\\" + item.Replace(".exe", ".png"));
                pbModulo.Location = new Point((20 + pbModulo.Width) * i + 20, 20);
                pbModulo.SizeMode = PictureBoxSizeMode.StretchImage;
                pbModulo.Click += PbModulo_Click;
                pbModulo.MouseHover += cambiarCursor;
                pbModulo.MouseLeave += cursorDefault;

                Label lblModulo = new Label();
                lblModulo.Tag = item;
                lblModulo.Font = new Font("Orbitron", 12, FontStyle.Bold);
                lblModulo.Size = new Size(100, 40);
                lblModulo.Location = new Point((20 + pbModulo.Width) * i + 20, 20+pbModulo.Height);
                lblModulo.Text = item.Replace(".exe", "").ToUpper();
                lblModulo.TextAlign = ContentAlignment.MiddleCenter;

                this.Controls.Add(pbModulo);
                this.Controls.Add(lblModulo);
                i++;
            }

            PictureBox btAñadir = new PictureBox();
            btAñadir.Image = Properties.Resources.btAdd;
            btAñadir.Size = new Size(50, 50);
            btAñadir.SizeMode = PictureBoxSizeMode.StretchImage;
            btAñadir.MouseHover += cambiarCursor;
            btAñadir.MouseLeave += cursorDefault;
            btAñadir.Click += btAñadirModulo_click;
            btAñadir.Location = new Point(this.Controls[this.Controls.Count - 1].Right + 50, 30);

            PictureBox btEliminar = new PictureBox();
            btEliminar.Image = Properties.Resources.btRemove;
            btEliminar.Size = new Size(50, 50);
            btEliminar.MouseHover += cambiarCursor;
            btEliminar.MouseLeave += cursorDefault;
            btEliminar.Click += btEliminarModelo_click;
            btEliminar.SizeMode = PictureBoxSizeMode.StretchImage;
            btEliminar.Location = new Point(this.Controls[this.Controls.Count - 1].Right + 50, btEliminar.Bottom + 50);


            this.Controls.Add(btAñadir);
            this.Controls.Add(btEliminar);
            tmDesplegar.Start();
        }
        
        private void PbModulo_Click(object sender, EventArgs e)
        {
            if (((PictureBox)sender).Tag.ToString() == "Fronton.exe")
            {
                pararProcess("KinectV2MouseControl");
            }
            Process.Start(Application.StartupPath+"\\modulos\\" + ((PictureBox)sender).Tag);
        }

        private void abrirPerfiles()
        {
            borrarControles();
            int i = 0;
            controladorUser.cargarXML();
            foreach (XmlNode node in controladorUser.xDoc.DocumentElement.ChildNodes)
            {
                PictureBox pbModulo = new PictureBox();
                pbModulo.Tag = node.ChildNodes[0].InnerText + ";" + node.ChildNodes[1].InnerText;                
                pbModulo.Size = new Size(100, 100);
                pbModulo.Image = new Bitmap(node.ChildNodes[1].InnerText);
                pbModulo.Location = new Point((20 + pbModulo.Width) * i + 20, 20);
                pbModulo.SizeMode = PictureBoxSizeMode.StretchImage;
                pbModulo.Click += PbPerfil_Click;
                pbModulo.MouseHover += cambiarCursor;
                pbModulo.MouseLeave += cursorDefault;

                Label lblModulo = new Label();
                lblModulo.Font = new Font(lblModulo.Font.FontFamily, 12, FontStyle.Bold);
                lblModulo.Size = new Size(100, 40);
                lblModulo.Location = new Point((20 + pbModulo.Width) * i + 20, 20 + pbModulo.Height);
                lblModulo.Text = node.ChildNodes[0].InnerText;
                lblModulo.TextAlign = ContentAlignment.MiddleCenter;

                this.Controls.Add(pbModulo);
                this.Controls.Add(lblModulo);
                i++;
            }

            PictureBox btAñadir = new PictureBox();
            btAñadir.Image = Properties.Resources.btAdd;
            btAñadir.Size = new Size(50, 50);
            btAñadir.SizeMode = PictureBoxSizeMode.StretchImage; 
            btAñadir.Location = new Point(this.Controls[this.Controls.Count - 1].Right + 50, 30);
            btAñadir.MouseHover += cambiarCursor;
            btAñadir.MouseLeave += cursorDefault;
            btAñadir.Click += btAñadirPerfil_click;

            PictureBox btEliminar = new PictureBox();
            btEliminar.Image = Properties.Resources.btRemove;
            btEliminar.Size = new Size(50, 50);
            btEliminar.SizeMode = PictureBoxSizeMode.StretchImage;
            btEliminar.Location = new Point(this.Controls[this.Controls.Count - 1].Right + 50, btEliminar.Bottom+50);
            btEliminar.MouseHover += cambiarCursor;
            btEliminar.MouseLeave += cursorDefault;
            btEliminar.Click += btEliminarPerfil_click;

            this.Controls.Add(btAñadir);
            this.Controls.Add(btEliminar);

            tmDesplegar.Start();
        }

        private void PbPerfil_Click(object sender, EventArgs e)
        {
            String[] datos = ((PictureBox)sender).Tag.ToString().Split(';');
            frmUsers = new FrmPerfilUser(datos[0], datos[1]);
            frmUsers.ShowDialog();
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
            Process.Start("http://localhost/docs/examples/carousel/index.html");
            

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

            encenderProcess(Application.StartupPath+"\\KinectV2MouseControl.exe", "KinectV2MouseControl");

        }

        private void descargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Abrir web aparado descargas 
            System.Diagnostics.Process.Start("http://localhost/docs/examples/carousel/downloads.html");
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //muestra uuna lista con las app's instaladas y te permite eliminarlas, es muy parecido 
            if (!frmIsOpen("FrmEliminarModulo"))
            {
                fEliminarModulo.ShowDialog();
            }
        }
        
        private void encenderProcess(String process, String processName)
        {
            pararProcess(processName);
            //Process.Start(process);
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

        public void abrirAccesosDirectos()
        {
            if (!frmIsOpen("FrmAccesosDirectos"))
            {
                fAccDirec.ShowDialog();
            }
                          
        }

        public void borrarControles()
        {
            int i = 0;

            while (this.Controls.Count != 0)
            {
                if(this.Controls[i] is PictureBox || this.Controls[i] is Label)
                {
                    this.Controls.RemoveAt(i);
                }
            }
        }

        private void cambiarCursor(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cursorDefault(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btEliminarPerfil_click(object sender, EventArgs e)
        {
            frmEliminarUser = new FrmEliminarUser();
            frmEliminarUser.ShowDialog();
        }

        private void btAñadirPerfil_click(object sender, EventArgs e)
        {
            frmUsers = new FrmPerfilUser();
            frmUsers.ShowDialog();
        }

        private void btAñadirModulo_click(object sender, EventArgs e)
        {
            Process.Start("http://localhost/docs/examples/carousel/downloads.html");
        }

        private void btEliminarModelo_click(object sender, EventArgs e)
        {
            if (!frmIsOpen("FrmConfig"))
            {                                
                fEliminarModulo.ShowDialog();
            }
        }

        //public void limpiarControls()
        //{
        //    Boolean eliminar;
        //    Console.WriteLine("-------Eliminando-------");
        //    var controles = this.Controls;       
        //    foreach (Control c in controles)
        //    {
        //        eliminar = false;
        //        if (typeof(Label) == c.GetType())
        //        {
        //            eliminar = true;
        //        }
        //        if (typeof(PictureBox) == c.GetType())
        //        {
        //            eliminar = true;                    
        //        }
        //        if (eliminar)
        //        {
        //            Console.WriteLine(c.GetType() + "Eliminado");
        //            this.Controls.Remove(c);
        //        }
        //        Visible = false;
        //        Refresh();
        //        Visible = true;
        //    }
        //    Console.WriteLine("-------Todo Eliminado-------");
        //}

        public Boolean frmIsOpen(String psName)
        {
            Boolean isOpen = false;
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Name == psName)
                {
                    isOpen = true;
                }
            }

            return isOpen;
        }
    }
}

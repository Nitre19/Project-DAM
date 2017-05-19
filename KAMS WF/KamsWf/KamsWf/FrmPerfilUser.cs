using KamsWf.CLAS;
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
    public partial class FrmPerfilUser : Form
    {
        ClControladorUser modelUser = new ClControladorUser(Application.StartupPath);
        Bitmap foto;
        String nomUser;

        public FrmPerfilUser()
        {
            InitializeComponent();
            nomUser = "";
        }

        public FrmPerfilUser(String nomUser, String rutaFoto)
        {
            InitializeComponent();
            //NOMBRE USER
            tbNomUsuari.Text = nomUser;
            this.nomUser = nomUser;

            //FOTO

            opfFoto.FileName = rutaFoto;
            foto = new Bitmap(rutaFoto);
            pbFotoUsuari.Image = foto;

        }
        private void btExaminar_Click(object sender, EventArgs e)
        {
            opfFoto.Filter = "All Files|*.png;*.jpg;*.jepg; *.gif | PNG |*.png | JPG|*.jpg | JEPG|*.jepg | GIF|*.gif";
            DialogResult dialog = opfFoto.ShowDialog();

            if(dialog == DialogResult.OK)
            {
                foto = new Bitmap(opfFoto.FileName.ToString());
                pbFotoUsuari.Image = foto;
            }
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            if (nomUser.Equals(""))
            {
                if (opfFoto.FileName != "" && tbNomUsuari.Text != "")
                {
                    if (!modelUser.crearUser(tbNomUsuari.Text, opfFoto.FileName))
                    {
                        MessageBox.Show("Ja existeix l'usuari");
                    }
                }
                else
                {
                    MessageBox.Show("Tienes que seleccionar una imagen y un nombre para el usuario", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (opfFoto.FileName != "" && tbNomUsuari.Text != "")
                {
                    modelUser.modificaUser(tbNomUsuari.Text, nomUser, opfFoto.FileName);
                }
                else
                {
                    MessageBox.Show("Tienes que seleccionar una imagen y un nombre para el usuario", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.Close();
        }
    }
}

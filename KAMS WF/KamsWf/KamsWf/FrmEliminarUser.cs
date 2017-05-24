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
using System.Xml;

namespace KamsWf
{
    public partial class FrmEliminarUser : Form
    {
        ClModelUser modelUser = new ClModelUser(Application.StartupPath);

        public FrmEliminarUser()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            cargarListBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("¿Seguro que quieres borrar este usuario?\nNombre: " + textBox1.Text, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(dialog== DialogResult.Yes)
            {
                if (modelUser.eliminarUser(textBox1.Text))
                {
                    MessageBox.Show("Usuari eliminat correctament");
                    cargarListBox();
                }
            }
        }

        private void lbUsuaris_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bitmap foto = new Bitmap(modelUser.findFoto(lbUsuaris.SelectedItem.ToString()));
            pbImagen.Image = foto;

            textBox1.Text = lbUsuaris.SelectedItems[0].ToString();
        }

        private void cargarListBox()
        {
            lbUsuaris.Items.Clear();

            XmlDocument xdoc = new XmlDocument();
            modelUser.cargarXML("xmlUsers.xml");
            xdoc = modelUser.xDoc;

            foreach (XmlNode xnode in xdoc.DocumentElement.ChildNodes)
            {
                lbUsuaris.Items.Add(xnode.ChildNodes[0].InnerText);
            }
        }
    }
}

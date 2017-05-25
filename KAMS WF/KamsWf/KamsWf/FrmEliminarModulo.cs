using KamsWf.CLAS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KamsWf
{
    public partial class FrmEliminarModulo : Form
    {
        List<String> archivosEncontrados = new List<string>();

        public FrmEliminarModulo()
        {
            InitializeComponent();
        }
        private void FrmEliminarModulo_Load(object sender, EventArgs e)
        {
            lbModulos.Items.Clear();
            archivosEncontrados = ClBuscador.RecuperaEXES(Application.StartupPath+"\\modulos");

            foreach (var item in archivosEncontrados)
            {
                lbModulos.Items.Add(item);
            }
        }

        private void lbModulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbNom.Text = lbModulos.SelectedItems[0].ToString().Replace(".exe","");
            pbImagen.Image = new Bitmap(Application.StartupPath + "\\img\\imgModulos\\" + lbModulos.SelectedItems[0].ToString().Replace(".exe", ".png"));

        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            File.Delete(Application.StartupPath+"\\modulos\\"+lbModulos.SelectedItems[0].ToString());
            this.Close();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

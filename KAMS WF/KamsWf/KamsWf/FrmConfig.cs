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
    public partial class FrmConfig : Form
    {
        public FrmConfig()
        {
            InitializeComponent();
        }

        private void FrmConfig_Load(object sender, EventArgs e)
        {
            cmbIdioma.SelectedIndex = 0;
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            //Guardar datos en XML
            this.Close();
        }
    }
}

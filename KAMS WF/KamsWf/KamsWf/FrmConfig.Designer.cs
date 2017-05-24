namespace KamsWf
{
    partial class FrmConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSpeedApp = new System.Windows.Forms.Label();
            this.tbSpeedApp = new System.Windows.Forms.TrackBar();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.lblSpeedDobleClick = new System.Windows.Forms.Label();
            this.lblIdioma = new System.Windows.Forms.Label();
            this.cmbIdioma = new System.Windows.Forms.ComboBox();
            this.tbSpeedClickDerecho = new System.Windows.Forms.TrackBar();
            this.lblSpeedClickDerecho = new System.Windows.Forms.Label();
            this.btGuardar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeedApp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeedClickDerecho)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSpeedApp
            // 
            this.lblSpeedApp.AutoSize = true;
            this.lblSpeedApp.Location = new System.Drawing.Point(12, 9);
            this.lblSpeedApp.Name = "lblSpeedApp";
            this.lblSpeedApp.Size = new System.Drawing.Size(106, 13);
            this.lblSpeedApp.TabIndex = 0;
            this.lblSpeedApp.Text = "Velocidad del cursor:";
            // 
            // tbSpeedApp
            // 
            this.tbSpeedApp.Location = new System.Drawing.Point(145, 9);
            this.tbSpeedApp.Maximum = 20;
            this.tbSpeedApp.Name = "tbSpeedApp";
            this.tbSpeedApp.Size = new System.Drawing.Size(257, 45);
            this.tbSpeedApp.TabIndex = 1;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(145, 49);
            this.trackBar1.Maximum = 20;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(257, 45);
            this.trackBar1.TabIndex = 3;
            // 
            // lblSpeedDobleClick
            // 
            this.lblSpeedDobleClick.AutoSize = true;
            this.lblSpeedDobleClick.Location = new System.Drawing.Point(12, 49);
            this.lblSpeedDobleClick.Name = "lblSpeedDobleClick";
            this.lblSpeedDobleClick.Size = new System.Drawing.Size(112, 13);
            this.lblSpeedDobleClick.TabIndex = 2;
            this.lblSpeedDobleClick.Text = "Velocidad doble Click:";
            // 
            // lblIdioma
            // 
            this.lblIdioma.AutoSize = true;
            this.lblIdioma.Location = new System.Drawing.Point(13, 149);
            this.lblIdioma.Name = "lblIdioma";
            this.lblIdioma.Size = new System.Drawing.Size(41, 13);
            this.lblIdioma.TabIndex = 4;
            this.lblIdioma.Text = "Idioma:";
            // 
            // cmbIdioma
            // 
            this.cmbIdioma.FormattingEnabled = true;
            this.cmbIdioma.Items.AddRange(new object[] {
            "Español",
            "Ingles",
            "Catalan"});
            this.cmbIdioma.Location = new System.Drawing.Point(145, 146);
            this.cmbIdioma.Name = "cmbIdioma";
            this.cmbIdioma.Size = new System.Drawing.Size(121, 21);
            this.cmbIdioma.TabIndex = 5;
            // 
            // tbSpeedClickDerecho
            // 
            this.tbSpeedClickDerecho.Location = new System.Drawing.Point(145, 100);
            this.tbSpeedClickDerecho.Maximum = 20;
            this.tbSpeedClickDerecho.Name = "tbSpeedClickDerecho";
            this.tbSpeedClickDerecho.Size = new System.Drawing.Size(257, 45);
            this.tbSpeedClickDerecho.TabIndex = 7;
            // 
            // lblSpeedClickDerecho
            // 
            this.lblSpeedClickDerecho.AutoSize = true;
            this.lblSpeedClickDerecho.Location = new System.Drawing.Point(12, 100);
            this.lblSpeedClickDerecho.Name = "lblSpeedClickDerecho";
            this.lblSpeedClickDerecho.Size = new System.Drawing.Size(127, 13);
            this.lblSpeedClickDerecho.TabIndex = 6;
            this.lblSpeedClickDerecho.Text = "Velocidad Click Derecho:";
            // 
            // btGuardar
            // 
            this.btGuardar.Location = new System.Drawing.Point(42, 173);
            this.btGuardar.Name = "btGuardar";
            this.btGuardar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btGuardar.Size = new System.Drawing.Size(75, 23);
            this.btGuardar.TabIndex = 8;
            this.btGuardar.Text = "Guardar";
            this.btGuardar.UseVisualStyleBackColor = true;
            this.btGuardar.Click += new System.EventHandler(this.btGuardar_Click);
            // 
            // FrmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 208);
            this.Controls.Add(this.btGuardar);
            this.Controls.Add(this.tbSpeedClickDerecho);
            this.Controls.Add(this.lblSpeedClickDerecho);
            this.Controls.Add(this.cmbIdioma);
            this.Controls.Add(this.lblIdioma);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.lblSpeedDobleClick);
            this.Controls.Add(this.tbSpeedApp);
            this.Controls.Add(this.lblSpeedApp);
            this.Name = "FrmConfig";
            this.Text = "Config KAMS";
            this.Load += new System.EventHandler(this.FrmConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeedApp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeedClickDerecho)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSpeedApp;
        private System.Windows.Forms.TrackBar tbSpeedApp;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label lblSpeedDobleClick;
        private System.Windows.Forms.Label lblIdioma;
        private System.Windows.Forms.ComboBox cmbIdioma;
        private System.Windows.Forms.TrackBar tbSpeedClickDerecho;
        private System.Windows.Forms.Label lblSpeedClickDerecho;
        private System.Windows.Forms.Button btGuardar;
    }
}
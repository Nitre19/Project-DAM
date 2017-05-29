namespace KamsWf
{
    partial class FrmPerfilUser
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
            this.pbFotoUsuari = new System.Windows.Forms.PictureBox();
            this.btExaminar = new System.Windows.Forms.Button();
            this.btHacerFoto = new System.Windows.Forms.Button();
            this.tbNomUsuari = new System.Windows.Forms.TextBox();
            this.lbFoto = new System.Windows.Forms.Label();
            this.opfFoto = new System.Windows.Forms.OpenFileDialog();
            this.lbNom = new System.Windows.Forms.Label();
            this.btGuardar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbFotoUsuari)).BeginInit();
            this.SuspendLayout();
            // 
            // pbFotoUsuari
            // 
            this.pbFotoUsuari.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbFotoUsuari.Location = new System.Drawing.Point(141, 49);
            this.pbFotoUsuari.Name = "pbFotoUsuari";
            this.pbFotoUsuari.Size = new System.Drawing.Size(143, 132);
            this.pbFotoUsuari.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFotoUsuari.TabIndex = 0;
            this.pbFotoUsuari.TabStop = false;
            this.pbFotoUsuari.Click += new System.EventHandler(this.btExaminar_Click);
            // 
            // btExaminar
            // 
            this.btExaminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExaminar.Location = new System.Drawing.Point(357, 58);
            this.btExaminar.Name = "btExaminar";
            this.btExaminar.Size = new System.Drawing.Size(143, 41);
            this.btExaminar.TabIndex = 1;
            this.btExaminar.Text = "Examinar";
            this.btExaminar.UseVisualStyleBackColor = true;
            this.btExaminar.Click += new System.EventHandler(this.btExaminar_Click);
            // 
            // btHacerFoto
            // 
            this.btHacerFoto.Enabled = false;
            this.btHacerFoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btHacerFoto.Location = new System.Drawing.Point(357, 139);
            this.btHacerFoto.Name = "btHacerFoto";
            this.btHacerFoto.Size = new System.Drawing.Size(143, 41);
            this.btHacerFoto.TabIndex = 2;
            this.btHacerFoto.Text = "Hacer Foto";
            this.btHacerFoto.UseVisualStyleBackColor = true;
            // 
            // tbNomUsuari
            // 
            this.tbNomUsuari.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNomUsuari.Location = new System.Drawing.Point(89, 209);
            this.tbNomUsuari.Name = "tbNomUsuari";
            this.tbNomUsuari.Size = new System.Drawing.Size(241, 26);
            this.tbNomUsuari.TabIndex = 3;
            // 
            // lbFoto
            // 
            this.lbFoto.AutoSize = true;
            this.lbFoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFoto.Location = new System.Drawing.Point(187, 19);
            this.lbFoto.Name = "lbFoto";
            this.lbFoto.Size = new System.Drawing.Size(46, 20);
            this.lbFoto.TabIndex = 4;
            this.lbFoto.Text = "Foto";
            // 
            // opfFoto
            // 
            this.opfFoto.Title = "Escoge una foto de perfil";
            // 
            // lbNom
            // 
            this.lbNom.AutoSize = true;
            this.lbNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNom.Location = new System.Drawing.Point(12, 212);
            this.lbNom.Name = "lbNom";
            this.lbNom.Size = new System.Drawing.Size(71, 20);
            this.lbNom.TabIndex = 5;
            this.lbNom.Text = "Nombre";
            // 
            // btGuardar
            // 
            this.btGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGuardar.Location = new System.Drawing.Point(382, 267);
            this.btGuardar.Name = "btGuardar";
            this.btGuardar.Size = new System.Drawing.Size(143, 41);
            this.btGuardar.TabIndex = 6;
            this.btGuardar.Text = "Guardar";
            this.btGuardar.UseVisualStyleBackColor = true;
            this.btGuardar.Click += new System.EventHandler(this.btGuardar_Click);
            // 
            // FrmPerfilUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 321);
            this.Controls.Add(this.btGuardar);
            this.Controls.Add(this.lbNom);
            this.Controls.Add(this.lbFoto);
            this.Controls.Add(this.tbNomUsuari);
            this.Controls.Add(this.btHacerFoto);
            this.Controls.Add(this.btExaminar);
            this.Controls.Add(this.pbFotoUsuari);
            this.Name = "FrmPerfilUser";
            this.Text = "FrmPerfilUser";
            ((System.ComponentModel.ISupportInitialize)(this.pbFotoUsuari)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbFotoUsuari;
        private System.Windows.Forms.Button btExaminar;
        private System.Windows.Forms.Button btHacerFoto;
        private System.Windows.Forms.TextBox tbNomUsuari;
        private System.Windows.Forms.Label lbFoto;
        private System.Windows.Forms.OpenFileDialog opfFoto;
        private System.Windows.Forms.Label lbNom;
        private System.Windows.Forms.Button btGuardar;
    }
}


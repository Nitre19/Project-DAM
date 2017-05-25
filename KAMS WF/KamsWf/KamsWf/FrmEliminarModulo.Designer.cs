namespace KamsWf
{
    partial class FrmEliminarModulo
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
            this.tbNom = new System.Windows.Forms.TextBox();
            this.btEliminar = new System.Windows.Forms.Button();
            this.pbImagen = new System.Windows.Forms.PictureBox();
            this.lbModulos = new System.Windows.Forms.ListBox();
            this.btCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // tbNom
            // 
            this.tbNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNom.Location = new System.Drawing.Point(334, 202);
            this.tbNom.Name = "tbNom";
            this.tbNom.ReadOnly = true;
            this.tbNom.Size = new System.Drawing.Size(148, 26);
            this.tbNom.TabIndex = 8;
            // 
            // btEliminar
            // 
            this.btEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEliminar.Location = new System.Drawing.Point(419, 241);
            this.btEliminar.Name = "btEliminar";
            this.btEliminar.Size = new System.Drawing.Size(94, 42);
            this.btEliminar.TabIndex = 7;
            this.btEliminar.Text = "Eliminar";
            this.btEliminar.UseVisualStyleBackColor = true;
            this.btEliminar.Click += new System.EventHandler(this.btEliminar_Click);
            // 
            // pbImagen
            // 
            this.pbImagen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImagen.Location = new System.Drawing.Point(334, 20);
            this.pbImagen.Name = "pbImagen";
            this.pbImagen.Size = new System.Drawing.Size(149, 159);
            this.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImagen.TabIndex = 6;
            this.pbImagen.TabStop = false;
            // 
            // lbModulos
            // 
            this.lbModulos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbModulos.FormattingEnabled = true;
            this.lbModulos.ItemHeight = 20;
            this.lbModulos.Location = new System.Drawing.Point(12, 10);
            this.lbModulos.Name = "lbModulos";
            this.lbModulos.Size = new System.Drawing.Size(257, 264);
            this.lbModulos.TabIndex = 5;
            this.lbModulos.SelectedIndexChanged += new System.EventHandler(this.lbModulos_SelectedIndexChanged);
            // 
            // btCancelar
            // 
            this.btCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancelar.Location = new System.Drawing.Point(319, 241);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(94, 42);
            this.btCancelar.TabIndex = 9;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // FrmEliminarModulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 288);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.tbNom);
            this.Controls.Add(this.btEliminar);
            this.Controls.Add(this.pbImagen);
            this.Controls.Add(this.lbModulos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmEliminarModulo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmEliminarModulo";
            this.Load += new System.EventHandler(this.FrmEliminarModulo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbNom;
        private System.Windows.Forms.Button btEliminar;
        private System.Windows.Forms.PictureBox pbImagen;
        private System.Windows.Forms.ListBox lbModulos;
        private System.Windows.Forms.Button btCancelar;
    }
}
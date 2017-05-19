namespace KamsWf
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ActivarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desactivarKAMSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.gestionarModulosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descargarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.acercaDeKAMSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmPosMouse = new System.Windows.Forms.Timer(this.components);
            this.tmMirarPosMouse = new System.Windows.Forms.Timer(this.components);
            this.tmDesplegar = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "KAMS";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActivarToolStripMenuItem,
            this.desactivarKAMSToolStripMenuItem,
            this.toolStripSeparator1,
            this.gestionarModulosToolStripMenuItem,
            this.configuraciónToolStripMenuItem,
            this.toolStripSeparator2,
            this.acercaDeKAMSToolStripMenuItem,
            this.toolStripSeparator3,
            this.salirToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(175, 154);
            // 
            // ActivarToolStripMenuItem
            // 
            this.ActivarToolStripMenuItem.Checked = true;
            this.ActivarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ActivarToolStripMenuItem.Name = "ActivarToolStripMenuItem";
            this.ActivarToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.ActivarToolStripMenuItem.Text = "Activar KAMS";
            this.ActivarToolStripMenuItem.Click += new System.EventHandler(this.holaToolStripMenuItem_Click);
            // 
            // desactivarKAMSToolStripMenuItem
            // 
            this.desactivarKAMSToolStripMenuItem.Name = "desactivarKAMSToolStripMenuItem";
            this.desactivarKAMSToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.desactivarKAMSToolStripMenuItem.Text = "Desactivar KAMS";
            this.desactivarKAMSToolStripMenuItem.Click += new System.EventHandler(this.desactivarKAMSToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(171, 6);
            // 
            // gestionarModulosToolStripMenuItem
            // 
            this.gestionarModulosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.descargarToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.gestionarModulosToolStripMenuItem.Name = "gestionarModulosToolStripMenuItem";
            this.gestionarModulosToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.gestionarModulosToolStripMenuItem.Text = "Gestionar modulos";
            // 
            // descargarToolStripMenuItem
            // 
            this.descargarToolStripMenuItem.Name = "descargarToolStripMenuItem";
            this.descargarToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.descargarToolStripMenuItem.Text = "Descargar";
            this.descargarToolStripMenuItem.Click += new System.EventHandler(this.descargarToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // configuraciónToolStripMenuItem
            // 
            this.configuraciónToolStripMenuItem.Name = "configuraciónToolStripMenuItem";
            this.configuraciónToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.configuraciónToolStripMenuItem.Text = "Configuración";
            this.configuraciónToolStripMenuItem.Click += new System.EventHandler(this.configuraciónToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(171, 6);
            // 
            // acercaDeKAMSToolStripMenuItem
            // 
            this.acercaDeKAMSToolStripMenuItem.Name = "acercaDeKAMSToolStripMenuItem";
            this.acercaDeKAMSToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.acercaDeKAMSToolStripMenuItem.Text = "Acerca de KAMS...";
            this.acercaDeKAMSToolStripMenuItem.Click += new System.EventHandler(this.acercaDeKAMSToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(171, 6);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // tmPosMouse
            // 
            this.tmPosMouse.Interval = 3000;
            // 
            // tmMirarPosMouse
            // 
            this.tmMirarPosMouse.Interval = 50;
            // 
            // tmDesplegar
            // 
            this.tmDesplegar.Interval = 5;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(0, 0);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(99999, 200);
            this.Name = "FrmMain";
            this.Opacity = 0.8D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Kinect Advanced Movement Sensor";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.MouseLeave += new System.EventHandler(this.FrmMain_MouseLeave);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ActivarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem desactivarKAMSToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem gestionarModulosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem acercaDeKAMSToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.Timer tmPosMouse;
        private System.Windows.Forms.Timer tmMirarPosMouse;
        private System.Windows.Forms.ToolStripMenuItem descargarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.Timer tmDesplegar;
    }
}


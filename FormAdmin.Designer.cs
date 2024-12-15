namespace ProyectoFinal
{
    partial class FormAdmin
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
            buttonSalir = new Button();
            menuStrip1 = new MenuStrip();
            agregarToolStripMenuItem = new ToolStripMenuItem();
            eliminarToolStripMenuItem = new ToolStripMenuItem();
            verToolStripMenuItem = new ToolStripMenuItem();
            ventasToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // buttonSalir
            // 
            buttonSalir.BackColor = Color.Transparent;
            buttonSalir.BackgroundImage = Properties.Resources.cerrarsesion;
            buttonSalir.BackgroundImageLayout = ImageLayout.Stretch;
            buttonSalir.Cursor = Cursors.Hand;
            buttonSalir.FlatAppearance.BorderSize = 0;
            buttonSalir.FlatStyle = FlatStyle.Flat;
            buttonSalir.Location = new Point(752, 404);
            buttonSalir.Name = "buttonSalir";
            buttonSalir.Size = new Size(36, 34);
            buttonSalir.TabIndex = 1;
            buttonSalir.UseVisualStyleBackColor = false;
            buttonSalir.Click += buttonSalir_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.AutoSize = false;
            menuStrip1.Dock = DockStyle.None;
            menuStrip1.Items.AddRange(new ToolStripItem[] { agregarToolStripMenuItem, eliminarToolStripMenuItem, verToolStripMenuItem, ventasToolStripMenuItem });
            menuStrip1.Location = new Point(-2, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(802, 38);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // agregarToolStripMenuItem
            // 
            agregarToolStripMenuItem.AutoSize = false;
            agregarToolStripMenuItem.Image = Properties.Resources.agregarproducto;
            agregarToolStripMenuItem.ImageTransparentColor = Color.Transparent;
            agregarToolStripMenuItem.Name = "agregarToolStripMenuItem";
            agregarToolStripMenuItem.Size = new Size(60, 40);
            agregarToolStripMenuItem.Text = "Agregar";
            agregarToolStripMenuItem.TextImageRelation = TextImageRelation.TextAboveImage;
            // 
            // eliminarToolStripMenuItem
            // 
            eliminarToolStripMenuItem.AutoSize = false;
            eliminarToolStripMenuItem.Image = Properties.Resources.eliminarproducto;
            eliminarToolStripMenuItem.ImageTransparentColor = Color.Transparent;
            eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            eliminarToolStripMenuItem.Size = new Size(60, 40);
            eliminarToolStripMenuItem.Text = "Eliminar";
            eliminarToolStripMenuItem.TextImageRelation = TextImageRelation.TextAboveImage;
            // 
            // verToolStripMenuItem
            // 
            verToolStripMenuItem.AutoSize = false;
            verToolStripMenuItem.Image = Properties.Resources.verproducto;
            verToolStripMenuItem.ImageTransparentColor = Color.Transparent;
            verToolStripMenuItem.Name = "verToolStripMenuItem";
            verToolStripMenuItem.Size = new Size(60, 40);
            verToolStripMenuItem.Text = "Almacen";
            verToolStripMenuItem.TextImageRelation = TextImageRelation.TextAboveImage;
            // 
            // ventasToolStripMenuItem
            // 
            ventasToolStripMenuItem.AutoSize = false;
            ventasToolStripMenuItem.Image = Properties.Resources.ventas;
            ventasToolStripMenuItem.ImageTransparentColor = Color.Transparent;
            ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            ventasToolStripMenuItem.Size = new Size(60, 40);
            ventasToolStripMenuItem.Text = "Ventas";
            ventasToolStripMenuItem.TextImageRelation = TextImageRelation.TextAboveImage;
            // 
            // FormAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonSalir);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "FormAdmin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonSalir;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem agregarToolStripMenuItem;
        private ToolStripMenuItem eliminarToolStripMenuItem;
        private ToolStripMenuItem verToolStripMenuItem;
        private ToolStripMenuItem ventasToolStripMenuItem;
    }
}
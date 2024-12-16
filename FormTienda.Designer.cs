namespace ProyectoFinal
{
    partial class FormTienda
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonSalir = new Button();
            SuspendLayout();
            // 
            // buttonSalir
            // 
            buttonSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSalir.BackColor = Color.Transparent;
            buttonSalir.BackgroundImage = Properties.Resources.cerrarsesion;
            buttonSalir.BackgroundImageLayout = ImageLayout.Stretch;
            buttonSalir.Cursor = Cursors.Hand;
            buttonSalir.FlatAppearance.BorderSize = 0;
            buttonSalir.FlatStyle = FlatStyle.Flat;
            buttonSalir.Location = new Point(752, 404);
            buttonSalir.Name = "buttonSalir";
            buttonSalir.Size = new Size(36, 34);
            buttonSalir.TabIndex = 0;
            buttonSalir.UseVisualStyleBackColor = false;
            buttonSalir.Click += buttonSalir_Click;
            // 
            // FormTienda
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.tienda;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonSalir);
            DoubleBuffered = true;
            Name = "FormTienda";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            Load += FormTienda_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button buttonSalir;
    }
}

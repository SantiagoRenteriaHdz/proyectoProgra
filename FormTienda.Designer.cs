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
            buttonSalir.Location = new Point(1324, 885);
            buttonSalir.Margin = new Padding(6, 6, 6, 6);
            buttonSalir.Name = "buttonSalir";
            buttonSalir.Size = new Size(139, 49);
            buttonSalir.TabIndex = 0;
            buttonSalir.Text = "Salir";
            buttonSalir.UseVisualStyleBackColor = true;
            buttonSalir.Click += buttonSalir_Click;
            // 
            // FormTienda
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1486, 960);
            Controls.Add(buttonSalir);
            Margin = new Padding(6, 6, 6, 6);
            Name = "FormTienda";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            Load += this.FormTienda_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button buttonSalir;
    }
}

namespace ProyectoFinal
{
    partial class FormPortada
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
            buttonInicio = new Button();
            SuspendLayout();
            // 
            // buttonInicio
            // 
            buttonInicio.BackColor = Color.Transparent;
            buttonInicio.FlatAppearance.BorderSize = 0;
            buttonInicio.FlatAppearance.MouseDownBackColor = Color.DarkGoldenrod;
            buttonInicio.FlatAppearance.MouseOverBackColor = Color.Transparent;
            buttonInicio.FlatStyle = FlatStyle.Flat;
            buttonInicio.ForeColor = Color.Transparent;
            buttonInicio.Location = new Point(357, 366);
            buttonInicio.Margin = new Padding(0);
            buttonInicio.Name = "buttonInicio";
            buttonInicio.Size = new Size(84, 24);
            buttonInicio.TabIndex = 0;
            buttonInicio.UseVisualStyleBackColor = false;
            // 
            // FormPortada
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.portadachida;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonInicio);
            Name = "FormPortada";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Portada";
            WindowState = FormWindowState.Maximized;
            Load += FormPortada_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button buttonInicio;
    }
}
namespace ProyectoFinal
{
    partial class InicioSesion
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
            buttonCerrar = new Button();
            buttonIngresar = new Button();
            SuspendLayout();
            // 
            // buttonCerrar
            // 
            buttonCerrar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonCerrar.BackColor = Color.Transparent;
            buttonCerrar.FlatAppearance.BorderSize = 0;
            buttonCerrar.FlatAppearance.MouseDownBackColor = Color.Transparent;
            buttonCerrar.FlatAppearance.MouseOverBackColor = Color.Transparent;
            buttonCerrar.FlatStyle = FlatStyle.Flat;
            buttonCerrar.Location = new Point(529, 669);
            buttonCerrar.Name = "buttonCerrar";
            buttonCerrar.Size = new Size(170, 62);
            buttonCerrar.TabIndex = 0;
            buttonCerrar.UseVisualStyleBackColor = false;
            buttonCerrar.Click += buttonCerrar_Click;
            // 
            // buttonIngresar
            // 
            buttonIngresar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonIngresar.BackColor = Color.Transparent;
            buttonIngresar.FlatAppearance.BorderSize = 0;
            buttonIngresar.FlatAppearance.MouseDownBackColor = Color.Transparent;
            buttonIngresar.FlatAppearance.MouseOverBackColor = Color.Transparent;
            buttonIngresar.FlatStyle = FlatStyle.Flat;
            buttonIngresar.Location = new Point(786, 669);
            buttonIngresar.Name = "buttonIngresar";
            buttonIngresar.Size = new Size(177, 62);
            buttonIngresar.TabIndex = 1;
            buttonIngresar.UseVisualStyleBackColor = false;
            buttonIngresar.Click += buttonIngresar_Click;
            // 
            // InicioSesion
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.InicioDeSesion;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1486, 960);
            Controls.Add(buttonIngresar);
            Controls.Add(buttonCerrar);
            DoubleBuffered = true;
            Margin = new Padding(6);
            Name = "InicioSesion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "InicioSesion";
            ResumeLayout(false);
        }

        #endregion

        private Button buttonCerrar;
        private Button buttonIngresar;
    }
}
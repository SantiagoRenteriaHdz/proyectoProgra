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
            textBoxCuenta = new TextBox();
            textBoxContraseña = new TextBox();
            buttonMostrar = new Button();
            SuspendLayout();
            // 
            // buttonCerrar
            // 
            buttonCerrar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonCerrar.BackColor = Color.Transparent;
            buttonCerrar.Cursor = Cursors.Hand;
            buttonCerrar.FlatAppearance.BorderSize = 0;
            buttonCerrar.FlatAppearance.MouseDownBackColor = Color.Transparent;
            buttonCerrar.FlatAppearance.MouseOverBackColor = Color.Transparent;
            buttonCerrar.FlatStyle = FlatStyle.Flat;
            buttonCerrar.Location = new Point(285, 314);
            buttonCerrar.Margin = new Padding(2, 1, 2, 1);
            buttonCerrar.Name = "buttonCerrar";
            buttonCerrar.Size = new Size(92, 29);
            buttonCerrar.TabIndex = 0;
            buttonCerrar.UseVisualStyleBackColor = false;
            buttonCerrar.Click += buttonCerrar_Click;
            // 
            // buttonIngresar
            // 
            buttonIngresar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonIngresar.BackColor = Color.Transparent;
            buttonIngresar.Cursor = Cursors.Hand;
            buttonIngresar.FlatAppearance.BorderSize = 0;
            buttonIngresar.FlatAppearance.MouseDownBackColor = Color.Transparent;
            buttonIngresar.FlatAppearance.MouseOverBackColor = Color.Transparent;
            buttonIngresar.FlatStyle = FlatStyle.Flat;
            buttonIngresar.Location = new Point(423, 314);
            buttonIngresar.Margin = new Padding(2, 1, 2, 1);
            buttonIngresar.Name = "buttonIngresar";
            buttonIngresar.Size = new Size(95, 29);
            buttonIngresar.TabIndex = 1;
            buttonIngresar.UseVisualStyleBackColor = false;
            buttonIngresar.Click += buttonIngresar_Click;
            // 
            // textBoxCuenta
            // 
            textBoxCuenta.Anchor = AnchorStyles.None;
            textBoxCuenta.BackColor = Color.FromArgb(245, 239, 233);
            textBoxCuenta.BorderStyle = BorderStyle.None;
            textBoxCuenta.Cursor = Cursors.IBeam;
            textBoxCuenta.ForeColor = SystemColors.InfoText;
            textBoxCuenta.Location = new Point(285, 217);
            textBoxCuenta.Margin = new Padding(0);
            textBoxCuenta.Name = "textBoxCuenta";
            textBoxCuenta.PlaceholderText = "Cuenta";
            textBoxCuenta.Size = new Size(224, 16);
            textBoxCuenta.TabIndex = 2;
            textBoxCuenta.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxContraseña
            // 
            textBoxContraseña.Anchor = AnchorStyles.None;
            textBoxContraseña.BackColor = Color.FromArgb(245, 239, 233);
            textBoxContraseña.BorderStyle = BorderStyle.None;
            textBoxContraseña.Cursor = Cursors.IBeam;
            textBoxContraseña.ForeColor = SystemColors.InfoText;
            textBoxContraseña.Location = new Point(285, 260);
            textBoxContraseña.Margin = new Padding(0);
            textBoxContraseña.Name = "textBoxContraseña";
            textBoxContraseña.PlaceholderText = "Contraseña";
            textBoxContraseña.Size = new Size(224, 16);
            textBoxContraseña.TabIndex = 3;
            textBoxContraseña.TextAlign = HorizontalAlignment.Center;
            // 
            // buttonMostrar
            // 
            buttonMostrar.BackColor = Color.Transparent;
            buttonMostrar.BackgroundImage = Properties.Resources.mostrar;
            buttonMostrar.BackgroundImageLayout = ImageLayout.Stretch;
            buttonMostrar.Cursor = Cursors.Hand;
            buttonMostrar.FlatAppearance.BorderSize = 0;
            buttonMostrar.FlatAppearance.MouseDownBackColor = Color.Transparent;
            buttonMostrar.FlatAppearance.MouseOverBackColor = Color.Transparent;
            buttonMostrar.FlatStyle = FlatStyle.Flat;
            buttonMostrar.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonMostrar.ForeColor = Color.Black;
            buttonMostrar.Location = new Point(523, 243);
            buttonMostrar.Name = "buttonMostrar";
            buttonMostrar.Size = new Size(35, 38);
            buttonMostrar.TabIndex = 4;
            buttonMostrar.UseVisualStyleBackColor = false;
            buttonMostrar.Click += buttonMostrar_Click;
            // 
            // InicioSesion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.InicioDeSesion;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonMostrar);
            Controls.Add(textBoxContraseña);
            Controls.Add(textBoxCuenta);
            Controls.Add(buttonIngresar);
            Controls.Add(buttonCerrar);
            DoubleBuffered = true;
            Name = "InicioSesion";
            StartPosition = FormStartPosition.CenterScreen;
            Load += InicioSesion_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonCerrar;
        private Button buttonIngresar;
        private TextBox textBoxCuenta;
        private TextBox textBoxContraseña;
        private Button buttonMostrar;
    }
}
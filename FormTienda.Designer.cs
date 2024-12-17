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
            components = new System.ComponentModel.Container();
            buttonSalir = new Button();
            labelUsuario = new Label();
            labelFecha = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            labelDinero = new Label();
            buttonEliminar = new Button();
            buttonEfectivo = new Button();
            buttonTarjeta = new Button();
            buttonOxxo = new Button();
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
            buttonSalir.FlatAppearance.MouseDownBackColor = Color.Transparent;
            buttonSalir.FlatAppearance.MouseOverBackColor = Color.Transparent;
            buttonSalir.FlatStyle = FlatStyle.Flat;
            buttonSalir.Location = new Point(735, 371);
            buttonSalir.Name = "buttonSalir";
            buttonSalir.Size = new Size(53, 48);
            buttonSalir.TabIndex = 0;
            buttonSalir.UseVisualStyleBackColor = false;
            buttonSalir.Click += buttonSalir_Click;
            // 
            // labelUsuario
            // 
            labelUsuario.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelUsuario.BackColor = Color.Transparent;
            labelUsuario.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelUsuario.Location = new Point(682, 0);
            labelUsuario.Name = "labelUsuario";
            labelUsuario.Size = new Size(116, 40);
            labelUsuario.TabIndex = 1;
            labelUsuario.Text = "Usuario";
            // 
            // labelFecha
            // 
            labelFecha.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            labelFecha.BackColor = Color.Transparent;
            labelFecha.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelFecha.Location = new Point(589, 426);
            labelFecha.Name = "labelFecha";
            labelFecha.Size = new Size(209, 23);
            labelFecha.TabIndex = 2;
            labelFecha.Text = "Fecha";
            labelFecha.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // labelDinero
            // 
            labelDinero.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelDinero.AutoSize = true;
            labelDinero.BackColor = Color.Transparent;
            labelDinero.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelDinero.Location = new Point(653, 129);
            labelDinero.Name = "labelDinero";
            labelDinero.Size = new Size(86, 32);
            labelDinero.TabIndex = 3;
            labelDinero.Text = "Dinero";
            // 
            // buttonEliminar
            // 
            buttonEliminar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonEliminar.BackColor = Color.Transparent;
            buttonEliminar.Cursor = Cursors.Hand;
            buttonEliminar.FlatAppearance.BorderSize = 0;
            buttonEliminar.FlatAppearance.MouseDownBackColor = Color.Transparent;
            buttonEliminar.FlatAppearance.MouseOverBackColor = Color.Transparent;
            buttonEliminar.FlatStyle = FlatStyle.Flat;
            buttonEliminar.Location = new Point(613, 200);
            buttonEliminar.Name = "buttonEliminar";
            buttonEliminar.Size = new Size(152, 53);
            buttonEliminar.TabIndex = 4;
            buttonEliminar.UseVisualStyleBackColor = false;
            buttonEliminar.Click += buttonEliminar_Click;
            // 
            // buttonEfectivo
            // 
            buttonEfectivo.Location = new Point(613, 215);
            buttonEfectivo.Name = "buttonEfectivo";
            buttonEfectivo.Size = new Size(75, 23);
            buttonEfectivo.TabIndex = 5;
            buttonEfectivo.Text = "Efectivo";
            buttonEfectivo.UseVisualStyleBackColor = true;
            buttonEfectivo.Click += buttonEfectivo_Click;
            // 
            // buttonTarjeta
            // 
            buttonTarjeta.Location = new Point(613, 259);
            buttonTarjeta.Name = "buttonTarjeta";
            buttonTarjeta.Size = new Size(75, 23);
            buttonTarjeta.TabIndex = 6;
            buttonTarjeta.Text = "Tarjeta";
            buttonTarjeta.UseVisualStyleBackColor = true;
            buttonTarjeta.Click += buttonTarjeta_Click;
            // 
            // buttonOxxo
            // 
            buttonOxxo.Location = new Point(613, 302);
            buttonOxxo.Name = "buttonOxxo";
            buttonOxxo.Size = new Size(75, 23);
            buttonOxxo.TabIndex = 7;
            buttonOxxo.Text = "oxxo";
            buttonOxxo.UseVisualStyleBackColor = true;
            buttonOxxo.Click += buttonOxxo_Click;
            // 
            // FormTienda
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.tienda;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonOxxo);
            Controls.Add(buttonTarjeta);
            Controls.Add(buttonEfectivo);
            Controls.Add(buttonEliminar);
            Controls.Add(labelDinero);
            Controls.Add(labelFecha);
            Controls.Add(labelUsuario);
            Controls.Add(buttonSalir);
            DoubleBuffered = true;
            Name = "FormTienda";
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;
            Load += FormTienda_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonSalir;
        private Label labelUsuario;
        private Label labelFecha;
        private System.Windows.Forms.Timer timer1;
        private Label labelDinero;
        private Button buttonEliminar;
        private Button buttonEfectivo;
        private Button buttonTarjeta;
        private Button buttonOxxo;
    }
}

namespace ProyectoFinal
{
    partial class Pagos
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
            groupBoxEfectivo = new GroupBox();
            buttonPagar = new Button();
            textBoxRecibido = new TextBox();
            groupBoxTarjeta = new GroupBox();
            buttonPagoTarjeta = new Button();
            textBoxCvv = new TextBox();
            textBoxFecha = new TextBox();
            textBoxTarjeta = new TextBox();
            textBoxNombre = new TextBox();
            groupBoxOxxo = new GroupBox();
            pictureBoxQR = new PictureBox();
            buttonSalir = new Button();
            dataGridView1 = new DataGridView();
            labelFecha = new Label();
            labelTotproductos = new Label();
            labelPago = new Label();
            labelImpuesto = new Label();
            labelTotPago = new Label();
            groupBox1 = new GroupBox();
            button1 = new Button();
            groupBoxEfectivo.SuspendLayout();
            groupBoxTarjeta.SuspendLayout();
            groupBoxOxxo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxQR).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxEfectivo
            // 
            groupBoxEfectivo.BackColor = Color.FromArgb(210, 197, 183);
            groupBoxEfectivo.Controls.Add(buttonPagar);
            groupBoxEfectivo.Controls.Add(textBoxRecibido);
            groupBoxEfectivo.Location = new Point(89, 391);
            groupBoxEfectivo.Name = "groupBoxEfectivo";
            groupBoxEfectivo.Size = new Size(214, 198);
            groupBoxEfectivo.TabIndex = 7;
            groupBoxEfectivo.TabStop = false;
            // 
            // buttonPagar
            // 
            buttonPagar.Location = new Point(67, 150);
            buttonPagar.Name = "buttonPagar";
            buttonPagar.Size = new Size(75, 23);
            buttonPagar.TabIndex = 1;
            buttonPagar.Text = "Pagar";
            buttonPagar.UseVisualStyleBackColor = true;
            buttonPagar.Click += buttonPagar_Click_1;
            // 
            // textBoxRecibido
            // 
            textBoxRecibido.Location = new Point(42, 28);
            textBoxRecibido.Name = "textBoxRecibido";
            textBoxRecibido.PlaceholderText = "Cantidad a recibir";
            textBoxRecibido.Size = new Size(122, 23);
            textBoxRecibido.TabIndex = 0;
            // 
            // groupBoxTarjeta
            // 
            groupBoxTarjeta.BackColor = Color.FromArgb(210, 197, 183);
            groupBoxTarjeta.Controls.Add(buttonPagoTarjeta);
            groupBoxTarjeta.Controls.Add(textBoxCvv);
            groupBoxTarjeta.Controls.Add(textBoxFecha);
            groupBoxTarjeta.Controls.Add(textBoxTarjeta);
            groupBoxTarjeta.Controls.Add(textBoxNombre);
            groupBoxTarjeta.Location = new Point(321, 391);
            groupBoxTarjeta.Name = "groupBoxTarjeta";
            groupBoxTarjeta.Size = new Size(242, 197);
            groupBoxTarjeta.TabIndex = 8;
            groupBoxTarjeta.TabStop = false;
            groupBoxTarjeta.Text = "Datos de tarjeta";
            // 
            // buttonPagoTarjeta
            // 
            buttonPagoTarjeta.Location = new Point(144, 168);
            buttonPagoTarjeta.Name = "buttonPagoTarjeta";
            buttonPagoTarjeta.Size = new Size(75, 23);
            buttonPagoTarjeta.TabIndex = 4;
            buttonPagoTarjeta.Text = "Pagar";
            buttonPagoTarjeta.UseVisualStyleBackColor = true;
            buttonPagoTarjeta.Click += buttonPagoTarjeta_Click_1;
            // 
            // textBoxCvv
            // 
            textBoxCvv.Location = new Point(16, 111);
            textBoxCvv.Name = "textBoxCvv";
            textBoxCvv.PlaceholderText = "CVV";
            textBoxCvv.Size = new Size(75, 23);
            textBoxCvv.TabIndex = 3;
            // 
            // textBoxFecha
            // 
            textBoxFecha.Location = new Point(16, 82);
            textBoxFecha.Name = "textBoxFecha";
            textBoxFecha.PlaceholderText = "MM/AA";
            textBoxFecha.Size = new Size(100, 23);
            textBoxFecha.TabIndex = 2;
            // 
            // textBoxTarjeta
            // 
            textBoxTarjeta.Location = new Point(16, 53);
            textBoxTarjeta.Name = "textBoxTarjeta";
            textBoxTarjeta.PlaceholderText = "Numero de tarjeta";
            textBoxTarjeta.Size = new Size(203, 23);
            textBoxTarjeta.TabIndex = 1;
            // 
            // textBoxNombre
            // 
            textBoxNombre.Location = new Point(16, 24);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.PlaceholderText = "Nombre";
            textBoxNombre.Size = new Size(203, 23);
            textBoxNombre.TabIndex = 0;
            textBoxNombre.TextChanged += textBoxNombre_TextChanged;
            // 
            // groupBoxOxxo
            // 
            groupBoxOxxo.BackColor = Color.FromArgb(210, 197, 183);
            groupBoxOxxo.Controls.Add(pictureBoxQR);
            groupBoxOxxo.Location = new Point(593, 391);
            groupBoxOxxo.Name = "groupBoxOxxo";
            groupBoxOxxo.Size = new Size(218, 198);
            groupBoxOxxo.TabIndex = 9;
            groupBoxOxxo.TabStop = false;
            groupBoxOxxo.Text = "Escanea el QR para pagar";
            // 
            // pictureBoxQR
            // 
            pictureBoxQR.BackColor = Color.Transparent;
            pictureBoxQR.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBoxQR.Location = new Point(19, 28);
            pictureBoxQR.Name = "pictureBoxQR";
            pictureBoxQR.Size = new Size(178, 145);
            pictureBoxQR.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxQR.TabIndex = 0;
            pictureBoxQR.TabStop = false;
            pictureBoxQR.Click += pictureBoxQR_Click;
            // 
            // buttonSalir
            // 
            buttonSalir.BackColor = Color.Transparent;
            buttonSalir.Cursor = Cursors.Hand;
            buttonSalir.FlatAppearance.BorderSize = 0;
            buttonSalir.FlatStyle = FlatStyle.Flat;
            buttonSalir.Location = new Point(853, -1);
            buttonSalir.Name = "buttonSalir";
            buttonSalir.Size = new Size(46, 43);
            buttonSalir.TabIndex = 10;
            buttonSalir.UseVisualStyleBackColor = false;
            buttonSalir.Click += buttonSalir_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.BackgroundColor = Color.FromArgb(210, 197, 183);
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.GridColor = Color.FromArgb(185, 162, 136);
            dataGridView1.Location = new Point(105, 99);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(345, 256);
            dataGridView1.TabIndex = 0;
            // 
            // labelFecha
            // 
            labelFecha.BackColor = Color.Transparent;
            labelFecha.Font = new Font("Franklin Gothic Medium Cond", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelFecha.ForeColor = Color.FromArgb(210, 197, 183);
            labelFecha.Location = new Point(672, 17);
            labelFecha.Name = "labelFecha";
            labelFecha.Size = new Size(173, 23);
            labelFecha.TabIndex = 2;
            labelFecha.Text = "Fecha";
            // 
            // labelTotproductos
            // 
            labelTotproductos.BackColor = Color.Transparent;
            labelTotproductos.Font = new Font("Franklin Gothic Demi Cond", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelTotproductos.ForeColor = Color.FromArgb(79, 60, 42);
            labelTotproductos.Location = new Point(463, 141);
            labelTotproductos.Name = "labelTotproductos";
            labelTotproductos.Size = new Size(188, 23);
            labelTotproductos.TabIndex = 3;
            labelTotproductos.Text = "productos";
            // 
            // labelPago
            // 
            labelPago.BackColor = Color.Transparent;
            labelPago.Font = new Font("Franklin Gothic Demi Cond", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelPago.ForeColor = Color.FromArgb(79, 60, 42);
            labelPago.Location = new Point(463, 164);
            labelPago.Name = "labelPago";
            labelPago.Size = new Size(188, 23);
            labelPago.TabIndex = 4;
            labelPago.Text = "pago sin impuestos";
            // 
            // labelImpuesto
            // 
            labelImpuesto.BackColor = Color.Transparent;
            labelImpuesto.Font = new Font("Franklin Gothic Demi Cond", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelImpuesto.ForeColor = Color.FromArgb(79, 60, 42);
            labelImpuesto.Location = new Point(463, 187);
            labelImpuesto.Name = "labelImpuesto";
            labelImpuesto.Size = new Size(188, 23);
            labelImpuesto.TabIndex = 5;
            labelImpuesto.Text = "impuestos";
            // 
            // labelTotPago
            // 
            labelTotPago.BackColor = Color.FromArgb(79, 60, 42);
            labelTotPago.Font = new Font("Franklin Gothic Demi Cond", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelTotPago.ForeColor = Color.FromArgb(210, 197, 183);
            labelTotPago.Location = new Point(463, 210);
            labelTotPago.Name = "labelTotPago";
            labelTotPago.Size = new Size(188, 23);
            labelTotPago.TabIndex = 6;
            labelTotPago.Text = "Pago total";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.BackgroundImageLayout = ImageLayout.None;
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(labelFecha);
            groupBox1.Controls.Add(dataGridView1);
            groupBox1.Controls.Add(labelTotproductos);
            groupBox1.Controls.Add(labelPago);
            groupBox1.Controls.Add(labelTotPago);
            groupBox1.Controls.Add(labelImpuesto);
            groupBox1.FlatStyle = FlatStyle.Flat;
            groupBox1.Location = new Point(2, -8);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(897, 375);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Enter += groupBox1_Enter;
            // 
            // button1
            // 
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(851, 7);
            button1.Name = "button1";
            button1.Size = new Size(46, 43);
            button1.TabIndex = 7;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Pagos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.notaventa;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(899, 630);
            Controls.Add(groupBox1);
            Controls.Add(buttonSalir);
            Controls.Add(groupBoxOxxo);
            Controls.Add(groupBoxTarjeta);
            Controls.Add(groupBoxEfectivo);
            DoubleBuffered = true;
            Name = "Pagos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Pagos_Load;
            groupBoxEfectivo.ResumeLayout(false);
            groupBoxEfectivo.PerformLayout();
            groupBoxTarjeta.ResumeLayout(false);
            groupBoxTarjeta.PerformLayout();
            groupBoxOxxo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxQR).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBoxEfectivo;
        private Button buttonPagar;
        private TextBox textBoxRecibido;
        private GroupBox groupBoxTarjeta;
        private TextBox textBoxNombre;
        private TextBox textBoxCvv;
        private TextBox textBoxFecha;
        private TextBox textBoxTarjeta;
        private Button buttonPagoTarjeta;
        private GroupBox groupBoxOxxo;
        private PictureBox pictureBoxQR;
        private Button buttonSalir;
        private DataGridView dataGridView1;
        private Label labelFecha;
        private Label labelTotproductos;
        private Label labelPago;
        private Label labelImpuesto;
        private Label labelTotPago;
        private GroupBox groupBox1;
        private Button button1;
    }
}
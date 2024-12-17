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
            dataGridView1 = new DataGridView();
            labelProductos = new Label();
            labelFecha = new Label();
            labelTotproductos = new Label();
            labelPago = new Label();
            labelImpuesto = new Label();
            labelTotPago = new Label();
            groupBoxEfectivo = new GroupBox();
            buttonPagar = new Button();
            textBoxRecibido = new TextBox();
            groupBoxTarjeta = new GroupBox();
            groupBoxOxxo = new GroupBox();
            pictureBoxQR = new PictureBox();
            buttonPagoTarjeta = new Button();
            textBoxCvv = new TextBox();
            textBoxFecha = new TextBox();
            textBoxTarjeta = new TextBox();
            textBoxNombre = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBoxEfectivo.SuspendLayout();
            groupBoxTarjeta.SuspendLayout();
            groupBoxOxxo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxQR).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(59, 59);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(645, 237);
            dataGridView1.TabIndex = 0;
            // 
            // labelProductos
            // 
            labelProductos.AutoSize = true;
            labelProductos.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelProductos.Location = new Point(59, 31);
            labelProductos.Name = "labelProductos";
            labelProductos.Size = new Size(188, 25);
            labelProductos.TabIndex = 1;
            labelProductos.Text = "Productos a comprar";
            // 
            // labelFecha
            // 
            labelFecha.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelFecha.Location = new Point(770, 598);
            labelFecha.Name = "labelFecha";
            labelFecha.Size = new Size(117, 23);
            labelFecha.TabIndex = 2;
            labelFecha.Text = "Fecha";
            // 
            // labelTotproductos
            // 
            labelTotproductos.Location = new Point(59, 317);
            labelTotproductos.Name = "labelTotproductos";
            labelTotproductos.Size = new Size(188, 23);
            labelTotproductos.TabIndex = 3;
            labelTotproductos.Text = "productos";
            // 
            // labelPago
            // 
            labelPago.Location = new Point(59, 340);
            labelPago.Name = "labelPago";
            labelPago.Size = new Size(188, 23);
            labelPago.TabIndex = 4;
            labelPago.Text = "pago sin impuestos";
            // 
            // labelImpuesto
            // 
            labelImpuesto.Location = new Point(59, 363);
            labelImpuesto.Name = "labelImpuesto";
            labelImpuesto.Size = new Size(188, 23);
            labelImpuesto.TabIndex = 5;
            labelImpuesto.Text = "impuestos";
            // 
            // labelTotPago
            // 
            labelTotPago.BackColor = Color.FromArgb(255, 255, 128);
            labelTotPago.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTotPago.Location = new Point(59, 386);
            labelTotPago.Name = "labelTotPago";
            labelTotPago.Size = new Size(188, 23);
            labelTotPago.TabIndex = 6;
            labelTotPago.Text = "Pago total";
            // 
            // groupBoxEfectivo
            // 
            groupBoxEfectivo.Controls.Add(buttonPagar);
            groupBoxEfectivo.Controls.Add(textBoxRecibido);
            groupBoxEfectivo.Location = new Point(59, 437);
            groupBoxEfectivo.Name = "groupBoxEfectivo";
            groupBoxEfectivo.Size = new Size(206, 123);
            groupBoxEfectivo.TabIndex = 7;
            groupBoxEfectivo.TabStop = false;
            // 
            // buttonPagar
            // 
            buttonPagar.Location = new Point(11, 50);
            buttonPagar.Name = "buttonPagar";
            buttonPagar.Size = new Size(75, 23);
            buttonPagar.TabIndex = 1;
            buttonPagar.Text = "Pagar";
            buttonPagar.UseVisualStyleBackColor = true;
            buttonPagar.Click += buttonPagar_Click_1;
            // 
            // textBoxRecibido
            // 
            textBoxRecibido.Location = new Point(11, 21);
            textBoxRecibido.Name = "textBoxRecibido";
            textBoxRecibido.PlaceholderText = "Cantidad a recibir";
            textBoxRecibido.Size = new Size(122, 23);
            textBoxRecibido.TabIndex = 0;
            // 
            // groupBoxTarjeta
            // 
            groupBoxTarjeta.Controls.Add(buttonPagoTarjeta);
            groupBoxTarjeta.Controls.Add(textBoxCvv);
            groupBoxTarjeta.Controls.Add(textBoxFecha);
            groupBoxTarjeta.Controls.Add(textBoxTarjeta);
            groupBoxTarjeta.Controls.Add(textBoxNombre);
            groupBoxTarjeta.Location = new Point(389, 331);
            groupBoxTarjeta.Name = "groupBoxTarjeta";
            groupBoxTarjeta.Size = new Size(235, 150);
            groupBoxTarjeta.TabIndex = 8;
            groupBoxTarjeta.TabStop = false;
            groupBoxTarjeta.Text = "Datos de tarjeta";
            // 
            // groupBoxOxxo
            // 
            groupBoxOxxo.Controls.Add(pictureBoxQR);
            groupBoxOxxo.Location = new Point(630, 331);
            groupBoxOxxo.Name = "groupBoxOxxo";
            groupBoxOxxo.Size = new Size(218, 198);
            groupBoxOxxo.TabIndex = 9;
            groupBoxOxxo.TabStop = false;
            groupBoxOxxo.Text = "Escanea el QR para pagar";
            // 
            // pictureBoxQR
            // 
            pictureBoxQR.BackColor = Color.Transparent;
            pictureBoxQR.BackgroundImage = Properties.Resources.oxxo;
            pictureBoxQR.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBoxQR.Location = new Point(19, 28);
            pictureBoxQR.Name = "pictureBoxQR";
            pictureBoxQR.Size = new Size(178, 145);
            pictureBoxQR.TabIndex = 0;
            pictureBoxQR.TabStop = false;
            pictureBoxQR.Click += pictureBoxQR_Click;
            // 
            // buttonPagoTarjeta
            // 
            buttonPagoTarjeta.Location = new Point(144, 111);
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
            // 
            // Pagos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(899, 630);
            Controls.Add(groupBoxOxxo);
            Controls.Add(groupBoxTarjeta);
            Controls.Add(groupBoxEfectivo);
            Controls.Add(labelTotPago);
            Controls.Add(labelImpuesto);
            Controls.Add(labelPago);
            Controls.Add(labelTotproductos);
            Controls.Add(labelFecha);
            Controls.Add(labelProductos);
            Controls.Add(dataGridView1);
            Name = "Pagos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Pagos_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBoxEfectivo.ResumeLayout(false);
            groupBoxEfectivo.PerformLayout();
            groupBoxTarjeta.ResumeLayout(false);
            groupBoxTarjeta.PerformLayout();
            groupBoxOxxo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxQR).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label labelProductos;
        private Label labelFecha;
        private Label labelTotproductos;
        private Label labelPago;
        private Label labelImpuesto;
        private Label labelTotPago;
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
    }
}
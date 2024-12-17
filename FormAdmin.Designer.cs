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
            components = new System.ComponentModel.Container();
            buttonSalir = new Button();
            textBoxId = new TextBox();
            textBoxImagen = new TextBox();
            textBoxPrecio = new TextBox();
            textBoxDescripcion = new TextBox();
            textBoxExistencias = new TextBox();
            textBoxNombre = new TextBox();
            buttonAltas = new Button();
            buttonBajas = new Button();
            labelLista = new Label();
            buttonGrafica = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            dataGridView1 = new DataGridView();
            formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            labelVentas = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // buttonSalir
            // 
            buttonSalir.BackColor = Color.Transparent;
            buttonSalir.BackgroundImageLayout = ImageLayout.Stretch;
            buttonSalir.Cursor = Cursors.Hand;
            buttonSalir.FlatAppearance.BorderSize = 0;
            buttonSalir.FlatAppearance.MouseDownBackColor = Color.Transparent;
            buttonSalir.FlatAppearance.MouseOverBackColor = Color.Transparent;
            buttonSalir.FlatStyle = FlatStyle.Flat;
            buttonSalir.Location = new Point(774, 2);
            buttonSalir.Name = "buttonSalir";
            buttonSalir.Size = new Size(24, 22);
            buttonSalir.TabIndex = 1;
            buttonSalir.UseVisualStyleBackColor = false;
            buttonSalir.Click += buttonSalir_Click;
            // 
            // textBoxId
            // 
            textBoxId.BackColor = Color.FromArgb(245, 239, 233);
            textBoxId.BorderStyle = BorderStyle.None;
            textBoxId.Location = new Point(58, 114);
            textBoxId.Name = "textBoxId";
            textBoxId.Size = new Size(182, 16);
            textBoxId.TabIndex = 9;
            // 
            // textBoxImagen
            // 
            textBoxImagen.BackColor = Color.FromArgb(245, 239, 233);
            textBoxImagen.BorderStyle = BorderStyle.None;
            textBoxImagen.Location = new Point(58, 350);
            textBoxImagen.Name = "textBoxImagen";
            textBoxImagen.Size = new Size(182, 16);
            textBoxImagen.TabIndex = 10;
            // 
            // textBoxPrecio
            // 
            textBoxPrecio.BackColor = Color.FromArgb(245, 239, 233);
            textBoxPrecio.BorderStyle = BorderStyle.None;
            textBoxPrecio.Location = new Point(58, 304);
            textBoxPrecio.Name = "textBoxPrecio";
            textBoxPrecio.Size = new Size(182, 16);
            textBoxPrecio.TabIndex = 11;
            // 
            // textBoxDescripcion
            // 
            textBoxDescripcion.BackColor = Color.FromArgb(245, 239, 233);
            textBoxDescripcion.BorderStyle = BorderStyle.None;
            textBoxDescripcion.Location = new Point(58, 258);
            textBoxDescripcion.Name = "textBoxDescripcion";
            textBoxDescripcion.Size = new Size(182, 16);
            textBoxDescripcion.TabIndex = 12;
            // 
            // textBoxExistencias
            // 
            textBoxExistencias.BackColor = Color.FromArgb(245, 239, 233);
            textBoxExistencias.BorderStyle = BorderStyle.None;
            textBoxExistencias.Location = new Point(58, 210);
            textBoxExistencias.Name = "textBoxExistencias";
            textBoxExistencias.Size = new Size(182, 16);
            textBoxExistencias.TabIndex = 13;
            // 
            // textBoxNombre
            // 
            textBoxNombre.BackColor = Color.FromArgb(245, 239, 233);
            textBoxNombre.BorderStyle = BorderStyle.None;
            textBoxNombre.Location = new Point(58, 163);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(182, 16);
            textBoxNombre.TabIndex = 14;
            // 
            // buttonAltas
            // 
            buttonAltas.BackColor = Color.Transparent;
            buttonAltas.BackgroundImageLayout = ImageLayout.Stretch;
            buttonAltas.Cursor = Cursors.Hand;
            buttonAltas.FlatAppearance.BorderSize = 0;
            buttonAltas.FlatAppearance.MouseDownBackColor = Color.Transparent;
            buttonAltas.FlatAppearance.MouseOverBackColor = Color.Transparent;
            buttonAltas.FlatStyle = FlatStyle.Flat;
            buttonAltas.Location = new Point(160, 388);
            buttonAltas.Name = "buttonAltas";
            buttonAltas.Size = new Size(37, 34);
            buttonAltas.TabIndex = 16;
            buttonAltas.TextAlign = ContentAlignment.BottomCenter;
            buttonAltas.UseVisualStyleBackColor = false;
            buttonAltas.Click += buttonAltas_Click;
            // 
            // buttonBajas
            // 
            buttonBajas.BackColor = Color.Transparent;
            buttonBajas.BackgroundImageLayout = ImageLayout.Stretch;
            buttonBajas.Cursor = Cursors.Hand;
            buttonBajas.FlatAppearance.BorderSize = 0;
            buttonBajas.FlatAppearance.MouseDownBackColor = Color.Transparent;
            buttonBajas.FlatAppearance.MouseOverBackColor = Color.Transparent;
            buttonBajas.FlatStyle = FlatStyle.Flat;
            buttonBajas.Location = new Point(98, 388);
            buttonBajas.Name = "buttonBajas";
            buttonBajas.Size = new Size(37, 34);
            buttonBajas.TabIndex = 17;
            buttonBajas.TextImageRelation = TextImageRelation.ImageAboveText;
            buttonBajas.UseVisualStyleBackColor = false;
            buttonBajas.Click += buttonBajas_Click;
            // 
            // labelLista
            // 
            labelLista.AutoSize = true;
            labelLista.BackColor = Color.Transparent;
            labelLista.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelLista.Location = new Point(430, 75);
            labelLista.Name = "labelLista";
            labelLista.Size = new Size(166, 25);
            labelLista.TabIndex = 18;
            labelLista.Text = "Lista de productos";
            // 
            // buttonGrafica
            // 
            buttonGrafica.BackColor = Color.Transparent;
            buttonGrafica.Cursor = Cursors.Hand;
            buttonGrafica.FlatAppearance.BorderSize = 0;
            buttonGrafica.FlatAppearance.MouseDownBackColor = Color.Transparent;
            buttonGrafica.FlatAppearance.MouseOverBackColor = Color.Transparent;
            buttonGrafica.FlatStyle = FlatStyle.Flat;
            buttonGrafica.Location = new Point(477, 388);
            buttonGrafica.Name = "buttonGrafica";
            buttonGrafica.Size = new Size(99, 34);
            buttonGrafica.TabIndex = 19;
            buttonGrafica.UseVisualStyleBackColor = false;
            buttonGrafica.Click += buttonGrafica_Click;
            // 
            // timer1
            // 
            timer1.Interval = 3000;
            timer1.Tick += timer1_Tick;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.GridColor = SystemColors.Window;
            dataGridView1.Location = new Point(266, 114);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(499, 268);
            dataGridView1.TabIndex = 20;
            // 
            // formsPlot1
            // 
            formsPlot1.BackColor = Color.Transparent;
            formsPlot1.DisplayScale = 1F;
            formsPlot1.Location = new Point(266, 114);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(499, 268);
            formsPlot1.TabIndex = 21;
            // 
            // labelVentas
            // 
            labelVentas.AutoSize = true;
            labelVentas.BackColor = Color.Transparent;
            labelVentas.Location = new Point(266, 398);
            labelVentas.Name = "labelVentas";
            labelVentas.Size = new Size(80, 15);
            labelVentas.TabIndex = 22;
            labelVentas.Text = "Ventas Totales";
            // 
            // FormAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.admin2;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(labelVentas);
            Controls.Add(formsPlot1);
            Controls.Add(dataGridView1);
            Controls.Add(buttonGrafica);
            Controls.Add(labelLista);
            Controls.Add(buttonBajas);
            Controls.Add(buttonAltas);
            Controls.Add(textBoxNombre);
            Controls.Add(textBoxExistencias);
            Controls.Add(textBoxDescripcion);
            Controls.Add(textBoxPrecio);
            Controls.Add(textBoxImagen);
            Controls.Add(textBoxId);
            Controls.Add(buttonSalir);
            DoubleBuffered = true;
            Name = "FormAdmin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            FormClosing += FormAdmin_FormClosing;
            Load += FormAdmin_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button buttonSalir;
        private TextBox textBoxId;
        private TextBox textBoxImagen;
        private TextBox textBoxPrecio;
        private TextBox textBoxDescripcion;
        private TextBox textBoxExistencias;
        private TextBox textBoxNombre;
        private Button buttonAltas;
        private Button buttonBajas;
        private Label labelLista;
        private Button buttonGrafica;
        private System.Windows.Forms.Timer timer1;
        private DataGridView dataGridView1;
        private ScottPlot.WinForms.FormsPlot formsPlot1;
        private Label labelVentas;
    }
}
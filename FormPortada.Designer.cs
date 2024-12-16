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
            buttonSalir = new Button();
            dateTimePicker1 = new DateTimePicker();
            SuspendLayout();
            // 
            // buttonInicio
            // 
            buttonInicio.Anchor = AnchorStyles.Bottom;
            buttonInicio.BackColor = Color.Transparent;
            buttonInicio.Cursor = Cursors.Hand;
            buttonInicio.FlatAppearance.BorderSize = 0;
            buttonInicio.FlatAppearance.MouseDownBackColor = Color.Transparent;
            buttonInicio.FlatAppearance.MouseOverBackColor = Color.Transparent;
            buttonInicio.FlatStyle = FlatStyle.Flat;
            buttonInicio.ForeColor = Color.Transparent;
            buttonInicio.Location = new Point(357, 366);
            buttonInicio.Margin = new Padding(0);
            buttonInicio.Name = "buttonInicio";
            buttonInicio.Size = new Size(94, 25);
            buttonInicio.TabIndex = 0;
            buttonInicio.UseVisualStyleBackColor = false;
            buttonInicio.Click += buttonInicio_Click;
            // 
            // buttonSalir
            // 
            buttonSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonSalir.BackColor = Color.Transparent;
            buttonSalir.Cursor = Cursors.Hand;
            buttonSalir.FlatAppearance.BorderSize = 0;
            buttonSalir.FlatAppearance.MouseDownBackColor = Color.Transparent;
            buttonSalir.FlatAppearance.MouseOverBackColor = Color.Transparent;
            buttonSalir.FlatStyle = FlatStyle.Flat;
            buttonSalir.Location = new Point(25, 410);
            buttonSalir.Margin = new Padding(2, 1, 2, 1);
            buttonSalir.Name = "buttonSalir";
            buttonSalir.Size = new Size(41, 23);
            buttonSalir.TabIndex = 1;
            buttonSalir.UseVisualStyleBackColor = false;
            buttonSalir.Click += buttonSalir_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarMonthBackground = Color.Transparent;
            dateTimePicker1.CalendarTitleBackColor = Color.Transparent;
            dateTimePicker1.CalendarTitleForeColor = SystemColors.ActiveBorder;
            dateTimePicker1.Enabled = false;
            dateTimePicker1.Location = new Point(423, 328);
            dateTimePicker1.Margin = new Padding(2, 1, 2, 1);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(217, 23);
            dateTimePicker1.TabIndex = 2;
            // 
            // FormPortada
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.portada7;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(dateTimePicker1);
            Controls.Add(buttonSalir);
            Controls.Add(buttonInicio);
            DoubleBuffered = true;
            Name = "FormPortada";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Portada";
            Load += FormPortada_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button buttonInicio;
        private Button buttonSalir;
        private DateTimePicker dateTimePicker1;
    }
}
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
            buttonInicio.FlatAppearance.BorderSize = 0;
            buttonInicio.FlatAppearance.MouseDownBackColor = Color.Transparent;
            buttonInicio.FlatAppearance.MouseOverBackColor = Color.Transparent;
            buttonInicio.FlatStyle = FlatStyle.Flat;
            buttonInicio.ForeColor = Color.Transparent;
            buttonInicio.Location = new Point(663, 780);
            buttonInicio.Margin = new Padding(0);
            buttonInicio.Name = "buttonInicio";
            buttonInicio.Size = new Size(174, 53);
            buttonInicio.TabIndex = 0;
            buttonInicio.UseVisualStyleBackColor = false;
            buttonInicio.Click += buttonInicio_Click;
            // 
            // buttonSalir
            // 
            buttonSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonSalir.BackColor = Color.Transparent;
            buttonSalir.FlatAppearance.BorderSize = 0;
            buttonSalir.FlatAppearance.MouseDownBackColor = Color.Transparent;
            buttonSalir.FlatAppearance.MouseOverBackColor = Color.Transparent;
            buttonSalir.FlatStyle = FlatStyle.Flat;
            buttonSalir.Location = new Point(47, 874);
            buttonSalir.Name = "buttonSalir";
            buttonSalir.Size = new Size(76, 49);
            buttonSalir.TabIndex = 1;
            buttonSalir.UseVisualStyleBackColor = false;
            buttonSalir.Click += buttonSalir_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Enabled = false;
            dateTimePicker1.Location = new Point(785, 700);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(400, 39);
            dateTimePicker1.TabIndex = 2;
            // 
            // FormPortada
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.portada5;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1486, 960);
            Controls.Add(dateTimePicker1);
            Controls.Add(buttonSalir);
            Controls.Add(buttonInicio);
            DoubleBuffered = true;
            Margin = new Padding(6);
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
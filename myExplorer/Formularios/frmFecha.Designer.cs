namespace myExplorer.Formularios
{
    partial class frmFecha
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
            this.btnAceptar = new System.Windows.Forms.Button();
            this.dtmFecha = new System.Windows.Forms.DateTimePicker();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblDiaHora = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Location = new System.Drawing.Point(179, 67);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // dtmFecha
            // 
            this.dtmFecha.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtmFecha.Location = new System.Drawing.Point(15, 29);
            this.dtmFecha.Name = "dtmFecha";
            this.dtmFecha.Size = new System.Drawing.Size(239, 20);
            this.dtmFecha.TabIndex = 3;
            this.dtmFecha.ValueChanged += new System.EventHandler(this.dtmFecha_ValueChanged);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Location = new System.Drawing.Point(12, 12);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(178, 13);
            this.lblHeader.TabIndex = 4;
            this.lblHeader.Text = "Seleccione el dia y la hora del turno.";
            // 
            // lblDiaHora
            // 
            this.lblDiaHora.AutoSize = true;
            this.lblDiaHora.Location = new System.Drawing.Point(12, 67);
            this.lblDiaHora.Name = "lblDiaHora";
            this.lblDiaHora.Size = new System.Drawing.Size(53, 13);
            this.lblDiaHora.TabIndex = 6;
            this.lblDiaHora.Text = "dia y hora";
            // 
            // frmFecha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 99);
            this.Controls.Add(this.lblDiaHora);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.dtmFecha);
            this.Controls.Add(this.btnAceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFecha";
            this.Text = "Fecha";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmFecha_FormClosed);
            this.Load += new System.EventHandler(this.frmCalendario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.DateTimePicker dtmFecha;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblDiaHora;
    }
}
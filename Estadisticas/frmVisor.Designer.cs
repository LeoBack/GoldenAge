namespace Estadisticas
{
    partial class frmVisor
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
            this.crVisor = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crVisor
            // 
            this.crVisor.ActiveViewIndex = -1;
            this.crVisor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crVisor.Cursor = System.Windows.Forms.Cursors.Default;
            this.crVisor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crVisor.Location = new System.Drawing.Point(0, 0);
            this.crVisor.Name = "crVisor";
            this.crVisor.Size = new System.Drawing.Size(571, 400);
            this.crVisor.TabIndex = 0;
            // 
            // frmVisor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 400);
            this.Controls.Add(this.crVisor);
            this.Name = "frmVisor";
            this.Text = "frmVisorE";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmVisorE_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crVisor;
    }
}
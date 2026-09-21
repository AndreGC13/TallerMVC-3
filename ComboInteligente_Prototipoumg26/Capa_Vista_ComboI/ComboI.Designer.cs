namespace Capa_Vista_ComboI
{
    partial class ComboI
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codigo generado por el Diseñador de componentes

        private void InitializeComponent()
        {
            this.cboPrueba = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            //
            // cboPrueba
            //
            this.cboPrueba.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboPrueba.FormattingEnabled = true;
            this.cboPrueba.Location = new System.Drawing.Point(0, 0);
            this.cboPrueba.Name = "cboPrueba";
            this.cboPrueba.Size = new System.Drawing.Size(220, 24);
            this.cboPrueba.TabIndex = 0;
            //
            // ComboI
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cboPrueba);
            this.Name = "ComboI";
            this.Size = new System.Drawing.Size(220, 24);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ComboBox cboPrueba;
    }
}

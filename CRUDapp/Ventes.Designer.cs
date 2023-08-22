namespace CRUDapp
{
    partial class Ventes
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
            this.TitreForm = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TitreForm
            // 
            this.TitreForm.AutoSize = true;
            this.TitreForm.Font = new System.Drawing.Font("SF Pro Display", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitreForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(38)))), ((int)(((byte)(28)))));
            this.TitreForm.Location = new System.Drawing.Point(12, 30);
            this.TitreForm.Name = "TitreForm";
            this.TitreForm.Size = new System.Drawing.Size(170, 51);
            this.TitreForm.TabIndex = 30;
            this.TitreForm.Text = "Ventes:";
            // 
            // Ventes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 676);
            this.Controls.Add(this.TitreForm);
            this.Name = "Ventes";
            this.Text = "Ventes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitreForm;
    }
}
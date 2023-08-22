namespace CRUDapp
{
    partial class Service
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
            this.TitreForm.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TitreForm.AutoSize = true;
            this.TitreForm.Font = new System.Drawing.Font("SF Compact Text", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitreForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(38)))), ((int)(((byte)(28)))));
            this.TitreForm.Location = new System.Drawing.Point(12, 9);
            this.TitreForm.Name = "TitreForm";
            this.TitreForm.Size = new System.Drawing.Size(164, 48);
            this.TitreForm.TabIndex = 30;
            this.TitreForm.Text = "Service";
            // 
            // Service
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(963, 619);
            this.Controls.Add(this.TitreForm);
            this.Name = "Service";
            this.Text = "Service";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitreForm;
    }
}
namespace PrikazFlote
{
    partial class FormFlota
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
            this.buttonSložiFlotu = new System.Windows.Forms.Button();
            this.mrežaZaFlotu = new PrikazFlote.MrežaZaFlotu();
            this.SuspendLayout();
            // 
            // buttonSložiFlotu
            // 
            this.buttonSložiFlotu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSložiFlotu.Location = new System.Drawing.Point(364, 436);
            this.buttonSložiFlotu.Name = "buttonSložiFlotu";
            this.buttonSložiFlotu.Size = new System.Drawing.Size(75, 23);
            this.buttonSložiFlotu.TabIndex = 1;
            this.buttonSložiFlotu.Text = "Složi";
            this.buttonSložiFlotu.UseVisualStyleBackColor = true;
            this.buttonSložiFlotu.Click += new System.EventHandler(this.buttonSložiFlotu_Click);
            // 
            // mrežaZaFlotu
            // 
            this.mrežaZaFlotu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mrežaZaFlotu.Location = new System.Drawing.Point(12, 12);
            this.mrežaZaFlotu.Name = "mrežaZaFlotu";
            this.mrežaZaFlotu.Size = new System.Drawing.Size(427, 406);
            this.mrežaZaFlotu.TabIndex = 2;
            this.mrežaZaFlotu.Text = "mrežaZaFlotu";
            // 
            // FormFlota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 471);
            this.Controls.Add(this.mrežaZaFlotu);
            this.Controls.Add(this.buttonSložiFlotu);
            this.DoubleBuffered = true;
            this.Name = "FormFlota";
            this.Text = "Slaganje flote";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSložiFlotu;
        private MrežaZaFlotu mrežaZaFlotu;
    }
}


namespace MLRiVuCApp
{
    partial class CustomMessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomMessageBox));
            this.btnOpc1 = new System.Windows.Forms.Button();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.btnOpc2 = new System.Windows.Forms.Button();
            this.btnOpc3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOpc1
            // 
            this.btnOpc1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnOpc1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOpc1.Location = new System.Drawing.Point(7, 60);
            this.btnOpc1.Name = "btnOpc1";
            this.btnOpc1.Size = new System.Drawing.Size(93, 34);
            this.btnOpc1.TabIndex = 0;
            this.btnOpc1.UseVisualStyleBackColor = true;
            this.btnOpc1.Click += new System.EventHandler(this.btnOpc1_Click);
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.Location = new System.Drawing.Point(12, 19);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(0, 13);
            this.lblMensaje.TabIndex = 1;
            // 
            // btnOpc2
            // 
            this.btnOpc2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpc2.Location = new System.Drawing.Point(113, 60);
            this.btnOpc2.Name = "btnOpc2";
            this.btnOpc2.Size = new System.Drawing.Size(93, 34);
            this.btnOpc2.TabIndex = 2;
            this.btnOpc2.UseVisualStyleBackColor = true;
            this.btnOpc2.Click += new System.EventHandler(this.btnOpc2_Click);
            // 
            // btnOpc3
            // 
            this.btnOpc3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnOpc3.Location = new System.Drawing.Point(219, 60);
            this.btnOpc3.Name = "btnOpc3";
            this.btnOpc3.Size = new System.Drawing.Size(93, 34);
            this.btnOpc3.TabIndex = 3;
            this.btnOpc3.UseVisualStyleBackColor = true;
            this.btnOpc3.Click += new System.EventHandler(this.btnOpc3_Click);
            // 
            // CustomMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(319, 104);
            this.Controls.Add(this.btnOpc3);
            this.Controls.Add(this.btnOpc2);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.btnOpc1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomMessageBox";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustomMessageBox";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmCustomMsgBx_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpc1;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Button btnOpc2;
        private System.Windows.Forms.Button btnOpc3;
    }
}
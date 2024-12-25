namespace AudioChannelInspector
{
    partial class MainForm
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
            this.lblSelectFile = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblChannels = new System.Windows.Forms.Label();
            this.txtChannels = new System.Windows.Forms.TextBox();
            this.lblChannelOrder = new System.Windows.Forms.Label();
            this.txtChannelOrder = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblSelectFile
            // 
            this.lblSelectFile.AutoSize = true;
            this.lblSelectFile.Location = new System.Drawing.Point(12, 15);
            this.lblSelectFile.Name = "lblSelectFile";
            this.lblSelectFile.Size = new System.Drawing.Size(86, 13);
            this.lblSelectFile.TabIndex = 0;
            this.lblSelectFile.Text = "Select Audio File:";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(104, 12);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(460, 20);
            this.txtFilePath.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(570, 10);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblChannels
            // 
            this.lblChannels.AutoSize = true;
            this.lblChannels.Location = new System.Drawing.Point(12, 55);
            this.lblChannels.Name = "lblChannels";
            this.lblChannels.Size = new System.Drawing.Size(54, 13);
            this.lblChannels.TabIndex = 3;
            this.lblChannels.Text = "Channels:";
            // 
            // txtChannels
            // 
            this.txtChannels.Location = new System.Drawing.Point(104, 52);
            this.txtChannels.Name = "txtChannels";
            this.txtChannels.ReadOnly = true;
            this.txtChannels.Size = new System.Drawing.Size(541, 20);
            this.txtChannels.TabIndex = 4;
            // 
            // lblChannelOrder
            // 
            this.lblChannelOrder.AutoSize = true;
            this.lblChannelOrder.Location = new System.Drawing.Point(12, 95);
            this.lblChannelOrder.Name = "lblChannelOrder";
            this.lblChannelOrder.Size = new System.Drawing.Size(79, 13);
            this.lblChannelOrder.TabIndex = 5;
            this.lblChannelOrder.Text = "Channel Order:";
            // 
            // txtChannelOrder
            // 
            this.txtChannelOrder.Location = new System.Drawing.Point(104, 92);
            this.txtChannelOrder.Name = "txtChannelOrder";
            this.txtChannelOrder.ReadOnly = true;
            this.txtChannelOrder.Size = new System.Drawing.Size(541, 20);
            this.txtChannelOrder.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 130);
            this.Controls.Add(this.txtChannelOrder);
            this.Controls.Add(this.lblChannelOrder);
            this.Controls.Add(this.txtChannels);
            this.Controls.Add(this.lblChannels);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.lblSelectFile);
            this.Name = "MainForm";
            this.Text = "Audio Channel Inspector";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblSelectFile;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblChannels;
        private System.Windows.Forms.TextBox txtChannels;
        private System.Windows.Forms.Label lblChannelOrder;
        private System.Windows.Forms.TextBox txtChannelOrder;
    }
}

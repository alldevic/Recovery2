using System.ComponentModel;
using System.Windows.Forms;

namespace Recovery2.Views
{
    partial class ContestView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ContestLabel = new System.Windows.Forms.Label();
            this.ContestImage = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.ContestImage)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.ContestLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ContestImage, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 561);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ContestLabel
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.ContestLabel, 3);
            this.ContestLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContestLabel.Location = new System.Drawing.Point(3, 0);
            this.ContestLabel.Name = "ContestLabel";
            this.ContestLabel.Size = new System.Drawing.Size(778, 84);
            this.ContestLabel.TabIndex = 0;
            this.ContestLabel.Text = "label1";
            this.ContestLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ContestImage
            // 
            this.ContestImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContestImage.Location = new System.Drawing.Point(199, 182);
            this.ContestImage.Name = "ContestImage";
            this.ContestImage.Size = new System.Drawing.Size(386, 280);
            this.ContestImage.TabIndex = 1;
            this.ContestImage.TabStop = false;
            // 
            // ContestView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ContestView";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "ContestView";
            this.SizeChanged += new System.EventHandler(this.ContestView_SizeChanged);
            this.KeyDown += new KeyEventHandler(this.ContestView_KeyDown);
            this.FormClosing += new FormClosingEventHandler(this.ContestView_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.ContestImage)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.PictureBox ContestImage;

        private System.Windows.Forms.Label ContestLabel;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

        #endregion
    }
}
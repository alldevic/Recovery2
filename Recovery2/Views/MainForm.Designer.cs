using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Recovery2.Views
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.LabelLastName = new System.Windows.Forms.Label();
            this.LabelFirstName = new System.Windows.Forms.Label();
            this.LabelSecondName = new System.Windows.Forms.Label();
            this.LabelAge = new System.Windows.Forms.Label();
            this.LabelGender = new System.Windows.Forms.Label();
            this.TextLastName = new System.Windows.Forms.TextBox();
            this.TextFirstName = new System.Windows.Forms.TextBox();
            this.TextSecondName = new System.Windows.Forms.TextBox();
            this.TextAge = new System.Windows.Forms.TextBox();
            this.ButtonBegin = new System.Windows.Forms.Button();
            this.RadioMale = new System.Windows.Forms.RadioButton();
            this.RadioFemale = new System.Windows.Forms.RadioButton();
            this.ButtonClear = new System.Windows.Forms.Button();
            this.ButtonConfig = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.LabelLastName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.LabelFirstName, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.LabelSecondName, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.LabelAge, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.LabelGender, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.TextLastName, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.TextFirstName, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.TextSecondName, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.TextAge, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.ButtonBegin, 5, 11);
            this.tableLayoutPanel1.Controls.Add(this.RadioMale, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.RadioFemale, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.ButtonClear, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.ButtonConfig, 5, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 13;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 561);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // LabelLastName
            // 
            this.LabelLastName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelLastName.Location = new System.Drawing.Point(155, 137);
            this.LabelLastName.Name = "LabelLastName";
            this.LabelLastName.Size = new System.Drawing.Size(90, 26);
            this.LabelLastName.TabIndex = 0;
            this.LabelLastName.Text = "Фамилия:";
            this.LabelLastName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelFirstName
            // 
            this.LabelFirstName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelFirstName.Location = new System.Drawing.Point(155, 163);
            this.LabelFirstName.Name = "LabelFirstName";
            this.LabelFirstName.Size = new System.Drawing.Size(90, 26);
            this.LabelFirstName.TabIndex = 1;
            this.LabelFirstName.Text = "Имя:";
            this.LabelFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelSecondName
            // 
            this.LabelSecondName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelSecondName.Location = new System.Drawing.Point(155, 189);
            this.LabelSecondName.Name = "LabelSecondName";
            this.LabelSecondName.Size = new System.Drawing.Size(90, 26);
            this.LabelSecondName.TabIndex = 2;
            this.LabelSecondName.Text = "Отчество:";
            this.LabelSecondName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelAge
            // 
            this.LabelAge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelAge.Location = new System.Drawing.Point(155, 215);
            this.LabelAge.Name = "LabelAge";
            this.LabelAge.Size = new System.Drawing.Size(90, 26);
            this.LabelAge.TabIndex = 3;
            this.LabelAge.Text = "Возраст:";
            this.LabelAge.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelGender
            // 
            this.LabelGender.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelGender.Location = new System.Drawing.Point(155, 241);
            this.LabelGender.Name = "LabelGender";
            this.LabelGender.Size = new System.Drawing.Size(90, 26);
            this.LabelGender.TabIndex = 4;
            this.LabelGender.Text = "Пол:";
            this.LabelGender.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TextLastName
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.TextLastName, 2);
            this.TextLastName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextLastName.Location = new System.Drawing.Point(251, 140);
            this.TextLastName.MaxLength = 50;
            this.TextLastName.Name = "TextLastName";
            this.TextLastName.Size = new System.Drawing.Size(186, 20);
            this.TextLastName.TabIndex = 5;
            // 
            // TextFirstName
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.TextFirstName, 2);
            this.TextFirstName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextFirstName.Location = new System.Drawing.Point(251, 166);
            this.TextFirstName.MaxLength = 50;
            this.TextFirstName.Name = "TextFirstName";
            this.TextFirstName.Size = new System.Drawing.Size(186, 20);
            this.TextFirstName.TabIndex = 6;
            // 
            // TextSecondName
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.TextSecondName, 2);
            this.TextSecondName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextSecondName.Location = new System.Drawing.Point(251, 192);
            this.TextSecondName.MaxLength = 50;
            this.TextSecondName.Name = "TextSecondName";
            this.TextSecondName.Size = new System.Drawing.Size(186, 20);
            this.TextSecondName.TabIndex = 7;
            // 
            // TextAge
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.TextAge, 2);
            this.TextAge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextAge.Location = new System.Drawing.Point(251, 218);
            this.TextAge.MaxLength = 3;
            this.TextAge.Name = "TextAge";
            this.TextAge.Size = new System.Drawing.Size(186, 20);
            this.TextAge.TabIndex = 8;
            this.TextAge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextAge_KeyPress);
            // 
            // ButtonBegin
            // 
            this.ButtonBegin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonBegin.Location = new System.Drawing.Point(536, 397);
            this.ButtonBegin.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonBegin.Name = "ButtonBegin";
            this.ButtonBegin.Size = new System.Drawing.Size(96, 26);
            this.ButtonBegin.TabIndex = 13;
            this.ButtonBegin.Text = "Начать";
            this.ButtonBegin.UseVisualStyleBackColor = true;
            this.ButtonBegin.Click += new System.EventHandler(this.ButtonBegin_Click);
            // 
            // RadioMale
            // 
            this.RadioMale.Location = new System.Drawing.Point(251, 244);
            this.RadioMale.Name = "RadioMale";
            this.RadioMale.Size = new System.Drawing.Size(90, 20);
            this.RadioMale.TabIndex = 9;
            this.RadioMale.TabStop = true;
            this.RadioMale.Text = "Мужской";
            this.RadioMale.UseVisualStyleBackColor = true;
            // 
            // RadioFemale
            // 
            this.RadioFemale.Location = new System.Drawing.Point(347, 244);
            this.RadioFemale.Name = "RadioFemale";
            this.RadioFemale.Size = new System.Drawing.Size(90, 20);
            this.RadioFemale.TabIndex = 10;
            this.RadioFemale.TabStop = true;
            this.RadioFemale.Text = "Женский";
            this.RadioFemale.UseVisualStyleBackColor = true;
            // 
            // ButtonClear
            // 
            this.ButtonClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonClear.Location = new System.Drawing.Point(152, 397);
            this.ButtonClear.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonClear.Name = "ButtonClear";
            this.ButtonClear.Size = new System.Drawing.Size(96, 26);
            this.ButtonClear.TabIndex = 11;
            this.ButtonClear.Text = "Очистить";
            this.ButtonClear.UseVisualStyleBackColor = true;
            this.ButtonClear.Click += new System.EventHandler(this.ButtonClear_Click);
            // 
            // ButtonConfig
            // 
            this.ButtonConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonConfig.Location = new System.Drawing.Point(536, 137);
            this.ButtonConfig.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonConfig.Name = "ButtonConfig";
            this.ButtonConfig.Size = new System.Drawing.Size(96, 26);
            this.ButtonConfig.TabIndex = 12;
            this.ButtonConfig.Text = "Параметры";
            this.ButtonConfig.UseVisualStyleBackColor = true;
            this.ButtonConfig.Click += new System.EventHandler(this.ButtonConfig_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.Text = "Восстановление";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button ButtonBegin;
        private System.Windows.Forms.Button ButtonClear;
        private System.Windows.Forms.Button ButtonConfig;
        private System.Windows.Forms.Label LabelAge;
        private System.Windows.Forms.Label LabelFirstName;
        private System.Windows.Forms.Label LabelGender;
        private System.Windows.Forms.Label LabelLastName;
        private System.Windows.Forms.Label LabelSecondName;
        private System.Windows.Forms.RadioButton RadioFemale;
        private System.Windows.Forms.RadioButton RadioMale;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox TextAge;
        private System.Windows.Forms.TextBox TextFirstName;
        private System.Windows.Forms.TextBox TextLastName;
        private System.Windows.Forms.TextBox TextSecondName;

        #endregion
    }
}

namespace CCNHS_QR_Attendance
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.dateTimePicker_to = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker_from = new System.Windows.Forms.DateTimePicker();
            this.comboBox_QRCode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_ExportAllData = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_DataFormat = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // dateTimePicker_to
            // 
            this.dateTimePicker_to.Location = new System.Drawing.Point(134, 53);
            this.dateTimePicker_to.Name = "dateTimePicker_to";
            this.dateTimePicker_to.Size = new System.Drawing.Size(150, 20);
            this.dateTimePicker_to.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "End Date: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Starting Date: ";
            // 
            // dateTimePicker_from
            // 
            this.dateTimePicker_from.CustomFormat = "";
            this.dateTimePicker_from.Location = new System.Drawing.Point(134, 21);
            this.dateTimePicker_from.Name = "dateTimePicker_from";
            this.dateTimePicker_from.Size = new System.Drawing.Size(150, 20);
            this.dateTimePicker_from.TabIndex = 14;
            // 
            // comboBox_QRCode
            // 
            this.comboBox_QRCode.FormattingEnabled = true;
            this.comboBox_QRCode.Location = new System.Drawing.Point(134, 89);
            this.comboBox_QRCode.Name = "comboBox_QRCode";
            this.comboBox_QRCode.Size = new System.Drawing.Size(256, 21);
            this.comboBox_QRCode.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Choose QR Code:";
            // 
            // button_ExportAllData
            // 
            this.button_ExportAllData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ExportAllData.Location = new System.Drawing.Point(91, 176);
            this.button_ExportAllData.Name = "button_ExportAllData";
            this.button_ExportAllData.Size = new System.Drawing.Size(272, 31);
            this.button_ExportAllData.TabIndex = 20;
            this.button_ExportAllData.Text = "EXPORT TARGET DATA AS .CSV FILE";
            this.button_ExportAllData.UseVisualStyleBackColor = true;
            this.button_ExportAllData.Click += new System.EventHandler(this.button_ExportAllData_onclick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Data Format: ";
            // 
            // comboBox_DataFormat
            // 
            this.comboBox_DataFormat.FormattingEnabled = true;
            this.comboBox_DataFormat.Location = new System.Drawing.Point(134, 128);
            this.comboBox_DataFormat.Name = "comboBox_DataFormat";
            this.comboBox_DataFormat.Size = new System.Drawing.Size(121, 21);
            this.comboBox_DataFormat.TabIndex = 22;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 231);
            this.Controls.Add(this.comboBox_DataFormat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_ExportAllData);
            this.Controls.Add(this.comboBox_QRCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker_to);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker_from);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export Attendance Data";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker_to;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker_from;
        private System.Windows.Forms.ComboBox comboBox_QRCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_ExportAllData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_DataFormat;
    }
}
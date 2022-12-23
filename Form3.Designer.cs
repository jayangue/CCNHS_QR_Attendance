
namespace CCNHS_QR_Attendance
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker_MainDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_QRCode = new System.Windows.Forms.ComboBox();
            this.checkBox_ArrivalMorning = new System.Windows.Forms.CheckBox();
            this.checkBox_DepartureMorning = new System.Windows.Forms.CheckBox();
            this.checkBox_ArrivalAfternoon = new System.Windows.Forms.CheckBox();
            this.checkBox_DepartureAfternoon = new System.Windows.Forms.CheckBox();
            this.dateTimePicker_ArrivalMorning = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_DepartureMorning = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_ArrivalAfternoon = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_DepartureAfternoon = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Target Date: ";
            // 
            // dateTimePicker_MainDate
            // 
            this.dateTimePicker_MainDate.Location = new System.Drawing.Point(100, 20);
            this.dateTimePicker_MainDate.Name = "dateTimePicker_MainDate";
            this.dateTimePicker_MainDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_MainDate.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Choose QR Code:";
            // 
            // comboBox_QRCode
            // 
            this.comboBox_QRCode.FormattingEnabled = true;
            this.comboBox_QRCode.Location = new System.Drawing.Point(123, 61);
            this.comboBox_QRCode.Name = "comboBox_QRCode";
            this.comboBox_QRCode.Size = new System.Drawing.Size(176, 21);
            this.comboBox_QRCode.TabIndex = 3;
            // 
            // checkBox_ArrivalMorning
            // 
            this.checkBox_ArrivalMorning.AutoSize = true;
            this.checkBox_ArrivalMorning.Location = new System.Drawing.Point(27, 113);
            this.checkBox_ArrivalMorning.Name = "checkBox_ArrivalMorning";
            this.checkBox_ArrivalMorning.Size = new System.Drawing.Size(102, 17);
            this.checkBox_ArrivalMorning.TabIndex = 4;
            this.checkBox_ArrivalMorning.Text = "Arrival Morning: ";
            this.checkBox_ArrivalMorning.UseVisualStyleBackColor = true;
            // 
            // checkBox_DepartureMorning
            // 
            this.checkBox_DepartureMorning.AutoSize = true;
            this.checkBox_DepartureMorning.Location = new System.Drawing.Point(27, 143);
            this.checkBox_DepartureMorning.Name = "checkBox_DepartureMorning";
            this.checkBox_DepartureMorning.Size = new System.Drawing.Size(120, 17);
            this.checkBox_DepartureMorning.TabIndex = 5;
            this.checkBox_DepartureMorning.Text = "Departure Morning: ";
            this.checkBox_DepartureMorning.UseVisualStyleBackColor = true;
            // 
            // checkBox_ArrivalAfternoon
            // 
            this.checkBox_ArrivalAfternoon.AutoSize = true;
            this.checkBox_ArrivalAfternoon.Location = new System.Drawing.Point(27, 178);
            this.checkBox_ArrivalAfternoon.Name = "checkBox_ArrivalAfternoon";
            this.checkBox_ArrivalAfternoon.Size = new System.Drawing.Size(104, 17);
            this.checkBox_ArrivalAfternoon.TabIndex = 6;
            this.checkBox_ArrivalAfternoon.Text = "Arrival Afternoon";
            this.checkBox_ArrivalAfternoon.UseVisualStyleBackColor = true;
            // 
            // checkBox_DepartureAfternoon
            // 
            this.checkBox_DepartureAfternoon.AutoSize = true;
            this.checkBox_DepartureAfternoon.Location = new System.Drawing.Point(27, 212);
            this.checkBox_DepartureAfternoon.Name = "checkBox_DepartureAfternoon";
            this.checkBox_DepartureAfternoon.Size = new System.Drawing.Size(128, 17);
            this.checkBox_DepartureAfternoon.TabIndex = 7;
            this.checkBox_DepartureAfternoon.Text = "Departure Afternoon: ";
            this.checkBox_DepartureAfternoon.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker_ArrivalMorning
            // 
            this.dateTimePicker_ArrivalMorning.Location = new System.Drawing.Point(161, 108);
            this.dateTimePicker_ArrivalMorning.Name = "dateTimePicker_ArrivalMorning";
            this.dateTimePicker_ArrivalMorning.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_ArrivalMorning.TabIndex = 8;
            // 
            // dateTimePicker_DepartureMorning
            // 
            this.dateTimePicker_DepartureMorning.Location = new System.Drawing.Point(161, 143);
            this.dateTimePicker_DepartureMorning.Name = "dateTimePicker_DepartureMorning";
            this.dateTimePicker_DepartureMorning.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_DepartureMorning.TabIndex = 9;
            // 
            // dateTimePicker_ArrivalAfternoon
            // 
            this.dateTimePicker_ArrivalAfternoon.Location = new System.Drawing.Point(161, 178);
            this.dateTimePicker_ArrivalAfternoon.Name = "dateTimePicker_ArrivalAfternoon";
            this.dateTimePicker_ArrivalAfternoon.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_ArrivalAfternoon.TabIndex = 10;
            // 
            // dateTimePicker_DepartureAfternoon
            // 
            this.dateTimePicker_DepartureAfternoon.Location = new System.Drawing.Point(161, 212);
            this.dateTimePicker_DepartureAfternoon.Name = "dateTimePicker_DepartureAfternoon";
            this.dateTimePicker_DepartureAfternoon.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_DepartureAfternoon.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(148, 265);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 33);
            this.button1.TabIndex = 12;
            this.button1.Text = "Edit Attendance";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button_EditAttendance_onclick);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(16, 266);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 34);
            this.button2.TabIndex = 13;
            this.button2.Text = "Randomize Time";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button_RandomizeTime_onclick);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(273, 266);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(109, 32);
            this.button3.TabIndex = 14;
            this.button3.Text = "Add Attendance";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button_AddAttendance_onclick);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 315);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimePicker_DepartureAfternoon);
            this.Controls.Add(this.dateTimePicker_ArrivalAfternoon);
            this.Controls.Add(this.dateTimePicker_DepartureMorning);
            this.Controls.Add(this.dateTimePicker_ArrivalMorning);
            this.Controls.Add(this.checkBox_DepartureAfternoon);
            this.Controls.Add(this.checkBox_ArrivalAfternoon);
            this.Controls.Add(this.checkBox_DepartureMorning);
            this.Controls.Add(this.checkBox_ArrivalMorning);
            this.Controls.Add(this.comboBox_QRCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker_MainDate);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modify Attendance";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_MainDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_QRCode;
        private System.Windows.Forms.CheckBox checkBox_ArrivalMorning;
        private System.Windows.Forms.CheckBox checkBox_DepartureMorning;
        private System.Windows.Forms.CheckBox checkBox_ArrivalAfternoon;
        private System.Windows.Forms.CheckBox checkBox_DepartureAfternoon;
        private System.Windows.Forms.DateTimePicker dateTimePicker_ArrivalMorning;
        private System.Windows.Forms.DateTimePicker dateTimePicker_DepartureMorning;
        private System.Windows.Forms.DateTimePicker dateTimePicker_ArrivalAfternoon;
        private System.Windows.Forms.DateTimePicker dateTimePicker_DepartureAfternoon;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}
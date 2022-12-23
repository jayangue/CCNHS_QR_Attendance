
namespace CCNHS_QR_Attendance
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox_Main = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_QRData = new System.Windows.Forms.TextBox();
            this.button_StartScan = new System.Windows.Forms.Button();
            this.checkBox_Arrival = new System.Windows.Forms.CheckBox();
            this.checkBox_Departure = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_ShowData = new System.Windows.Forms.ComboBox();
            this.dataGridView_main = new System.Windows.Forms.DataGridView();
            this.button_ExportAllData = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.timer_Main = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_DeviceList = new System.Windows.Forms.ComboBox();
            this.button_DeleteAll = new System.Windows.Forms.Button();
            this.button_AdvanceSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_main)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Main
            // 
            this.pictureBox_Main.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox_Main.Location = new System.Drawing.Point(22, 38);
            this.pictureBox_Main.Name = "pictureBox_Main";
            this.pictureBox_Main.Size = new System.Drawing.Size(425, 415);
            this.pictureBox_Main.TabIndex = 2;
            this.pictureBox_Main.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 476);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "QR Data: ";
            // 
            // textBox_QRData
            // 
            this.textBox_QRData.Location = new System.Drawing.Point(119, 459);
            this.textBox_QRData.Multiline = true;
            this.textBox_QRData.Name = "textBox_QRData";
            this.textBox_QRData.Size = new System.Drawing.Size(270, 48);
            this.textBox_QRData.TabIndex = 4;
            // 
            // button_StartScan
            // 
            this.button_StartScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_StartScan.Location = new System.Drawing.Point(22, 528);
            this.button_StartScan.Name = "button_StartScan";
            this.button_StartScan.Size = new System.Drawing.Size(173, 67);
            this.button_StartScan.TabIndex = 5;
            this.button_StartScan.Text = "START SCAN";
            this.button_StartScan.UseVisualStyleBackColor = true;
            this.button_StartScan.Click += new System.EventHandler(this.button_StartScan_onclick);
            // 
            // checkBox_Arrival
            // 
            this.checkBox_Arrival.AutoSize = true;
            this.checkBox_Arrival.Checked = true;
            this.checkBox_Arrival.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Arrival.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_Arrival.Location = new System.Drawing.Point(212, 550);
            this.checkBox_Arrival.Name = "checkBox_Arrival";
            this.checkBox_Arrival.Size = new System.Drawing.Size(71, 24);
            this.checkBox_Arrival.TabIndex = 6;
            this.checkBox_Arrival.Text = "Arrival";
            this.checkBox_Arrival.UseVisualStyleBackColor = true;
            this.checkBox_Arrival.Click += new System.EventHandler(this.checkBox_Arrival_onclick);
            // 
            // checkBox_Departure
            // 
            this.checkBox_Departure.AutoSize = true;
            this.checkBox_Departure.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_Departure.Location = new System.Drawing.Point(289, 550);
            this.checkBox_Departure.Name = "checkBox_Departure";
            this.checkBox_Departure.Size = new System.Drawing.Size(100, 24);
            this.checkBox_Departure.TabIndex = 7;
            this.checkBox_Departure.Text = "Departure";
            this.checkBox_Departure.UseVisualStyleBackColor = true;
            this.checkBox_Departure.Click += new System.EventHandler(this.checkBox_Departure_onclick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(517, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Show Data: ";
            // 
            // comboBox_ShowData
            // 
            this.comboBox_ShowData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ShowData.FormattingEnabled = true;
            this.comboBox_ShowData.Location = new System.Drawing.Point(589, 33);
            this.comboBox_ShowData.Name = "comboBox_ShowData";
            this.comboBox_ShowData.Size = new System.Drawing.Size(205, 21);
            this.comboBox_ShowData.TabIndex = 9;
            this.comboBox_ShowData.SelectedIndexChanged += new System.EventHandler(this.comboBox_ShowData_SelectedIndexChanged);
            // 
            // dataGridView_main
            // 
            this.dataGridView_main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_main.Location = new System.Drawing.Point(481, 63);
            this.dataGridView_main.Name = "dataGridView_main";
            this.dataGridView_main.Size = new System.Drawing.Size(487, 429);
            this.dataGridView_main.TabIndex = 10;
            this.dataGridView_main.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_main_CellClick);
            // 
            // button_ExportAllData
            // 
            this.button_ExportAllData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ExportAllData.Location = new System.Drawing.Point(501, 508);
            this.button_ExportAllData.Name = "button_ExportAllData";
            this.button_ExportAllData.Size = new System.Drawing.Size(270, 32);
            this.button_ExportAllData.TabIndex = 12;
            this.button_ExportAllData.Text = "EXPORT ATTENDANCE DATA";
            this.button_ExportAllData.UseVisualStyleBackColor = true;
            this.button_ExportAllData.Click += new System.EventHandler(this.button_ExportAllData_onclick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(768, 583);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "Version 0.2.0 Alpha by Jay C. Angue";
            // 
            // timer_Main
            // 
            this.timer_Main.Tick += new System.EventHandler(this.timer_Main_ontick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose Camera:";
            // 
            // comboBox_DeviceList
            // 
            this.comboBox_DeviceList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_DeviceList.FormattingEnabled = true;
            this.comboBox_DeviceList.Location = new System.Drawing.Point(181, 11);
            this.comboBox_DeviceList.Name = "comboBox_DeviceList";
            this.comboBox_DeviceList.Size = new System.Drawing.Size(114, 21);
            this.comboBox_DeviceList.TabIndex = 1;
            this.comboBox_DeviceList.SelectedIndexChanged += new System.EventHandler(this.comboBox_DeviceList_SelectedIndexChanged);
            // 
            // button_DeleteAll
            // 
            this.button_DeleteAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_DeleteAll.Location = new System.Drawing.Point(808, 508);
            this.button_DeleteAll.Name = "button_DeleteAll";
            this.button_DeleteAll.Size = new System.Drawing.Size(141, 32);
            this.button_DeleteAll.TabIndex = 14;
            this.button_DeleteAll.Text = "DELETE ALL DATA";
            this.button_DeleteAll.UseVisualStyleBackColor = true;
            this.button_DeleteAll.Click += new System.EventHandler(this.button_DeleteAll_onclick);
            // 
            // button_AdvanceSearch
            // 
            this.button_AdvanceSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_AdvanceSearch.Location = new System.Drawing.Point(831, 33);
            this.button_AdvanceSearch.Name = "button_AdvanceSearch";
            this.button_AdvanceSearch.Size = new System.Drawing.Size(118, 23);
            this.button_AdvanceSearch.TabIndex = 15;
            this.button_AdvanceSearch.Text = "Advance Search";
            this.button_AdvanceSearch.UseVisualStyleBackColor = true;
            this.button_AdvanceSearch.Click += new System.EventHandler(this.button_AdvanceSearch_onclick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 607);
            this.Controls.Add(this.button_AdvanceSearch);
            this.Controls.Add(this.button_DeleteAll);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button_ExportAllData);
            this.Controls.Add(this.dataGridView_main);
            this.Controls.Add(this.comboBox_ShowData);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkBox_Departure);
            this.Controls.Add(this.checkBox_Arrival);
            this.Controls.Add(this.button_StartScan);
            this.Controls.Add(this.textBox_QRData);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox_Main);
            this.Controls.Add(this.comboBox_DeviceList);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CCNHS QR Attendance";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_onclose);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_main)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox_Main;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_QRData;
        private System.Windows.Forms.Button button_StartScan;
        private System.Windows.Forms.CheckBox checkBox_Arrival;
        private System.Windows.Forms.CheckBox checkBox_Departure;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_ShowData;
        private System.Windows.Forms.DataGridView dataGridView_main;
        private System.Windows.Forms.Button button_ExportAllData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer_Main;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_DeviceList;
        private System.Windows.Forms.Button button_DeleteAll;
        private System.Windows.Forms.Button button_AdvanceSearch;
    }
}


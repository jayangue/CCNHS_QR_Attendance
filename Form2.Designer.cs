
namespace CCNHS_QR_Attendance
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_QRCodeContent = new System.Windows.Forms.TextBox();
            this.button_StartSearch = new System.Windows.Forms.Button();
            this.dataGridView_main = new System.Windows.Forms.DataGridView();
            this.button_GoBack = new System.Windows.Forms.Button();
            this.dateTimePicker_from = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker_to = new System.Windows.Forms.DateTimePicker();
            this.comboBox_ChooseMode = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button_Modify = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_main)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 86);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "QR Code Content : ";
            // 
            // textBox_QRCodeContent
            // 
            this.textBox_QRCodeContent.Location = new System.Drawing.Point(249, 82);
            this.textBox_QRCodeContent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_QRCodeContent.Name = "textBox_QRCodeContent";
            this.textBox_QRCodeContent.Size = new System.Drawing.Size(254, 26);
            this.textBox_QRCodeContent.TabIndex = 1;
            // 
            // button_StartSearch
            // 
            this.button_StartSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_StartSearch.Location = new System.Drawing.Point(297, 625);
            this.button_StartSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_StartSearch.Name = "button_StartSearch";
            this.button_StartSearch.Size = new System.Drawing.Size(230, 51);
            this.button_StartSearch.TabIndex = 4;
            this.button_StartSearch.Text = "START SEARCH";
            this.button_StartSearch.UseVisualStyleBackColor = true;
            this.button_StartSearch.Click += new System.EventHandler(this.button_StartSearch_onclick);
            // 
            // dataGridView_main
            // 
            this.dataGridView_main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_main.Location = new System.Drawing.Point(34, 138);
            this.dataGridView_main.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView_main.Name = "dataGridView_main";
            this.dataGridView_main.RowHeadersWidth = 62;
            this.dataGridView_main.Size = new System.Drawing.Size(994, 477);
            this.dataGridView_main.TabIndex = 5;
            this.dataGridView_main.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_main_CellClick);
            // 
            // button_GoBack
            // 
            this.button_GoBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_GoBack.Location = new System.Drawing.Point(535, 625);
            this.button_GoBack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_GoBack.Name = "button_GoBack";
            this.button_GoBack.Size = new System.Drawing.Size(234, 51);
            this.button_GoBack.TabIndex = 6;
            this.button_GoBack.Text = "GO BACK";
            this.button_GoBack.UseVisualStyleBackColor = true;
            this.button_GoBack.Click += new System.EventHandler(this.button_GoBack_onclick);
            // 
            // dateTimePicker_from
            // 
            this.dateTimePicker_from.CustomFormat = "";
            this.dateTimePicker_from.Location = new System.Drawing.Point(716, 26);
            this.dateTimePicker_from.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePicker_from.Name = "dateTimePicker_from";
            this.dateTimePicker_from.Size = new System.Drawing.Size(223, 26);
            this.dateTimePicker_from.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(594, 35);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Starting Date: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(594, 86);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "End Date: ";
            // 
            // dateTimePicker_to
            // 
            this.dateTimePicker_to.Location = new System.Drawing.Point(716, 77);
            this.dateTimePicker_to.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePicker_to.Name = "dateTimePicker_to";
            this.dateTimePicker_to.Size = new System.Drawing.Size(223, 26);
            this.dateTimePicker_to.TabIndex = 13;
            // 
            // comboBox_ChooseMode
            // 
            this.comboBox_ChooseMode.FormattingEnabled = true;
            this.comboBox_ChooseMode.Location = new System.Drawing.Point(249, 23);
            this.comboBox_ChooseMode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox_ChooseMode.Name = "comboBox_ChooseMode";
            this.comboBox_ChooseMode.Size = new System.Drawing.Size(254, 28);
            this.comboBox_ChooseMode.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(108, 28);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Choose Mode: ";
            // 
            // button_Modify
            // 
            this.button_Modify.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Modify.Location = new System.Drawing.Point(1042, 676);
            this.button_Modify.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_Modify.Name = "button_Modify";
            this.button_Modify.Size = new System.Drawing.Size(10, 10);
            this.button_Modify.TabIndex = 16;
            this.button_Modify.UseVisualStyleBackColor = true;
            this.button_Modify.Click += new System.EventHandler(this.button_Modify_onclick);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 690);
            this.Controls.Add(this.button_Modify);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox_ChooseMode);
            this.Controls.Add(this.dateTimePicker_to);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker_from);
            this.Controls.Add(this.button_GoBack);
            this.Controls.Add(this.dataGridView_main);
            this.Controls.Add(this.button_StartSearch);
            this.Controls.Add(this.textBox_QRCodeContent);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Advance Search";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_main)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_QRCodeContent;
        private System.Windows.Forms.Button button_StartSearch;
        private System.Windows.Forms.DataGridView dataGridView_main;
        private System.Windows.Forms.Button button_GoBack;
        private System.Windows.Forms.DateTimePicker dateTimePicker_from;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker_to;
        private System.Windows.Forms.ComboBox comboBox_ChooseMode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_Modify;
    }
}
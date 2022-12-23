using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CCNHS_QR_Attendance
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            dateTimePicker_from.Format = DateTimePickerFormat.Custom;
            dateTimePicker_from.CustomFormat = "MM/dd/yyyy";
            dateTimePicker_to.Format = DateTimePickerFormat.Custom;
            dateTimePicker_to.CustomFormat = "MM/dd/yyyy";

            comboBox_ChooseMode.Items.Add("Arrival & Departure");
            comboBox_ChooseMode.Items.Add("Arrival Morning");
            comboBox_ChooseMode.Items.Add("Departure Morning");
            comboBox_ChooseMode.Items.Add("Arrival Afternoon");
            comboBox_ChooseMode.Items.Add("Departure Afternoon");
            comboBox_ChooseMode.SelectedIndex = 0;

        }

        string QR_DATA_DirectoryPath = @"c:\CCNHS_QR_Attendance_DATABASE";
        string QR_DATA_FilePath = @"c:\CCNHS_QR_Attendance_DATABASE\CCNHS_QR_Attendance_DATABASE.txt";

        int dataGridView_main_last_index = 0;

        List<string> QR_DATA = new List<string>();
        List<string> QR_CORRECT_DATA = new List<string>();

        Form3 form3 = new Form3();

        

        private void Read_QR_DATABASE()
        {
            if (Directory.Exists(QR_DATA_DirectoryPath) == true)
            {
                if (File.Exists(QR_DATA_FilePath) == true)
                {

                    try
                    {
                        QR_DATA.Clear();
                        string line = "";
                        System.IO.StreamReader file = new System.IO.StreamReader(QR_DATA_FilePath);
                        while ((line = file.ReadLine()) != null)
                        {
                            QR_DATA.Add(line);
                        }

                        file.Close();
                    }
                    catch (Exception e)
                    {
                        string message = e.Message;
                        string title = "CRITICAL ERROR";
                        MessageBox.Show(message, title);
                    }


                }

            }


        }

        private void Write_QR_DATABASE()
        {

            if (Directory.Exists(QR_DATA_DirectoryPath) == true)
            {
                if (File.Exists(QR_DATA_FilePath) == true)
                {
                    File.Delete(QR_DATA_FilePath);
                }


                try
                {
                    using (TextWriter tw = new StreamWriter(QR_DATA_FilePath))
                    {
                        for (int i = 0; i <= QR_DATA.Count - 1; i++)
                        {
                            tw.WriteLine(QR_DATA[i]);
                        }

                    }
                }
                catch (Exception e)
                {
                    string message = e.Message;
                    string title = "CRITICAL ERROR";
                    MessageBox.Show(message, title);
                }

            }
            else
            {
                System.IO.Directory.CreateDirectory(QR_DATA_DirectoryPath);

                try
                {
                    using (TextWriter tw = new StreamWriter(QR_DATA_FilePath))
                    {
                        for (int i = 0; i <= QR_DATA.Count - 1; i++)
                        {
                            tw.WriteLine(QR_DATA[i]);
                        }

                    }
                }
                catch (Exception e)
                {
                    string message = e.Message;
                    string title = "CRITICAL ERROR";
                    MessageBox.Show(message, title);
                }


            }


        }//end of write qr database

        private void button_StartSearch_onclick(object sender, EventArgs e)
        {

            Update_DataGridView();
        }

        public void Update_DataGridView()
        {

            Read_QR_DATABASE();
            QR_CORRECT_DATA.Clear();

            string mode = comboBox_ChooseMode.SelectedItem.ToString();
            string qr_content = textBox_QRCodeContent.Text.ToUpper();
            string date_from = dateTimePicker_from.Value.Date.ToShortDateString();
            string date_to = dateTimePicker_to.Value.Date.ToShortDateString();

            string[] date_from_array = date_from.Split('/');
            string[] date_to_array = date_to.Split('/');

            //MessageBox.Show("" + mode, "");


            for (int i = 0; i <= QR_DATA.Count - 1; i++)
            {
                try
                {
                    string QR_DATA_line = i + ">>>" + QR_DATA[i];
                    string[] QR_DATA_result = QR_DATA_line.Split(new string[] { "##" }, StringSplitOptions.None);

                    string[] content_mode_array = QR_DATA_result[0].Split(new string[] { ">>>" }, StringSplitOptions.None);
                    string content_mode = content_mode_array[1];
                    string content_id = QR_DATA_result[1].ToUpper();
                    string content_date_string = QR_DATA_result[3];
                    string[] date_content_array = content_date_string.Split('/');


                    if (date_content_array.Length >= 3)
                    {
                        int date_from_int_month = 0; int.TryParse(date_from_array[1], out date_from_int_month);
                        int date_to_int_month = 0; int.TryParse(date_to_array[1], out date_to_int_month);
                        int date_content_int_month = 0; int.TryParse(date_content_array[0], out date_content_int_month);


                        int date_from_int_day = 0; int.TryParse(date_from_array[0], out date_from_int_day);
                        int date_to_int_day = 0; int.TryParse(date_to_array[0], out date_to_int_day);
                        int date_content_int_day = 0; int.TryParse(date_content_array[1], out date_content_int_day);

                        if (date_content_int_month >= date_from_int_month && date_content_int_month <= date_to_int_month)
                        {
                            if (date_content_int_day >= date_from_int_day && date_content_int_day <= date_to_int_day)
                            {
                                if (content_id.Contains(qr_content) == true)
                                {
                                    if (mode == "Arrival & Departure")
                                    {
                                        QR_CORRECT_DATA.Add(QR_DATA_line);

                                    }
                                    else if (mode == "Arrival Morning" && Check_Time_Mode(QR_DATA_result[2]) == "Arrival-Morning")
                                    {
                                        QR_CORRECT_DATA.Add(QR_DATA_line);
                                    }
                                    else if (mode == "Departure Morning" && Check_Time_Mode(QR_DATA_result[2]) == "Departure-Morning")
                                    {
                                        QR_CORRECT_DATA.Add(QR_DATA_line);
                                    }
                                    else if (mode == "Arrival Afternoon" && Check_Time_Mode(QR_DATA_result[2]) == "Arrival-Afternoon")
                                    {
                                        QR_CORRECT_DATA.Add(QR_DATA_line);
                                    }
                                    else if (mode == "Departure Afternoon" && Check_Time_Mode(QR_DATA_result[2]) == "Departure-Afternoon")
                                    {
                                        QR_CORRECT_DATA.Add(QR_DATA_line);
                                    }


                                }

                            };
                        };
                    };


                }
                catch (Exception exc)
                {
                    string message = exc.Message;
                    string title = "CRITICAL ERROR";
                    MessageBox.Show(message, title);
                }

            }

            DataTable dt = new DataTable();

            dataGridView_main.DataSource = null;
            dataGridView_main.Columns.Clear();
            dataGridView_main.Rows.Clear();

            DataGridViewButtonColumn btn_delete = new DataGridViewButtonColumn();
            dataGridView_main.Columns.Add(btn_delete);
            btn_delete.HeaderText = "";
            btn_delete.Text = "DELETE";
            btn_delete.UseColumnTextForButtonValue = true;


            dt.Columns.Add(new DataColumn("Mode", typeof(string)));
            dt.Columns.Add(new DataColumn("Data", typeof(string)));
            dt.Columns.Add(new DataColumn("Time", typeof(string)));
            dt.Columns.Add(new DataColumn("Date", typeof(string)));

            for (int i = 0; i <= QR_CORRECT_DATA.Count - 1; i++)
            {
                string correct_data_line = QR_CORRECT_DATA[i];
                //Console.WriteLine(correct_data_line);
                string[] raw_data_line = correct_data_line.Split(new string[] { ">>>" }, StringSplitOptions.None);
                string edited_correct_data_line = raw_data_line[1];
                string[] correct_data_result = edited_correct_data_line.Split(new string[] { "##" }, StringSplitOptions.None);
                dt.Rows.Add(correct_data_result[0], correct_data_result[1], correct_data_result[2], correct_data_result[3]);

            }

            dataGridView_main.DataSource = dt;
            dataGridView_main.AutoResizeColumns();
            dataGridView_main.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            DataGridViewColumn column = dataGridView_main.Columns[1];
            column.Width = 10;

            dataGridView_main_last_index = dt.Rows.Count;



        }

        private void dataGridView_main_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.ColumnIndex == 0 && e.RowIndex != dataGridView_main_last_index)
            {
                var main_mode = dataGridView_main.Rows[e.RowIndex].Cells[1].Value.ToString();
                var main_qr_code = dataGridView_main.Rows[e.RowIndex].Cells[2].Value.ToString();
                var main_time = dataGridView_main.Rows[e.RowIndex].Cells[3].Value.ToString();
                var main_date = dataGridView_main.Rows[e.RowIndex].Cells[4].Value.ToString();

                check_attendance(main_date,main_qr_code,main_mode,main_time);

                void check_attendance(string target_date, string target_qrcode, string target_mode,string target_time)
                {
                    for (int i = 0; i <= QR_DATA.Count - 1; i++)
                    {
                        try
                        {
                            string[] QR_DATA_result = QR_DATA[i].Split(new string[] { "##" }, StringSplitOptions.None);
                            
                            bool DateareSame = String.Equals(target_date, QR_DATA_result[3], StringComparison.OrdinalIgnoreCase);
                            bool IDareSame = String.Equals(target_qrcode, QR_DATA_result[1], StringComparison.OrdinalIgnoreCase);
                            bool ModeareSame = String.Equals(target_mode, QR_DATA_result[0], StringComparison.OrdinalIgnoreCase);
                            bool TimeareSame = String.Equals(target_time, QR_DATA_result[2], StringComparison.OrdinalIgnoreCase);

                            if (DateareSame == true && IDareSame == true && ModeareSame == true && TimeareSame == true)
                            {

                                string themessage = "Mode: " + QR_DATA_result[0] +
                                    "\nContent: " + QR_DATA_result[1] +
                                    "\nTime: " + QR_DATA_result[2] +
                                    "\nDate: " + QR_DATA_result[3];

                                DialogResult dialogResult = MessageBox.Show(themessage, "Do you really want to delete the following?", MessageBoxButtons.YesNo);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    QR_DATA.RemoveAt(i);
                                    Write_QR_DATABASE();
                                    Update_DataGridView();

                                }

                            }

                        }
                        catch (Exception exc)
                        {
                            string message = exc.Message;
                            string title = "dataGridView_delete_cell";
                            MessageBox.Show(message + " >> " + QR_DATA[i], title + " ERROR");
                        }

                    }
                }
            }
        }

        private void button_GoBack_onclick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Modify_onclick(object sender, EventArgs e)
        {
            try { 

                form3.Show();

            }catch(Exception exc){

                form3 = new Form3();
                form3.Show();
            }
        }

        string Check_Time_Mode(string time)
        {

            DateTime dateTime;
            DateTime.TryParse(time, out dateTime);

            string time_format = dateTime.ToString("tt", System.Globalization.CultureInfo.InvariantCulture);
            string mode_result = null;

            if (time_format == "AM")
            {
                if (dateTime.Hour >= 6 && dateTime.Hour <= 10)
                {
                    mode_result = "Arrival-Morning";

                }
                else if (dateTime.Hour >= 11 && dateTime.Hour <= 12)
                {
                    mode_result = "Departure-Morning";
                }
            }
            else if (time_format == "PM")
            {

                if (dateTime.Hour == 12 && dateTime.Minute < 30)
                {
                    mode_result = "Departure-Morning";
                }
                else if (dateTime.Hour == 12 && dateTime.Minute >= 30)
                {
                    mode_result = "Arrival-Afternoon";
                }
                else if (dateTime.Hour >= 13 && dateTime.Hour <= 15)
                {
                    mode_result = "Arrival-Afternoon";
                }
                else if (dateTime.Hour >= 16 && dateTime.Hour <= 19)
                {
                    mode_result = "Departure-Afternoon";
                }


            }

            return mode_result;

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace CCNHS_QR_Attendance
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        string QR_DATA_DirectoryPath = @"c:\CCNHS_QR_Attendance_DATABASE";
        string QR_DATA_FilePath = @"c:\CCNHS_QR_Attendance_DATABASE\CCNHS_QR_Attendance_DATABASE.txt";

        List<string> QR_DATA = new List<string>();
        List<int> LIST_OF_SECONDS = new List<int>();

        private void Form4_Load(object sender, EventArgs e)
        {
            dateTimePicker_from.Format = DateTimePickerFormat.Custom;
            dateTimePicker_from.CustomFormat = "MM/dd/yyyy";
            dateTimePicker_to.Format = DateTimePickerFormat.Custom;
            dateTimePicker_to.CustomFormat = "MM/dd/yyyy";

            string[] id_list = Get_QR_List();
            Array.Sort(id_list, (x, y) => String.Compare(x, y));

            comboBox_QRCode.Items.Add("All");
            for (var i = 0; i <= id_list.Length - 1; i++)
            {
                comboBox_QRCode.Items.Add(id_list[i]);
            }
            comboBox_QRCode.SelectedIndex = 0;

            comboBox_DataFormat.Items.Add("Default Format");
            comboBox_DataFormat.SelectedIndex = 0;

        }

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
                        string title = "Read_QR_Database";
                        MessageBox.Show(message, title + " ERROR");
                    }


                }

            }


        }

        string[] Get_QR_List()
        {

            Read_QR_DATABASE();

            List<string> id_list = new List<string>();

            for (int i = 0; i <= QR_DATA.Count - 1; i++)
            {
                try
                {

                    string[] QR_DATA_result = QR_DATA[i].Split(new string[] { "##" }, StringSplitOptions.None);

                    if (id_list.IndexOf(QR_DATA_result[1]) <= -1)
                    {
                        id_list.Add(QR_DATA_result[1]);
                    }


                }
                catch (Exception exc)
                {
                    string message = exc.Message;
                    string title = "Get_QR_List";
                    MessageBox.Show(message + " >> " + QR_DATA[i], title + " ERROR");
                }

            }

            //MessageBox.Show("" + id_list.Count, "");
            string[] new_list = id_list.ToArray();

            return new_list;
        }

        public List<string> QR_DATA_EXPORTER_DEFAULT(List<string> QR_DATA)
        {

            string qr_code = comboBox_QRCode.SelectedItem.ToString();
            string date_from = dateTimePicker_from.Value.Date.ToShortDateString();
            string date_to = dateTimePicker_to.Value.Date.ToShortDateString();

            DateTime dateTime_start;
            DateTime.TryParse(date_from, out dateTime_start);

            DateTime dateTime_end;
            DateTime.TryParse(date_to, out dateTime_end);

            string[] date_from_array = date_from.Split('/');
            string[] date_to_array = date_to.Split('/');


            List<string> final_result = new List<string>();
            List<string[]> QR_DATA_NEW = new List<string[]>();


            for (int i = 0; i <= QR_DATA.Count - 1; i++)
            {
                try
                {
                    string[] QR_DATA_result = QR_DATA[i].Split(new string[] { "##" }, StringSplitOptions.None);
                    string time_mode = Check_Time_Mode(QR_DATA_result[2]);
                    string[] new_line = { time_mode, QR_DATA_result[1], QR_DATA_result[2], QR_DATA_result[3] };
                    QR_DATA_NEW.Add(new_line);

                }
                catch (Exception exc)
                {
                    string message = exc.Message;
                    string title = "button_ApplyChanges_onclick";
                    MessageBox.Show(message, title + " ERROR");
                }

            }

            for (int i = 0; i <= QR_DATA_NEW.Count - 1; i++)
            {
                string[] target_line = QR_DATA_NEW[i];

                for (int i2 = 0; i2 <= QR_DATA_NEW.Count - 1; i2++)
                {
                    string[] target_line2 = QR_DATA_NEW[i2];

                    if (String.Equals(target_line[1], target_line2[1], StringComparison.OrdinalIgnoreCase) == true &&
                        String.Equals(target_line[3], target_line2[3], StringComparison.OrdinalIgnoreCase) == true)
                    {

                        if (target_line[0] == "Arrival-Morning" && target_line2[0] == "Departure-Morning") { add_line(); }
                        if (target_line[0] == "Arrival-Afternoon" && target_line2[0] == "Departure-Afternoon") { add_line(); };

                        void add_line()
                        {
                            string content_date_string = target_line[3];
                            string[] date_content_array = content_date_string.Split('/');

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
                                    if (qr_code == "All")
                                    {
                                        
                                        string[] time_data = Generate_Time_Data(target_line[2], target_line2[2]);
                                        string final_line = "\"" + target_line[1] + "\",\"" + target_line[3] + "\",\"" + time_data[0] + "\",\"" + target_line2[3] + "\",\"" + time_data[1] + "\",\"" + time_data[2] + "\"";
                                        if (final_result.Contains(final_line) == false)
                                        {
                                            final_result.Add(final_line); 
                                        }
                                    }
                                    else if (String.Equals(qr_code, target_line[1], StringComparison.OrdinalIgnoreCase) == true && String.Equals(qr_code, target_line2[1], StringComparison.OrdinalIgnoreCase) == true)
                                    {
                                        string[] time_data = Generate_Time_Data(target_line[2], target_line2[2]);
                                        string final_line = "\"" + target_line[1] + "\",\"" + target_line[3] + "\",\"" + time_data[0] + "\",\"" + target_line2[3] + "\",\"" + time_data[1] + "\",\"" + time_data[2] + "\"";
                                        if (final_result.Contains(final_line) == false) { final_result.Add(final_line); }
                                    }
                                }
                            }

                            

                        }
                    };


                }


            }


            final_result.Sort();
            return final_result;
        }

        string Check_Time_Mode(string time)
        {

            DateTime dateTime;
            DateTime.TryParse(time, out dateTime);

            string time_format = dateTime.ToString("tt", System.Globalization.CultureInfo.InvariantCulture);
            string mode_result = "Unknown";

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

        string[] Generate_Time_Data(string start_time, string end_time)
        {
            //We need to put Sleep so that the RNG will really work
            //10 is the minimum. Below that it will not work anymore
            System.Threading.Thread.Sleep(10);

            string[] time_data = { "", "", "" };

            if (LIST_OF_SECONDS.Count >= 56)
            {
                LIST_OF_SECONDS = new List<int>();
            }

            Random rnd = new Random();
            int starting_seconds;
            int end_seconds;

            do
            {
                starting_seconds = rnd.Next(55);
                LIST_OF_SECONDS.Add(starting_seconds);
                break;

            } while (LIST_OF_SECONDS.IndexOf(starting_seconds) <= -1);

            do
            {
                end_seconds = rnd.Next(55);
                LIST_OF_SECONDS.Add(end_seconds);
                break;

            } while (LIST_OF_SECONDS.IndexOf(end_seconds) <= -1);

            string temp_starting_seconds = "" + starting_seconds;
            string temp_end_seconds = "" + end_seconds;
                
            if (starting_seconds < 10) { temp_starting_seconds = "0" + starting_seconds; };
            if (end_seconds < 10) { temp_end_seconds = "0" + end_seconds; };


            string[] start_time_array = start_time.Split(' ');
            string[] end_time_array = end_time.Split(' ');

            string[] start_time_array2 = start_time_array[0].Split(':');
            string[] end_time_array2 = end_time_array[0].Split(':');

            string new_start_time = start_time;
            string new_end_time = end_time;

            if (start_time_array2.Length <= 2)
            {
                new_start_time = start_time_array[0] + ":" + temp_starting_seconds + " " + start_time_array[1];
            }
            

            if (end_time_array2.Length <= 2)
            {
                new_end_time = end_time_array[0] + ":" + temp_end_seconds + " " + end_time_array[1];
            }
            
            DateTime dateTime_start;
            DateTime.TryParse(new_start_time, out dateTime_start);

            DateTime dateTime_end;
            DateTime.TryParse(new_end_time, out dateTime_end);

            TimeSpan result = dateTime_end - dateTime_start;

            int hour_span = result.Hours;
            int minute_span = result.Minutes;
            int second_span = result.Seconds;

            time_data[0] = new_start_time;
            time_data[1] = new_end_time;
            time_data[2] = hour_span + " hrs " + minute_span + " min " + second_span + " seg";

            return time_data;
        }

        private void button_ExportAllData_onclick(object sender, EventArgs e)
        {
            MessageBox.Show("Your computer may suffer from LAG for a couple of seconds depends on the amount of Attendance you will export. Please wait for the SAVE AS window to show because it may be delayed depends on the amount of Attendance data."," LAG WARNING!");

            Read_QR_DATABASE();

            string data_format = comboBox_DataFormat.SelectedItem.ToString();

            if (data_format == "Default Format")
            {
                List<string> QR_EXPORT_DATA = QR_DATA_EXPORTER_DEFAULT(QR_DATA);

                try
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "(*.csv)|*.csv";
                    saveFileDialog.DefaultExt = "csv";
                    saveFileDialog.AddExtension = true;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (Stream new_file = File.Open(saveFileDialog.FileName, FileMode.CreateNew))
                        using (TextWriter tw = new StreamWriter(new_file))

                        {
                            string data_title = "\"" + "NAME" + "\",\"" + "ARRIVAL DATE" + "\",\"" + "ARRIVAL TIME" + "\",\"" + "DEPARTURE DATE" + "\",\"" + "DEPARTURE TIME" + "\",\"" + "TOTAL" + "\"";
                            tw.WriteLine(data_title);

                            for (int i = 0; i <= QR_EXPORT_DATA.Count - 1; i++)
                            {
                                string QR_DATA_csv_line = QR_EXPORT_DATA[i];
                                //MessageBox.Show(QR_DATA_csv_line);
                                tw.WriteLine(QR_DATA_csv_line);
                            }


                        }

                    }
                }
                catch (Exception exc)
                {
                    string message = exc.Message;
                    string title = "button_ExportAllData_onclick";
                    MessageBox.Show(message, title + " ERROR");
                }
            }
            else if (data_format == "Minimized Format")
            {
               
                //TO DO

            };

        }

    
    }
}

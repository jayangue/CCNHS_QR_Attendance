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
using System.Collections;

namespace CCNHS_QR_Attendance
{
    public partial class Form3 : Form
    {
        List<string> QR_DATA = new List<string>();

        string QR_DATA_DirectoryPath = @"c:\CCNHS_QR_Attendance_DATABASE";
        string QR_DATA_FilePath = @"c:\CCNHS_QR_Attendance_DATABASE\CCNHS_QR_Attendance_DATABASE.txt";

        string main_date;
        string main_qrcode;
        string main_time_arrival_morning;
        string main_time_departure_morning;
        string main_time_arrival_afternoon;
        string main_time_departure_afternoon;
        bool arrival_morning_activated;
        bool departure_morning_activated;
        bool arrival_afternoon_activated;
        bool departure_afternoon_activated;

        public Form3()
        {
            InitializeComponent();
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

        private void Form3_Load(object sender, EventArgs e)
        {
            string[] id_list = Get_QR_List();
            Array.Sort(id_list, (x, y) => String.Compare(x, y));
    

            for (var i= 0; i <= id_list.Length - 1;i++)
            {
                comboBox_QRCode.Items.Add(id_list[i]);
            }
            comboBox_QRCode.SelectedIndex = 0;

            dateTimePicker_MainDate.Format = DateTimePickerFormat.Custom;
            dateTimePicker_MainDate.CustomFormat = "MM/dd/yyyy";

            dateTimePicker_ArrivalMorning.Format = DateTimePickerFormat.Custom;
            dateTimePicker_ArrivalMorning.CustomFormat = "hh:mm tt";
            dateTimePicker_ArrivalAfternoon.Format = DateTimePickerFormat.Custom;
            dateTimePicker_ArrivalAfternoon.CustomFormat = "hh:mm tt";
            dateTimePicker_DepartureMorning.Format = DateTimePickerFormat.Custom;
            dateTimePicker_DepartureMorning.CustomFormat = "hh:mm tt";
            dateTimePicker_DepartureAfternoon.Format = DateTimePickerFormat.Custom;
            dateTimePicker_DepartureAfternoon.CustomFormat = "hh:mm tt";


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

        private void Prepare_Data()
        {
            Read_QR_DATABASE();

            arrival_morning_activated = false;
            departure_morning_activated = false;
            arrival_afternoon_activated = false;
            departure_afternoon_activated = false;

            main_date = dateTimePicker_MainDate.Value.ToString("MM/dd/yyyy");
            main_qrcode = comboBox_QRCode.SelectedItem.ToString();

            main_time_arrival_morning = dateTimePicker_ArrivalMorning.Value.ToShortTimeString();
            main_time_arrival_morning = convert_time_am(main_time_arrival_morning);
            main_time_departure_morning = dateTimePicker_DepartureMorning.Value.ToShortTimeString();
            main_time_departure_morning = convert_time_am(main_time_departure_morning);
            main_time_arrival_afternoon = dateTimePicker_ArrivalAfternoon.Value.ToShortTimeString();
            main_time_arrival_afternoon = convert_time_pm(main_time_arrival_afternoon);
            main_time_departure_afternoon = dateTimePicker_DepartureAfternoon.Value.ToShortTimeString();
            main_time_departure_afternoon = convert_time_pm(main_time_departure_afternoon);

            string convert_time_pm(string target_dateTime)
            {
                DateTime temp_dateTime; DateTime.TryParse(target_dateTime, out temp_dateTime);
                string time_format = temp_dateTime.ToString("tt", System.Globalization.CultureInfo.InvariantCulture);

                if (time_format == "PM")
                {
                    int temp_hour_int = 12;
                    if (temp_dateTime.Hour >= 13)
                    {
                        temp_hour_int = temp_dateTime.Hour - 12;
                    };

                    string temp_hour = temp_hour_int.ToString();
                    string temp_minute = temp_dateTime.Minute.ToString();
                    if (temp_hour_int < 10) { temp_hour = "0" + temp_hour_int; };
                    if (temp_dateTime.Minute < 10) { temp_minute = "0" + temp_minute; };

                    return temp_hour + ":" + temp_minute + " pm";
                }
                else
                {
                    return target_dateTime;
                };
            };

            string convert_time_am(string target_dateTime)
            {
                DateTime temp_dateTime; DateTime.TryParse(target_dateTime, out temp_dateTime);
                string time_format = temp_dateTime.ToString("tt", System.Globalization.CultureInfo.InvariantCulture);

                if (time_format == "AM")
                {
                    string temp_hour = temp_dateTime.Hour.ToString();
                    string temp_minute = temp_dateTime.Minute.ToString();
                    if (temp_dateTime.Hour < 10) { temp_hour = "0" + temp_hour; };
                    if (temp_dateTime.Minute < 10) { temp_minute = "0" + temp_minute; };

                    return temp_hour + ":" + temp_minute + " am";
                }
                else
                {
                    return target_dateTime;
                }
            };

            arrival_morning_activated = checkBox_ArrivalMorning.Checked;
            departure_morning_activated = checkBox_DepartureMorning.Checked;
            arrival_afternoon_activated = checkBox_ArrivalAfternoon.Checked;
            departure_afternoon_activated = checkBox_DepartureAfternoon.Checked;



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

        private void button_RandomizeTime_onclick(object sender, EventArgs e)
        {
            arrival_morning_activated = checkBox_ArrivalMorning.Checked;
            departure_morning_activated = checkBox_DepartureMorning.Checked;
            arrival_afternoon_activated = checkBox_ArrivalAfternoon.Checked;
            departure_afternoon_activated = checkBox_DepartureAfternoon.Checked;

            Random rnd = new Random();
            int minutes = 0;

            if (arrival_morning_activated == true)
            {
                TimeSpan morning_arrival = TimeSpan.FromHours(7);
                minutes = 40 + rnd.Next(35);
                TimeSpan t2 = morning_arrival.Add(TimeSpan.FromMinutes(minutes));
                DateTime dt = new DateTime(1800, 01, 01);
                dt = dt + t2;
                dateTimePicker_ArrivalMorning.Value = dt;
            }

            if (departure_morning_activated == true)
            {
                TimeSpan morning_departure = TimeSpan.FromHours(12);
                minutes = rnd.Next(15);
                TimeSpan t2 = morning_departure.Add(TimeSpan.FromMinutes(minutes));
                DateTime dt = new DateTime(1800, 01, 01);
                dt = dt + t2;
                dateTimePicker_DepartureMorning.Value = dt;
            }

            if (arrival_afternoon_activated == true)
            {
                TimeSpan afternoon_arrival = TimeSpan.FromHours(12);
                minutes = 45 + rnd.Next(15);
                TimeSpan t2 = afternoon_arrival.Add(TimeSpan.FromMinutes(minutes));
                DateTime dt = new DateTime(1800, 01, 01);
                dt = dt + t2;
                dateTimePicker_ArrivalAfternoon.Value = dt;
            }

            if (departure_afternoon_activated == true)
            {
                TimeSpan afternoon_departure = TimeSpan.FromHours(17);
                minutes = rnd.Next(40);
                TimeSpan t2 = afternoon_departure.Add(TimeSpan.FromMinutes(minutes));
                DateTime dt = new DateTime(1800, 01, 01);
                dt = dt + t2;
                dateTimePicker_DepartureAfternoon.Value = dt;
            }


        }

        private void button_EditAttendance_onclick(object sender, EventArgs e)
        {

            Prepare_Data();

            if (arrival_morning_activated == true)
            {
                DateTime dateTime; DateTime.TryParse(main_time_arrival_morning, out dateTime);
                if (dateTime.Hour <= 10)
                {
                    if (check_attendance(main_date, main_qrcode,"Arrival", "Arrival-Morning",main_time_arrival_morning) == true)
                    {
                       //Do nothing
                    }
                    else
                    {
                        string message = "The following date " + main_date + " of " + main_qrcode + " doesn't have a Morning Arrival time!. Please use Add Attendance instead.";
                        string title = "ATTENTION";
                        MessageBox.Show(message, title);
                    }
                }
                else
                {
                    string message = "Arrival Morning time must be less than 10 am";
                    string title = "ATTENTION";
                    MessageBox.Show(message, title);
                };

               
            };

            if (departure_morning_activated == true)
            {
                DateTime dateTime; DateTime.TryParse(main_time_departure_morning, out dateTime);
                if (dateTime.Hour >= 11 && dateTime.Hour <= 12)
                {
                    if (check_attendance(main_date, main_qrcode, "Departure", "Departure-Morning", main_time_departure_morning) == true)
                    {
                        //Do nothing
                    }
                    else
                    {
                        string message = "The following date " + main_date + " of " + main_qrcode + " doesn't have a Morning Departure time!. Please use Add Attendance instead.";
                        string title = "ATTENTION";
                        MessageBox.Show(message, title);
                    }
                }
                else
                {
                    string message = "Departure Morning time must be between 11 am and 12 pm";
                    string title = "ATTENTION";
                    MessageBox.Show(message, title);
                };

                
            }

            if (arrival_afternoon_activated == true)
            {
                DateTime dateTime; DateTime.TryParse(main_time_arrival_afternoon, out dateTime);
                if (dateTime.Hour >= 12 && dateTime.Hour <= 15)
                {
                    if (check_attendance(main_date, main_qrcode, "Arrival", "Arrival-Afternoon", main_time_arrival_afternoon) == true)
                    {
                        //Do nothing
                    }
                    else
                    {
                        string message = "The following date " + main_date + " of " + main_qrcode + " doesn't have a Afternoon Arrival time!. Please use Add Attendance instead.";
                        string title = "ATTENTION";
                        MessageBox.Show(message, title);
                    }
                }
                else
                {
                    string message = "Arrival Afternoon time must be between 12 pm and 3 pm ";
                    string title = "ATTENTION";
                    MessageBox.Show(message, title);
                };

                
            }

            if (departure_afternoon_activated == true)
            {
                DateTime dateTime; DateTime.TryParse(main_time_departure_afternoon, out dateTime);
                if (dateTime.Hour >= 16 && dateTime.Hour <= 20)
                {
                    if (check_attendance(main_date, main_qrcode, "Departure", "Departure-Afternoon", main_time_departure_afternoon) == true)
                    {
                        //Do nothing
                    }
                    else
                    {
                        string message = "The following date " + main_date + " of " + main_qrcode + " doesn't have a Afternoon Departure time!. Please use Add Attendance instead.";
                        string title = "ATTENTION";
                        MessageBox.Show(message, title);
                    }
                }
                else
                {
                    string message = "Departure Afternoon time must be between 4 pm and 8 pm ";
                    string title = "ATTENTION";
                    MessageBox.Show(message, title);
                };

                
            }

            bool check_attendance(string target_date,string target_qrcode,string target_mode, string target_time_mode,string target_time)
            {
                for (int i = 0; i <= QR_DATA.Count - 1; i++)
                {
                    try
                    {
                        string[] QR_DATA_result = QR_DATA[i].Split(new string[] { "##" }, StringSplitOptions.None);
                        string[] QR_DATA_mode_array = QR_DATA_result[0].Split(new string[] { ">>>" }, StringSplitOptions.None);
                        string time_mode = Check_Time_Mode(QR_DATA_result[2]);

                        bool DateareSame = String.Equals(target_date, QR_DATA_result[3], StringComparison.OrdinalIgnoreCase);
                        bool IDareSame = String.Equals(target_qrcode, QR_DATA_result[1], StringComparison.OrdinalIgnoreCase);
                        bool ModeareSame = String.Equals(target_time_mode, time_mode, StringComparison.OrdinalIgnoreCase);

                        if (DateareSame == true && IDareSame == true && ModeareSame == true)
                        {

                            DialogResult dialogResult = MessageBox.Show(" The time " + QR_DATA_result[2] + " of " + QR_DATA_result[1] + " with a date of " + QR_DATA_result[3] + " will be edited to " + target_time, "Do you really want to edit the following?", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                 QR_DATA[i] = target_mode + "##" + QR_DATA_result[1] + "##" + target_time + "##" + QR_DATA_result[3];
                            }

                            return true;
                        }

                    }
                    catch (Exception exc)
                    {
                        string message = exc.Message;
                        string title = "button_EditAttendance_onclick";
                        MessageBox.Show(message + " >> " + QR_DATA[i], title + " ERROR");
                    }

                }

                return false;

            }

            Write_QR_DATABASE();


        }

        private void button_AddAttendance_onclick(object sender, EventArgs e)
        {
            Prepare_Data();

            if (arrival_morning_activated == true)
            {
                DateTime dateTime; DateTime.TryParse(main_time_arrival_morning, out dateTime);
                if (dateTime.Hour <= 10)
                {
                    if (check_attendance(main_date, main_qrcode, "Arrival", "Arrival-Morning", main_time_arrival_morning) == false)
                    {
                        DialogResult dialogResult = MessageBox.Show(" Morning Arrival of " + main_qrcode + " with the time of " + main_time_departure_morning + " and with a date of " + main_date + " will be added.", "Do you really want to add the following?", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            string new_data = "Arrival" + "##" + main_qrcode + "##" + main_time_arrival_morning + "##" + main_date;
                            QR_DATA.Add(new_data);
                        }
                    }
                    else
                    {
                        string message = "The following date " + main_date + " of " + main_qrcode + " already contains a Morning Arrival Time. Please use EDIT ATTENDANCE instead!";
                        string title = "ATTENTION";
                        MessageBox.Show(message, title);
                    }
                }
                else
                {
                    string message = "Arrival Morning time must be less than 10 am";
                    string title = "ATTENTION";
                    MessageBox.Show(message, title);
                };


            };

            if (departure_morning_activated == true)
            {
                DateTime dateTime; DateTime.TryParse(main_time_departure_morning, out dateTime);
                if (dateTime.Hour >= 11 && dateTime.Hour <= 12)
                {
                    if (check_attendance(main_date, main_qrcode, "Departure", "Departure-Morning", main_time_departure_morning) == false)
                    {
                        DialogResult dialogResult = MessageBox.Show(" Morning Departure of " + main_qrcode + " with the time of " + main_time_departure_morning + " and with a date of " + main_date + " will be added.", "Do you really want to add the following?", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            string new_data = "Departure" + "##" + main_qrcode + "##" + main_time_departure_morning + "##" + main_date;
                            QR_DATA.Add(new_data);
                        }
                    }
                    else
                    {
                        string message = "The following date " + main_date + " of " + main_qrcode + " already contains a Morning Departure Time. Please use EDIT ATTENDANCE instead!";
                        string title = "ATTENTION";
                        MessageBox.Show(message, title);
                    }
                }
                else
                {
                    string message = "Departure Morning time must be between 11 am and 12 pm";
                    string title = "ATTENTION";
                    MessageBox.Show(message, title);
                };


            }

            if (arrival_afternoon_activated == true)
            {
                DateTime dateTime; DateTime.TryParse(main_time_arrival_afternoon, out dateTime);
                if (dateTime.Hour >= 12 && dateTime.Hour <= 15)
                {
                    if (check_attendance(main_date, main_qrcode, "Arrival", "Arrival-Afternoon", main_time_arrival_afternoon) == false)
                    {
                        DialogResult dialogResult = MessageBox.Show(" Afternoon Arrival of " + main_qrcode + " with the time of " + main_time_arrival_afternoon + " and with a date of " + main_date + " will be added.", "Do you really want to add the following?", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            string new_data = "Arrival" + "##" + main_qrcode + "##" + main_time_arrival_afternoon + "##" + main_date;
                            QR_DATA.Add(new_data);
                        }
                    }
                    else
                    {
                        string message = "The following date " + main_date + " of " + main_qrcode + " already contains a Afternoon Arrival Time. Please use EDIT ATTENDANCE instead!";
                        string title = "ATTENTION";
                        MessageBox.Show(message, title);
                    }
                }
                else
                {
                    string message = "Arrival Afternoon time must be between 12 pm and 3 pm ";
                    string title = "ATTENTION";
                    MessageBox.Show(message, title);
                };


            }

            if (departure_afternoon_activated == true)
            {
                DateTime dateTime; DateTime.TryParse(main_time_departure_afternoon, out dateTime);
                if (dateTime.Hour >= 16 && dateTime.Hour <= 20)
                {
                    if (check_attendance(main_date, main_qrcode, "Departure", "Departure-Afternoon", main_time_departure_afternoon) == false)
                    {
                        DialogResult dialogResult = MessageBox.Show(" Afternoon Departure of " + main_qrcode + " with the time of " + main_time_departure_afternoon + " and with a date of " + main_date + " will be added.", "Do you really want to add the following?", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            string new_data = "Departure" + "##" + main_qrcode + "##" + main_time_departure_afternoon + "##" + main_date;
                            QR_DATA.Add(new_data);
                        }
                    }
                    else
                    {
                        string message = "The following date " + main_date + " of " + main_qrcode + " already contains a Afternoon Departure Time. Please use EDIT ATTENDANCE instead!";
                        string title = "ATTENTION";
                        MessageBox.Show(message, title);
                    }
                }
                else
                {
                    string message = "Departure Afternoon time must be between 4 pm and 8 pm ";
                    string title = "ATTENTION";
                    MessageBox.Show(message, title);
                };


            }

            bool check_attendance(string target_date, string target_qrcode, string target_mode, string target_time_mode, string target_time)
            {
                for (int i = 0; i <= QR_DATA.Count - 1; i++)
                {
                    try
                    {
                        string[] QR_DATA_result = QR_DATA[i].Split(new string[] { "##" }, StringSplitOptions.None);
                        string[] QR_DATA_mode_array = QR_DATA_result[0].Split(new string[] { ">>>" }, StringSplitOptions.None);
                        string time_mode = Check_Time_Mode(QR_DATA_result[2]);

                        bool DateareSame = String.Equals(target_date, QR_DATA_result[3], StringComparison.OrdinalIgnoreCase);
                        bool IDareSame = String.Equals(target_qrcode, QR_DATA_result[1], StringComparison.OrdinalIgnoreCase);
                        bool ModeareSame = String.Equals(target_time_mode, time_mode, StringComparison.OrdinalIgnoreCase);

                        if (DateareSame == true && IDareSame == true && ModeareSame == true)
                        {
                            return true;
                        }

                    }
                    catch (Exception exc)
                    {
                        string message = exc.Message;
                        string title = "button_EditAttendance_onclick";
                        MessageBox.Show(message + " >> " + QR_DATA[i], title + " ERROR");
                    }

                }

                return false;

            }

            Write_QR_DATABASE();


        }

      
    }

    
}

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
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;

namespace CCNHS_QR_Attendance
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice captureDevice;

        string QR_DATA_DirectoryPath = @"c:\CCNHS_QR_Attendance_DATABASE";
        string QR_DATA_FilePath = @"c:\CCNHS_QR_Attendance_DATABASE\CCNHS_QR_Attendance_DATABASE.txt";

        int dataGridView_main_last_index = 0;

        string current_attendance_data_mode = "Arrival";
        string current_attendance_data_content = "";
        string current_attendance_data_date = "";
        string current_attendance_data_time = "";

        List<string> QR_DATA = new List<string>();
        List<string> QR_CORRECT_DATA = new List<string>();

        Form2 form2 = new Form2();
        Form4 form4 = new Form4();

        private object _locker = new object();

        /*======================================================================================================*/

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
                    string title = "Write_QR_Database";
                    MessageBox.Show(message, title + " ERROR");
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
                    string title = "Write_QR_Database";
                    MessageBox.Show(message, title + " ERROR");
                }


            }


        }//end of write qr database

/*======================================================================================================*/

        private void Update_DataGridView()
        {
            int data_view_mode = comboBox_ShowData.SelectedIndex;
            QR_CORRECT_DATA.Clear();
           
            switch (data_view_mode)
            {
                case 0:

                    for (int i = 0; i <= QR_DATA.Count - 1; i++)
                    {
                        try
                        {
                            string QR_DATA_line = i + ">>>" + QR_DATA[i];
                            string[] QR_DATA_result = QR_DATA_line.Split(new string[] { "##" }, StringSplitOptions.None);
                            bool areSame = String.Equals(DateTime.Now.ToString("MM/dd/yyyy"), QR_DATA_result[3], StringComparison.OrdinalIgnoreCase);
                            if (areSame == true)
                            {
                                QR_CORRECT_DATA.Add(QR_DATA_line);
                            }
                        }
                        catch (Exception e)
                        {
                            string message = e.Message;
                            string title = "Update_DataGridView";
                            MessageBox.Show(message, title + " ERROR");
                        }

                    }

                break;
                case 1:

                    for (int i = 0; i <= QR_DATA.Count - 1; i++)
                    {
                        string QR_DATA_line = i + ">>>" + QR_DATA[i];
                        QR_CORRECT_DATA.Add(QR_DATA_line);

                    }

              break;
            }

            dataGridView_main.DataSource = null;
            dataGridView_main.Columns.Clear();
            dataGridView_main.Rows.Clear();

            DataTable dt = new DataTable();

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            dataGridView_main.Columns.Add(btn);
            btn.HeaderText = "";
            btn.Text = "DELETE";
            btn.UseColumnTextForButtonValue = true;

            dt.Columns.Add(new DataColumn("Mode", typeof(string)));
            dt.Columns.Add(new DataColumn("Data", typeof(string)));
            dt.Columns.Add(new DataColumn("Time", typeof(string)));
            dt.Columns.Add(new DataColumn("Date", typeof(string)));

            for (int i = 0; i <= QR_CORRECT_DATA.Count - 1; i++)
            {
                string correct_data_line = QR_CORRECT_DATA[i];
                Console.WriteLine(correct_data_line);
                string[] raw_data_line = correct_data_line.Split(new string[] { ">>>" }, StringSplitOptions.None);
                string edited_correct_data_line = raw_data_line[1];
                string[] correct_data_result = edited_correct_data_line.Split(new string[] { "##" }, StringSplitOptions.None);
                dt.Rows.Add(correct_data_result[0],correct_data_result[1],correct_data_result[2],correct_data_result[3]);

            }

            dataGridView_main.DataSource = dt;
            dataGridView_main.AutoResizeColumns();
            dataGridView_main.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            DataGridViewColumn column = dataGridView_main.Columns[1];
            column.Width = 10;

            dataGridView_main_last_index = dt.Rows.Count;





        }//end of update datagrid
        private void dataGridView_main_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != dataGridView_main_last_index)
            {
                var main_mode = dataGridView_main.Rows[e.RowIndex].Cells[1].Value.ToString();
                var main_qr_code = dataGridView_main.Rows[e.RowIndex].Cells[2].Value.ToString();
                var main_time = dataGridView_main.Rows[e.RowIndex].Cells[3].Value.ToString();
                var main_date = dataGridView_main.Rows[e.RowIndex].Cells[4].Value.ToString();

                check_attendance(main_date, main_qr_code, main_mode, main_time);

                void check_attendance(string target_date, string target_qrcode, string target_mode, string target_time)
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


        /*======================================================================================================*/
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                comboBox_ShowData.Items.Add("Attendance For Today");
                comboBox_ShowData.Items.Add("All Attendance");
                comboBox_ShowData.SelectedIndex = 0;

                //Load all current available cameras
                filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                foreach (FilterInfo filterInfo in filterInfoCollection)
                    comboBox_DeviceList.Items.Add(filterInfo.Name);
                comboBox_DeviceList.SelectedIndex = 0;

                timer_Main.Stop();
                if (captureDevice.IsRunning)
                    captureDevice.Stop();

                //Load saved QR Data from a file
                Read_QR_DATABASE();
                Update_DataGridView();
            }
            catch (Exception exc)
            {
                string message = exc.Message;
                string title = "Form1_Load";
                MessageBox.Show(message, title + " ERROR");
            }

        }//end of Form1_Load

        private void Form1_onclose(object sender, FormClosedEventArgs e)
        {
            try
            {
                timer_Main.Stop();
                if(captureDevice != null)
                {
                    if (captureDevice.IsRunning)
                        captureDevice.Stop();
                }
                
            }
            catch (Exception err)
            {
                string message = err.Message;
                string title = "Form1_onclose";
                MessageBox.Show(message, title + " ERROR");
            }
        }
/*======================================================================================================*/
        private void button_StartScan_onclick(object sender, EventArgs e)
        {
            try
            {
                timer_Main.Stop();
                if (captureDevice.IsRunning)
                    captureDevice.Stop();

                captureDevice = new VideoCaptureDevice(filterInfoCollection[comboBox_DeviceList.SelectedIndex].MonikerString);
                captureDevice.NewFrame += CaptureDevice_NewFrame;
                captureDevice.Start();
                timer_Main.Start();
                pictureBox_Main.Image = null;
                textBox_QRData.Text = null;
            }
            catch (Exception exc)
            {
                string message = exc.Message;
                string title = "button_StartScan_onclick";
                MessageBox.Show(message, title + " ERROR");
            }

        }

        private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                 lock (_locker) { pictureBox_Main.Image = (Bitmap)eventArgs.Frame.Clone(); };
            }
            catch (Exception exc)
            {
                string message = exc.Message;
                string title = "CaptureDevice_NewFrame";
                MessageBox.Show(message, title + " ERROR");
            }
        }

        private void timer_Main_ontick(object sender, EventArgs e)
        {
            try
            {
                if (pictureBox_Main.Image != null)
                {
                    BarcodeReader barcodeReader = new BarcodeReader();
                    Result result;
                    lock (_locker) { result = barcodeReader.Decode((Bitmap)pictureBox_Main.Image); };
                    if (result != null)
                    {

                        current_attendance_data_date = DateTime.Now.ToString("MM/dd/yyyy");
                        current_attendance_data_time = DateTime.Now.ToString("hh:mm tt");
                        current_attendance_data_content = result.ToString();

                        string[] current_attendance_data = new string[4];
                        current_attendance_data[0] = current_attendance_data_mode;
                        current_attendance_data[1] = current_attendance_data_content;
                        current_attendance_data[2] = current_attendance_data_time;
                        current_attendance_data[3] = current_attendance_data_date;
                        string combined_attendance_data = string.Join("##", current_attendance_data);
                        

                        if (current_attendance_data_mode == "Arrival")
                        {
                            if (Check_Time_Mode(current_attendance_data_time) == "Arrival-Morning" || Check_Time_Mode(current_attendance_data_time) == "Arrival-Afternoon")
                            {
                                Update_Attendance();
                            }
                            else
                            {
                                timer_Main.Stop();
                                if (captureDevice.IsRunning)
                                    captureDevice.Stop();
                                MessageBox.Show("The time " + current_attendance_data_time + " does not suit for Arrival in either Morning and Afternoon. Changed it to Departure instead and Press START SCAN again.","ATTENTION");
                            }

                        }else if (current_attendance_data_mode == "Departure")
                        {
                            if (Check_Time_Mode(current_attendance_data_time) == "Departure-Morning" || Check_Time_Mode(current_attendance_data_time) == "Departure-Afternoon")
                            {
                                Update_Attendance();
                            }
                            else
                            {
                                timer_Main.Stop();
                                if (captureDevice.IsRunning)
                                    captureDevice.Stop();
                                MessageBox.Show("The time " + current_attendance_data_time + " does not suit for Departure in either Morning and Afternoon. Changed it to Arrival instead and Press START SCAN again.", "ATTENTION");
                            }
                        }

                        void Update_Attendance()
                        {
                            QR_DATA.Add(combined_attendance_data);
                            Write_QR_DATABASE();
                            Update_DataGridView();

                            textBox_QRData.Text = "MODE:" + current_attendance_data_mode + " | CONTENT:  " + current_attendance_data_content + " | TIME: " + current_attendance_data_time + " | DATE: " + current_attendance_data_date;
                            timer_Main.Stop();
                            if (captureDevice.IsRunning )
                                captureDevice.Stop();
                        }
                        

                       
                    }
                }
            }
            catch (Exception exc)
            {
                string message = exc.Message;
                string title = "timer_Main_ontick";
                MessageBox.Show(message, title + " ERROR");
            }
        }

/*======================================================================================================*/
        private void checkBox_Arrival_onclick(object sender, EventArgs e)
        {
           
            if (checkBox_Arrival.Checked == true)
            {
                current_attendance_data_mode = "Arrival";
                checkBox_Departure.Checked = false;
            }
            else
            {
                current_attendance_data_mode = "Departure";
                checkBox_Departure.Checked = true;
            }
        }

        private void checkBox_Departure_onclick(object sender, EventArgs e)
        {
            if (checkBox_Departure.Checked == true)
            {
                current_attendance_data_mode = "Departure";
                checkBox_Arrival.Checked = false;
            }
            else
            {
                current_attendance_data_mode = "Arrival";
                checkBox_Arrival.Checked = true;
            }
        }

/*======================================================================================================*/



/*======================================================================================================*/
        private void comboBox_ShowData_SelectedIndexChanged(object sender, EventArgs e)
        {
            Update_DataGridView();
        }
 /*======================================================================================================*/
        private void button_ExportAllData_onclick(object sender, EventArgs e)
        {
            
            try
            {
                form4.Show();

            }
            catch (Exception exc)
            {

                form4 = new Form4();
                form4.Show();
            }
            

        }

        private void button_DeleteAll_onclick(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("You are about to delete all the attendance data. Are you sure you want to do this?", "WARNING", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                QR_DATA.Clear();
                Write_QR_DATABASE();
                Update_DataGridView();
            };

          
        }

        private void comboBox_DeviceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                timer_Main.Stop();
                if (captureDevice != null)
                {
                    if (captureDevice.IsRunning)
                        captureDevice.Stop();
                }


                captureDevice = new VideoCaptureDevice(filterInfoCollection[comboBox_DeviceList.SelectedIndex].MonikerString);
                captureDevice.NewFrame += CaptureDevice_NewFrame;
                captureDevice.Start();
                timer_Main.Start();
                pictureBox_Main.Image = null;
                textBox_QRData.Text = null;
            }
            catch (Exception exc)
            {
                string message = exc.Message;
                string title = "comboBox_DeviceList_SelectedIndexChanged";
                MessageBox.Show(message, title + " ERROR");
            }

        }

        private void button_AdvanceSearch_onclick(object sender, EventArgs e)
        {
            try
            {
                form2.Show();

            }
            catch (Exception exc)
            {

                form2 = new Form2();
                form2.Show();
            }
        }

        /*======================================================================================================*/
   
        static string Check_Time_Mode(string time)
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


    }//end of class Form1
}//end of namespace

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tobii.Research;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace GazeTracking
{
    public partial class Form1 : Form
    {
        private IEyeTracker eyeTracker;
        private TobiiUtility tobiiUtility;

        public string TobiiData;
        private Timer timer1;

        public Form1()
        {
            tobiiUtility = new TobiiUtility();
            InitializeComponent();
        }

        private void findEyeTracker_button_Click(object sender, EventArgs e)
        {
            Task<IEyeTracker> task = new Task<IEyeTracker>(tobiiUtility.FindEyeTracker);
            task.Start();

            eyeTracker = task.Result;

            if (eyeTracker == null)
            {
                info_textBox.Text = "Could not find eye tracker";
            }
            else
            {
                info_textBox.Text = string.Format("Found eye tracker: {0}", eyeTracker.DeviceName);
            }
        }

        private void calibrate_button_Click(object sender, EventArgs e)
        {
            CalibrateAsync();
        }

        private async void CalibrateAsync()
        {
            if (eyeTracker == null)
            {
                info_textBox.Text = "No eye trackers connected, could not calibrate";
            }
            else
            {
                Form2 form2 = new Form2();
                form2.Show();

                tobiiUtility.CalibrateEyeTracker();

                Task<string> task = new Task<string>(tobiiUtility.CalibrateEyeTracker);
                task.Start();

                form2.MoveCalibrationPoint((int)(form2.Width * 0.5f), (int)(form2.Height * 0.5f));
                await Task.Delay(700);
                form2.MoveCalibrationPoint((int)(form2.Width * 0.9f), (int)(form2.Height * 0.1f));
                await Task.Delay(700);
                form2.MoveCalibrationPoint((int)(form2.Width * 0.1f), (int)(form2.Height * 0.1f));
                await Task.Delay(700);
                form2.MoveCalibrationPoint((int)(form2.Width * 0.1f), (int)(form2.Height * 0.9f));
                await Task.Delay(700);
                form2.MoveCalibrationPoint((int)(form2.Width * 0.9f), (int)(form2.Height * 0.9f));
                await Task.Delay(700);

                string result = task.Result;
                info_textBox.Text = result;

                form2.Dispose();
            }
        }

        private void collectData_button_Click(object sender, EventArgs e)
        {
            if (eyeTracker == null)
            {
                info_textBox.Text = "No eye trackers connected, could not get data";
            }
            else
            {
                tobiiUtility.GazeData(eyeTracker);
                InitTimer();
            }
        }

        public void InitTimer()
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000; 
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SendHTTP();
            tobiiUtility.InitDataGather();
        }

        private void SendHTTP()
        {
            string data = tobiiUtility.GetData();

            DataJson dataJson = new DataJson();
            dataJson.user_id = "User1";
            dataJson.datetime = DateTime.Now.ToString();
            dataJson.data = data;

            string json = JsonConvert.SerializeObject(data);

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://riski.business/eyetrack");
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }
    }

    [Serializable]
    public class DataJson
    {
        public string user_id;
        public string datetime;
        public string data;
    }
}

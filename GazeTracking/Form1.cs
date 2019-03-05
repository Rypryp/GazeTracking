using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tobii.Research;
using Newtonsoft.Json;
using System.Net;

namespace GazeTracking
{
    public partial class Form1 : Form
    {
        private IEyeTracker eyeTracker;
        private TobiiUtility tobiiUtility;

        public Form1()
        {
            tobiiUtility = new TobiiUtility();

            InitializeComponent();
        }

        private void findEyeTracker_button_Click(object sender, EventArgs e)
        {
            eyeTracker = tobiiUtility.FindEyeTracker();

            if(eyeTracker == null)
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
            if (eyeTracker == null)
            {
                info_textBox.Text = "No eye trackers connected, could not calibrate";
            }
            else
            {
                tobiiUtility.CalibrateEyeTracker(eyeTracker, info_textBox);
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
                tobiiUtility.GazeData(eyeTracker, info_textBox);
            }
        }

        private void button1_ClickAsync(object sender, EventArgs e)
        {
            SendHTTP();
        }

        private async void SendHTTP()
        {

            DataJson data = new DataJson();
            data.user_id = "User1";
            data.datetime = DateTime.Now.ToString();
            data.data = "12,45,0.1,0.1";

            string json = JsonConvert.SerializeObject(data);
        
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://riski.business/eyetrack");
            //httpWebRequest.ContentType = "gazedata";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
            }

            info_textBox.Text = "Sended " + json;
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

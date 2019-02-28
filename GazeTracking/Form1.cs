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

        private void Form1_Load(object sender, EventArgs e)
        {

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
                tobiiUtility.CalibrateEyeTracker(eyeTracker);
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
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GazeTracking
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
        }

        public void MoveCalibrationPoint(int x, int y)
        {
            calibrationPoint.Location = new Point(x, y);
        }
    }
}

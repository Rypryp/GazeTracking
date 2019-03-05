using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tobii.Research;
using System.IO;
using System.Windows.Forms;

namespace GazeTracking
{
    class TobiiUtility
    {
        private TextBox infoTextBox;
        
        public IEyeTracker FindEyeTracker()
        {
            Console.WriteLine("Searching for eye tracker...");
            EyeTrackerCollection eyeTrackers = EyeTrackingOperations.FindAllEyeTrackers();

            if (eyeTrackers.Count == 0)
            {
                Console.WriteLine("Could not find any eye trackers");
                return null;
            }
            else
            {
                Console.WriteLine("Found eye tracker: {0}, {1}, {2}, {3}, {4}, {5}", eyeTrackers[0].Address, eyeTrackers[0].DeviceName, eyeTrackers[0].Model, eyeTrackers[0].SerialNumber, eyeTrackers[0].FirmwareVersion, eyeTrackers[0].RuntimeVersion);
                return eyeTrackers[0];
            }
        }

        public void CalibrateEyeTracker(IEyeTracker eyeTracker, TextBox infoTextBox)
        {
            var calibration = new ScreenBasedCalibration(eyeTracker);

            calibration.EnterCalibrationMode();

            var pointsToCalibrate = new NormalizedPoint2D[] {
                new NormalizedPoint2D(0.5f, 0.5f),
                new NormalizedPoint2D(0.5f, 0.5f),
                new NormalizedPoint2D(0.5f, 0.5f),
                new NormalizedPoint2D(0.5f, 0.5f),
                new NormalizedPoint2D(0.5f, 0.5f),
            };

            foreach (var point in pointsToCalibrate)
            {
                infoTextBox.Text = string.Format("Show point on screen at ({0}, {1})", point.X, point.Y);
                System.Threading.Thread.Sleep(700);

                CalibrationStatus status = calibration.CollectData(point);

                if (status != CalibrationStatus.Success)
                {
                    calibration.CollectData(point);
                }
            }

            CalibrationResult calibrationResult = calibration.ComputeAndApply();
            infoTextBox.Text = string.Format("Compute and apply returned {0} and collected at {1} points.", calibrationResult.Status, calibrationResult.CalibrationPoints.Count);       

            calibration.LeaveCalibrationMode();
        }

        public void GazeData(IEyeTracker eyeTracker, TextBox infoTextBox)
        {
            this.infoTextBox = infoTextBox;

            eyeTracker.GazeDataReceived += GazeDataReceived;

        }

        public void GazeDataReceived(object sender, GazeDataEventArgs e)
        {
            string data = string.Format("Got gaze data with {0} left eye origin at point ({1}, {2}, {3}) in the user coordinate system.",
                e.LeftEye.GazeOrigin.Validity,
                e.LeftEye.GazeOrigin.PositionInUserCoordinates.X,
                e.LeftEye.GazeOrigin.PositionInUserCoordinates.Y,
                e.LeftEye.GazeOrigin.PositionInUserCoordinates.Z);

            infoTextBox.Text = data;
            Console.WriteLine(data);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tobii.Research;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;

namespace GazeTracking
{
    class TobiiUtility
    {
        public IEyeTracker currentEyeTracker;
        public int sleepTime = 700;

        private double EyeMovement;
        private List<float> LeftPupil;
        private List<float> RightPupil;
        
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

                currentEyeTracker = eyeTrackers[0];
                return currentEyeTracker;
            }
        }

        public string CalibrateEyeTracker()
        {
             var calibration = new ScreenBasedCalibration(currentEyeTracker);
             calibration.EnterCalibrationMode();

            var pointsToCalibrate = new NormalizedPoint2D[] {
                new NormalizedPoint2D(0.9f, 0.9f),
                new NormalizedPoint2D(0.9f, 0.1f),
                new NormalizedPoint2D(0.1f, 0.1f),
                new NormalizedPoint2D(0.1f, 0.9f),
                new NormalizedPoint2D(0.5f, 0.5f),
            };

            foreach (var point in pointsToCalibrate)
            {                
                Thread.Sleep(sleepTime);

                 CalibrationStatus status = calibration.CollectData(point);

                if (status != CalibrationStatus.Success)
                 {
                     calibration.CollectData(point);
                 }
            }

            CalibrationResult calibrationResult = calibration.ComputeAndApply();
            calibration.LeaveCalibrationMode();
            return string.Format("Compute and apply returned {0} and collected at {1} points.", calibrationResult.Status, calibrationResult.CalibrationPoints.Count);
        }
        
        public void GazeData(IEyeTracker eyeTracker)
        {
            eyeTracker.GazeDataReceived += GazeDataReceived;
        }

        public void GazeDataReceived(object sender, GazeDataEventArgs e)
        {
            EyeMovement =+ CalculateMovement(e.LeftEye.GazeOrigin.PositionInUserCoordinates.X, e.LeftEye.GazeOrigin.PositionInUserCoordinates.Y);

            RightPupil.Add(e.RightEye.Pupil.PupilDiameter);
            LeftPupil.Add(e.LeftEye.Pupil.PupilDiameter);
        }

        private double CalculateMovement(double x, double y)
        {
            double hypo = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            return hypo;
        }

        public void InitDataGather()
        {
            EyeMovement = 0;
            LeftPupil.Clear();
            RightPupil.Clear();
        }

        public string GetData()
        {
            float leftPupilMedian = 0;
            foreach(float p in LeftPupil)
            {
                leftPupilMedian = + p;
            }
            leftPupilMedian = leftPupilMedian / LeftPupil.Count;

            float rightPupilMedian = 0;
            foreach (float p in RightPupil)
            {
                rightPupilMedian = +p;
            }
            rightPupilMedian = rightPupilMedian / RightPupil.Count;

            string data = EyeMovement + ":" + leftPupilMedian + ":" + rightPupilMedian;
            return data;
        }
    }
}

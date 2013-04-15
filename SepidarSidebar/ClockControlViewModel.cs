using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;

namespace SG.SepidarSidebar
{
    public class ClockControlViewModel : ViewModelBase
    {
        #region Fields

        private double _hourDegree, _minuteDegree, _secondDegree;
        private DispatcherTimer _clockTimer;
        private DateTime _lastTime;
        private bool _showSecondHandle = true;

        #endregion

        public ClockControlViewModel()
        {
            _lastTime = DateTime.Now;
            RefreshTime(_lastTime);
            _clockTimer = new DispatcherTimer(DispatcherPriority.DataBind);
            _clockTimer.Tick +=_clockTimer_Tick;
            _clockTimer.Interval = TimeSpan.FromSeconds(0.1);
            _clockTimer.Start();
        }

        private void _clockTimer_Tick(object sender, EventArgs e)
        {
            DateTime t = DateTime.Now;
            if (t != _lastTime)
            {
                _lastTime = t;
                RefreshTime(t);
            }
        }

        #region Properties

        public double HourDegree
        {
            get { return _hourDegree; }
            set
            {
                if (_hourDegree != value)
                {
                    _hourDegree = value;
                    OnPropertyChanged("HourDegree");
                }
            }
        }

        public double MinuteDegree
        {
            get { return _minuteDegree; }
            set
            {
                if (_minuteDegree != value)
                {
                    _minuteDegree = value;
                    OnPropertyChanged("MinuteDegree");
                }
            }
        }

        public double SecondDegree
        {
            get { return _secondDegree; }
            set
            {
                if (_secondDegree != value)
                {
                    _secondDegree = value;
                    OnPropertyChanged("SecondDegree");
                }
            }
        }

        public bool ShowSecondHandle
        {
            get { return _showSecondHandle; }
            set
            {
                if (_showSecondHandle != value)
                {
                    _showSecondHandle = value;
                    OnPropertyChanged("ShowSecondHandle");
                }
            }
        }

        #endregion

        #region Methods

        public void RefreshTime(DateTime time)
        {
            HourDegree = -(30.0 * (time.Hour % 12) + time.Minute * 0.5);
            MinuteDegree = -(6.0 * time.Minute + 0.1 * time.Second);
            SecondDegree = -(6.0 * time.Second);
        }

        #endregion

    }
}

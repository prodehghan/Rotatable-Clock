using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SG.SepidarSidebar
{
    public class MainWindowViewModel : ViewModelBase
    {
        private double _verticalRotationDegree = -17;
        private double _horizontalRotationDegree = 0;

        public double VerticalRotationDegree
        {
            get { return _verticalRotationDegree; }
            set
            {
                if (_verticalRotationDegree != value)
                {
                    _verticalRotationDegree = value;
                    OnPropertyChanged("VerticalRotationDegree");
                }
            }
        }

        public double HorizontalRotationDegree
        {
            get { return _horizontalRotationDegree; }
            set
            {
                if (_horizontalRotationDegree != value)
                {
                    _horizontalRotationDegree = value;
                    OnPropertyChanged("HorizontalRotationDegree");
                }
            }
        }

    }
}

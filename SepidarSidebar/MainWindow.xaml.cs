using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SG.SepidarSidebar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();

            _viewModel = new MainWindowViewModel();
            this.DataContext = _viewModel;
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.LeftButton == MouseButtonState.Pressed && e.RightButton == MouseButtonState.Released)
                this.DragMove();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.Key == Key.D0)
                ResetTransforms();
            else if (e.Key == Key.OemPlus)
            {
                double w = this.Width * 1.5;
                double sw = SystemParameters.PrimaryScreenWidth, sh = SystemParameters.PrimaryScreenHeight;
                if (w > sw || w > sh)
                    w = Math.Min(sw, sh);
                this.Width = this.Height = w;
            }
            else if (e.Key == Key.OemMinus)
            {
                if (this.Width > 20)
                {
                    this.Width = this.Height = this.Width / 1.5;
                }
            }
            else if (e.Key == Key.Right)
            {
                if (_viewModel.VerticalRotationDegree < 50)
                    _viewModel.VerticalRotationDegree += 5;
            }
            else if (e.Key == Key.Left)
            {
                if (_viewModel.VerticalRotationDegree > -50)
                    _viewModel.VerticalRotationDegree -= 5;
            }
            else if (e.Key == Key.Down)
            {
                if (_viewModel.HorizontalRotationDegree < 50)
                    _viewModel.HorizontalRotationDegree += 5;
            }
            else if (e.Key == Key.Up)
            {
                if (_viewModel.HorizontalRotationDegree > -50)
                    _viewModel.HorizontalRotationDegree -= 5;
            }
        }

        public void ResetTransforms()
        {
            _viewModel.HorizontalRotationDegree = 0;
            _viewModel.VerticalRotationDegree = -17;
            Width = 250;
            Height = 250;
        }
    }
}

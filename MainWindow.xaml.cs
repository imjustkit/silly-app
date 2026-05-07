using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace silly
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int count = 0;
        bool relayingMousePos = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void FadeIn(object sender, RoutedEventArgs e)
        {
            Loaded -= FadeIn;
            var animation = new DoubleAnimation(0, 1, (Duration)TimeSpan.FromSeconds(0.5));
            this.BeginAnimation(UIElement.OpacityProperty, animation);
        }

        private void FadeOut(object sender, CancelEventArgs e)
        {
            Closing -= FadeOut;
            e.Cancel = true;
            var animation = new DoubleAnimation(1, 0, (Duration)TimeSpan.FromSeconds(0.5));
            animation.Completed += (s, _) => Close();
            this.BeginAnimation(UIElement.OpacityProperty, animation);
        }

        private void btnClick_Click(object sender, RoutedEventArgs e)
        {
            count++;
            lblMessage.Content = $"you clicked the button {count} :3";
        }

        private void dragging(object sender, RoutedEventArgs e)
        {
            this.DragMove();
        }

        private void MoveImage(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(this);
            Canvas.SetLeft(anime, ((mousePos.X / 640) * 15) - 30);
            Canvas.SetTop(anime, ((mousePos.Y / 480) * 15) - 30);
        }

        private async void startPosRelay(object sender, RoutedEventArgs e)
        {
            while ((bool)checkMousePos.IsChecked)
            {
                Point mousePos = Mouse.GetPosition(this);
                lblMessage.Content = $"Mouse Position: {mousePos.X}, {mousePos.Y}";
                await Task.Delay(1);
            }
            
        }
    }
}

using Chern_App.News;
using System.Media;
using System.Windows;
using System.Windows.Input;

namespace Chern_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SoundPlayer player;
        SoundPlayer player2;
        SoundPlayer player3;
        public MainWindow()
        {
            InitializeComponent();
            player = new SoundPlayer(Properties.Resources.sound);
            player2 = new SoundPlayer(Properties.Resources.sound2);
            player3 = new SoundPlayer(Properties.Resources.sound3);
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sideBar.Visibility == Visibility.Collapsed)
            {
                sideBar.Visibility = Visibility.Visible;
                sideBarRotateTransform.Angle = 90;
                SideBarElement.UseFullName = true;
                player2.Play();
            }
            else
            {
                sideBar.Visibility = Visibility.Collapsed;
                sideBarRotateTransform.Angle = 0;
                SideBarElement.UseFullName = false;
                player3.Play();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = PageController.GetPageObject<NewsPage>();
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            player.Play();
        }
    }
}

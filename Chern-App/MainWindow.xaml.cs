using Chern_App.News;
using System.Media;
using System.Windows;
using System.Windows.Input;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;

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
      
        private readonly string localizationPath = "localization";
      
        public MainWindow()
        {
            InitLocalization();
            InitializeComponent();
          
            player = new SoundPlayer(Properties.Resources.sound);
            player2 = new SoundPlayer(Properties.Resources.sound2);
            player3 = new SoundPlayer(Properties.Resources.sound3);
          
            ModuleManager.AddButtonRequested += ModuleManager_AddButtonRequested;
            ModuleManager.ShowPageRequested += ModuleManager_ShowPageRequested;
        }

        private void InitLocalization()
        {
            if (File.Exists(localizationPath) && new FileInfo(localizationPath).Length > 0)
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(File.ReadAllText(localizationPath));
            }
        }

        private void ModuleManager_ShowPageRequested(Page page)
        {
            PageFrame.Content = page;
        }

        private void ModuleManager_AddButtonRequested(Button button)
        {
            button.Style = FindResource("SideBarButtonStyle") as Style;
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

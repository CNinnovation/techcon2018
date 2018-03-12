using DISampleViewModels.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text;
using System.Windows;
using Windows.ApplicationModel;
using Windows.System;

namespace WPFDISample
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            SetPackageName();
        }

        private void SetPackageName()
        {
            try
            {
                Package package = Package.Current;
                packageName.Text = package.DisplayName;
                packageId.Text = package.Id.FullName;
            }
            catch (InvalidOperationException)
            {
                packageName.Text = "no package";
            }

        }

        public MainViewModel ViewModel => ApplicationServices.Instance.ServiceProvider.GetService<MainViewModel>();

        private async void OnLaunchUWP(object sender, RoutedEventArgs e)
        { 
            string protocol = "showit2018";
            var uri = new Uri($"{protocol}://");
            var success = await Launcher.LaunchUriAsync(uri);
        }
    }
}

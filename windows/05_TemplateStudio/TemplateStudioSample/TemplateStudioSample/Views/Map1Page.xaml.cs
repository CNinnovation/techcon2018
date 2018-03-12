using System;

using TemplateStudioSample.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace TemplateStudioSample.Views
{
    public sealed partial class Map1Page : Page
    {
        public Map1ViewModel ViewModel { get; } = new Map1ViewModel();

        public Map1Page()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await ViewModel.InitializeAsync(mapControl);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            ViewModel.Cleanup();
        }
    }
}

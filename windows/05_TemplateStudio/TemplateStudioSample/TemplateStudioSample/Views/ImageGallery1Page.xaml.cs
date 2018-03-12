using System;

using TemplateStudioSample.ViewModels;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TemplateStudioSample.Views
{
    public sealed partial class ImageGallery1Page : Page
    {
        public ImageGallery1ViewModel ViewModel { get; } = new ImageGallery1ViewModel();

        public ImageGallery1Page()
        {
            InitializeComponent();
        }

        private async void GridView_Loaded(object sender, RoutedEventArgs e)
        {
            var gridView = sender as GridView;
            await ViewModel.LoadAnimationAsync(gridView);
        }
    }
}

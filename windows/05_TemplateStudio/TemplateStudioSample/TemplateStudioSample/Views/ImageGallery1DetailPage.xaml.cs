using System;

using TemplateStudioSample.Models;
using TemplateStudioSample.ViewModels;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace TemplateStudioSample.Views
{
    public sealed partial class ImageGallery1DetailPage : Page
    {
        public ImageGallery1DetailViewModel ViewModel { get; } = new ImageGallery1DetailViewModel();

        public ImageGallery1DetailPage()
        {
            InitializeComponent();
            ViewModel.SetImage(previewImage);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ViewModel.Initialize(e.Parameter as SampleImage);
            showFlipView.Begin();
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
            if (e.NavigationMode == NavigationMode.Back)
            {
                previewImage.Visibility = Visibility.Visible;
                ViewModel.SetAnimation();
            }
        }
    }
}

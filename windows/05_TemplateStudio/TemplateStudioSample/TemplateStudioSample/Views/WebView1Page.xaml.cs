using System;

using TemplateStudioSample.ViewModels;

using Windows.UI.Xaml.Controls;

namespace TemplateStudioSample.Views
{
    public sealed partial class WebView1Page : Page
    {
        public WebView1ViewModel ViewModel { get; } = new WebView1ViewModel();

        public WebView1Page()
        {
            InitializeComponent();
            ViewModel.Initialize(webView);
        }
    }
}

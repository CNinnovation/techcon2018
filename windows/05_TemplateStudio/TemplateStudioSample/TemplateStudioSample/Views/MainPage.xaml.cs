using System;

using TemplateStudioSample.ViewModels;

using Windows.UI.Xaml.Controls;

namespace TemplateStudioSample.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
        }
    }
}

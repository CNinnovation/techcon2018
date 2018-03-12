using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using TemplateStudioSample.Helpers;
using TemplateStudioSample.Models;
using TemplateStudioSample.Services;

using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Animation;

namespace TemplateStudioSample.ViewModels
{
    public class ImageGallery1DetailViewModel : Observable
    {
        private static UIElement _image;
        private object _selectedImage;
        private ObservableCollection<SampleImage> _source;

        public object SelectedImage
        {
            get => _selectedImage;
            set
            {
                Set(ref _selectedImage, value);
                ApplicationData.Current.LocalSettings.SaveString(ImageGallery1ViewModel.ImageGallery1SelectedIdKey, ((SampleImage)SelectedImage).ID);
            }
        }

        public ObservableCollection<SampleImage> Source
        {
            get => _source;
            set => Set(ref _source, value);
        }

        public ImageGallery1DetailViewModel()
        {
            // TODO WTS: Replace this with your actual data
            Source = SampleDataService.GetGallerySampleData();
        }

        public void SetImage(UIElement image) => _image = image;

        public void Initialize(SampleImage sampleImage)
        {
            SelectedImage = Source.FirstOrDefault(i => i.ID == sampleImage.ID);
            var animation = ConnectedAnimationService.GetForCurrentView().GetAnimation(ImageGallery1ViewModel.ImageGallery1AnimationOpen);
            animation?.TryStart(_image);
        }

        public void SetAnimation()
        {
            ConnectedAnimationService.GetForCurrentView()?.PrepareToAnimate(ImageGallery1ViewModel.ImageGallery1AnimationClose, _image);
        }
    }
}

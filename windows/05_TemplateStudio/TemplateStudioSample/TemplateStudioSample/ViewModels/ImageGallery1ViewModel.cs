using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

using TemplateStudioSample.Helpers;
using TemplateStudioSample.Models;
using TemplateStudioSample.Services;
using TemplateStudioSample.Views;

using Windows.Storage;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace TemplateStudioSample.ViewModels
{
    public class ImageGallery1ViewModel : Observable
    {
        public const string ImageGallery1SelectedIdKey = "ImageGallery1SelectedIdKey";
        public const string ImageGallery1AnimationOpen = "ImageGallery1_AnimationOpen";
        public const string ImageGallery1AnimationClose = "ImageGallery1_AnimationClose";

        private ObservableCollection<SampleImage> _source;
        private ICommand _itemSelectedCommand;
        private GridView _imagesGridView;

        public ObservableCollection<SampleImage> Source
        {
            get => _source;
            set => Set(ref _source, value);
        }

        public ICommand ItemSelectedCommand => _itemSelectedCommand ?? (_itemSelectedCommand = new RelayCommand<ItemClickEventArgs>(OnsItemSelected));

        public ImageGallery1ViewModel()
        {
            // TODO WTS: Replace this with your actual data
            Source = SampleDataService.GetGallerySampleData();
        }

        public async Task LoadAnimationAsync(GridView imagesGridView)
        {
            _imagesGridView = imagesGridView;
            var selectedImageId = await ApplicationData.Current.LocalSettings.ReadAsync<string>(ImageGallery1SelectedIdKey);
            if (!string.IsNullOrEmpty(selectedImageId))
            {
                var animation = ConnectedAnimationService.GetForCurrentView().GetAnimation(ImageGallery1AnimationClose);
                if (animation != null)
                {
                    var item = _imagesGridView.Items.FirstOrDefault(i => ((SampleImage)i).ID == selectedImageId);
                    _imagesGridView.ScrollIntoView(item);
                    await _imagesGridView.TryStartConnectedAnimationAsync(animation, item, "galleryImage");
                }

                ApplicationData.Current.LocalSettings.SaveString(ImageGallery1SelectedIdKey, string.Empty);
            }
        }

        private void OnsItemSelected(ItemClickEventArgs args)
        {
            var selected = args.ClickedItem as SampleImage;
            _imagesGridView.PrepareConnectedAnimation(ImageGallery1AnimationOpen, selected, "galleryImage");
            NavigationService.Navigate<ImageGallery1DetailPage>(args.ClickedItem);
        }
    }
}

using System;
using System.Collections.ObjectModel;

using TemplateStudioSample.Helpers;
using TemplateStudioSample.Models;
using TemplateStudioSample.Services;

namespace TemplateStudioSample.ViewModels
{
    public class Grid1ViewModel : Observable
    {
        public ObservableCollection<SampleOrder> Source
        {
            get
            {
                // TODO WTS: Replace this with your actual data
                return SampleDataService.GetGridSampleData();
            }
        }
    }
}

using System;
using System.Collections.ObjectModel;

using TemplateStudioSample.Helpers;
using TemplateStudioSample.Models;
using TemplateStudioSample.Services;

namespace TemplateStudioSample.ViewModels
{
    public class Chart1ViewModel : Observable
    {
        public Chart1ViewModel()
        {
        }

        public ObservableCollection<DataPoint> Source
        {
            get
            {
                // TODO WTS: Replace this with your actual data
                return SampleDataService.GetChartSampleData();
            }
        }
    }
}

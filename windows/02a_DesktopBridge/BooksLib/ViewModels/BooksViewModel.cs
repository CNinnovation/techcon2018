﻿using BooksLib.Models;
using BooksLib.Services;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;

namespace BooksLib.ViewModels
{
    public class BooksViewModel : BindableBase
    {
        private readonly IBooksService _booksService;
        private readonly ILaunchProtocolService _launchProtocolService;
        private readonly IUpdateTileService _updateTileService;
        private readonly IAppServiceClientService _appServiceClientService;

        public BooksViewModel(IBooksService booksService, ILaunchProtocolService launchProtocolService, IPackageNameService packageNameService, IUpdateTileService updateTileService, IAppServiceClientService appServiceClientService)
        {
            _booksService = booksService ?? throw new ArgumentNullException(nameof(booksService));
            _launchProtocolService = launchProtocolService ?? throw new ArgumentNullException(nameof(launchProtocolService));
            _updateTileService = updateTileService ?? throw new ArgumentNullException(nameof(updateTileService));
            _appServiceClientService = appServiceClientService ?? throw new ArgumentNullException(nameof(appServiceClientService));
            _package = packageNameService?.GetPackageName() ?? throw new ArgumentNullException(nameof(packageNameService));
            LaunchUWPCommand = new DelegateCommand(OnLaunchUWP);
            UpdateTileCommand = new DelegateCommand(OnUpdateTile);
            AppServiceCommand = new DelegateCommand(OnAppService);
        }

        public DelegateCommand LaunchUWPCommand { get; }
        public DelegateCommand UpdateTileCommand { get; }
        public DelegateCommand AppServiceCommand { get; }

        public IEnumerable<Book> Books => _booksService.Books;

        public async void OnLaunchUWP()
        {
            await _launchProtocolService.LaunchAppAsync("sampleapp");
        }

        public void OnUpdateTile()
        {
            _updateTileService.UpdateTile();
        }

        public void OnAppService()
        {
            _appServiceClientService.SendMessageAsync("Message from WPF");
        }

        public string PackageName => Package.name;
        public string PackageId => Package.id;

        private readonly (string name, string id) _package;
        public (string name, string id) Package => _package;
    }
}

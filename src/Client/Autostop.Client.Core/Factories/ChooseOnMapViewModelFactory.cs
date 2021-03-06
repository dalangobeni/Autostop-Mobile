﻿using Autostop.Client.Abstraction.Factories;
using Autostop.Client.Abstraction.ViewModels;
using Autostop.Client.Core.IoC;
using JetBrains.Annotations;
using ViewModelKeys = Autostop.Common.Shared.Constants.IoC.ViewModelKeys;

namespace Autostop.Client.Core.Factories
{
    [UsedImplicitly]
    public class ChooseOnMapViewModelFactory : IChooseOnMapViewModelFactory
    {
        public ISearchableViewModel GetChooseDestinationOnMapViewModel()
        {
	        return Locator.ResolveNamed<ISearchableViewModel>(ViewModelKeys.ChooseDestinationOnMap);
        }
    }
}

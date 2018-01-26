﻿using System;
using System.Reactive.Linq;
using System.Windows.Input;
using Autostop.Client.Abstraction.Factories;
using Autostop.Client.Abstraction.Models;
using Autostop.Client.Abstraction.Providers;
using Autostop.Client.Abstraction.Services;
using Autostop.Client.Abstraction.ViewModels;
using Autostop.Client.Core.Models;
using Autostop.Client.Core.ViewModels.Passenger.LocationEditor;
using Conditions;
using GalaSoft.MvvmLight.Command;

namespace Autostop.Client.Core.ViewModels.Passenger.Trip
{
	public class TripLocationViewModel : BaseViewModel, ITripLocationViewModel
	{
		private readonly IBaseSearchPlaceViewModel _pickupSearchPlaceViewModel;
		private readonly IBaseSearchPlaceViewModel _destinationSearchPlaceViewModel;
		private readonly INavigationService _navigationService;

		public TripLocationViewModel(
			ISchedulerProvider schedulerProvider,
			INavigationService navigationService,
			ISearchPlaceViewModelFactory searchPlaceViewModelFactory)
		{
			schedulerProvider.Requires(nameof(schedulerProvider)).IsNotNull();
			navigationService.Requires(nameof(navigationService)).IsNotNull();
			searchPlaceViewModelFactory.Requires(nameof(searchPlaceViewModelFactory)).IsNotNull();


			_pickupSearchPlaceViewModel = searchPlaceViewModelFactory.GetPickupSearchPlaceViewModel();
			_destinationSearchPlaceViewModel = searchPlaceViewModelFactory.DestinationSearchPlaceViewModel(this);
			_navigationService = navigationService;
			
			_pickupSearchPlaceViewModel.SelectedAddress
				.ObserveOn(schedulerProvider.SynchronizationContextScheduler)
				.Subscribe(address =>
				{
					PickupAddress.SetAddress(address);
					_navigationService.GoBack();
				});

			_destinationSearchPlaceViewModel.SelectedAddress
				.ObserveOn(schedulerProvider.SynchronizationContextScheduler)
				.Subscribe(address =>
				{
					DestinationAddress.SetAddress(address);
					_navigationService.GoBack();
				});
		}

		public IAddressModel PickupAddress { get; } = new AddressModel();

		public IAddressModel DestinationAddress { get; } = new AddressModel();
	
		public ICommand NavigateToPickupSearch => new RelayCommand(
			() =>
			{
				_navigationService.NavigateToSearchView(_pickupSearchPlaceViewModel as PickupLocationEditorViewModel);
				_pickupSearchPlaceViewModel.SearchText = PickupAddress.FormattedAddress;
			});

		public ICommand NavigateToWhereTo => new RelayCommand(
			() =>
			{
				_navigationService.NavigateToSearchView(_destinationSearchPlaceViewModel as DestinationLocationEditorViewModel);
				_destinationSearchPlaceViewModel.SearchText = string.Empty;
			});
	}
}

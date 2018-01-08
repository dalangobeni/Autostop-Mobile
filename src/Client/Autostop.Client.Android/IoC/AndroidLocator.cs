﻿using Android.App;
using Android.Locations;
using Autofac;
using Autostop.Client.Abstraction;
using Autostop.Client.Abstraction.Adapters;
using Autostop.Client.Abstraction.Managers;
using Autostop.Client.Abstraction.Providers;
using Autostop.Client.Abstraction.Services;
using Autostop.Client.Android.Adapters;
using Autostop.Client.Android.Providers;
using Autostop.Client.Android.Services;
using Autostop.Client.Android.Views;
using Autostop.Client.Core.IoC;
using Autostop.Client.Core.ViewModels.Passenger;
using Autostop.Client.Shared.UI.IoC;
using Plugin.CurrentActivity;

namespace Autostop.Client.Android.IoC
{
	public class AndroidLocator : Locator
	{
		protected override void ContainerRegistery(ContainerBuilder builder)
		{	
		    builder.RegisterType<PageToFragmentAdapter>().As<IViewAdapter<Fragment>>();
		    builder.RegisterType<FirebasePhoneAuthenticationProvider>().As<IPhoneAuthenticationProvider>();
		    builder.RegisterType<NavigationService>().As<INavigationService>();
			builder.RegisterType<Managers.LocationManager>().As<ILocationManager>();
			builder.RegisterInstance(CrossCurrentActivity.Current).As<ICurrentActivity>();			

		    builder.RegisterType<MainFragment>().As<IScreenFor<MainViewModel>>();

		    builder.ClientTypesRegistry();
        }
    }
}
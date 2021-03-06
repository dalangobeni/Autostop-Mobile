﻿using System;
using System.Diagnostics;
using Autostop.Client.Abstraction;
using Autostop.Client.Abstraction.Factories;
using Autostop.Client.Core.IoC;

namespace Autostop.Client.Core.Factories
{
    public sealed class ViewFactory : IViewFactory
    {
        public IScreenFor<TViewModel> CreateView<TViewModel>(TViewModel vm)
        {
	        try
	        {
		        var viewType = typeof(IScreenFor<>).MakeGenericType(vm.GetType());
		        if (!(Locator.Resolve(viewType) is IScreenFor<TViewModel> view))
			        throw new ArgumentException($"Resolve type {typeof(TViewModel).Name} does not implement IScreen");

		        view.ViewModel = vm;

		        return view;
			}
	        catch (Exception e)
	        {
				Debug.WriteLine(e);
	        }

	        return null;
        }
    }
}
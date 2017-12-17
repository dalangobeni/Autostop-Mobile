﻿using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Autostop.Client.Abstraction.ViewModels;
using Google.Maps.Places;

namespace Autostop.Client.Abstraction.Providers
{
	public interface IPlacesProvider
	{
		Task<ObservableCollection<IAutoCompleteResultViewModel>> GetAutoCompleteResponse(string input);
	}
}
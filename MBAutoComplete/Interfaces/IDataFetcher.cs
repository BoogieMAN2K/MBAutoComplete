using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;

namespace MBAutoComplete
{
	public interface IDataFetcher<T> where T : IMvxNotifyPropertyChanged
	{
		Task PerformFetch(MBAutoCompleteTextField textField, Action<ICollection<T>> completionHandler);
	}
}


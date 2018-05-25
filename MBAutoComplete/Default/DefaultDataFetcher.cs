using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;

namespace MBAutoComplete
{
	public class DefaultDataFetcher<T> : IDataFetcher<T> where T : IMvxNotifyPropertyChanged
	{
		private ICollection<T> _unsortedData; 

		public DefaultDataFetcher(ICollection<T> unsortedData)
		{
			_unsortedData = unsortedData;
		}

		public async Task PerformFetch(MBAutoCompleteTextField textfield, Action<ICollection<T>> completionHandler)
		{
			completionHandler(_unsortedData);
		}
	}
}


using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using MvvmCross.Core.ViewModels;
using UIKit;


namespace MBAutoComplete
{
	public abstract class MBAutoCompleteViewSource<T> : UITableViewSource where T : IMvxNotifyPropertyChanged
	{
		public event EventHandler RowSelectedEvent;
		public T SelectedItem;
        
		private ICollection<T> _suggestions = new List<T>();
		public ICollection<T> Suggestions
		{
			get
			{
				return _suggestions;
			}
			set
			{
				_suggestions = value;
				NewSuggestions(_suggestions);
			}
		}

		public abstract void NewSuggestions(ICollection<T> suggestions);

		public MBAutoCompleteTextField AutoCompleteTextField
		{
			get;
			set;
		}

		public abstract override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath);

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return Suggestions.Count;
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			AutoCompleteTextField.Text = Suggestions.ElementAt(indexPath.Row).ToString();
			AutoCompleteTextField.AutoCompleteTableView.Hidden = true;
			SelectedItem = Suggestions.ElementAt(indexPath.Row);
			RowSelectedEvent?.Invoke(this, EventArgs.Empty);
		}
	}
}


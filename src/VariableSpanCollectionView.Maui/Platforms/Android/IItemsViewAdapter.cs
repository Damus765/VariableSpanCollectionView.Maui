using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Handlers.Items;

namespace VariableSpanCollectionView.Maui
{
	public interface IItemsViewAdapter
	{
		IItemsViewSource ItemsSource { get; }

		ItemsView ItemsView { get; }
	}
}
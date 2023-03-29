using Microsoft.Maui.Controls.Handlers.Items;

namespace VariableSpanCollectionView.Maui
{
	public interface IObservableItemsViewSource : IItemsViewSource
	{
		bool ObserveChanges { get; set; }
	}
}
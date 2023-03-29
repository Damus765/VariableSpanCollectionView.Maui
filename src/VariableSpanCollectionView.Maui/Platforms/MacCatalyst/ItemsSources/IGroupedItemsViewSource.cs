using Foundation;
using Microsoft.Maui.Controls.Handlers.Items;

namespace VariableSpanCollectionView.Maui
{
	public interface IGroupedItemsViewSource : IItemsViewSource
	{
		IItemsViewSource GroupItemsViewSource(NSIndexPath indexPath);
	}
}
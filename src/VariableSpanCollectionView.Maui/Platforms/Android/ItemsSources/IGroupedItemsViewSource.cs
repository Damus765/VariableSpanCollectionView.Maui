using System.Collections;
using Microsoft.Maui.Controls.Handlers.Items;

namespace VariableSpanCollectionView.Maui
{
	public interface IGroupedItemsViewSource : IGroupableItemsViewSource
	{
		(int, int) GetGroupAndIndex(int position);
		object GetGroup(int groupIndex);
		IItemsViewSource GetGroupItemsViewSource(int groupIndex);
	}
}
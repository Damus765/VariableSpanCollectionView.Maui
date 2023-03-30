using Microsoft.Maui.Controls.Handlers.Items;
using UIKit;

namespace VariableSpanCollectionView.Maui
{
	public class VariableSpanCollectionViewController<TItemsView> : ReorderableItemsViewController<TItemsView>
		where TItemsView : VariableSpanCollectionView
	{
		public VariableSpanCollectionViewController(TItemsView variableSpanCollectionView, ItemsViewLayout layout)
			: base(variableSpanCollectionView, layout)
		{
		}

		protected override UICollectionViewDelegateFlowLayout CreateDelegator()
		{
			return new VariableSpanCollectionViewDelegator<TItemsView, VariableSpanCollectionViewController<TItemsView>>(ItemsViewLayout, this);
		}
	}
}
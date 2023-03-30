using CoreGraphics;
using Foundation;
using UIKit;
using Microsoft.Maui.Controls.Handlers.Items;

namespace VariableSpanCollectionView.Maui
{
	public class VariableSpanCollectionViewDelegator<TItemsView, TViewController> : ReorderableItemsViewDelegator<TItemsView, TViewController>
		where TItemsView : VariableSpanCollectionView
		where TViewController : VariableSpanCollectionViewController<TItemsView>
	{
		public VariableSpanCollectionViewDelegator(ItemsViewLayout itemsViewLayout, TViewController itemsViewController)
			: base(itemsViewLayout, itemsViewController)
		{
		}

		public override CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
		{
			if (ItemsViewLayout is VariableSpanGridViewLayout variableSpanLayout)
			{
				var itemsLayout = variableSpanLayout.ItemsLayout;
				var columnSpan = itemsLayout.ItemSpanLookup?.GetColumnSpan(ViewController.ItemsSource[indexPath]) ?? 1;
				if (columnSpan > 1)
				{
					var itemWidth = (itemsLayout.ItemWidth * columnSpan) + itemsLayout.HorizontalItemSpacing * (columnSpan - 1);
					return new CGSize(itemWidth, itemsLayout.ItemHeight);
				}
				else
				{
					return variableSpanLayout.ItemSize;
				}
			}
			else
			{
				return base.GetSizeForItem(collectionView, layout, indexPath);
			}
		}
	}
}
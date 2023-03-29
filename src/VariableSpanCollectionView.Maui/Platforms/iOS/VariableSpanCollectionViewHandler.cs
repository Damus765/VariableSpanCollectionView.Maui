using System;
using Microsoft.Maui.Controls.Handlers.Items;
using Microsoft.Maui.Essentials;
using Microsoft.Maui.Graphics;

namespace VariableSpanCollectionView.Maui
{
	public partial class VariableSpanCollectionViewHandler : GroupableItemsViewHandler<VariableSpanCollectionView>
	{
		protected override ItemsViewController<VariableSpanCollectionView> CreateController(VariableSpanCollectionView itemsView, ItemsViewLayout layout)
			=> new VariableSpanCollectionViewController<VariableSpanCollectionView>(itemsView, layout);

		public override Size GetDesiredSize(double widthConstraint, double heightConstraint)
		{
			if (Controller.Layout is VariableSpanGridViewLayout variableSpanLayout)
			{
				var info = DeviceDisplay.MainDisplayInfo;
				var scaled = new Size(info.Width / info.Density, info.Height / info.Density);
				var maxWidth = Math.Min(scaled.Width, widthConstraint);
				var maxHeight = Math.Min(scaled.Height, heightConstraint);
				var fitSize = variableSpanLayout.GetSizeThatFits(maxWidth, maxHeight, Controller.ItemsSource);
				return fitSize;
			}
			return base.GetDesiredSize(widthConstraint, heightConstraint);
		}

		protected override ItemsViewLayout SelectLayout()
		{
			var itemsLayout = ItemsView.ItemsLayout;

			if (itemsLayout is VariableSpanGridItemsLayout variableSpanItemsLayout)
			{
				return new VariableSpanGridViewLayout(variableSpanItemsLayout);
			}
			else
			{
				return base.SelectLayout();
			}
		}

		public static void MapCanReorderItems(VariableSpanCollectionViewHandler handler, VariableSpanCollectionView itemsView)
		{
			(handler.Controller as VariableSpanCollectionViewController<VariableSpanCollectionView>)?.UpdateCanReorderItems();
		}
	}
}
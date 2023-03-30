using System;
using Android.Content;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Handlers.Items;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Platform;

namespace VariableSpanCollectionView.Maui
{
	public class VariableSpanCollectionViewAdapter<TItemsView, TItemsViewSource> : ReorderableItemsViewAdapter<TItemsView, TItemsViewSource>, IItemsViewAdapter
		where TItemsView : VariableSpanCollectionView
		where TItemsViewSource : IGroupableItemsViewSource
	{
		IItemsViewSource IItemsViewAdapter.ItemsSource => ItemsSource;
		ItemsView IItemsViewAdapter.ItemsView => ItemsView;

		public VariableSpanCollectionViewAdapter(TItemsView variableSpanCollectionView,
			Func<View, Context, ItemContentView> createView = null) : base(variableSpanCollectionView, createView)
		{
		}

		protected override void BindTemplatedItemViewHolder(TemplatedItemViewHolder templatedItemViewHolder, object context)
		{
			if (ItemsView.ItemsLayout is VariableSpanGridItemsLayout variableSpanLayout)
			{
				var itemViewType = templatedItemViewHolder.ItemViewType;
				if (itemViewType == ItemViewType.TemplatedItem || itemViewType == ItemViewType.TextItem)
				{
					var androidContext = templatedItemViewHolder.ItemView.Context;
					var columnSpan = variableSpanLayout.ItemSpanLookup?.GetColumnSpan(context) ?? 1;
					var itemWidth = (columnSpan * variableSpanLayout.ItemWidth) + variableSpanLayout.HorizontalItemSpacing * (columnSpan - 1);
					templatedItemViewHolder.Bind(context, ItemsView, null, new Size(androidContext.ToPixels(itemWidth), androidContext.ToPixels(variableSpanLayout.ItemHeight)));
					return;
				}
			}

			base.BindTemplatedItemViewHolder(templatedItemViewHolder, context);
		}
	}
}
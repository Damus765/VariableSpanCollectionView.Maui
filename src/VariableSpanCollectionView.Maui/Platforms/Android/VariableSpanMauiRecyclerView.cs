using System;
using System.ComponentModel;
using Android.Content;
using AndroidX.RecyclerView.Widget;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Handlers.Items;
using Microsoft.Maui.Platform;

namespace VariableSpanCollectionView.Maui
{
	public class VariableSpanMauiRecyclerView<TItemsView, TAdapter, TItemsViewSource> : MauiRecyclerView<TItemsView, TAdapter, TItemsViewSource>, IMauiRecyclerView<TItemsView>
		where TItemsView : ItemsView
		where TAdapter : ItemsViewAdapter<TItemsView, TItemsViewSource>
		where TItemsViewSource : IItemsViewSource
	{
		public VariableSpanMauiRecyclerView(Context context, Func<IItemsLayout> getItemsLayout, Func<TAdapter> getAdapter) : base(context, getItemsLayout, getAdapter)
		{
		}

		protected override void LayoutPropertyChanged(object sender, PropertyChangedEventArgs propertyChanged)
		{
			base.LayoutPropertyChanged(sender, propertyChanged);

			if (ItemsLayout is VariableSpanGridItemsLayout variableLayout)
			{
				if (propertyChanged.PropertyName == VariableSpanGridItemsLayout.ItemWidthProperty.PropertyName || propertyChanged.PropertyName == VariableSpanGridItemsLayout.ItemHeightProperty.PropertyName)
				{
					if (GetLayoutManager() is VariableSpanGridLayoutManager gridLayoutManager)
					{
						UpdateVariableSpanGridColumnWidth(gridLayoutManager, variableLayout);
						ItemsViewAdapter?.NotifyDataSetChanged();
					}
				}
				else if (propertyChanged.PropertyName == VariableSpanGridItemsLayout.HorizontalItemSpacingProperty.PropertyName || propertyChanged.PropertyName == VariableSpanGridItemsLayout.VerticalItemSpacingProperty.PropertyName)
				{
					if (GetLayoutManager() is VariableSpanGridLayoutManager gridLayoutManager)
					{
						UpdateVariableSpanGridColumnWidth(gridLayoutManager, variableLayout);
					}
					UpdateItemSpacing();
				}
				else if (propertyChanged.PropertyName == VariableSpanGridItemsLayout.ItemSpanSizeLookupProperty.PropertyName)
				{
					if (GetLayoutManager() is VariableSpanGridLayoutManager gridLayoutManager && gridLayoutManager.GetSpanSizeLookup() is VariableSpanGridSizeLookup spanLookup)
					{
						spanLookup.Lookup = variableLayout.ItemSpanLookup;
						ItemsViewAdapter?.NotifyDataSetChanged();
					}
				}
			}
		}

		protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
		{
			base.OnMeasure(widthMeasureSpec, heightMeasureSpec);

			if (GetLayoutManager() is VariableSpanGridLayoutManager gridLayoutManager)
			{
				// The default measurement stretches the entire width when using headers & footers.
				var fitWidth = (gridLayoutManager.SpanCount * (int)gridLayoutManager.ColumnWidth) + PaddingRight + PaddingLeft;
				var newMeasuredWidth = Math.Min(fitWidth, MeasuredWidth);
				SetMeasuredDimension(newMeasuredWidth, MeasuredHeight);
			}
		}

		protected override LayoutManager SelectLayoutManager(IItemsLayout layoutSpecification)
		{
			switch (layoutSpecification)
			{
				case VariableSpanGridItemsLayout gridItemsLayout:
					var layoutManager = new VariableSpanGridLayoutManager(Context, LinearLayoutManager.Vertical, false);
					UpdateVariableSpanGridColumnWidth(layoutManager, gridItemsLayout);
					layoutManager.SetSpanSizeLookup(new VariableSpanGridSizeLookup(gridItemsLayout.ItemSpanLookup, this));
					return layoutManager;
				default:
					return base.SelectLayoutManager(layoutSpecification);
			}
		}

		void UpdateVariableSpanGridColumnWidth(VariableSpanGridLayoutManager layoutManager, VariableSpanGridItemsLayout itemsLayout)
		{
			layoutManager.ColumnWidth = Context.ToPixels(itemsLayout.ItemWidth + itemsLayout.HorizontalItemSpacing);
		}
	}
}
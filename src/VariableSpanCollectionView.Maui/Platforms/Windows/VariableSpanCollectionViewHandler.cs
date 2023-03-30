using Microsoft.Maui.Controls.Handlers.Items;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using WSetter = Microsoft.UI.Xaml.Setter;
using WStyle = Microsoft.UI.Xaml.Style;
using WThickness = Microsoft.UI.Xaml.Thickness;

namespace VariableSpanCollectionView.Maui
{
	public partial class VariableSpanCollectionViewHandler : ReorderableItemsViewHandler<VariableSpanCollectionView>
	{
		protected override void ConnectHandler(ListViewBase nativeView)
		{
			base.ConnectHandler(nativeView);
			nativeView.SetValue(FormsListViewAttachedProperties.ItemsViewProperty, Element);
		}

		protected override void DisconnectHandler(ListViewBase nativeView)
		{
			nativeView.ClearValue(FormsListViewAttachedProperties.ItemsViewProperty);
			base.DisconnectHandler(nativeView);
		}

		protected override CollectionViewSource CreateCollectionViewSource()
		{
			if (Element.IsGrouped)
			{
				return base.CreateCollectionViewSource();
			}

			var itemsSource = Element.ItemsSource;

			return new CollectionViewSource
			{
				Source = itemsSource,
				IsSourceGrouped = false
			};
		}

		/*  
		// The default Maui Windows handlers do not currently respond to Layout property changes.
		// So we won't worry about the VariableSpanGridItemsLayout property changes at this time.
		// We'll include them once they are implemented for the LinearItemsLayout & GridItemsLayouts.
		protected override void HandleLayoutPropertyChanged(PropertyChangedEventArgs property)
		{
			base.HandleLayoutPropertyChanged(property);

			if (Layout is VariableSpanGridItemsLayout variableSpanLayout && ListViewBase is FormsVariableSpanGridView variableSpanGridView)
			{
				if (property.PropertyName == VariableSpanGridItemsLayout.ItemWidthProperty.PropertyName || property.PropertyName == VariableSpanGridItemsLayout.ItemHeightProperty.PropertyName)
				{
					UpdateVariableSpanGridItemSize(variableSpanGridView, variableSpanLayout);
				}
				else if (property.PropertyName == VariableSpanGridItemsLayout.HorizontalItemSpacingProperty.PropertyName || property.PropertyName == VariableSpanGridItemsLayout.VerticalItemSpacingProperty.PropertyName)
				{
					UpdateVariableSpanGridSpacing(variableSpanGridView, variableSpanLayout);
					UpdateVariableSpanGridItemSize(variableSpanGridView, variableSpanLayout);
				}
				else if (property.PropertyName == VariableSpanGridItemsLayout.ItemSpanSizeLookupProperty.PropertyName)
				{
					UpdateVariableSpanGridLookup(variableSpanGridView, variableSpanLayout);
					UpdateVariableSpanGridItemSize(variableSpanGridView, variableSpanLayout);
				}
			}
		}*/

		protected override ListViewBase SelectListViewBase()
		{
			switch (Layout)
			{
				case VariableSpanGridItemsLayout variableSpanLayout:
					var gridView = new FormsVariableSpanGridView() { VerticalContentAlignment = VerticalAlignment.Stretch };
					UpdateVariableSpanGridLookup(gridView, variableSpanLayout);
					UpdateVariableSpanGridItemSize(gridView, variableSpanLayout);
					UpdateVariableSpanGridSpacing(gridView, variableSpanLayout);
					return gridView;
				default:
					return base.SelectListViewBase();
			}
		}

		protected override void UpdateItemTemplate()
		{
			if (Element != null && Element.IsGrouped)
			{
				base.UpdateItemTemplate();
				return;
			}

			if (Element == null || ListViewBase == null)
			{
				return;
			}

			ListViewBase.ItemTemplate = Element.ItemTemplate == null ? null : VariableSpanCollectionViewTemplates.GetItemTemplate();

			UpdateItemsSource();
		}

		void UpdateVariableSpanGridItemSize(FormsVariableSpanGridView gridView, VariableSpanGridItemsLayout itemsLayout)
		{
			var itemWidth = itemsLayout.ItemWidth + itemsLayout.HorizontalItemSpacing;
			var itemHeight = itemsLayout.ItemHeight + itemsLayout.VerticalItemSpacing;
			gridView.ItemsPanel = itemsLayout.ItemSpanLookup != null ? VariableSpanCollectionViewTemplates.GetVariableSizedWrapGrid(itemWidth, itemHeight) : VariableSpanCollectionViewTemplates.GetItemsWrapGrid(itemWidth, itemHeight);
		}

		void UpdateVariableSpanGridLookup(FormsVariableSpanGridView gridView, VariableSpanGridItemsLayout itemsLayout)
		{
			gridView.ItemSpanLookup = itemsLayout.ItemSpanLookup;
		}

		void UpdateVariableSpanGridSpacing(FormsVariableSpanGridView gridView, VariableSpanGridItemsLayout itemsLayout)
		{
			var horizontalPadding = -itemsLayout.HorizontalItemSpacing / 2.0;
			var verticalPadding = -itemsLayout.VerticalItemSpacing / 2.0;
			var padding = new WThickness(horizontalPadding, verticalPadding, horizontalPadding, verticalPadding);

			var itemHorizontalMargin = itemsLayout.HorizontalItemSpacing / 2.0;
			var itemVerticalMargin = itemsLayout.VerticalItemSpacing / 2.0;
			var itemMargin = new WThickness(itemHorizontalMargin, itemVerticalMargin, itemHorizontalMargin, itemVerticalMargin);
			var itemContainerStyle = new WStyle(typeof(GridViewItem));
			itemContainerStyle.Setters.Add(new WSetter(FrameworkElement.MarginProperty, itemMargin));

			gridView.Padding = padding;
			gridView.ItemContainerStyle = itemContainerStyle;
		}
	}
}
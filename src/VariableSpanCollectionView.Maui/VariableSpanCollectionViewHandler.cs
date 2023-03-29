using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Controls = Microsoft.Maui.Controls;

namespace VariableSpanCollectionView.Maui
{
	public partial class VariableSpanCollectionViewHandler
	{
		public VariableSpanCollectionViewHandler() : base(VariableSpanCollectionViewMapper)
		{

		}
		public VariableSpanCollectionViewHandler(PropertyMapper mapper = null) : base(mapper ?? VariableSpanCollectionViewMapper)
		{

		}

		public static PropertyMapper<VariableSpanCollectionView, VariableSpanCollectionViewHandler> VariableSpanCollectionViewMapper = new PropertyMapper<VariableSpanCollectionView, VariableSpanCollectionViewHandler>(ViewMapper)
		{
			[Controls.ItemsView.ItemsSourceProperty.PropertyName] = MapItemsSource,
			[Controls.ItemsView.HorizontalScrollBarVisibilityProperty.PropertyName] = MapHorizontalScrollBarVisibility,
			[Controls.ItemsView.VerticalScrollBarVisibilityProperty.PropertyName] = MapVerticalScrollBarVisibility,
			[Controls.ItemsView.ItemTemplateProperty.PropertyName] = MapItemTemplate,
			[Controls.ItemsView.EmptyViewProperty.PropertyName] = MapEmptyView,
			[Controls.ItemsView.EmptyViewTemplateProperty.PropertyName] = MapEmptyViewTemplate,
			[Controls.ItemsView.FlowDirectionProperty.PropertyName] = MapFlowDirection,
			[Controls.ItemsView.IsVisibleProperty.PropertyName] = MapIsVisible,
			[Controls.ItemsView.ItemsUpdatingScrollModeProperty.PropertyName] = MapItemsUpdatingScrollMode,
			[StructuredItemsView.HeaderTemplateProperty.PropertyName] = MapHeaderTemplate,
			[StructuredItemsView.FooterTemplateProperty.PropertyName] = MapFooterTemplate,
			[StructuredItemsView.ItemsLayoutProperty.PropertyName] = MapItemsLayout,
			[StructuredItemsView.ItemSizingStrategyProperty.PropertyName] = MapItemSizingStrategy,
			[ReorderableItemsView.CanReorderItemsProperty.PropertyName] = MapCanReorderItems,
			//[SelectableItemsView.SelectedItemProperty.PropertyName] = MapSelectedItem,
			//[SelectableItemsView.SelectedItemsProperty.PropertyName] = MapSelectedItems,
			//[SelectableItemsView.SelectionModeProperty.PropertyName] = MapSelectionMode,
			//[GroupableItemsView.IsGroupedProperty.PropertyName] = MapIsGrouped
		};
	}
}
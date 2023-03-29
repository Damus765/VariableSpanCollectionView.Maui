using System;
using AndroidX.RecyclerView.Widget;
using Microsoft.Maui.Controls.Handlers.Items;

namespace VariableSpanCollectionView.Maui
{
	public partial class VariableSpanCollectionViewHandler : GroupableItemsViewHandler<VariableSpanCollectionView>
	{
		new protected VariableSpanCollectionViewAdapter<VariableSpanCollectionView, IGroupableItemsViewSource> CreateAdapter() => new(VirtualView);

		protected override RecyclerView CreateNativeView() =>
			new VariableSpanMauiRecyclerView<VariableSpanCollectionView, VariableSpanCollectionViewAdapter<VariableSpanCollectionView, IGroupableItemsViewSource>, IGroupableItemsViewSource>(Context, GetItemsLayout, CreateAdapter);

		public static void MapCanReorderItems(VariableSpanCollectionViewHandler handler, VariableSpanCollectionView itemsView)
		{
			(handler.NativeView as IVariableSpanMauiRecyclerView<VariableSpanCollectionView>)?.UpdateCanReorderItems();
		}
	}
}
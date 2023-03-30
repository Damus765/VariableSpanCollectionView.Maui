using AndroidX.RecyclerView.Widget;
using Microsoft.Maui.Controls.Handlers.Items;

namespace VariableSpanCollectionView.Maui
{
	public partial class VariableSpanCollectionViewHandler : ReorderableItemsViewHandler<VariableSpanCollectionView>
	{
		new protected VariableSpanCollectionViewAdapter<VariableSpanCollectionView, IGroupableItemsViewSource> CreateAdapter() => new(VirtualView);

		protected override RecyclerView CreatePlatformView() =>
			new VariableSpanMauiRecyclerView<VariableSpanCollectionView, VariableSpanCollectionViewAdapter<VariableSpanCollectionView, IGroupableItemsViewSource>, IGroupableItemsViewSource>(Context, GetItemsLayout, CreateAdapter);
	}
}
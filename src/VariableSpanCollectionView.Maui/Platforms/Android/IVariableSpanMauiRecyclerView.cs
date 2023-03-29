using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Handlers.Items;

namespace VariableSpanCollectionView.Maui
{
	public interface IVariableSpanMauiRecyclerView<TItemsView> : IMauiRecyclerView<TItemsView>
		where TItemsView : ItemsView
	{
		void UpdateCanReorderItems();
	}
}
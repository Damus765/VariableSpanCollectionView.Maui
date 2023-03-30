using Microsoft.Maui;

namespace VariableSpanCollectionView.Maui
{
	public partial class VariableSpanCollectionViewHandler
	{
		public VariableSpanCollectionViewHandler() : base(ReorderableItemsViewMapper)
		{

		}

		public VariableSpanCollectionViewHandler(PropertyMapper mapper = null) : base(mapper ?? ReorderableItemsViewMapper)
		{

		}
	}
}
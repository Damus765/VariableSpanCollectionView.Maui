using VariableSpanCollectionViewDemos.ViewModels;
using Microsoft.Maui.Controls;

namespace VariableSpanCollectionViewDemos.Views
{
    public partial class VerticalGridGroupingCanMixGroupsPage : ContentPage
    {
        public VerticalGridGroupingCanMixGroupsPage()
        {
            InitializeComponent();
            BindingContext = new GroupedAnimalsViewModel();
        }
	}
}

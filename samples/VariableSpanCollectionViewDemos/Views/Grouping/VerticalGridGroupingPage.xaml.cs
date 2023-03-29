using VariableSpanCollectionViewDemos.ViewModels;
using Microsoft.Maui.Controls;

namespace VariableSpanCollectionViewDemos.Views
{
    public partial class VerticalGridGroupingPage : ContentPage
    {
        public VerticalGridGroupingPage()
        {
            InitializeComponent();
            BindingContext = new GroupedAnimalsViewModel();
        }
    }
}

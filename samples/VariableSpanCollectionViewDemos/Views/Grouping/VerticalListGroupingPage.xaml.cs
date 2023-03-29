using VariableSpanCollectionViewDemos.ViewModels;
using Microsoft.Maui.Controls;

namespace VariableSpanCollectionViewDemos.Views
{
    public partial class VerticalListGroupingPage : ContentPage
    {
        public VerticalListGroupingPage()
        {
            InitializeComponent();
            BindingContext = new GroupedAnimalsViewModel();
        }
    }
}

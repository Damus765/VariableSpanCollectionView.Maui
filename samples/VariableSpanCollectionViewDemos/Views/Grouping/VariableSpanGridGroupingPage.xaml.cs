using VariableSpanCollectionViewDemos.ViewModels;
using Microsoft.Maui.Controls;

namespace VariableSpanCollectionViewDemos.Views
{
    public partial class VariableSpanGridGroupingPage : ContentPage
    {
        public VariableSpanGridGroupingPage()
        {
            InitializeComponent();
            BindingContext = new GroupedAnimalsViewModel();
        }
    }
}

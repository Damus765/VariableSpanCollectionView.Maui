using Microsoft.Maui.Controls;
using VariableSpanCollectionViewDemos.ViewModels;

namespace VariableSpanCollectionViewDemos.Views
{
    public partial class VerticalGridPage : ContentPage
    {
        public VerticalGridPage()
        {
            InitializeComponent();
            BindingContext = new MonkeysViewModel();
        }
    }
}

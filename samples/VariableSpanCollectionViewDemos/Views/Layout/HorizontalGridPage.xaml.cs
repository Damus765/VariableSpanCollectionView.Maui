using Microsoft.Maui.Controls;
using VariableSpanCollectionViewDemos.ViewModels;

namespace VariableSpanCollectionViewDemos.Views
{
    public partial class HorizontalGridPage : ContentPage
    {
        public HorizontalGridPage()
        {
            InitializeComponent();
            BindingContext = new MonkeysViewModel();
        }
    }
}

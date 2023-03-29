using Microsoft.Maui.Controls;
using VariableSpanCollectionViewDemos.ViewModels;

namespace VariableSpanCollectionViewDemos.Views
{
    public partial class HorizontalListPage : ContentPage
    {
        public HorizontalListPage()
        {
            InitializeComponent();
            BindingContext = new MonkeysViewModel();
        }
    }
}

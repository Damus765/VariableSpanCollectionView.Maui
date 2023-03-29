using Microsoft.Maui.Controls;
using VariableSpanCollectionViewDemos.ViewModels;

namespace VariableSpanCollectionViewDemos.Views
{
    public partial class VerticalListPage : ContentPage
    {
        public VerticalListPage()
        {
            InitializeComponent();
            BindingContext = new MonkeysViewModel();
        }
    }
}

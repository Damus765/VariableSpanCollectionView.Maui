using Microsoft.Maui.Controls;
using VariableSpanCollectionViewDemos.ViewModels;

namespace VariableSpanCollectionViewDemos.Views
{
    public partial class VariableSpanGridPage : ContentPage
    {
        public VariableSpanGridPage()
        {
            InitializeComponent();
            BindingContext = new MonkeysViewModel();
        }
    }
}

using VariableSpanCollectionViewDemos.ViewModels;
using Microsoft.Maui.Controls;

namespace VariableSpanCollectionViewDemos.Views
{
    public partial class VariableSpanGridSpacingPage : ContentPage
    {
        public VariableSpanGridSpacingPage()
        {
            InitializeComponent();
            BindingContext = new MonkeysViewModel();
        }
    }
}

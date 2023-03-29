using Microsoft.Maui.Controls;
using VariableSpanCollectionViewDemos.ViewModels;
using VariableSpanCollectionView.Maui;
using VariableSpanCollectionViewDemos.Models;

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

using Microsoft.Maui.Controls;
using VariableSpanCollectionViewDemos.ViewModels;
using VariableSpanCollectionView.Maui;
using VariableSpanCollectionViewDemos.Models;

namespace VariableSpanCollectionViewDemos.Views
{
	public partial class VariableSpanGridSizingPage : ContentPage, IItemSpanLookup
	{
		public VariableSpanGridSizingPage()
		{
			InitializeComponent();
			VariableSpanLayout.ItemSpanLookup = this;
			BindingContext = new MonkeysViewModel();
		}

		public int GetColumnSpan(object item)
		{
			if (item is Monkey monkey && monkey.Name == "Blue Monkey")
			{
				return 2;
			}
			return 1;
		}
	}
}

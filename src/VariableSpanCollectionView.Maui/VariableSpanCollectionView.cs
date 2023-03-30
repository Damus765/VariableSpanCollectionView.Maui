using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Internals;
using Microsoft.Maui.Graphics;

namespace VariableSpanCollectionView.Maui
{
	public class VariableSpanCollectionView : CollectionView
	{
		INotifyCollectionChanged _notifyCollection;
		IItemsLayout _itemsLayout;
		IPlatformSizeService _platformSizeService;

		void HandleCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (ItemsLayout is VariableSpanGridItemsLayout)
			{
				var invalidateMeasure = () => InvalidateMeasureNonVirtual(InvalidationTrigger.MeasureChanged);
				if (Dispatcher.IsDispatchRequired)
				{
					Dispatcher.Dispatch(invalidateMeasure);
				}
				else
				{
					invalidateMeasure();
				}
			}
		}

		void HandleLayoutPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (ItemsLayout is VariableSpanGridItemsLayout)
			{
				InvalidateMeasureNonVirtual(InvalidationTrigger.MeasureChanged);
			}
		}

		protected virtual void OnItemsLayoutChanged()
		{
			if (_itemsLayout != null)
			{
				_itemsLayout.PropertyChanged -= HandleLayoutPropertyChanged;
			}
			_itemsLayout = ItemsLayout;
			if (_itemsLayout != null)
			{
				_itemsLayout.PropertyChanged += HandleLayoutPropertyChanged;
			}

			if (ItemsLayout is VariableSpanGridItemsLayout)
			{
				InvalidateMeasureNonVirtual(InvalidationTrigger.MeasureChanged);
			}
		}

		protected virtual void OnItemsSourceChanged()
		{
			if (_notifyCollection != null)
			{
				_notifyCollection.CollectionChanged -= HandleCollectionChanged;
			}
			_notifyCollection = ItemsSource as INotifyCollectionChanged;
			if (_notifyCollection != null)
			{
				_notifyCollection.CollectionChanged += HandleCollectionChanged;
			}

			if (ItemsLayout is VariableSpanGridItemsLayout)
			{
				InvalidateMeasureNonVirtual(InvalidationTrigger.MeasureChanged);
			}
		}

		protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
		{
			if (ItemsLayout is VariableSpanGridItemsLayout)
			{
				if (!IsPlatformEnabled)
					return new SizeRequest(new Size(-1, -1));

				if (Handler != null)
					return new SizeRequest(Handler.GetDesiredSize(widthConstraint, heightConstraint));

				_platformSizeService ??= DependencyService.Get<IPlatformSizeService>();
				return _platformSizeService.GetPlatformSize(this, widthConstraint, heightConstraint);
			}
			else
			{
				return base.OnMeasure(widthConstraint, heightConstraint);
			}
		}

		protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			if (propertyName == ItemsLayoutProperty.PropertyName)
			{
				OnItemsLayoutChanged();
			}
			else if (propertyName == ItemsSourceProperty.PropertyName)
			{
				OnItemsSourceChanged();
			}

			base.OnPropertyChanged(propertyName);
		}
	}
}
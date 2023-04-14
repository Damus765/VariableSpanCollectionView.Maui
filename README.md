# VariableSpanCollectionView for .NET MAUI

This is a fork of Bill Venhaus' [ReorderableCollectionView](https://github.com/billvenhaus/ReorderableCollectionView.Maui). Drag-and-drop item reordering has been [merged to MAUI's CollectionView](https://github.com/dotnet/maui/pull/3768), but the VariableSpanGridItemsLayout [issue is still pending](https://github.com/dotnet/maui/issues/3803). This fork removes the reordering capabilities of the ReorderableCollectionView, to use those of MAUI's CollectionView, but keeps the VariableSpanGridItemsLayout.

The VariableSpanCollectionView extends the standard [CollectionView](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.collectionview) to include support for a new [ItemsLayout](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.structureditemsview.itemslayout) called `VariableSpanGridItemsLayout`.

Aside from that, it will behave & function exactly as the standard `CollectionView`. The existing `GridItemsLayout` & `LinearItemLayout` are also compatible with this new control.

![VariableSpanCollectionView on iOS](images/variablespangriditemslayout_android.gif)

<br/>

The `VariableSpanGridItemsLayout` is much like the [GridItemsLayout](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.griditemslayout) however it does not have a fixed span. It instead has a column span which will vary based on the size of the control. Rather than having item sizes that grow & shrink, the span will grow & shrink. If desired, items can span multiple columns by supplying a custom lookup.


![VariableSpanGridItemsLayout on Windows](images/variablespangriditemslayout_windows.gif)
<!-- ![VariableSpanGridItemsLayout on Android](images/variablespangriditemslayout_android.gif) -->

# Getting started

Register the view handlers in `MauiProgram.cs`. To do this, have the builder call `RegisterVariableSpanCollectionView()`.

```c#
public static MauiApp CreateMauiApp()
{
	var builder = MauiApp.CreateBuilder();
	builder
		.UseMauiApp<App>()
		.RegisterVariableSpanCollectionView();
	return builder.Build();
}
```

Then simply add the namespace declaration to your files:

In your C# pages, add:

```c#
using VariableSpanCollectionView.Maui;
```

In your XAML page, add the namespace attribute:

```xml
xmlns:vscv="clr-namespace:VariableSpanCollectionView.Maui;assembly=VariableSpanCollectionView.Maui"
```

# Syntax

Here's the sytax if you'd like to try the new `VariableSpanGridItemsLayout`.

```xml
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:vscv="clr-namespace:VariableSpanCollectionView.Maui;assembly=VariableSpanCollectionView.Maui"
             x:Class="MyLittleApp.MainPage">

     <Grid>

        <vscv:VariableSpanCollectionView ItemsSource="{Binding Monkeys}">
           <vscv:VariableSpanCollectionView.ItemsLayout>
              <vscv:VariableSpanGridItemsLayout ItemWidth="150" ItemHeight="80"
                                                VerticalItemSpacing="5"
                                                HorizontalItemSpacing="5" />
           </vscv:VariableSpanCollectionView.ItemsLayout>
        </vscv:VariableSpanCollectionView>

    </Grid>

</ContentPage>
```

The default column span for each item within a `VariableSpanGridItemsLayout` is 1. This can be overridden by supplying an optional custom `ItemSpanLookup`. (Optional)

```C#
public class SpanLookup : ISpanLookup
{
    public int GetColumnSpan(object item)
    {
        if (item is Monkey monkey && monkey.Name == "Blue Monkey")
        {
            return 2;
        }
        return 1;
    }
}

```

# Properties

Properties for the VariableSpanGridItemsLayout 

| Property | Type | Description |
| --- | --- | --- |
| `ItemWidth`| double | Gets or sets the width of the layout area for each item contained within the grid. |
| `ItemHeight`| double | Gets or sets the height of the layout area for each item contained within the grid. |
| `HorizontalItemSpacing`| double | Gets or sets the horizontal spacing between items. |
| `VerticalItemSpacing`| double | Gets or sets the vertical spacing between items. |
| `ItemSpanLookup`| IItemSpanLookup | Gets or sets a lookup that can assign custom column spans to each item. |

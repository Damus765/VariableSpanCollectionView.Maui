using System;
using Microsoft.Maui.Hosting;

namespace VariableSpanCollectionView.Maui
{
	public static class VariableSpanCollectionViewRegistrationExtensions
	{
		public static MauiAppBuilder RegisterVariableSpanCollectionView(this MauiAppBuilder appHostBuilder)
		{
			if (appHostBuilder is null)
			{
				throw new ArgumentNullException(nameof(appHostBuilder));
			}

			appHostBuilder.ConfigureMauiHandlers(handlers => handlers.AddHandler<VariableSpanCollectionView, VariableSpanCollectionViewHandler>());

			return appHostBuilder;
		}
	}
}
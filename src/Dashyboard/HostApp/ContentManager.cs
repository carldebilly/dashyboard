using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.ApplicationModel.AppExtensions;
using Windows.ApplicationModel.AppService;
using Windows.Foundation.Collections;

namespace HostApp
{
	internal class ContentManager : IDisposable
	{
		private readonly AppExtensionCatalog _catalog;
		private IReadOnlyList<AppExtension> _packages;

		public ContentManager()
		{
			_catalog = AppExtensionCatalog.Open("Dashyboard-Content");
			Init();
		}

		public async Task Init()
		{
			_packages = (await _catalog.FindAllAsync()).ToArray();

			_catalog.PackageInstalled += CatalogOnPackageInstalled;
			_catalog.PackageStatusChanged += CatalogOnPackageStatusChanged;

			foreach (var p in _packages)
			{
				EstablishConnection(p);
			}
		}

		private async void EstablishConnection(AppExtension appExtension)
		{
			using (var conn = new AppServiceConnection())
			{
				conn.AppServiceName = "Dashyboard-Content";
				conn.PackageFamilyName = appExtension.Package.Id.FamilyName;

				var status = await conn.OpenAsync();

				conn.RequestReceived += (sender, args) => { };

				var msg = new ValueSet
				{
					{"Request", "Value"}
				};

				var response=  await conn.SendMessageAsync(msg);

				var responseMsg = response.Message;

				await Task.Delay(10000);
			}
		}

		private void CatalogOnPackageStatusChanged(AppExtensionCatalog sender, AppExtensionPackageStatusChangedEventArgs args)
		{
		}

		private void CatalogOnPackageInstalled(AppExtensionCatalog sender, AppExtensionPackageInstalledEventArgs args)
		{
		}

		public void Dispose()
		{
			//_catalog.Dispose();
		}
	}
}

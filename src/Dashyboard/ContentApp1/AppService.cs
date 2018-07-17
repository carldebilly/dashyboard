using System;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.AppService;
using Windows.ApplicationModel.Background;
using Windows.Foundation.Collections;

namespace ContentApp1
{
	internal class AppService
	{
		private BackgroundTaskDeferral _serviceDeferral;
		private IBackgroundTaskInstance _instance;
		private AppServiceTriggerDetails _serviceDetails;
		private AppServiceConnection _connection;

		public AppService(BackgroundActivatedEventArgs args)
		{
			_instance = args.TaskInstance;
			_serviceDetails = _instance.TriggerDetails as AppServiceTriggerDetails;
			_serviceDeferral = _instance.GetDeferral();
			_instance.Canceled += OnInstanceCanceled;
			_connection = _serviceDetails.AppServiceConnection;
			_connection.RequestReceived += ConnectionOnRequestReceived;
			_connection.ServiceClosed += ConnectionOnServiceClosed;
		}

		private void ConnectionOnServiceClosed(AppServiceConnection sender, AppServiceClosedEventArgs args)
		{
		}

		private async void ConnectionOnRequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
		{
			var messageDeferral = args.GetDeferral();
			var message = args.Request.Message;
			string text = message["Request"] as string;

			if ("Value" == text)
			{
				var returnMessage = new ValueSet
				{
					{"Response", "True"}
				};
				await args.Request.SendResponseAsync(returnMessage);
			}
			messageDeferral.Complete();

			var msg2 = new ValueSet
			{
				{ "Unsollicitated", "True" }
			};

			await _connection.SendMessageAsync(msg2);
		}

		private void OnInstanceCanceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason)
		{
		}
	}
}

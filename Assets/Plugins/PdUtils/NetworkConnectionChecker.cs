using System;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;

namespace PdUtils
{
	public static class NetworkConnectionChecker
	{
		public static void Check(Action success, Action fail)
		{
			if (Application.internetReachability == NetworkReachability.NotReachable)
			{
				fail?.Invoke();
				return;
			}

			try
			{
				var request = UnityWebRequest.Get("https://search.yahoo.com");
				var async = request.SendWebRequest();
				async.completed += _ =>
				{
					var someError = request.result == UnityWebRequest.Result.ConnectionError
					                || request.result == UnityWebRequest.Result.ProtocolError
					                || request.responseCode != (long) HttpStatusCode.OK;
					if (someError)
						fail?.Invoke();
					else
						success?.Invoke();
				};
			}
			catch (Exception e)
			{
				fail?.Invoke();
			}
		}
	}
}
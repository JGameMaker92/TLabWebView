using UnityEngine;

namespace TLab.Android.WebView
{
	[RequireComponent(typeof(TLabWebView))]
	public class TLabWebViewAutoPlay : MonoBehaviour
	{
		private TLabWebView webView;

		[Tooltip("Enable or disable autoplay for YouTube videos")]
		public bool enableAutoplay = true;

		private void Awake()
		{
			webView = GetComponent<TLabWebView>();
		}

		private void Start()
		{
			if (webView != null)
			{
				webView.Init();
			}
			else
			{
				Debug.LogError("TLabWebView component is not found on the GameObject.");
			}
		}

		public void LoadUrl(string url)
		{
			string modifiedUrl = EnsureYoutubeAutoplay(url);
			webView.LoadUrl(modifiedUrl);
		}

		private string EnsureYoutubeAutoplay(string url)
		{
			if (enableAutoplay && (url.Contains("youtube.com") || url.Contains("youtu.be")))
			{
				if (!url.Contains("autoplay=1"))
				{
					if (url.Contains("?"))
					{
						url += "&autoplay=1";
					}
					else
					{
						url += "?autoplay=1";
					}
				}
			}
			return url;
		}
	}
}

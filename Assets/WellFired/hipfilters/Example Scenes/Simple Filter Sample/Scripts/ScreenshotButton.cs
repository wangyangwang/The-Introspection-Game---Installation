using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

namespace WellFired
{
	public class ScreenshotButton : MonoBehaviour 
	{
		public Filters ActiveFilter 
		{
			get;
			set;
		}

		public Camera CameraToFilter 
		{
			get;
			set;
		}
		
#if UNITY_STANDALONE
		private string openFile = string.Empty;
#endif

		private void Start() 
		{
			var button = GetComponent<Button>();
			button.onClick.AddListener(TakeScreenshot);

			if(!WellFired.Shared.OpenFactory.PlatformCanOpen())
				GameObject.Destroy(gameObject);
		}
	
		private void TakeScreenshot()
		{
#if UNITY_STANDALONE
			var screenshotPath = Application.persistentDataPath + "/Screenshot.png";
			if(File.Exists(screenshotPath))
				File.Delete(screenshotPath);

			var directory = (new FileInfo(screenshotPath)).Directory.FullName;
			if(!Directory.Exists(directory))
			   Directory.CreateDirectory(directory);

			HipFiltersHelper.TakeScreenShotWithFilter(screenshotPath, 2, CameraToFilter, ActiveFilter);

			openFile = screenshotPath;
#endif
		}

		private void Update()
		{
#if UNITY_STANDALONE
			if(openFile != string.Empty)
			{
				if(File.Exists(openFile))
				{
					var open = WellFired.Shared.OpenFactory.CreateOpen();
					open.OpenFolderToDisplayFile(openFile);
					openFile = string.Empty;
				}
			}
#endif
		}
	}
}
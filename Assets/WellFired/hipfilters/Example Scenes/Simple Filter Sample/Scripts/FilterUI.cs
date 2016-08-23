using System;
using System.Collections;
using UnityEngine;

namespace WellFired
{
	public class FilterUI : MonoBehaviour 
	{
		public Filters activeFilter = Filters.None;

		[SerializeField]
		private UnityEngine.UI.Button nextButton;

		[SerializeField]
		private UnityEngine.UI.Button previousButton;
		
		[SerializeField]
		private UnityEngine.UI.Text activeText;
		
		[SerializeField]
		private ScreenshotButton screenshotButton;
		
		[SerializeField]
		private Camera cameraToApplyFilter;

		private void Awake()
		{
			nextButton.onClick.AddListener(OnNextButton);
			previousButton.onClick.AddListener(OnPreviousButton);
		}

		private void OnNextButton()
		{
			var filterInt = (int)activeFilter;
			filterInt++;
			
			if(filterInt >= Enum.GetNames(typeof(Filters)).Length)
				filterInt = 0;

			activeFilter = (Filters)filterInt;
			SetupFilter();
		}

		private void OnPreviousButton()
		{
			var filterInt = (int)activeFilter;
			filterInt--;

			if(filterInt < 0)
				filterInt = Enum.GetNames(typeof(Filters)).Length - 1;
			
			activeFilter = (Filters)filterInt;
			SetupFilter();
		}

		private void Update()
		{
			if(Input.GetKeyUp(KeyCode.RightArrow))
			   OnNextButton();
			if(Input.GetKeyUp(KeyCode.LeftArrow))
			   OnPreviousButton();
			
			if(screenshotButton)
			{
				screenshotButton.ActiveFilter = activeFilter;
				screenshotButton.CameraToFilter = cameraToApplyFilter;
			}
		}

		private void SetupFilter()
		{
			activeText.text = activeFilter.ToString();
			HipFiltersHelper.ApplyFilterToCamera(cameraToApplyFilter, activeFilter);
		}
	}
}
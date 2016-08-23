using UnityEngine;
using System.Collections;

public static class myParameters {

	//CHAPTER ONE _ THE START
	public static int c1MinimalStayingTime = 40;
	public static int c1FadeTime = 10; //fadeouttime

	public static float cityAmbienceTargetVol = 0.5f;
	public static float cityAmbienceSoundFadeInRate = 0.04f;

	public static float fogFadeRelativeSpeed = 0.9f;
	public static float soundFadeRalativeSpeed = 1.0f;
	public static float sphereFadeRelativeSpeed = 0.5f;


	
	//CHAPTER TWO _ THE FRAGMENTS
	public static int c2TimeUntillEverythingFadeIn = 3;

	public static float c2StartFogDensity = 0.2f;
	public static float c2NormalFogDensity = 0.003f;
	public static int c2FadeInTime = 4;
	public static int c2fadeInTime = 3;
	
	public static int xRange = 200;
	public static int zRange = 200;

	public static int realWorldObjectStartHeight = 0;
	public static int realWorldOBjectEndHeight = -300;
	public static int halfRealObjectStartHeight = -200;
	public static int halfRealObjectEndHeight = -360;
	public static int abstractObjectStartHeight = -300;
	public static int abstractObjectEndHeight = -440;
	public static int startFadeOutHeight = -550;
	public static int sceneCutHeight = -630;

	public static int realWorldObjectNumber = 250;
	public static int halfRealObjectNumber = 100;
	public static int abstractObjectNumber = 240;

	public static Vector2 abstractObjectRange = new Vector2(1.0f,30.0f); //size

	public static float generatedObjectRotatationSpeed = 3.3f;

	
	//CHAPTER THREE _ THE DARKNESS                            
	public static float c3StartFogDensity = 0.09f;
	public static float c3NormalFogDensity = 0.001f;

	public static float waitingTimeTillSwtich = 20.0f;


	//CHAPTER FOUR _ THE ISLAND

	public static float heartScaleFadeOutSpeed = 100.0f;
	public static float enlargeRate = 3.0f;
	public static float lightAmplifyRate = 10.0f;
	public static int chapterFourLastingTime = 10000;



	//CHAPTER FIVE _ THE END


}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdManager : MonoBehaviour
{
    public static AdManager instance = null;

     private static BannerView bannerView;
     private static InterstitialAd interstitial;

    private static int interstitalFrequency = 2;
    private static int interstitialFrequencyCount = 0;


    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }


    void Start()
    {
        MobileAds.Initialize(initStatus => { });
        RequestBanner();
        RequestInterstitial();

        AdManager.ShowBanner();

    }

   


    private static void RequestBanner()
    {


        // Test IDs Andoird: ca-app-pub-3940256099942544/6300978111
        // ios: ca-app-pub-3940256099942544/2934735716

#if UNITY_ANDROID
             string adUnitId = "";
#elif UNITY_IPHONE
        string adUnitId = "";
#else
             string adUnitId = "unexpected_platform";
#endif

        bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);

        AdRequest request = new AdRequest.Builder().Build();

        bannerView.LoadAd(request);
    }

     public static void ShowBanner()
    {
        if (bannerView != null)
        {
            bannerView.Show();
        }
        else
        {

            RequestBanner();

        }
         
        

    }

     public static void HideBanner()
    {

      
        bannerView.Hide();
    }



    private static  void RequestInterstitial()
    {

        // Test IDs Andoird: ca-app-pub-3940256099942544/1033173712
        // ios: ca-app-pub-3940256099942544/4411468910



#if UNITY_ANDROID
               string adUnitId = "";
#elif UNITY_IPHONE
        string adUnitId = "";
#else
               string adUnitId = "unexpected_platform";
#endif

        interstitial = new InterstitialAd(adUnitId);
        AdRequest request = new AdRequest.Builder().Build();
        interstitial.LoadAd(request);
    }


    static public void ShowIntersitial()
    {
        if(interstitialFrequencyCount > interstitalFrequency)
        {

            if ((interstitial != null) &&  (interstitial.IsLoaded()))
             
            {
                interstitial.Show();
                interstitialFrequencyCount = 0;
            }
            else
            {
                RequestInterstitial();
            }
            
         }
        else
        {
            interstitialFrequencyCount++;

        }
    }
    


}

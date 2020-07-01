using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_ADS
using UnityEngine.Advertisements;
#endif
public class UnityAdControl : MonoBehaviour
{
    public static bool testMode = true;
    public static string gameId = "3686829";
    public static bool showAds = true;
    public static void ShowAd()
    {
#if UNITY_ADS
        ShowOptions options = new ShowOptions();
        options.resultCallback = Unpause;

        if (Advertisement.IsReady()) {
            Advertisement.Show(options);
        }

        MenuPauseComp.pausado = true;
        Time.timeScale = 0;
#endif
    }

    public static void Unpause(ShowResult result)
    {
#if UNITY_ADS
        MenuPauseComp.pausado = false;
        Time.timeScale = 1f;
#endif
    }

    public static void InitializeAds()
    {
#if UNITY_ADS
        Advertisement.Initialize(gameId, testMode);
#endif
    }
}
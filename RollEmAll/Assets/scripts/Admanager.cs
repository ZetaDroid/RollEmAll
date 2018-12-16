using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Admanager : MonoBehaviour
{

    static int i;
    static GameObject go;

    void Start ()
    {
        go = this.gameObject;
        i = 0;
        DontDestroyOnLoad(this.gameObject);
	}
	public static void Reset()
    {
        
        Destroy(go);
    }
	
	public static void CheckForAd()
    {
        i++;
        if (i >= 2)
        {
            ShowAd();
        }
    }
    private static void ShowAd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show(new ShowOptions() { resultCallback = HandleAdResult });
        }
    }

    private static void HandleAdResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                i = 0;
                break;
            case ShowResult.Skipped:
                break;
            case ShowResult.Failed:
                break;
        }
    }
}

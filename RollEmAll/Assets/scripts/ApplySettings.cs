using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplySettings : MonoBehaviour
{
    float Volume;
    bool toKeepD1,toKeepD2;

    GameObject dpad1, dpad2;

    void Awake()
    {
        toKeepD1 = Settings.LoadToKeepD1();
        toKeepD2 = Settings.LoadToKeepD2();
        Volume = Settings.LoadVolume();
        dpad1 = transform.Find("DPad1").gameObject;
        dpad2 = transform.Find("DPad2").gameObject;

        if (dpad1 != null)
        {
            dpad1.SetActive(toKeepD1);
        }
        if (dpad2 != null)
        {
            dpad2.SetActive(toKeepD2);
        }
        AudioListener.volume = Volume;
    }

	
}

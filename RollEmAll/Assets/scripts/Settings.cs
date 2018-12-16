using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class Settings 
{
    public static void SaveSettings(bool keepD1,bool KeepD2, float vol)
    {

        BinaryFormatter bf = new BinaryFormatter();
        FileStream settingsStream = new FileStream(Application.persistentDataPath + "/PlayerPreference.ball", FileMode.Create);
        PlayerPreferences  plPref = new PlayerPreferences(keepD1,KeepD2,vol);
        bf.Serialize(settingsStream, plPref);
        settingsStream.Close();
    }

    public static float LoadVolume()
    {
        if (File.Exists(Application.persistentDataPath + "/PlayerPreference.ball"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream settingsStream = new FileStream(Application.persistentDataPath + "/PlayerPreference.ball", FileMode.Open);
            PlayerPreferences plPref = bf.Deserialize(settingsStream) as PlayerPreferences;
            settingsStream.Close();
            return plPref.volume;
        }
        else
        {
            
            return 1f;
            //Debug.LogError("File Missing!"); 
        }
    }
    public static bool LoadToKeepD2()
    {
        if (File.Exists(Application.persistentDataPath + "/PlayerPreference.ball"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream settingsStream = new FileStream(Application.persistentDataPath + "/PlayerPreference.ball", FileMode.Open);
            PlayerPreferences plPref = bf.Deserialize(settingsStream) as PlayerPreferences;
            settingsStream.Close();
            return plPref.toKeepDpad2;
        }
        else
        {

            return true;
            //Debug.LogError("File Missing!"); 
        }
    }
    public static bool LoadToKeepD1()
    {
        if (File.Exists(Application.persistentDataPath + "/PlayerPreference.ball"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream settingsStream = new FileStream(Application.persistentDataPath + "/PlayerPreference.ball", FileMode.Open);
            PlayerPreferences plPref = bf.Deserialize(settingsStream) as PlayerPreferences;
            settingsStream.Close();
            return plPref.toKeepDpad1;
        }
        else
        {

            return true;
            //Debug.LogError("File Missing!"); 
        }
    }


}
[Serializable]
public class PlayerPreferences
{
    public float volume;
    public bool toKeepDpad1;
    public bool toKeepDpad2;
    public PlayerPreferences(bool keepD1, bool KeepD2, float vol)
    {
        volume = vol;
        toKeepDpad1 = keepD1;
        toKeepDpad2 = KeepD2;
    }
}

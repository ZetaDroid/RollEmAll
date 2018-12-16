using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class CanvasContainerRotation 
{
    public static void SaveRotation(float rotation)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream settingsStream = new FileStream(Application.persistentDataPath + "/cvsrt.ball", FileMode.Create);
        CvsRt cvsrt = new CvsRt(rotation);
        bf.Serialize(settingsStream, cvsrt);
        settingsStream.Close();
    }
    public static float LoadRotation()
    {
        if (File.Exists(Application.persistentDataPath + "/cvsrt.ball"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream settingsStream = new FileStream(Application.persistentDataPath + "/cvsrt.ball", FileMode.Open);
            CvsRt cvsrt = bf.Deserialize(settingsStream) as CvsRt;
            settingsStream.Close();
            return cvsrt.lchsrCvsRtQuat;
        }
        else
        {

            return 0f;
            //Debug.LogError("File Missing!"); 
        }
    }
    [Serializable]
    public class CvsRt
    {
        public float lchsrCvsRtQuat;
        public CvsRt(float rotationEuler)
        {
            lchsrCvsRtQuat = rotationEuler;
        }
    }
	
}

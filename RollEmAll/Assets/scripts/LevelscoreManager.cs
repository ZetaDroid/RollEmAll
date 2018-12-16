using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class LevelscoreManager
{

    //public float[] recordTimeArray = new float[37];

    public static void SavePlayer(int[] starRec,float[] timeRec, int recScore)
    {
        
        BinaryFormatter bf = new BinaryFormatter();
        FileStream timeRecordStream = new FileStream(Application.persistentDataPath + "/tr.ball",FileMode.Create);
        GameData data = new GameData(starRec,timeRec,recScore);
        bf.Serialize(timeRecordStream, data);
        timeRecordStream.Close();
    }
    
    //Load Record Time From File.
    public static float[] LoadRecordTime()
    {
        if (File.Exists(Application.persistentDataPath + "/tr.ball"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream timeRecordStream = new FileStream(Application.persistentDataPath + "/tr.ball", FileMode.Open);
            GameData data = bf.Deserialize(timeRecordStream) as GameData;
            timeRecordStream.Close();
            float[] returnData = data.recordTimeArraySerializable;
            return returnData;
        }
        else
        {
            return new float[37];
            //Debug.LogError("File Missing!"); 
        }
    }

    //Load Record Stars From File;
    public static int[] LoadRecordStar()
    {
        if (File.Exists(Application.persistentDataPath + "/tr.ball"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream timeRecordStream = new FileStream(Application.persistentDataPath + "/tr.ball", FileMode.Open);
            GameData data = bf.Deserialize(timeRecordStream) as GameData;
            timeRecordStream.Close();
            int[] returnData = data.recordStarArray;
            return returnData;
        }
        else
        {
            return new int[37];
            //Debug.LogError("File Missing!");
        }
    }
    public static int LoadRecordScore()
    {
        if (File.Exists(Application.persistentDataPath + "/tr.ball"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream timeRecordStream = new FileStream(Application.persistentDataPath + "/tr.ball", FileMode.Open);
            GameData data = bf.Deserialize(timeRecordStream) as GameData;
            timeRecordStream.Close();
            int returnData = data.recordScore;
            return returnData;
        }
        else
        {
            return 0;
            //Debug.LogError("File Missing!");
        }
    }


}
[Serializable]
public class GameData
{
    //initialize save data;
    public int[] recordStarArray = new int[37];
    public float[] recordTimeArraySerializable = new float[37];
    public int recordScore;
    public GameData(int[] starRec, float[] timeRec, int recScore)
    {
        recordStarArray = starRec;
        recordTimeArraySerializable = timeRec;
        recordScore = recScore;
        
    }

}

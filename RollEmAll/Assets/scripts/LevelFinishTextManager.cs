using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinishTextManager{

    public static string[] levelfailedStrings = new string[14] 
    {
        "OOPS!",//1
        "SLOW AND STEADY",//2
        "NOT AGAIN!",//3
        "STUPID BALL",//4
        "....?!?....",//5
        "LET'S TRY THAT AGAIN",//6
        "OH COME ON",//7
        "ALMOST HAD IT",//8
        "LITTLE TOO FAST MAYBE?",//9
        "UNLUCKY",//10
        "SPEED KILLS, YOU KNOW.",//11
        "ONE MORE TIME",//12
        "YOU DUMB WEIRD LOOKING BALL!",//13
        "LET'S JUST BLAME THE BALL AND TRY AGAIN"//14
    };
    public static string[] levelPassedStrings = new string[12] 
    {
        "YEAAAAHH!",//1
        "THEY SEE ME ROLLIN'..",//2
        "GREAT JOB",//3
        "THATS THE WAAAAAAAY THE BALL ROLLS",//4
        "FANTASTIC!",//5
        "THAT WAS AMAZING",//6
        "GRACEFULLY DONE",//7
        "NICE!",//8
        "FEELS GOOD DOESN'T IT?",//9
        "THAT BALL SHOULD BE PROUD",//10
        "NAILED IT!",//11
        "AWWWWWWWSOME!"//12
        

    };

    public static string RandLevelFailedText()
    {
        float rand = Random.Range(0f,13.9f);
        int randRound = (int)rand;
        return levelfailedStrings[randRound];
    }
    public static string RandLevelPassedText()
    {
        float rand = Random.Range(0f, 11.9f);
        int randRound = (int)rand;
        return levelPassedStrings[randRound];
    }



}

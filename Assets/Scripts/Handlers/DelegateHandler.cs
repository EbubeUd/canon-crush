using Assets.Scripts.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * DelegateHandler class defines the delegates that are used in this game
 */
public class DelegateHandler : MonoBehaviour
{
    // Declaration of the delegate that is meant to be invoked whenever a gun is fired
    public delegate void OnGunFired();

    public delegate void OnHighScoreReached(int Score);

    // Declaration of the delegate that is meant to be invoked whenever a box is destroyed
    public delegate void OnBoxDestroyed(ColumnType columnType, BoxType boxType);

    // Declaration of the delegate that is meant to be invoked whenever a box is spawned
    public delegate void OnBoxSpawned();

    //Called when a Combo is achieved
    public delegate void OnComboAchieved();

    //Called when a match is attained 
    public delegate void OnMatchAttained();

    public delegate void OnGamePaused(bool status);


    // Instance of the OnGunFired delegate
    public static OnGunFired GunFired;

    // Instance of the OnBoxDestroyed delegate
    public static OnBoxDestroyed BoxDestroyed;

    public static OnBoxSpawned BoxSpawned;

    public static OnComboAchieved ComboAchieved;

    public static OnHighScoreReached HighScoreReached;

    public static OnMatchAttained MatchAttained;

    public static OnGamePaused GamePaused;



}

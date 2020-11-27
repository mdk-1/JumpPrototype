using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script to control data to be serialized/deserialized

[System.Serializable]
public class PlayerData
{
    public string loadedPlayerName;
    public int loadedhighScore;

    //player name and high score for display
    public PlayerData (ScoreManager player)
    {
        loadedPlayerName = player.savedPlayerName;
        loadedhighScore = player.savedhighScore;
    }
}

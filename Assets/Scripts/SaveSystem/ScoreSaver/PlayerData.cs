using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    private readonly string _username;
    private int _maxScore;

    public PlayerData(string username, int maxScore)
    {
        _username = username;
        _maxScore = maxScore;
    }

    public string Username => _username;

    public int MaxScore => _maxScore;

    public void UpdateScore(int score)
    {
        if (score < 0)
            return;

        if(_maxScore < score)
            _maxScore = score; 
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    private readonly string _username;
    private int _maxScore;
    private int _lastScore;

    public PlayerData(string username, int maxScore, int lastScore)
    {
        _username = username;
        _maxScore = maxScore;
        _lastScore = lastScore;
    }

    public string Username => _username;

    public int MaxScore => _maxScore;
    public int LastScore => _lastScore;

    public void UpdateScore(int score)
    {
        if (score < 0)
            return;

        if(_maxScore < score)
            _maxScore = score;
        
        _lastScore = score;      
    }
}

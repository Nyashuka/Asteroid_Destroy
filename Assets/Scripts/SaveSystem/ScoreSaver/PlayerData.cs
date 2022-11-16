using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : IComparable<PlayerData>
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

    public int CompareTo(PlayerData other)
    {
        if (other == null)
            return 0;

        return _maxScore.CompareTo(other._maxScore);
    }

}

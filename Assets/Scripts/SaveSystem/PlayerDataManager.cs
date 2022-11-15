using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    private ISaveSystem _saveSystem;
    public List<PlayerData> PlayersData { get; private set; }
    public PlayerData CurrentPlayer { get; private set; }

    private void Awake()
    {
        DontDestroyOnLoad(this);
        _saveSystem = ServicesProvider.Instance.SaveSystem;

        SaveData data = _saveSystem.Load();

        PlayersData = data.GetPlayersData();
        CurrentPlayer = data.GetMainPlayer(); ;
    }

    public PlayerData TryGetPlayer(string username)
    {
        PlayerData player = null;

        try
        {
            player = PlayersData.First(x => x.Username.ToLower() == username.ToLower());
        }
        catch (System.Exception)
        {
            
        }

        return player;
    }

    public void UpdatePlayerData(int score)
    {
        CurrentPlayer.UpdateScore(score);

        SaveData();
    }

    public void SaveSomePlayer(string username, int score)
    {
        var player = TryGetPlayer(username);

        if (player != null)
        {
            player.UpdateScore(score);
        }
        else
        {
            PlayersData.Add(new PlayerData(username, score));
        }

        SaveData();
    }

    public void SaveData()
    {
        _saveSystem.Save(new SaveData(CurrentPlayer, PlayersData));
    }
}


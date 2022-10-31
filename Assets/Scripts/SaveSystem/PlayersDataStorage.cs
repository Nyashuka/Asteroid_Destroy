using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayersDataStorage : MonoBehaviour
{
    [SerializeField] private ServicesProvider _servicesProvider;

    private List<PlayerData> _playersData;
    public PlayerData _currentPlayer { get; private set; }
   
    private void Start()
    {
        DontDestroyOnLoad(this);

       _playersData = _servicesProvider.saveSystem.Load().GetPlayersData();
    }

    public PlayerData TryGetPlayer(string username)
    {
        var player = _playersData.First(x => x.Username.ToLower() == username.ToLower());

        return player;
    }

    public void UpdatePlayerData(int score)
    {
        _currentPlayer.UpdateScore(score);
        
        SaveData();
    }

    public bool TryCreateNewPlayer(string username)
    {
        if(TryGetPlayer(username) != null)
        {
            return false;
        }

        _playersData.Add(new PlayerData(username, 0, 0));

        return true;
    }

    public void SaveData()
    {
        _servicesProvider.saveSystem.Save(new SaveData(_playersData));
    }
}


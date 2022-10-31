using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayersDataStorage : MonoBehaviour
{
    private List<PlayerData> _playersData;
    private JsonSaveSystem _saveSystem;
   
    private void Start()
    {
        DontDestroyOnLoad(this);

        _saveSystem = new JsonSaveSystem();
        _playersData = new JsonSaveSystem().Load().GetPlayersDatas();
    }

    public PlayerData TryGetPlayer(string username)
    {
        var player = _playersData.First(x => x.Username.ToLower() == username.ToLower());

        return player;
    }

    public void UpdatePlayerData(PlayerData playerData)
    {
        var a = TryGetPlayer(playerData.Username); 
        a = playerData;
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
        _saveSystem.Save(new SaveData(_playersData));
    }
}


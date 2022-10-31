using System;
using System.Collections.Generic;

[Serializable]
public class SaveData
{
    public List<PlayerDataDTO> playersData;

    public SaveData()
    {
        playersData = new List<PlayerDataDTO>();
    }

    public SaveData(List<PlayerData> receivedlayersData)
    {
        playersData = new List<PlayerDataDTO>();

        foreach (PlayerData data in receivedlayersData)
        {
            playersData.Add(new PlayerDataDTO(data));
        }
    }

    public List<PlayerData> GetPlayersData()
    {
        List<PlayerData> returnPlayerData = new List<PlayerData>();

        foreach (var data in playersData)
        {
            returnPlayerData.Add(new PlayerData(data.username, data.maxScore, data.lastScore));
        }

        return returnPlayerData;
    }
}


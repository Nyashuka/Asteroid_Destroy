using System;
using System.Collections.Generic;

[Serializable]
public class SaveData
{
    public PlayerDataDTO mainPlayerData;

    public List<PlayerDataDTO> playersData;

    public SaveData()
    {
        playersData = new List<PlayerDataDTO>();
    }

    public SaveData(PlayerData receivedMainPlayerData, List<PlayerData> receivedlayersData)
    {
        mainPlayerData = new PlayerDataDTO(receivedMainPlayerData);
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
            returnPlayerData.Add(new PlayerData(data.username, data.maxScore));
        }

        return returnPlayerData;
    }

    public PlayerData GetMainPlayer()
    {
        if (mainPlayerData == null)
            return new PlayerData("Main", 0);

        return new PlayerData(mainPlayerData.username, mainPlayerData.maxScore);
    }
}


using System;
using System.Collections.Generic;
using SaveSystem.DTOs;
using SaveSystem.ScoreSaver;

[Serializable]
public class SaveData
{
    public PlayerDataDTO mainPlayerData;

    public List<PlayerDataDTO> playersData;

    public SaveData()
    {
        playersData = new List<PlayerDataDTO>();
    }

    public SaveData(PlayerScoreData receivedMainPlayerScoreData, List<PlayerScoreData> receivedlayersData)
    {
        mainPlayerData = new PlayerDataDTO(receivedMainPlayerScoreData);
        playersData = new List<PlayerDataDTO>();

        foreach (PlayerScoreData data in receivedlayersData)
        {
            playersData.Add(new PlayerDataDTO(data));
        }
    }

    public List<PlayerScoreData> GetPlayersData()
    {
        List<PlayerScoreData> returnPlayerData = new List<PlayerScoreData>();

        foreach (var data in playersData)
        {
            returnPlayerData.Add(new PlayerScoreData(data.username, data.maxScore));
        }

        return returnPlayerData;
    }

    public PlayerScoreData GetMainPlayer()
    {
        if (mainPlayerData == null)
            return new PlayerScoreData("Main", 0);

        return new PlayerScoreData(mainPlayerData.username, mainPlayerData.maxScore);
    }
}


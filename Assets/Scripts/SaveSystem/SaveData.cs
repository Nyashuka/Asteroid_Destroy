using System;
using System.Collections.Generic;

[Serializable]
public class SaveData
{
    public List<PlayerDataDTO> playersDatas;

    public SaveData(List<PlayerData> receivedlayersDatas)
    {
        playersDatas = new List<PlayerDataDTO>();

        foreach (PlayerData data in receivedlayersDatas)
        {
            playersDatas.Add(new PlayerDataDTO(data));
        }
    }

    public List<PlayerData> GetPlayersDatas()
    {
        List<PlayerData> returnPlayerDatas = new List<PlayerData>();

        foreach (var data in playersDatas)
        {
            returnPlayerDatas.Add(new PlayerData(data.username, data.maxScore, data.lastScore));
        }

        return returnPlayerDatas;
    }
}


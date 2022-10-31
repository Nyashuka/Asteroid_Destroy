using System;

[Serializable]
public class PlayerDataDTO
{
    public string username;
    public int maxScore;
    public int lastScore;

    public PlayerDataDTO(PlayerData playerData)
    {
        username = playerData.Username;
        maxScore = playerData.MaxScore;
        lastScore = playerData.LastScore;
    }
}


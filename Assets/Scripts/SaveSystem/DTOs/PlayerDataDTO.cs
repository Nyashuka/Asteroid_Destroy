using System;

[Serializable]
public class PlayerDataDTO
{
    public string username;
    public int maxScore;

    public PlayerDataDTO(PlayerData playerData)
    {
        username = playerData.Username;
        maxScore = playerData.MaxScore;
    }
}


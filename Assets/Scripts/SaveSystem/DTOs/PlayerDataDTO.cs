using System;
using SaveSystem.ScoreSaver;

namespace SaveSystem.DTOs
{
    [Serializable]
    public class PlayerDataDTO
    {
        public string username;
        public int maxScore;

        public PlayerDataDTO(PlayerScoreData playerScoreData)
        {
            username = playerScoreData.Username;
            maxScore = playerScoreData.MaxScore;
        }
    }
}


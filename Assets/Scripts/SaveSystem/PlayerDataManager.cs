using System.Collections.Generic;
using System.Linq;
using Core.Services.ServiceLocatorSystem;
using SaveSystem.Abstract;
using SaveSystem.ScoreSaver;

namespace SaveSystem
{
    public class PlayerDataManager : IService
    {
        private readonly ISaveSystem _saveSystem;
        public List<PlayerScoreData> PlayersData { get; private set; }
        public PlayerScoreData CurrentPlayerScore { get; private set; }

        public PlayerDataManager(ISaveSystem saveSystem)
        {
            _saveSystem = saveSystem;

            SaveData data = _saveSystem.Load();

            PlayersData = data.GetPlayersData();
            CurrentPlayerScore = data.GetMainPlayer(); ;
        }

        public PlayerScoreData TryGetPlayer(string username)
        {
            PlayerScoreData playerScore = null;

            try
            {
                playerScore = PlayersData.First(x => x.Username.ToLower() == username.ToLower());
            }
            catch (System.Exception)
            {
            
            }

            return playerScore;
        }

        public void UpdatePlayerData(int score)
        {
            CurrentPlayerScore.UpdateScore(score);

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
                PlayersData.Add(new PlayerScoreData(username, score));
            }

            SaveData();
        }

        public void SaveData()
        {
            _saveSystem.Save(new SaveData(CurrentPlayerScore, PlayersData));
        }
    }
}


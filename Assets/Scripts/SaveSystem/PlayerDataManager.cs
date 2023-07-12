using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Services.ServiceLocatorSystem;
using Services.ServiceLocatorSystem;

namespace SaveSystem
{
    public class PlayerDataManager : IService
    {
        private readonly ISaveSystem _saveSystem;
        public List<PlayerData> PlayersData { get; private set; }
        public PlayerData CurrentPlayer { get; private set; }

        public PlayerDataManager(ISaveSystem saveSystem)
        {
            _saveSystem = saveSystem;

            SaveData data = _saveSystem.Load();

            PlayersData = data.GetPlayersData();
            CurrentPlayer = data.GetMainPlayer(); ;
        }

        public PlayerData TryGetPlayer(string username)
        {
            PlayerData player = null;

            try
            {
                player = PlayersData.First(x => x.Username.ToLower() == username.ToLower());
            }
            catch (System.Exception)
            {
            
            }

            return player;
        }

        public void UpdatePlayerData(int score)
        {
            CurrentPlayer.UpdateScore(score);

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
                PlayersData.Add(new PlayerData(username, score));
            }

            SaveData();
        }

        public void SaveData()
        {
            _saveSystem.Save(new SaveData(CurrentPlayer, PlayersData));
        }
    }
}


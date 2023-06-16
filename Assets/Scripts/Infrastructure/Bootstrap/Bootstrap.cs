using UnityEngine;

namespace Infrastructure.Bootstrap
{
    [DefaultExecutionOrder(100)]
    public class Bootstrap : MonoBehaviour
    {
        private Game _game;
        
        public async void Awake()
        {
            DontDestroyOnLoad(gameObject);

            _game = new Game();
            
            await _game.Boot();
        }
    }
}

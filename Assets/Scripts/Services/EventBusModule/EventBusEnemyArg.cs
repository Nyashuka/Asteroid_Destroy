using Core.Enemies;

namespace Services.EventBusModule
{
    public class EventBusEnemyArg
    {
        private readonly Enemy _enemy;
        public Enemy Enemy => _enemy;
        
        public EventBusEnemyArg(Enemy enemy)
        {
            _enemy = enemy;
        }
    }
}
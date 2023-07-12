namespace Services.EventBusService
{
    public class IntEventBusArgs : EventBusArgs
    {
        private int _argumentValue;
        public int ArgumentValue => _argumentValue;

        public IntEventBusArgs(int argumentValue)
        {
            _argumentValue = argumentValue;
        }
    }
}
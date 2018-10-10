namespace PilotLib
{
    public class Airoplane
    {
        private int _speed;

        public Airoplane()
        {
            _speed = 0;
        }
        public int Speed { get { return _speed; } }


        internal void SetSpeed(int change)
        {
            _speed += change;
        }

    }
}

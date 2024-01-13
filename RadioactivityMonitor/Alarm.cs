namespace RadioactivityMonitor
{
    public class Alarm
    {
        private const double LowThreshold = 17;
        private const double HighThreshold = 21;

        private Sensor _sensor;

        bool _alarmOn = false;
        private long _alarmCount = 0;

        public Alarm(Sensor sensor)
        {
            _sensor = sensor;
        }

        public void Check()
        {
            double value = _sensor.NextMeasure();

            if (value < LowThreshold | HighThreshold  < value)
            {
                _alarmOn = true;
                _alarmCount += 1;
            }
        }

        public bool AlarmOn
        {
            get { return _alarmOn; }
        }
    }
}

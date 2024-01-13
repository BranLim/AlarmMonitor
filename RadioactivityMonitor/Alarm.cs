namespace RadioactivityMonitor
{
    public class Alarm
    {
        private const double LowThreshold = 17;
        private const double HighThreshold = 21;

        bool _alarmOn = false;
        private long _alarmCount = 0;

        public Func<double> SensorMeasurement { get; set; } = () => new Sensor().NextMeasure();

        public bool AlarmOn
        {
            get { return _alarmOn; }
        }

        public void Check()
        {
            double value = SensorMeasurement.Invoke();

            if (value < LowThreshold | HighThreshold < value)
            {
                _alarmOn = true;
                _alarmCount += 1;
            }
        }
    }
}
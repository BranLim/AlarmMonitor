namespace RadioactivityMonitor
{
    public class Alarm
    {
        public const double LowThreshold = 17;
        public const double HighThreshold = 21;

        bool _alarmOn = false;
        private long _alarmCount = 0;

        public Func<double> SensorMeasurement { get; set; } = () => new Sensor().NextMeasure();

        public bool AlarmOn
        {
            get { return _alarmOn; }
        }

        public long AlarmCount => _alarmCount;

        public void Check()
        {
            double value = SensorMeasurement.Invoke();
            /*
             * The if statement can be inverted and the function returned early.
             * This makes the code cleaner and easier to read.
             */
            if (value < LowThreshold | HighThreshold < value)
            {
                _alarmOn = true;
                /*
                 * _alarmCount can be removed if it is not used anywhere.
                 * Additional properties add an overhead to code maintenance.
                 */
                _alarmCount += 1;
            }
        }
    }
}
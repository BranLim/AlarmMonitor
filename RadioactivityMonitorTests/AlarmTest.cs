using RadioactivityMonitor;

namespace RadioactivityMonitorTests;

public class AlarmTest
{

    [Test]
    public void GivenMeasurementBelowThreshold_ThenAlarmIsSet()
    {
        var alarm = new Alarm
        {
            SensorMeasurement = () => Alarm.LowThreshold - 1
        };

        alarm.Check();

        Assert.IsTrue(alarm.AlarmOn, "Alarm should be true but received false");
    }
    
    [Test]
    public void GivenMeasurementAboveThreshold_ThenAlarmIsSet()
    {
        var alarm = new Alarm
        {
            SensorMeasurement = () => Alarm.HighThreshold + 1
        };

        alarm.Check();

        Assert.IsTrue(alarm.AlarmOn, "Alarm should be true but received false");
    }
    
    [Test]
    public void GivenMeasurementIsWithinThreshold_ThenAlarmIsNotSet()
    {
        var alarm = new Alarm
        {
            SensorMeasurement = () => Alarm.HighThreshold - 1
        };

        alarm.Check();

        Assert.IsFalse(alarm.AlarmOn, "Alarm should be false but received true");
    }
    
    [Test]
    public void GivenMeasurementIsHigherThanThreshold_ThenAlarmCountIs1()
    {
        var alarm = new Alarm
        {
            SensorMeasurement = () => Alarm.HighThreshold + 1
        };

        alarm.Check();

        Assert.That(alarm.AlarmCount, Is.EqualTo(1));
    }
    
    [Test]
    public void GivenMeasurementIsLowerThanThreshold_ThenAlarmCountIs1()
    {
        var alarm = new Alarm
        {
            SensorMeasurement = () => Alarm.LowThreshold - 1
        };

        alarm.Check();

        Assert.That(alarm.AlarmCount, Is.EqualTo(1));
    }
}
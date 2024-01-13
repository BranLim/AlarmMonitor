using RadioactivityMonitor;

namespace RadioactivityMonitorTests;

public class AlarmTest
{

    [Test]
    public void GivenMeasurementBelowThreshold_ThenAlarmIsSet()
    {
        var alarm = new Alarm();
        alarm.SensorMeasurement = () => 15;
        
        alarm.Check();

        Assert.IsTrue(alarm.AlarmOn);
    }
    
    [Test]
    public void GivenMeasurementAboveThreshold_ThenAlarmIsSet()
    {
        var alarm = new Alarm();
        alarm.SensorMeasurement = () => 30;
        
        alarm.Check();

        Assert.IsTrue(alarm.AlarmOn);
    }
    
    [Test]
    public void GivenMeasurementIsWithinThreshold_ThenAlarmIsNotSet()
    {
        var alarm = new Alarm();
        alarm.SensorMeasurement = () => 20;
        
        alarm.Check();

        Assert.IsFalse(alarm.AlarmOn);
    }
}
using RadioactivityMonitor;

namespace RadioactivityMonitorTests;

public class AlarmTest
{
    [SetUp]
    public void Setup()
    {
    }

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
    
    
}
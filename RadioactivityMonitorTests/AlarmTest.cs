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
        MockLowMeasureSensor mockSensor = new MockLowMeasureSensor();
        var alarm = new Alarm(mockSensor);
        
        alarm.Check();

        Assert.IsTrue(alarm.AlarmOn);
    }
    
    [Test]
    public void GivenMeasurementAboveThreshold_ThenAlarmIsSet()
    {
        MockHighMeasureSensor mockSensor = new MockHighMeasureSensor();
        var alarm = new Alarm(mockSensor);
        
        alarm.Check();

        Assert.IsTrue(alarm.AlarmOn);
    }
}
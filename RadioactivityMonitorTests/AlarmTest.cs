using RadioactivityMonitor;

namespace RadioactivityMonitorTests;

public class AlarmTest
{
    [Test]
    public void GivenMeasurementBelowThreshold_ThenAlarmIsSet()
    {
        var alarm = CreateAlarmWithSensorBelowThreshold();

        alarm.Check();

        Assert.IsTrue(alarm.AlarmOn, "Alarm should be true but received false");
    }


    [Test]
    public void GivenMeasurementAboveThreshold_ThenAlarmIsSet()
    {
        var alarm = CreateAlarmWithSensorAboveThreshold();

        alarm.Check();

        Assert.IsTrue(alarm.AlarmOn, "Alarm should be true but received false");
    }


    [Test]
    public void GivenMeasurementIsWithinThreshold_ThenAlarmIsNotSet()
    {
        var alarm = CreateAlarmWithSensorWithinThreshold();

        alarm.Check();

        Assert.IsFalse(alarm.AlarmOn, "Alarm should be false but received true");
    }

    [Test]
    public void GivenMeasurementIsHigherThanThreshold_ThenAlarmCountIs1()
    {
        var alarm = CreateAlarmWithSensorAboveThreshold();

        alarm.Check();

        Assert.That(alarm.AlarmCount, Is.EqualTo(1));
    }

    [Test]
    public void GivenMeasurementIsLowerThanThreshold_ThenAlarmCountIs1()
    {
        var alarm = CreateAlarmWithSensorBelowThreshold();

        alarm.Check();

        Assert.That(alarm.AlarmCount, Is.EqualTo(1));
    }

    [Test]
    public void GivenMeasurementIsWithinThreshold_ThenAlarmCountIs0()
    {
        var alarm = CreateAlarmWithSensorWithinThreshold();

        alarm.Check();

        Assert.That(alarm.AlarmCount, Is.EqualTo(0));
    }

    private static Alarm CreateAlarmWithSensorAboveThreshold() => new Alarm
    {
        SensorMeasurement = () => Alarm.HighThreshold + 1
    };

    private static Alarm CreateAlarmWithSensorBelowThreshold() => new Alarm
    {
        SensorMeasurement = () => Alarm.LowThreshold - 1
    };

    private static Alarm CreateAlarmWithSensorWithinThreshold() => new Alarm
    {
        SensorMeasurement = () => Alarm.LowThreshold + 1
    };
}
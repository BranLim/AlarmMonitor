using RadioactivityMonitor;

namespace RadioactivityMonitorTests;

public class MockLowMeasureSensor : Sensor
{
    public new double NextMeasure()
    {
        return 15;
    }
}
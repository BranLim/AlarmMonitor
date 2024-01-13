using RadioactivityMonitor;

namespace RadioactivityMonitorTests;

public class MockHighMeasureSensor : Sensor
{
    public new double NextMeasure()
    {
        return 30;
    }
}
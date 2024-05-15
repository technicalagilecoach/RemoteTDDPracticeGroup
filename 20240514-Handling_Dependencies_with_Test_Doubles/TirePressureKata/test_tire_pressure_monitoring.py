from alarm import Alarm
from sensor import Sensor
from fake_sensor import Fake_Sensor

def test_alarm_is_off_by_default():
    sensor = Fake_Sensor(0)
    alarm = Alarm(sensor)
    assert not alarm.is_alarm_on

def test_wether_alarm_is_switched_on_for_low_pressure():
    sensor = Fake_Sensor(16)
    alarm = Alarm(sensor)
    alarm.check()
    assert alarm.is_alarm_on

def test_wether_alarm_is_switched_on_for_high_pressure():
    sensor = Fake_Sensor(22)
    alarm = Alarm(sensor)
    alarm.check()
    assert alarm.is_alarm_on

def test_wether_alarm_is_switched_off_within_the_range():
    sensor = Fake_Sensor(18)
    alarm = Alarm(sensor)
    alarm.check()
    assert not alarm.is_alarm_on


class Fake_Sensor(object):

    def __init__(self, pressure):
        self.pressure = pressure
        
    def pop_next_pressure_psi_value(self):
        return self.pressure


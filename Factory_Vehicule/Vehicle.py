class vehicle:

    def __init__(self) :
        self.engine ="engine"
        self.color ="color"
        self.marque ="marque"
        self.type ="type"

    def preparation(self):
        pass

    def get_engine(self):
        return self.engine
    def get_color(self):
        return self.color
    def get_type(self):
        return self.type
    def get_marque(self):
        return self.marque
   
    def set_engine(self, engine):
        self.engine =engine
    def set_color(self, color):
        self.color =color
    def set_type(self, type):
         self.type =type
    def set_marque(self, marque):
         self.marque =marque

class ground_vehicle(vehicle):
    def __init__(self) :
        super().__init__()
        self.door =0
        self.wheel =0

    def get_door(self):
        return self.door
    
    def get_wheel(self):
        return self.wheel
    
    def set_door(self, door):
         self.door =door
    
    def set_wheel(self, wheel):
         self.wheel =wheel

class bus(ground_vehicle):

    def __init__(self) :
        super().__init__()
        self.color ="blue"
        self.marque ="autoEcole"
        self.type ="bus"
        self.door =3
        self.wheel =12


    def preparation(self):
        print("bus")


class car(ground_vehicle):

    def __init__(self) :
        super().__init__()
        self.color ="red"
        self.marque ="Ferrari"
        self.type ="car"
        self.door =4
        self.wheel =4
    def preparation(self):
        print("car")


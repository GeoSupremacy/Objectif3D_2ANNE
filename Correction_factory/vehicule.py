class color:
    def __init__(self, _value):
        self.value = _value

class vehicule:
    base_color = color("white")
    base_door = 4
  
    def __init__(self, _color, door =4):
        self. base_color = _color
        self.base_door = door
        self.serial_number = id(self)
        print("new vehicule: "+ self. base_color.value)
        print("base_door: "+ str(self.base_door))

    def start(self):
        print ("start -> {0}".format(self.serial_number))

    def stop(self):
         print ("stop ->{0}".format(self.serial_number))
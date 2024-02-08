from vehicule import*

class car(vehicule):
    
    def __init__(self, _color, door=2):
      super().__init__( _color, door)
      print("new car {0} ".format(self.base_color.value))
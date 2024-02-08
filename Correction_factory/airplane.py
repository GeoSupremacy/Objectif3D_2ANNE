from vehicule import*
class airplane(vehicule):
    def __init__(self, _color, door=2):
      super().__init__( _color, door)
    def take_off(self):
        print("take_off")
    def landing(self):
        print("landing")
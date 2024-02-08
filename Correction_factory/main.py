from car import*
from airplane import*
import os
import json


vehicules = []
to_save =[]
filename =os.path.join(os.path.dirname(__file__), "vehicules.txt")


def main():
   vehicules.append(vehicule(color("blue")))
   vehicules.append(car(color("red")))
   vehicules.append(airplane(color("red")))
   for v in vehicules:
       to_save.append("{0}".format(v.base_color.value))
       v.start()
       if(type(v) is airplane):
            v.take_off()
            v.landing()
       v.stop()

   with open(filename,'w') as file:
            json.dump(to_save, file, indent=4)

main()
input()
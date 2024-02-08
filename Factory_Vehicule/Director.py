import json
import os
from Factory import*


class Director:
    
    def __init__(self):
        self._bus_factory = bus_factory()
        self._car_factory = car_factory()
        self.all_vehicle=[]
        self.menu_choices = ["Add vehicle", "read all factory"]
        self.vehicle_choice=[ "Add Car", "Add bus"]
        self.filename =os.path.join(os.path.dirname(__file__), "vehicle.txt")
          
#region INIT
    def init_menu(self):
     print("Factory\n")
     index=1
     for choices in self.menu_choices:
        print(index," - ",choices)
        index+=1

    def init_menu_creation_vehicle(self):
        print("Creation vehicle\n")
        index=1
        for choices in self.vehicle_choice:
            print(index," - ",choices)
            index+=1

    def init_actions_menu(self):
        return [self.menu_vehicle, self.read_vehicle_json]
    
    
    def init_actions_vehicle(self):
         return [self.create_car, self.create_bus]


#endregion
    
#region CHOICE
    
    def select_menu(self):
        index =input()
        while(index.isdigit() == False or int(index) <=0 or int(index) > len(self.menu_choices)):
            index =input()
        return int(index)-1
    
    def select_vehicle(self):
        index =input()
        while(index.isdigit() == False or int(index) <=0 or int(index) > len(self.vehicle_choice)):
            index =input()
        return int(index)-1


    def menu_vehicle(self):
     
        actions_vehicle =self.init_actions_vehicle()
        self.init_menu_creation_vehicle()
        actions_vehicle[self.select_vehicle()]()
   

    def add_vehicle(self, result):
        self.all_vehicle.append(result)
        self.write_vehicle_json()
        print("add_vehicle")
#endregion
    
#region PRODUCT
    def create_car(self):
        print("Custom or not? (1/0)")
        index =input()
        while(index.isdigit() == False):
            index =input()

            self._car_factory.create(int(index))
            self.add_vehicle(self._car_factory.result())
            


    def create_bus(self):
         index =input()
         while(index.isdigit() == False):
            index =input()
         self._bus_factory.create(int(index))
         self.add_vehicle(self._bus_factory.result())

#endregion
   

#region JSON
    def write_vehicle_json(self):
        with open(self.filename,'w') as file:
            json.dump(self.all_vehicle, file, indent=4)
    
    def read_vehicle_json(self):
        data =open(self.filename)
        print(json.load(data))
#endregion
        

#region MENU
    def menu(self):
        actions_menu =self.init_actions_menu()
        self.init_menu()
        actions_menu[self.select_menu()]()
        self.menu()
#endregion
        

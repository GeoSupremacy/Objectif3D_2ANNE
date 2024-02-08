from Vehicle import*

class base_factory:
    def __init__(self) :
        
        self.set = ["Set color: ","Set door:" ,"Set engine:" ,"Set marque:" ,"Set type:" ,"Set wheel :" ]
    def create(self,param =0):
        pass
    def result(self):
        pass
    def custom():
        pass

class bus_factory(base_factory):

    def __init__(self) :
        super().__init__()
        self._bus =bus()

        self.action = [self._bus.set_color, self._bus.set_door, self._bus.set_engine, self._bus.set_marque, self._bus.set_type, self._bus.set_wheel ]
       

    def create(self, param =0):
         print("bus_factory")
         if(param==0):
            self._bus.preparation()
         else:
            self.custom()
    
    def custom(self):
        print("custom")
        index =0
        for action in self.action:
            print(self.set[index])
            action(input())
            index+=1
        self._bus.preparation()

    def result(self):
        return "{0} \n  {1} \n {2} \n  {3} ".format("Marque: "+self._bus.get_marque(),"engine: "+self._bus.get_engine() ,
                                                          "wheels: "+str(self._bus.get_wheel()),"door: "+str(self._bus.get_door()),"color: "+self._bus.get_color() )
        


class car_factory(base_factory):
     
    def __init__(self) :
        super().__init__()
        self._car =car()
        self.action = [self._car.set_color, self._car.set_door, self._car.set_engine, self._car.set_marque, self._car.set_type, self._car.set_wheel ]

    def create(self,param =0):
        print("car_factory")
        if(param==0):
            self._car.preparation()
        else:
            self.custom()

    def custom(self):
        print("custom")
        index =0
        for action in self.action:
            print(self.set[index])
            action(input())
            index+=1
        self._car.preparation()


    def result(self):
          return "{0} \n  {1} \n {2} \n  {3} ".format("Marque: "+self._car.get_marque(),"engine: "+self._car.get_engine() ,
                                                          "wheels: "+str(self._car.get_wheel()),"door: "+str(self._car.get_door()),"color: "+self._car.get_color() )

import maya.cmds as cmds
import maya.api.OpenMaya as om
import math

class polyform:

    polyform_name = 'polyform_name'
    

    def create_sphere(self,_x,_y,_z, _r =1, _sx = 20, _sy =20):
        
        cmds.polySphere(r =_r, sx =_sx, sy =_sy)
        cmds.move(_x,_y,_z)
        cmds.select(cl = True)

    def create_locator(self,_x,_y,_z):
        
        l =cmds.spaceLocator()
        cmds.move(_x,_y,_z)
        cmds.select(cl = True)
        return l
    
    def delete(self, poly):
        cmds.delete(poly)

class locator:
    def __init__(self):
        self.p = polyform()
       
        lc =cmds.ls(selection=True)
        index =self.num(lc)
        if index>2:
            self.create(lc[0],lc[1])

    def create (self, from1, to):
         dist =self.distance(from1,to)
         self.locate(from1,to)
         repat = dist/10
         tab = []
        
         for i in range(10):
            x1 =cmds.getAttr(from1+ '.translateX')+(repat*(i+1)*self.roll)
            y1 =cmds.getAttr(from1+ '.translateY')+(repat*(i+1)*self.pitch)
            z1 =cmds.getAttr(from1+ '.translateZ')+(repat*(i+1)*self.pitch)
            tab.append(self.p.create_sphere(x1,y1,z1))
          
         cmds.group(tab, n ="root")

    def distance(self, from1, to):
            x1 =cmds.getAttr(from1+ '.translateX')
            y1 =cmds.getAttr(from1+ '.translateY')
            z1 =cmds.getAttr(from1+ '.translateZ')

            x2 =cmds.getAttr(to+ '.translateX')
            y2 =cmds.getAttr(to+ '.translateY')
            z2 =cmds.getAttr(to+ '.translateZ')

            x =abs(x2-x1)
            y =abs(y2-y1)
            z = abs(z2-z1)

            return  math.sqrt(x*x+y*y+z*z)

    def length(self, vector):
      x =cmds.getAttr(vector+ '.translateX')
      y =cmds.getAttr(vector+ '.translateY')
      z =cmds.getAttr(vector+ '.translateZ')
      return  math.sqrt(x*x+y*y+z*z)
    
    def num(self, _list):
         index=1
         for l in _list:
              index+=1
         return index
    
    def normalized(self, vector):
        x =cmds.getAttr(vector+ '.translateX')
        y =cmds.getAttr(vector+ '.translateY')
        z =cmds.getAttr(vector+ '.translateZ')

        x = x/self.length(vector)
        y = x/self.length(vector)
        z = x/self.length(vector)
        return [x,y,z]

    def locate(self, from1, to):
        x1 =cmds.getAttr(from1+ '.translateX')
        y1 =cmds.getAttr(from1+ '.translateY')
        z1 =cmds.getAttr(from1+ '.translateZ')

        x2 =cmds.getAttr(to+ '.translateX')
        y2 =cmds.getAttr(to+ '.translateY')
        z2 =cmds.getAttr(to+ '.translateZ')

        x =x2-x1
        y =y2-y1
        z = z2-z1
        loca =self.p.create_locator(x , y, z)
        vector =self.normalized(loca)
        self.p.delete(loca)
        if(vector[0] >0):
            self.roll =1
        elif(vector[0] <0.5):
            if(vector[0] <0):
                self.roll =-1
            else:
                self.roll =0

        if(vector[1] >0):
            self.yaw =1
        elif(vector[1] <0.5):
            if(vector[1] <0):
                self.yaw =-1
            else:
                self.yaw =0

        if(vector[2] >0):
            self.pitch =1
        elif(vector[2] <0.5):
            if(vector[2] <0):
                self.pitch =-1
            else:
                self.pitch =0


locator()
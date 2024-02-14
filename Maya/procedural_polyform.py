import random

import maya.cmds as cmds
from PySide2 import QtWidgets as qtw
from PySide2.QtCore import Qt


#region util
class util(qtw.QWidget):
        def __init__(self, owner):
            super().__init__()
            self.owner =owner

        def button(self,callback =None, name ="Button"):
            self.button_action =qtw.QPushButton(name)
            if(callback):
                self.button_action.clicked.connect(callback)
            self.add(self.button_action)
            return self.button_action 
        
        def spinBox(self ,min =0, max = 100):
            self.spinbox =qtw.QSpinBox()
            self.spinbox.setMinimum(min)
            self.spinbox.setMaximum(max)
            self.add(self.button_action)
            return self.spinbox 
        
        def slider_ui(self,slide =Qt.Horizontal, min =0, max =100):
            self.slider =qtw.QSlider(slide)
            self.slider.setMinimum(min)
            self.slider.setMaximum(max)
            self.add(self.slider)
            return self.slider
        
        def label_ui(self, title="label",height =30,width =100, align =Qt.AlignmentFlag.AlignLeft,style =""):
            self.label = qtw.QLabel(title)
            self.label.setFixedHeight(height)
            self.label.setFixedWidth(width)
            self.label.setAlignment(align)
            self.label.setGeometry(0,0,0,0)
            self.label.setStyleSheet(style)
            self.add(self.label)
            return self.label
        
        def menu_ui(self):
            self.menu =qtw.QMenu()
            self.add(self.menu)
            return self.menu

        def add(self, widget):
            self.owner.layout.addWidget(widget)

#endregion

#region Poly
class polyform:

  
    

    def create_sphere(self,_x,_y,_z, _r =1, _sx = 20, _sy =20):
        
        cmds.polySphere(r =_r, sx =_sx, sy =_sy)
        cmds.move(_x,_y,_z)
        cmds.select(cl = True)

    def create_cube(self,_x,_y,_z,_sx = 20, _sy =20):
        
        cmds.polyCube(sx =_sx, sy =_sy)
        cmds.move(_x,_y,_z)
        cmds.select(cl = True)

    def create_cylinder(self,_x,_y,_z):
        cmds.polyCylinder(r =1, sx =20, sy =20)
        cmds.move(_x,_y,_z)
        cmds.select(cl = True)
    
    def create_cone(self,_x,_y,_z):
        cmds.polyCone(r =1, sx =20, sy =20)
        cmds.move(_x,_y,_z)
        cmds.select(cl = True)

    def move_polyform(self,_x,_y,_z):
        cmds.move(_x,_y,_z)
    
    def rotate_polyform(self,_x,_y,_z):
        cmds.rotate(x =_x, y=_y,z =_z)

#endregion
        
#region procedural
class procedural_polyform:
    
    CONST_SPHERE = "sphere"
    list_polyform = ["sphere","cube","cylinder","cone"]
    action = []

    poly = polyform()
    def __init__(self):
       self.action= self.init_actions()


    def choose_create(self,minx=0,maxx=10,miny =0,maxY=10,minz=0,maxz=10, choose =CONST_SPHERE):
        if(self.contain(choose)):
            print("this elment")
        
        self.action[self.search_index(choose)](random.randrange(minx, maxx),random.randrange(miny, maxY),random.randrange(minz, maxz))
       

    def init_actions(self):
        return [self.poly.create_sphere, self.poly.create_cube,self.poly.create_cylinder,self.poly.create_cone ]
    
    def contain(self, verify):
        for element in self.list_polyform:
            if(verify ==element):
                return True
        return False
    
    def search_index(self, choose):
        return self.list_polyform.index(choose)
    


#endregion     

#region tool
class tool_ui(qtw.QWidget):

    x_settings_min ="Min X: 1"
    x_settings_max ="Max X: 2"
    y_settings_min ="Min Y: 1"
    y_settings_max ="Max Y: 2"
    z_settings_min ="Min Z: 1"
    z_settings_max ="Max Z: 2"


    def __init__(self):
        super().__init__()
        self.poly =polyform()
        self.procedural = procedural_polyform()
        self.utils =util(self)

        self.init_ui()
        self.bind_ui()



    def init_ui(self):
        self.init_Title()
        self.draw_parameter()

    def bind_ui(self):
        pass
   
      
    def init_Title(self):
        self.setWindowTitle("Maya toolbox")
        self.layout = qtw.QVBoxLayout(self)
        self.setMinimumHeight(200)
        self.setMinimumWidth(200)

    def draw_parameter(self):
        self.draw_slide()
        self.draw_menu()
        

    def draw_menu(self):
        self.utils.button(self.create_random,"Create Random")
        self.utils.button(self.create_sphere,name ="Create sphere")
        self.utils.button(self.create_cone,name ="Create Cone")
        self.utils.button(self.create_cube,name ="Create Cube")
        self.utils.button(self.create_cylinder,name ="Create Cylinder")
        self.utils.button(self.create_all, name ="Create All")

    def draw_slide(self):
        #X
        self.x_settings_min_label =self.utils.label_ui(self.x_settings_min)
        self.x_position_min =self.settings_panel(self.x_position_min_settings_slider_bin)

        self.x_settings_max_label =self.utils.label_ui(self.x_settings_max)
        self.x_position_max =self.settings_panel(self.x_position_max_settings_slider_bin)
        #Y
        self.y_settings_min_label =self.utils.label_ui(self.y_settings_min)
        self.y_position_min =self.settings_panel(self.y_position_min_settings_slider_bin)

        self.y_settings_max_label =self.utils.label_ui(self.y_settings_max)
        self.y_position_max =self.settings_panel(self.y_position_max_settings_slider_bin)
        #Z
        self.z_settings_min_label =self.utils.label_ui(self.z_settings_min)
        self.z_position_min =self.settings_panel(self.z_position_min_settings_slider_bin)

        self.z_settings_max_label =self.utils.label_ui(self.z_settings_max)
        self.z_position_max =self.settings_panel(self.z_position_max_settings_slider_bin)
#region create
    def create_random(self):
        self.random_value()
        self.procedural.choose_create(self.xMin,self.xMax,self.yMin,self.yMax,self.zMin,self.zMax,self.procedural.list_polyform[random.randrange(0, 4)])

    def create_sphere(self):
        self.random_value()
        self.procedural.choose_create(self.xMin,self.xMax,self.yMin,self.yMax,self.zMin,self.zMax,"sphere")

    def create_cube(self):
        self.random_value()
        self.procedural.choose_create(self.xMin,self.xMax,self.yMin,self.yMax,self.zMin,self.zMax,"cube")
    
    def create_cylinder(self):
        self.random_value()
        self.procedural.choose_create(self.xMin,self.xMax,self.yMin,self.yMax,self.zMin,self.zMax,"cylinder")

    def create_cone(self):
        self.random_value()
        self.procedural.choose_create(self.xMin,self.xMax,self.yMin,self.yMax,self.zMin,self.zMax,"cone")

    def create_all(self):
       self.create_sphere()
       self.create_cylinder()
       self.create_cube()
       self.create_cone()

    def random_value(self):
        self.xMin =self.x_position_min.value()
        self.xMax =self.x_position_max.value()
        self.yMin =self.x_position_min.value()
        self.yMax =self.x_position_max.value()
        self.zMin =self.x_position_min.value()
        self.zMax =self.x_position_max.value()
#endregion create

#region slider
    def settings_panel(self, callbaback =None):
           self.slider = self.utils.slider_ui() 
           if(callbaback):
                self.slider.valueChanged.connect(callbaback)
           return self.slider

    def sphere_settings_slider_bin(self,value):
        self.label.setText("Min radius size : {0}".format(value))

    #X
    def x_position_min_settings_slider_bin(self,value):
         if(self.x_position_min.value() <= self.x_position_max.value()):
            self.x_settings_min_label.setText(self.x_settings_min+"{0}".format(value))

    def x_position_max_settings_slider_bin(self,value):
        if(self.x_position_max.value() < self.x_position_min.value()):
            self.x_settings_min_label.setText(self.x_settings_max+"{0}".format(value))

        self.x_settings_max_label .setText(self.x_settings_max+"{0}".format(value))
    #Y
    def y_position_min_settings_slider_bin(self,value):
         self.y_settings_min_label.setText(self.y_settings_min+"{0}".format(value))

    def y_position_max_settings_slider_bin(self,value):
         self.y_settings_max_label .setText(self.y_settings_max+"{0}".format(value))

    #Z
    def z_position_min_settings_slider_bin(self,value):
         self.z_settings_min_label.setText(self.z_settings_min+"{0}".format(value))

    def z_position_max_settings_slider_bin(self,value):
         self.z_settings_max_label .setText(self.z_settings_max+"{0}".format(value))
#endregion slider
#endregion


#######
app =tool_ui()
app.show()

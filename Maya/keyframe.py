import maya.cmds as cmds
from PySide2 import QtWidgets as qtw
from PySide2.QtCore import Qt


#region util
class util_ui(qtw.QWidget):
        def __init__(self, owner):
            super().__init__()
            self.owner =owner

        def button_util(self,callback =None, name ="Button"):
            self.button_action =qtw.QPushButton(name)
            if(callback):
                self.button_action.clicked.connect(callback)
            self.add(self.button_action)
            return self.button_action 
        
        def spinBox_util(self ,min =0, max = 100):
            self.spinbox =qtw.QSpinBox()
            self.spinbox.setMinimum(min)
            self.spinbox.setMaximum(max)
            self.add(self.button_action)
            return self.spinbox 
        
        def slider_util(self,slide =Qt.Horizontal, min =0, max =100):
            self.slider =qtw.QSlider(slide)
            self.slider.setMinimum(min)
            self.slider.setMaximum(max)
            self.add(self.slider)
            return self.slider
        
        def label_util(self, title="label",height =30,width =100, align =Qt.AlignmentFlag.AlignLeft,style =""):
            self.label = qtw.QLabel(title)
            self.label.setFixedHeight(height)
            self.label.setFixedWidth(width)
            self.label.setAlignment(align)
            self.label.setGeometry(0,0,0,0)
            self.label.setStyleSheet(style)
            self.add(self.label)
            return self.label
        
        def menu_util(self):
            self.menu =qtw.QMenu()
            self.add(self.menu)
            return self.menu
        
        def list_util(self):
            curve_list =qtw.QListWidget(self.owner)
            self.add(curve_list)
            return curve_list
        
        def add(self, widget):
            self.owner.layout.addWidget(widget)
#endregion
#region curve
class curve_tool:
    def __init__(self):
        self.listlocator=[]
        self.listX=[]
        self.listY=[]
        self.listZ=[]
    def get_all_nbsCurve(self):
        return cmds.ls(type='nurbsCurve', sn =True)
    
    def gererate_items(self,curve_name, itemNumber =10):
        if curve_name=="":
            return
        t=0
        group_name =curve_name + '_items'
        if  cmds.objExists(group_name):
            cmds.delete(group_name)
        #self.group =cmds.group (em =True, name =group_name)
        self.index =0
        while(t<1):
            
            pos =cmds.pointOnCurve(curve_name, pr =t, top= True, p =True)
            object_name =cmds.polySphere()
            self.listX.append(pos[0])
            self.listY.append(pos[1])
            self.listZ.append(pos[2])
           
            cmds.delete(object_name)
            self.index+=1
            t+=(1/itemNumber)
#endregion          
#region keyframe

class keyframe_tool():
    def __init__(self):
        super().__init__()
        self.curve_tool =curve_tool()

    def make_animation(self,object_animated):
       
        object_name= object_animated
       
        for i in range(self.curve_tool.index):
           
             x =self.curve_tool.listX[i]
             y =self.curve_tool.listY[i] 
             z =self.curve_tool.listZ[i] 
             cmds.setKeyframe(object_name, t =i , at ='translateZ', v =z)
             cmds.setKeyframe(object_name, t =i , at ='translateY', v =y)
             cmds.setKeyframe(object_name, t =i , at ='translateX', v =x)
             

    def play_animation(self):   
       cmds.play()

    def stop_animation(self):
        cmds.play(state=False)

    def send_curve_name(self,name):
        self.current_curve_name = name.text()

    def bind_obj_curve(self):
       
        object_name= cmds.ls(sl =True)
        self.curve_tool.gererate_items(self.current_curve_name)
        self.make_animation(object_name)
class keyframe_ui(qtw.QWidget):

    def __init__(self):
        super().__init__()
        self.util =util_ui(self)
        self.keyframe_tool = keyframe_tool()
        self.ini_ui()
        self.draw_ui()
        self.bind_ui()
        self.update_curve_list(self.keyframe_tool.curve_tool.get_all_nbsCurve())

    def ini_ui(self):
        self.layout =qtw.QVBoxLayout(self)

    def draw_ui(self):
        self.curve_list =self.util.list_util()
        self.btn_generate_keyframe= self.util.button_util(self.keyframe_tool.bind_obj_curve,name ="Bind it!")
        self.btn_play_animation= self.util.button_util(self.keyframe_tool.play_animation,name ="Play it!")
        self.btn_stop_animation= self.util.button_util(self.keyframe_tool.stop_animation,name ="Stop it!")
        self.refrech_button =self.util.button_util(lambda:self.update_curve_list(self.keyframe_tool.curve_tool.get_all_nbsCurve()), "Refrech curves list")

    def update_curve_list(self, items):
        self.curve_list.clear()
        self.curve_list.addItems(items)

    def bind_ui(self):
        self.curve_list.itemClicked.connect(self.keyframe_tool.send_curve_name)
   
   
#endregion

app =keyframe_ui()
app.show()

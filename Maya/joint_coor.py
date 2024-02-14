

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
class keyframe_tool_corr:
     
    def get_all(self):
        return cmds.ls(type='nurbsCurve', sn =True)
    

    def gererate_items(self,curve_name, itemNumber =10):
        if curve_name=="":
            return
        t=0
      
        joints = []
        loc =[]
        ik =[]
        
        while(t<1):
            
            pos =cmds.pointOnCurve(curve_name, pr =t, top= True, p =True)
            j1=cmds.joint(p =pos)
            t+=(1/itemNumber)
            joints.append(j1)
        
        for i in range(len(joints)):
            if i<len(joints)-1:
                ik.append(cmds.ikHandle(sj= joints[i], ee= joints[i+1]))
                offset =cmds.getAttr(ik[i][0] + ".translate")[0]
                loc.append(cmds.spaceLocator(p=(offset[0], offset[1] +5, offset[2])))
                cmds.parent(ik[i][0], 'joint1')
                cmds.parent(loc[i], 'joint1')

        for i in range(len(loc)):
            cmds.parentConstraint(loc[i], ik [i][0], mo = True)
        
class keyframe_tool_ui(qtw.QWidget):

    def __init__(self,):
        super().__init__()
        self.curve =keyframe_tool_corr()
        self.utils =util(self)
        self.draw_ui()
        self.bind_ui()
        self.update_curve_list(self.curve.get_all())

    def draw_ui(self):
        self.ini_ui()
        self.draw_button()

    def bind_ui(self):
        self.number_items.valueChanged.connect(self.update_items_label_ui)
        self.curve_list.itemClicked.connect(self.send_curve_name)

    def ini_ui(self):
        self.layout =qtw.QVBoxLayout(self)
        
    def draw_button(self):
        self.curve_list =qtw.QListWidget(self)
        self.layout.addWidget(self.curve_list )
        self.number_label= self.utils.label_ui("Item = 1")
        self.number_items = self.utils.slider_ui(min =0, max =100)
        self.number_items.setValue(10)

        self.btn =self.utils.button(lambda:self.curve.gererate_items(self.current_curve_name,self.number_items.value()),name= "Generate Curve")
        self.refrech_button =self.utils.button(lambda:self.update_curve_list(self.curve.get_all()), "Refrech curves list")

    def update_items_label_ui(self, value):
        self.number_label.setText("Items ={0}".format(value))

    def update_curve_list(self, items):
        self.curve_list.clear()
        self.curve_list.addItems(items)

    def send_curve_name(self,name):
        self.current_curve_name = name.text()

app=keyframe_tool_ui()
app.show()

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
    
class keyframe_tool:
    def get_all(self):
        return cmds.ls(type='nurbsCurve', sn =True)
    

    def gererate_items(self,curve_name, itemNumber =10):
        if curve_name=="":
            return
        t=0
        group_name =curve_name + '_items'
        if  cmds.objExists(group_name):
            cmds.delete(group_name)
        tab = []
        index =0
        while(t<1):
            
            pos =cmds.pointOnCurve(curve_name, pr =t, top= True, p =True)
            j1=cmds.joint()
            cmds.move(pos[0],pos[1],pos[2])
            tab.append(j1)
            if( index%3 ==0 and index >0):
                print(index) 
                cmds.ikHandle(sj=tab[index-2], ee= tab[index])
            index+=1
            t+=(1/itemNumber)
        #cmds.ikHandle(n ="ik_leg", sj=tab[0], ee= tab[index])
            

class keyframe_tool_ui(qtw.QWidget):

    def __init__(self,):
        super().__init__()
        self.curve =keyframe_tool()
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

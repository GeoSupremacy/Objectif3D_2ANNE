from PySide6.QtWidgets import *
from PySide6.QtCore import *
import unreal
import os
filePath = r"D:\Unreal\Objectif3D_2ANNE\Network"
#region util
class util_tool(QWidget):
        def __init__(self, owner):
            super().__init__()
            self.owner =owner

        def button_ui(self,callback =None, name ="Button"):
            self.button_action =QPushButton(name)
            if(callback):
                self.button_action.clicked.connect(callback)
            self.add(self.button_action)
            return self.button_action 
        
        def list_ui(self, selectionMode = QAbstractItemView.SelectionMode.SingleSelection, items = []):
            list =QListWidget()
            
            for f in items:
                  list.addItem(f.get_name())
            
            list.setSelectionMode(selectionMode) 
            
            self.add(list)
            return list
        

        def spinBox(self ,min =0, max = 100):
            spinbox =QSpinBox()
            spinbox.setMinimum(min)
            spinbox.setMaximum(max)
            self.add(spinbox)
            return spinbox
        
        def slider_ui(self,slide =Qt.Horizontal, min =0, max =100):
            self.slider =QSlider(slide)
            self.slider.setMinimum(min)
            self.slider.setMaximum(max)
            self.add(self.slider)
            return self.slider
        
        def label_ui(self, title="label",height =30,width =100, align =Qt.AlignmentFlag.AlignLeft,style =""):
            self.label = QLabel(title)
            self.label.setFixedHeight(height)
            self.label.setFixedWidth(width)
            self.label.setAlignment(align)
            self.label.setGeometry(0,0,0,0)
            self.label.setStyleSheet(style)
            self.add(self.label)
            return self.label
        
        def menu_ui(self):
            self.menu =QMenu()
            self.add(self.menu)
            return self.menu

        def add(self, widget):
            self.owner.layout.addWidget(widget)
#endregion
class launcher_game(): 
    def launch_steam(self):
        init  =open(filePath +"\Config\DefaultEngine.ini","r")
        content =init.read()
        content =content.replace("DefaultPlatformService=NULL","DefaultPlatformService=Steam")
        content =content.replace("bEnabled=false","bEnabled=true")
        init  =open(filePath + "\Config\DefaultEngine.ini","w")
        init.write(content)

    def path(self):
         init  =open(filePath +"\Config\DefaultEngine.ini","r")
         content =init.read()
         return content

    def launch_NULL(self):
        init  =open(filePath +"\Config\DefaultEngine.ini","r")
        content =init.read()
        content =content.replace("DefaultPlatformService=Steam","DefaultPlatformService=NULL")
        content =content.replace("bEnabled=true","bEnabled=false")
        init  =open(filePath +"\Config\DefaultEngine.ini","w")
        init.write(content)

class launcher_game_ui(QWidget):
    def __init__(self):
            super().__init__()
            self.laucher_game =launcher_game()
            self.util =util_tool(self)
               
            self.init_ui()
            self.draw_ui()
            self.bind_ui()
            self.update_ui()

    def init_ui(self):
        self.setWindowTitle("Laucher_game")
        self.setGeometry(0, 0, 200, 200)
        self.layout =QVBoxLayout(self)
    
    def draw_ui(self):
            self.label = self.util.label_ui("Mode: ")
            self.button_lauch_steam =self.util.button_ui(self.laucher_game.launch_steam, "STEAM")
            self.button_lauch_NULL =self.util.button_ui(self.laucher_game.launch_NULL, "NULL")

    def bind_ui(self):
            self.button_lauch_steam.clicked.connect(lambda:self.change_mode("STEAM"))
            self.button_lauch_NULL.clicked.connect(lambda:self.change_mode("NULL"))

    def change_mode(self, mode):
         self.label.setText("Mode: {0}".format(mode))

    def update_ui(self):
        path = self.laucher_game.path()
        if(path.__contains__("DefaultPlatformService=Steam")and path.__contains__("bEnabled=true")):
              self.label.setText("Mode: {0}".format("Steam"))
        elif(path.__contains__("DefaultPlatformService=NULL")and path.__contains__("bEnabled=false")):
            self.label.setText("Mode: {0}".format("NULL"))
        else:
             self.label.setText("Mode: {0}".format("not mod"))
##########
main =None
if not QApplication.instance():
    main =QApplication()
else:
    main =QApplication.instance()


start = launcher_game_ui()
start.show()
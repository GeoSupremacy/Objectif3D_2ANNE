import unreal
from PySide6.QtWidgets import *
from PySide6.QtCore import *

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
class correction_outliner(QWidget):
    ue_actor = unreal.EditorActorSubsystem()
    ue_ar =unreal.AssetRegistryHelpers()
    
    def __init__(self):
        super().__init__()
        self.util =util_tool(self)
        self.all_actors = self.ue_actor.get_all_level_actors()
        self.layout =QVBoxLayout(self)
        self.btn_refrech =self.util.button_ui(self.refrech_all,"Refrech")
        self.actor_list =self.util.list_ui()
        self.refrech_all()
        self.actor_list.itemClicked.connect(self.select_actor)
        self.levels_list = self.util.list_ui()
        self.levels_list.itemClicked.connect(self.load_level)
        self.get_all_levels()

    def refrech_all(self):
        self.all_actors = self.ue_actor.get_all_level_actors()
        self.actor_list.clear()
        for actor in self.all_actors:
            self.actor_list.addItem(actor.get_actor_label())

    def select_actor(self, item):
        index = self.actor_list.indexFromItem(item).row()
        self.current_actor = self.all_actors[index]
        self.ue_actor.set_selected_level_actors([self.current_actor])
        print(self.current_actor)

    def get_all_levels(self):
        registry = self.ue_ar.get_asset_registry()
        self.levels =registry.get_assets_by_class(unreal.TopLevelAssetPath("/Script/Engine", "World"), False)
        self.levels_list.clear()
        for l in self.levels:
            self.levels_list.addItem(str(l.asset_name))

    def load_level(self, item):
        loader =unreal.get_editor_subsystem(unreal.LevelEditorSubsystem)
        loader.load_level("/Game/Levels/"+ item.text())


##########
main =None
if not QApplication.instance():
    main =QApplication()
else:
    main =QApplication.instance()

start = correction_outliner()
start.show()
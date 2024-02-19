from PySide6.QtWidgets import *
from PySide6.QtCore import *
import unreal
import os

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

class custom_outliner():
     ue_actor = unreal.EditorActorSubsystem()
     ue_ar =unreal.AssetRegistryHelpers()
     def __init__(self):
       self.all_actors = self.ue_actor.get_all_level_actors()

     def find_actor(self): 
           return self.ue_actor.get_all_level_actors()  #EditorLevelLibrary
     def find_level(self):
        registry = self.ue_ar.get_asset_registry()
        self.levels =registry.get_assets_by_class(unreal.TopLevelAssetPath("/Script/Engine", "World"), False)
        #self.levels_list.clear()
        #for l in self.levels:
         #   self.levels_list.addItem(str(l.asset_name))
        ''' 
          list =[]
          folder =QDir("/Game/Levels/")
          files =folder.entryList(["*.fbx"], QDir.Files)
          for file in files:
               list.append(file)
          return list
        '''
     def set_actor_location(self, actor, valueX, valueY, ValueZ):
          actor.set_actor_location(unreal.Vector(valueX,valueY,ValueZ),False,False)

     def set_actor_rotation(self,actor, valueRoll, valuePitch,ValueYaw):
          actor.set_actor_rotation(unreal.Rotator(valueRoll,valuePitch,ValueYaw),False)

     def set_actor_scale(self,actor, scaleX, scaleY, scaleZ):
          actor.set_actor_scale3d(unreal.Vector(scaleX,scaleY,scaleZ))

     def refrech_all(self):
           self.all_actors = self.ue_actor.get_all_level_actors()

           
class custom_outliner_ui(QWidget):
           
            def __init__(self):
                super().__init__()
                self.custom_outliner =custom_outliner()
                self.util =util_tool(self)
               
                self.init_ui()
                self.draw_ui()
                self.bind_ui()

            def init_ui(self):
                self.setWindowTitle("UE_FBX-Imposter")
                self.setGeometry(0, 0, 750, 750)
                self.layout =QVBoxLayout(self)
                
            def draw_ui(self):
               self.action_ui()
               self. detail_ui()

            def bind_ui(self):
                self.actor_list.itemClicked.connect(self.update_detail)
                self.bind_box()
                

            def action_ui(self):
                self.actor_list =self.util.list_ui(items =self.custom_outliner.find_actor())
                self.btn_refrech =self.util.button_ui(self.refrech_action,"Refrech")
                self.btn_create_actor =self.util.button_ui(self.create_action,"Create Actor")
                self.btn_delete =self.util.button_ui(self.delete_action,"Delete: ")

            def bind_box(self):
            
                
                self.spin_box_location_x.valueChanged.connect(lambda: self.custom_outliner.set_actor_location(self.actor,self.spin_box_location_x.value(),self.spin_box_location_y.value(),self.spin_box_location_z.value()))
                self.spin_box_location_y.valueChanged.connect(lambda: self.custom_outliner.set_actor_location(self.actor,self.spin_box_location_x.value(),self.spin_box_location_y.value(),self.spin_box_location_z.value()))
                self.spin_box_location_z.valueChanged.connect(lambda: self.custom_outliner.set_actor_location(self.actor,self.spin_box_location_x.value(),self.spin_box_location_y.value(),self.spin_box_location_z.value()))
            
                self.spin_box_rotation_roll.valueChanged.connect(lambda: self.custom_outliner.set_actor_rotation(self.actor, valueRoll= self.spin_box_rotation_roll.value(), valuePitch=self.spin_box_rotation_pitch.value(), ValueYaw=self.spin_box_rotation_yaw.value()))
                self.spin_box_rotation_pitch.valueChanged.connect(lambda: self.custom_outliner.set_actor_rotation(self.actor, valueRoll= self.spin_box_rotation_roll.value(), valuePitch=self.spin_box_rotation_pitch.value(), ValueYaw=self.spin_box_rotation_yaw.value()))
                self.spin_box_rotation_yaw.valueChanged.connect(lambda: self.custom_outliner.set_actor_rotation(self.actor, valueRoll= self.spin_box_rotation_roll.value(), valuePitch=self.spin_box_rotation_pitch.value(), ValueYaw=self.spin_box_rotation_yaw.value()))

                self.spin_box_scale_x.valueChanged.connect(lambda: self.custom_outliner.set_actor_scale(self.actor,self.spin_box_scale_x.value(),self.spin_box_scale_y.value(),self.spin_box_scale_z.value()))
                self.spin_box_scale_y.valueChanged.connect(lambda: self.custom_outliner.set_actor_scale(self.actor,self.spin_box_scale_x.value(),self.spin_box_scale_y.value(),self.spin_box_scale_z.value()))
                self.spin_box_scale_z.valueChanged.connect(lambda: self.custom_outliner.set_actor_scale(self.actor, self.spin_box_scale_x.value(),self.spin_box_scale_y.value(),self.spin_box_scale_z.value()))


            def detail_ui(self):
                 self.label_detail =self.util.label_ui("Detail: ", width=500)
                 self.label_location =self.util.label_ui("Location: X= Y= Z= ", width=500)
                 self.spin_box_location_x = self.util.spinBox(min= -5000, max=5000)
                 self.spin_box_location_y = self.util.spinBox(min= -5000, max=5000)
                 self.spin_box_location_z = self.util.spinBox(min= -5000, max=5000)

                 self.label_rotation =self.util.label_ui("Rotation: R= P= Y= ", width=500)
                 self.spin_box_rotation_roll = self.util.spinBox(min= -5000, max=5000)
                 self.spin_box_rotation_pitch = self.util.spinBox(min= -5000, max=5000)
                 self.spin_box_rotation_yaw = self.util.spinBox(min= -5000, max=5000)

                 self.label_scale=self.util.label_ui("Scale: X= Y= Z= ", width=500)
                 self.spin_box_scale_x = self.util.spinBox(min= -5000, max=5000)
                 self.spin_box_scale_y = self.util.spinBox(min= -5000, max=5000)
                 self.spin_box_scale_z = self.util.spinBox(min= -5000, max=5000)

            def refrech_action(self):
                self.custom_outliner.refrech_all()
                self.actor_list.clear()
                for f in self.custom_outliner.find_actor():
                  self.actor_list.addItem(f.get_actor_label())
            
            def create_action(self):
                 if(self.actor==None):
                    return
                 actor_location = unreal.Vector(0,0,0)
                 unreal.EditorLevelLibrary.spawn_actor_from_object(self.actor , actor_location)
            
            def delete_action(self):
                self.actor.destroy_actor()
                ''''
                for actor in unreal.EditorLevelLibrary.get_all_level_actors():
                      if actor.get_name()== self.item:
                           actor.destroy_actor()
                           self.item =""
                           self.refrech_action()
                           break
                '''


            def update_detail(self, item):
                 self.btn_delete.setText("Delete: {0}".format(item.text())) 
                 self.item = item.text()
                 
                
                 index = self.actor_list.indexFromItem(item).row()
                 self.actor = self.custom_outliner.all_actors[index]
                 self.custom_outliner.ue_actor.set_selected_level_actors([self.actor])

                 lclx = self.actor.get_actor_location().x
                 lcly = self.actor.get_actor_location().y
                 lclz = self.actor.get_actor_location().z   
             
                 rool =self.actor.get_actor_rotation().roll
                 pitch =self.actor.get_actor_rotation().pitch
                 yaw =self.actor.get_actor_rotation().yaw

                 scalex =self.actor.get_actor_scale3d().x
                 scaley =self.actor.get_actor_scale3d().y
                 scalez =self.actor.get_actor_scale3d().z
                 self.label_detail.setText("Detail: {0}".format(self.actor.get_actor_label()))
                 self.label_location.setText("Location: X={0} Y={1} Z={2}".format(lclx,lcly,lclz))
                 self.spin_box_location_x.setValue(lclx)
                 self.spin_box_location_y.setValue(lcly)
                 self.spin_box_location_z.setValue(lclz)

                 self.label_rotation.setText("Rotation: R={0} P={1} Y={2}".format(rool,pitch,yaw))
                 self.spin_box_rotation_roll.setValue(rool)
                 self.spin_box_rotation_pitch.setValue(pitch)
                 self.spin_box_rotation_yaw.setValue(yaw)

                 self.label_scale.setText("Scale: X={0} Y={1} Z={2}".format(scalex,scaley,scalez))
                 self.spin_box_scale_x.setValue(scalex)
                 self.spin_box_scale_y.setValue(scaley)
                 self.spin_box_scale_z.setValue(scalez)

              

                

##########
main =None
if not QApplication.instance():
    main =QApplication()
else:
    main =QApplication.instance()

os.system('cls')
start = custom_outliner_ui()
start.show()
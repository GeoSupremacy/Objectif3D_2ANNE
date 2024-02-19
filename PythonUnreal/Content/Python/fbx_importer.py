from PySide6.QtWidgets import *
from PySide6.QtCore import *
import unreal

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
        
        def list_ui(self):
            list =QListWidget()
            list.setSelectionMode(QAbstractItemView.SelectionMode.MultiSelection) 
            
            self.add(list)
            return list
        

        def spinBox(self ,min =0, max = 100):
            self.spinbox =QSpinBox()
            self.spinbox.setMinimum(min)
            self.spinbox.setMaximum(max)
            self.add(self.button_action)
            return self.spinbox 
        
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
            

class starting_ue(QWidget):

    path_key ="fbx_from_path"
    def __init__(self):
        super().__init__()
        self.util =util_tool(self)
        self.save_settings =QSettings("O3D-P2", "UE_FBX-Imposter")
        self.init_ui()
        self.draw_ui()
        self.reload_save()
        self.bind_ui()

    def init_ui(self):
        self.setWindowTitle("UE_FBX-Imposter")
        self.layout =QVBoxLayout(self)

    def draw_ui(self):
        self.btn_from =self.util.button_ui(self.open_browner,"Select fbx folder")
        self.fbx_label= self.util.label_ui("Path :")
        self.btn_make_content_folder=self.util.button_ui(self.prepare_project_directory,"Prepare project directory")
        self.drop_btn=self.util.button_ui(self.drop_item,"Drop files into project")
        self.fbx_list =self.util.list_ui()

    def bind_ui(self):
        self.fbx_list.itemClicked.connect(self.update_ui)

    def open_browner(self):
        self.path =str(QFileDialog.getExistingDirectory(self, "Select Directory"))
        self.save_settings.setValue(self.path_key, self.path)
        self.fbx_label.setText("Path : {0}".format(self.path))
        self.read_directory(self.path)

    def reload_save(self):
        reload_path =self.save_settings.value(self.path_key)
        if reload_path==None:
            return
        self.path =self.save_settings.value(self.path_key)
        self.fbx_label.setText("Path : {0}".format(self.path))
        self.read_directory(self.path)

    def prepare_project_directory(self):
        unreal.EditorAssetLibrary.make_directory("/GAME/FBX")

    def drop_item(self):
        files_to_load =[]
        if len(self.fbx_list.selectedItems())==0:
            files_to_load =self.files
        else:
            for f in self.fbx_list.selectedItems():
                files_to_load.append(f.text())
        self.prepare_project_directory()
        tasks =[]
        for f in files_to_load:
            destination_path ="{0}".format("/Game/FBX/", f.split('.')[0])
            valid_filename = "{0}/{1}".format(self.path, f)
            valid_destination_name='FBX_{0}'.format(f)
            task = unreal.AssetImportTask()
            task.automated =True
            task.filename = valid_filename
            task.destination_name =  valid_destination_name
            task.destination_path =destination_path
            task.replace_existing = True
            task.save =True
            options =unreal.FbxImportUI()
            options.import_mesh =True
            options.import_textures =False
            options.import_materials =False
            options.import_as_skeletal =True
            data =unreal.FbxStaticMeshImportData()
            data.combine_meshes =True
            options.static_mesh_import_data =data
            task.options =options
            tasks.append(task)
            
        unreal.AssetToolsHelpers.get_asset_tools().import_asset_tasks(tasks)
        #unreal.EditorAssetLibrary.does_directory_exist("...")


    def read_directory(self,path):
        if not QDir(path).exists():
            self.fbx_label.setText('')
            self.save_settings.setValue(self.path_key,'')
            return
        folder =QDir(path)
        self.fbx_list.clear()
        self.files =folder.entryList(["*.fbx"], QDir.Files)
        for f in self.files:
            self.fbx_list.addItem(f)
        self.drop_btn.setText("Drop {0} files into project".format(len(self.files)))

    def update_ui(self):
        self.drop_btn.setText("Drop {0} files into project".format(len(self.fbx_list.selectedItems())))





##########
main =None
if not QApplication.instance():
    main =QApplication()
else:
    main =QApplication.instance()
start = starting_ue()
start.show()
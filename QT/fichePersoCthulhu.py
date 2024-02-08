from PySide6 import QtWidgets as qtw
from PySide6.QtCore import Qt
from Util import *


class fichePerso(qtw.QWidget):
    def __init__(self):
        super().__init__()
        self.utils =util(self)
        self.init_ui()
        self.draw_ui()
        self.bind_ui()


    def init_ui(self):
        self.setWindowTitle("Cthulhu")
        self.layout = qtw.QVBoxLayout(self)
        self.setGeometry(0, 0, 2000, 300)
        self.constitution_value =0
        self.power_value =0
        self.size_value =0
        
    def draw_ui(self):
      #self.block_civil()
      self.block_caracteristique()
      self.block_state()
       
    def bind_ui(self):
        self.power_box.valueChanged.connect(self.set_power_value)
        self.power_box.valueChanged.connect(self.set_mental_health)
        self.power_box.valueChanged.connect(self.set_magic_value)

        self.constitution_box.valueChanged.connect(self.set_constitution_value)
        self.size_box.valueChanged.connect(self.set_size_value)
        self.constitution_box.valueChanged.connect(self.set_health)
        self.size_box.valueChanged.connect(self.set_health)


#region UI
    def block_civil(self):
        self.label_2 = self.utils.text_ui('Etat civil',30,500,
                                          Qt.AlignmentFlag.AlignCenter, 
                                          "border: 1px solid black;")
    
        joueur= self.utils.label_ui("Nom")
        nom =self.utils.text_ui(".....")
        joueur= self.utils.label_ui("Joueur")
        editJ = self.utils.text_ui(".....")
        joueur= self.utils.label_ui("Occupation")
        self.utils.text_ui(".....")
        joueur= self.utils.label_ui("Age")
        self.utils.text_ui(".....")
        joueur= self.utils.label_ui("Sexe")
        self.utils.text_ui(".....")
        joueur= self.utils.label_ui("Residence")
        self.utils.text_ui(".....")
        joueur= self.utils.label_ui("Lieu de naissance")
        self.utils.text_ui(".....")

    def block_caracteristique(self):
        self.label_2 = self.utils.text_ui('Caractéristiques',30,500,
                                          Qt.AlignmentFlag.AlignCenter, 
                                          "border: 1px solid black;")
        self.utils.label_ui("FORCE")
        self.force_box = self.utils.spinBox()

        self.utils.label_ui("DEXTERITE")
        self.dexterity_box = self.utils.spinBox()

        self.utils.label_ui("TAILLE")
        self.size_box = self.utils.spinBox()

        self.utils.label_ui("POUVOIR")
        self.power_box = self.utils.spinBox()

        self.utils.label_ui("INTELLIGENCE")
        self.intelligence_box = self.utils.spinBox()

        self.utils.label_ui("APPARENCE")
        self.apperance_box = self.utils.spinBox()

        self.utils.label_ui("CONSTITUTION")
        self.constitution_box = self.utils.spinBox()

        self.utils.label_ui("EDUCATION")
        self.education_box = self.utils.spinBox()
   
    def block_state(self):
        self.label_2 = self.utils.text_ui('ETAT',30,500,
                                          Qt.AlignmentFlag.AlignCenter, 
                                          "border: 1px solid black;")
        self.utils.label_ui("POINTS DE VIE")
        self.health_box = self.utils.spinBox(0,20)

        self.utils.label_ui("POINTS DE MAGIE")
        self.magic_box = self.utils.spinBox(0,24)

        self.utils.label_ui("POINTS DE SANTE MENTALE",30,300)
        self.mental_health = self.utils.spinBox(0,100)

        self.utils.label_ui("CHANCE")
        self.chance_box = self.utils.spinBox(0,100)

#endregion
         
    def set_mental_health(self, _value=0):
        self.mental_health.setValue(self.power_value * 5) 

    def set_health(self, _value=0):
        v =((self.size_value + self.constitution_value))
        if(v ==0):
            v=45
        self.health_box.setValue( v/2) 

    def set_magic_value(self, _value):
        v =_value
        if(v ==0):
            v=15
        self.magic_box.setValue(self.power_value / 5) 


    def set_constitution_value(self, _value):
        self.constitution_value= _value

    def set_power_value(self, _value):
        self.power_value= _value

    def set_size_value(self, _value):
        self.size_value= _value

   

    
   

app= qtw.QApplication([])
_fichePerso = fichePerso()
_fichePerso.show()
app.exec()
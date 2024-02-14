from PySide6 import QtWidgets as qtw
from PySide6.QtCore import Qt
from util import *
from register import *

class fichePerso(qtw.QWidget):
    def __init__(self):
        super().__init__()
        self.utils =util(self)
        self.register =register()
        self.init_ui()
        self.draw_ui()
        self.bind_ui()


    def init_ui(self):
        self.setWindowTitle("Cthulhu")
        self.layout = qtw.QGridLayout(self)
        self.setGeometry(0, 0, 750, 1900)
        self.constitution_value =0
        self.power_value =0
        self.size_value =0
        
    def draw_ui(self):
      self.stat()
     
       
    def bind_ui(self):
       self.save.clicked.connect(self.registre)


#region UI
  

    def stat(self):

        pathfinder =self.utils.label_ui('Fiche perso',30,500,
                                          Qt.AlignmentFlag.AlignCenter, 
                                          "border: 1px solid black;")
        self.layout.addWidget(pathfinder,0,1)

        self.strength=  self.edit("Strength:",1)
        self.intelligence= self.edit("Intelligence:",2)
        self.agility =self.edit("Agility:",3)
        self.luck =self.edit("Luck:",4) 
        self.charisma =self.edit("Charisma:",5) 

        self.perception =self.edit("Perception:",1,2,3)
        self.endurance =self.edit("Endurance:",2,2,3)
        self.agility =self.edit("Agility:",3,2,3)
        self.knowledge =self.edit("Knowledge:",4,2,3) 
        self.wisdom =self.edit("Wisdom:",5,2,3) 

        self.willpower =self.edit("Willpower:",1,4,5)
        self.stealth =self.edit("Stealth:",2,4,5)
        self.dexterity =self.edit("Dexterity:",3,4,5)
        self.speed =self.edit("Speed:",4,4,5)
        self.ability =self.edit("Ability:",5,4,5) 

        self.save =self.button("Register")
       
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

    def button(self, name):
        button =self.utils.button(None,name)
        self.layout.addWidget(button,6,1)
        return button
   
    def edit(self, name ="name",number =0, position1 =0, position2 =1):
        strength =self.utils.label_ui(name)
        editName =self.utils.spinBox()
        self.layout.addWidget(strength,number,position1)
        self.layout.addWidget(editName,number,position2)
        return (editName.valueChanged)
    def registre(self):
        self.register.save(self)
        
   
'''
    def block_civil(self):

        civil_state =self.utils.label_ui('Etat civil',30,500,
                                          Qt.AlignmentFlag.AlignCenter, 
                                          "border: 1px solid black;")
        
        self.layout.addWidget(civil_state,0,0)
        
        

        name =self.utils.label_ui("Nom")
        editName =self.utils.text_ui(".....")
        self.layout.addWidget(name,1,0)
        self.layout.addWidget(editName,1,1)

        jc =self.utils.add(self.utils.label_ui("Joueur"))
        jc_e =self.utils.add(self.utils.text_ui("....."))
      

        
        occ =self.utils.add(self.utils.label_ui("Occupation"))
        occ_e = self.utils.add(self.utils.text_ui("....."))
        #self.layout.addWidget(occ,2,0)
        #self.layout.addWidget(occ_e,2,1)

        age =self.utils.add(self.utils.label_ui("Age"))
        age_e =self.utils.add(self.utils.text_ui("....."))
       # self.layout.addWidget(age,2,0)
       # self.layout.addWidget(age_e,2,1)

        sexe =self.utils.add(self.utils.label_ui("Sexe"))
        sexe_e =self.utils.add(self.utils.text_ui("....."))
       # self.layout.addWidget(sexe,2,0)
       # self.layout.addWidget(sexe_e,2,1)

        r =self.utils.add(self.utils.label_ui("Residence"))
        r_e =self.utils.add(self.utils.text_ui("....."))
       # self.layout.addWidget(r,2,0)
       # self.layout.addWidget(r_e,2,1)

        Ln =self.utils.add(self.utils.label_ui("Lieu de naissance"))
        Ln_e =self.utils.add( self.utils.text_ui("....."))
       # self.layout.addWidget(Ln,2,0)
       # self.layout.addWidget(Ln_e,2,1)

    def block_caracteristique(self):
        label_cc = self.utils.text_ui('Caractéristiques',30,500,
                                          Qt.AlignmentFlag.AlignCenter, 
                                          "border: 1px solid black;")
        
        self.layout.addWidget(label_cc,0,2)

        strenght =self.utils.label_ui("FORCE")
        self.force_box = self.utils.spinBox()

        self.layout.addWidget(strenght,1,2)
        self.layout.addWidget(self.force_box,1,3)


        dd =self.utils.label_ui("DEXTERITE")
        self.dexterity_box = self.utils.spinBox()

        self.layout.addWidget(dd,2,2)
        self.layout.addWidget(self.dexterity_box,2,3)


        size =self.utils.label_ui("TAILLE")
        self.size_box = self.utils.spinBox()
        self.layout.addWidget(size,3,2)
        self.layout.addWidget(self.size_box,3,3)


        power =self.utils.label_ui("POUVOIR")
        self.power_box = self.utils.spinBox()
        self.layout.addWidget(power,1,4)
        self.layout.addWidget(self.power_box,1,5)

        intel =self.utils.label_ui("INTELLIGENCE")
        self.intelligence_box = self.utils.spinBox()
        self.layout.addWidget(intel,2,4)
        self.layout.addWidget(self.intelligence_box,2,5)

        self.utils.label_ui("APPARENCE")
        self.apperance_box = self.utils.spinBox()
        self.layout.addWidget(intel,3,4)
        self.layout.addWidget(self.intelligence_box,3,5)

        self.utils.label_ui("CONSTITUTION")
        self.constitution_box = self.utils.spinBox()
        self.layout.addWidget(intel,4,4)
        self.layout.addWidget(self.intelligence_box,4,5)

        self.utils.label_ui("EDUCATION")
        self.education_box = self.utils.spinBox()
        self.layout.addWidget(intel,5,4)
        self.layout.addWidget(self.intelligence_box,5,5)
   
    def block_state(self):
        self.state = self.utils.text_ui('ETAT',30,500,
                                          Qt.AlignmentFlag.AlignCenter, 
                                          "border: 1px solid black;")
        

        self.layout.addWidget(self.state,5,2)
        
        he_label =self.utils.label_ui("POINTS DE VIE")
        self.health_box = self.utils.spinBox(0,20)

        self.layout.addWidget(he_label ,5,0)
        self.layout.addWidget(self.health_box  ,5,1)


        self.utils.label_ui("POINTS DE MAGIE")
        self.magic_box = self.utils.spinBox(0,24)

        self.utils.label_ui("POINTS DE SANTE MENTALE",30,300)
        self.mental_health = self.utils.spinBox(0,100)

        self.utils.label_ui("CHANCE")
        self.chance_box = self.utils.spinBox(0,100)

         self.power_box.valueChanged.connect(self.set_power_value)
        self.power_box.valueChanged.connect(self.set_mental_health)
        self.power_box.valueChanged.connect(self.set_magic_value)

        self.constitution_box.valueChanged.connect(self.set_constitution_value)
        self.size_box.valueChanged.connect(self.set_size_value)
        self.constitution_box.valueChanged.connect(self.set_health)
        self.size_box.valueChanged.connect(self.set_health)


'''

app= qtw.QApplication([])
_fichePerso = fichePerso()
_fichePerso.show()
app.exec()
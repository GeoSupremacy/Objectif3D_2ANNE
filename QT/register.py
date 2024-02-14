import json
import os
from encoder import *


class register():

    filename =os.path.join(os.path.dirname(__file__), "fichePerso.txt")

    def __init__(self):
        
        self.strength = int
        self.intelligence = int
        self.agility = int
        self.luck = int
        self.charisma = int
        self.perception = int
        self.endurance = int
        self.agility = int
        self.knowledge = int
        self.wisdom = int
        self.willpower = int
        self.stealth = int
        self.dexterity = int
        self.speed = int
        self.ability = int
        self.register = int

    def save(self, owner):
        self.strength = owner.strength
        self.intelligence = owner.intelligence
        self.agility = owner.agility
        self.luck = owner.luck
        self.charisma = owner.charisma
        self.perception = owner.perception
        self.endurance = owner.endurance
        self.agility = owner.agility
        self.knowledge = owner.knowledge
        self.wisdom = owner.wisdom
        self.willpower = owner.willpower
        self.stealth = owner.stealth
        self.dexterity = owner.dexterity
        self.speed = owner.speed
        self.ability = owner.ability
        self.register = owner.register
        self.write()

    def write(self):
      with open(self.filename,'w') as file:
            json.dump(self, file,indent=4, cls =encoder)
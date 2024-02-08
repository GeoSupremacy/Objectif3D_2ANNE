import os
import json
'''
os.system("cls")
def _age():
    print("Age")
    return input()

def _name():
    print("Name")
    return input()

def _surname():
    print("Surname")
    return input()

def _display(age, name, surname):
   print("Age: ",age,"Name: ",name,"Surname: ",surname)


def _center():
    age_verify=_age()
    name_verify =_name()
    surname_verify = _surname()
    _check(age_verify, name_verify, surname_verify)
   

def _check(age_verify, name_verify, surname_verify):
    _display(age_verify, name_verify, surname_verify)
    not_verify=True
    age=0
    name =""
    surname=""
    while(not_verify):
        age =_age()
        name =_name()
        surname = _surname()
        if(age_verify ==age):
            if(name_verify ==name):
                if(surname_verify == surname):
                    not_verify =False
                else:
                    print("wrong surname")
            else:
                print("wrong name_verify")
        else:
            print("wrong age_verify")

_center()
 print("check")




def _menu():
    menu =get_menu()
    print("\n \n MENU\n")
    if(menu=="2"):
        fistname =  get_firstname()
        lastname = get_lastname()
        age = get_age()
        add_contact(fistname, lastname, age)
    elif(menu=="1"):
        read_allcontacts()
def get_menu():
    menu =input(menu_prompt)
    while(menu.isdigit() ==False):
        menu =input(age_prompt)
    return menu






'''
#######CORRECTION#########
class contact:
    firstname_label_prompt ="Enter firstname :"
    lastname_label_prompt ="Enter lastname :"
    age_prompt ="Enter age :"
    menu_prompt ="1-Menu 2-Add: "
    all_contacts =[]
    menu_choices = ["Add contact", "Read contacts", "save", "read"]


    filename =os.path.join(os.path.dirname(__file__), "contacts.txt")



    def main_loop(self):
        actions =self.init_actions()
        self.init_menu()
        actions[self.select_menu()]()
        self.main_loop()

    def init_menu(self):
     print("Contact\n")
     index=1
     for choices in self.menu_choices:
        print(index," - ",choices)
        index+=1
    
    def init_actions(self):
        return [self.create_contact, self.read_allcontacts, self.write_contacts_json, self.read_contacts_json]
    
    def select_menu(self):
        index =input()
        while(index.isdigit() == False or int(index) <=0 or int(index) > len(self.menu_choices)):
            index =input()
        return int(index)-1

        
    def get_firstname(self):
        return input(self.firstname_label_prompt)
    def get_lastname(self):
        return input(self.lastname_label_prompt)
    def get_age(self):
        tmp_age =input(self.age_prompt)
        while(tmp_age.isdigit() ==False or int(tmp_age) <= 0):
            tmp_age =input(self.age_prompt)
        return tmp_age



    def create_contact(self):
        fistname =  self.get_firstname()
        lastname = self.get_lastname()
        age = self.get_age()
        self.add_contact(fistname, lastname, age)

    def add_contact(self,firstname, lastname, age):
        result = "{0} \n {1} \n {2}".format(firstname, lastname, age)
        self.all_contacts.append(result)

    def read_allcontacts(self):
        print("\n \n all contact:\n")
        for c in self.all_contacts:
            print(c,"\n")   
        print("\n")


    def write_contacts_json(self):
        with open(self.filename,'w') as file:
            json.dump(self.all_contacts, file, indent=4)
    

    def read_contacts_json(self):
        data =open(self.filename)
        print(json.load(data))

c =contact()
c.main_loop()
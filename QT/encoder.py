

from json import JSONEncoder


class encoder(JSONEncoder):

   def default(self, o):
            return o.__dir__()
   
   '''
    filename =os.path.join(os.path.dirname(__file__), "fichePerso.txt")

   def write(self, classS):
      with open(self.filename,'w') as file:
            json.dump(classS, file,indent=4, cls =encoder)
   '''
  

   
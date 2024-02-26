import os
init =open(os.path.dirname(__file__) + "\Config\DefaultEngine.ini","r")
content =init.read()
content =content.replace("DefaultPlatformService=NULL","DefaultPlatformService=Steam")
content =content.replace("bEnabled=false","bEnabled=true")
init =open(os.path.dirname(__file__) + "\Config\DefaultEngine.ini","w")
init.write(content)

bath =os.path.dirname(__file__) +"\lauch_online.bat"
os.startfile(bath)
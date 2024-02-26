import os
init =open(os.path.dirname(__file__) + "\Config\DefaultEngine.ini","r")
content =init.read()
content =content.replace("DefaultPlatformService=Steam","DefaultPlatformService=NULL")
content =content.replace("bEnabled=true","bEnabled=false")
init =open(os.path.dirname(__file__) + "\Config\DefaultEngine.ini","w")
init.write(content)

bath =os.path.dirname(__file__) +"\lauch_online.bat"
os.startfile(bath)
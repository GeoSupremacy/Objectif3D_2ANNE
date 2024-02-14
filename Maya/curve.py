import maya.cmds as cmds
import maya.api.OpenMaya as om

class attribut_example:
    def __init__(self):
        self.polyform_name = 'node'
        curve =cmds.ls(selection=True)[0]
        allCurves = cmds.listRelatives(curve, p=True, type = "nurbsCurve")
        self.index =0
        print("object selected " +curve)
        print(allCurves)
        for nb in allCurves:
            self.index+=1
            x =cmds.getAttr(nb+ '.translateX')
            y =cmds.getAttr(nb+ '.translateY')
            z =cmds.getAttr(nb+ '.translateZ')
            cmds.polySphere( n=self.polyform_name+self.index)
            cmds.move(x,y,z,self.polyform_name+self.index)

    '''M
        curve = cmds.ls(type='nurbsCurve')
        node =cmds.select(cmds.ls(curve))
        
        for c in node:
            if( not cmds.objExists(c+".generated")):
                cmds.addAttr(c, ln='generated',at='bool',k = True)
            if( not cmds.objExists(c+".node")):
                cmds.addAttr(c, ln='node',dt= 'nurbsCurve',k = True)
        '''
    


    def create(self):
        tab = []
        for p in range(10):
            tab.append(cmds.polySphere()[0])
        cmds.group(tab, n ="root")

    def delete_g(self):
        cmds.delete("root")

#attribut_example()
'''
app =attribut_example()
app.show()
'''


'''
    def __init__(self):
        cmds.select(cmds.polySphere())
        node =cmds.ls(selection=True)[0]
        print(node)
        x =cmds.getAttr(node+ '.translateX')
        pos =cmds.getAttr(node+ '.translate')
        print(x)
        print(pos[0][0])
        translate =cmds.getAttr(node+'.translate')
        rotate =cmds.getAttr(node+'.rotate')
        scale =cmds.getAttr(node+'.scale')
        print(translate, rotate, scale)
        cmds.setAttr(node+ '.translateX',20)
        if( not cmds.objExists(node+".var")):
            cmds.addAttr(node, ln='var',at='double',k = True)
        
        cmds.setAttr(node+".var", 4)
        print(cmds.getAttr(node+".var"))
    '''
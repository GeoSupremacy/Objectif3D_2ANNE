


j1=cmds.joint(p =(0,0,0))
j2=cmds.joint(p =(5,10,0))
j3=cmds.joint(p =(0,20,0))

ik=cmds.ikHandle(n ="ik_leg", sj=j1, ee= j3)

cmds.setKeyframe(ik[0], t =0)
cmds.setKeyframe(ik[0], t =48, at ='translateY', v =5)



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


'''
class curve_ex:
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

   
        curve = cmds.ls(type='nurbsCurve')
        node =cmds.select(cmds.ls(curve))
        
        for c in node:
            if( not cmds.objExists(c+".generated")):
                cmds.addAttr(c, ln='generated',at='bool',k = True)
            if( not cmds.objExists(c+".node")):
                cmds.addAttr(c, ln='node',dt= 'nurbsCurve',k = True)
     
    


    def create(self):
        tab = []
        for p in range(10):
            tab.append(cmds.polySphere()[0])
        cmds.group(tab, n ="root")

    def delete_g(self):
        cmds.delete("root")

curve_ex()

app =attribut_example()
app.show()
'''

'''
import maya.api.OpenMaya as om
class attribut_example:
    def __init__(self):
        All_curves = cmds.ls(type='nurbsCurve', ni=True, o=True, r=True, l = True, sl =True)
        curves_transforms = cmds.listRelatives(All_curves, p=True, type = "transform")

        cmds.select(curves_transforms)
        print(All_curves)

      
         d=cmds.curve(p=[(0, 0, 0), (3, 5, 6), (5, 6, 7), (9, 9, 9)])
         cmds.select(d)
        
         curves_transforms = cmds.listRelatives(All_curves, p=True, type = "transform")

         print(node)
       
        


    def create(self):
        tab = []
        for p in range(10):
            tab.append(cmds.polySphere()[0])
        cmds.group(tab, n ="root")

    def delete_g(self):
        cmds.delete("root")

attribut_example()

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

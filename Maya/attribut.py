


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

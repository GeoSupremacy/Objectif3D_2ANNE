import maya.cmds as cmds


class polyform:

    polyform_name = 'polyform_name'
    

    def create_sphere(self,_x,_y,_z, _r =1, _sx = 20, _sy =20):
        self.polyform_name ='sphere'
        cmds.polySphere(r =_r, sx =_sx, sy =_sy, n=self.polyform_name)
        cmds.move(_x,_y,_z,self.polyform_name)
        cmds.select(cl = True)

    def create_cube(self,_x,_y,_z,_sx = 20, _sy =20):
        self.polyform_name ='cube'
        cmds.polyCube(sx =_sx, sy =_sy, n=self.polyform_name)
        cmds.move(_x,_y,_z, self.polyform_name )
        cmds.select(cl = True)

    def create_cylinder(self,_x,_y,_z):
        self.polyform_name ='cylinder'
        cmds.polyCylinder(r =1, sx =20, sy =20, n=self.polyform_name)
        cmds.move(_x,_y,_z, self.polyform_name )
        cmds.select(cl = True)
    
    def create_cone(self,_x,_y,_z):
        self.polyform_name ='cone'
        cmds.polyCone(r =1, sx =20, sy =20, n=self.polyform_name)
        cmds.move(_x,_y,_z, self.polyform_name )
        cmds.select(cl = True)

    def move_polyform(self,_x,_y,_z):
        cmds.move(_x,_y,_z)
    
    def rotate_polyform(self,_x,_y,_z):
        cmds.rotate(x =_x, y=_y,z =_z)
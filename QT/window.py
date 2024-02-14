from PySide6 import QtWidgets
from PySide6.QtCore import QRect

class window(QtWidgets.QLayout):
    def __init__(self):
        super().__init__()


    def set_spacing(self, spacing):
        self.spacing(spacing)

    def addItem(self, item):
        pass

    def size_Hint(self):
        return self.sizeHint()
    def minimum_size(self):
        return self.minimumSize()
    def _count(self):
        return self.count()
    
    def item_at(self,index):
        return self.itemAt(index)
    

    def take_at(self,index):
        return self.takeAt(index) if  index >=0 and index < self.count() else 0
    def set_geometry(self, left,top,w,h):
        self.setGeometry(QRect(left,top,w,h))


    def add_widget(self, widget):
        self.addWidget(widget)
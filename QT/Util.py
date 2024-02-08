from PySide6 import QtWidgets as qtw
from PySide6.QtCore import Qt

class util(qtw.QWidget):
    def __init__(self, owner):
        super().__init__()
        self.owner =owner


    

    def button(self,callback =None, label ="Button"):
        self.button_action =qtw.QPushButton(label)
        if(callback):
            self.button_action.clicked.connect(callback)
        self.owner.layout.addWidget( self.button_action)

    def slider_ui(self,slide =Qt.Horizontal, min =0, max =100):
        self.slider =qtw.QSlider(slide)
        self.slider.setMinimum(min)
        self.slider.setMaximum(max)
        
        return self.slider.valueChanged._value

    def spinBox(self ,min =0, max = 100):
        self.spinbox =qtw.QSpinBox()
        self.spinbox.setMinimum(min)
        self.spinbox.setMaximum(max)
        self.spinbox.setFixedHeight(30)
        self.spinbox.setFixedWidth(50)
        
        self.owner.layout.addWidget(self.spinbox)
        return self.spinbox 

    def label_ui(self, title="label",height =30,width =100, align =Qt.AlignmentFlag.AlignLeft):
        self.label = qtw.QLabel(title)
        self.label.setFixedHeight(height)
        self.label.setFixedWidth(width)
        self.label.setAlignment(align)
        self.label.setGeometry(0,0,0,0)
        self.owner.layout.addWidget(self.label)
        return self.label
    
    def text_ui(self, title="label",height =30,width =100, align =Qt.AlignmentFlag.AlignLeft, style =""):
        self.text = qtw.QTextEdit(title)
        self.text.setFixedHeight(height)
        self.text.setFixedWidth(width)
        self.text.setAlignment(align)
        self.text.setStyleSheet(style)
        self.owner.layout.addWidget(self.text)
        return self.text

    def group_label(self,owner, title="group", height =100,width =100, align =Qt.AlignmentFlag.AlignLeft):
        self.group = qtw.QGroupBox(title)
        self.group.setFixedHeight(height)
        self.group.setFixedWidth(width)
        self.group.setAlignment(align)
        owner.layout.addWidget(self.group)
        return self.group


    def set_message_button(self, text="Text"):
        self.pop =qtw.QMessageBox()
        self.pop.setWindowTitle("Pop message")
        self.pop.setStandardButtons(qtw.QMessageBox.Ok | qtw.QMessageBox.Cancel)
        result =self.pop.exec()
        if(result == qtw.QMessageBox.Ok ):
            print("ok")
        else:
            print("Cancel")

    


from PySide6 import QtWidgets as qtw
from PySide6.QtCore import Qt


class qt_intro(qtw.QWidget):
    def __init__(self):
        super().__init__()
    
        self.init_ui()
        self.draw_ui()
        self.bind_ui()

    def init_ui(self):
        self.setWindowTitle("First try?")
        self.layout = qtw.QVBoxLayout(self)
        self.setFixedHeight(1000)
        self.setFixedWidth(750)

    def draw_ui(self):
        self.text_label(" first title")
        other =self.text_label(" other")
        other.move(10000000,0)
        self.spinBox()
        self.slider_ui()
        self.button(self.set_message_button)

    def bind_ui(self):
        pass

    def button(self,callback, label ="Button"):
        self.button_action =qtw.QPushButton(label)
        if(callback):
            self.button_action.clicked.connect(callback)
        self.layout.addWidget( self.button_action)

    def slider_ui(self,slide =Qt.Horizontal, min =0, max =100):
        self.slider =qtw.QSlider(slide)
        self.slider.setMinimum(min)
        self.slider.setMaximum(max)
        #if callback:
        self.slider.valueChanged.connect(self.spinBox_value)
        self.layout.addWidget( self.slider)

    def spinBox(self, minimum =0, maximum = 100):
        self.spinbox =qtw.QSpinBox()
        self.spinbox.setMinimum(minimum)
        self.spinbox.setMaximum(maximum)
        
        self.spinbox.valueChanged.connect(self.slider_value)
        self.layout.addWidget(self.spinbox)

    def text_label(self, title="title", height =10):
        self.title_label = qtw.QLabel(title)
        self.title_label.setFixedHeight(height)
        self.layout.addWidget(self.title_label )
        return self.title_label 
    
    def set_message_button(self, text="Text"):
        self.pop =qtw.QMessageBox()
        self.pop.setText("text")
        self.pop.setWindowTitle("Pop message")
        self.pop.setStandardButtons(qtw.QMessageBox.Ok | qtw.QMessageBox.Cancel)
        result =self.pop.exec()
        if(result == qtw.QMessageBox.Ok ):
            print("ok")
        else:
            print("Cancel")

    def slider_value(self, _value):
        self.slider.setValue(_value)
    
    def spinBox_value(self,_value):
         self.spinbox.setValue(_value)
    

app= qtw.QApplication([])
intro = qt_intro()
intro.show()
app.exec()

class parent_class:

    property =2

    def __init__(self, param):
        print("parent " + param)

    def other_example(self):
        print("parent")
       


class first_class(parent_class):

    message ="coucou"

    def __init__(self, param):
        super().__init__(param)



    def example(self):
        print(self.coucou)
        input()

    def other_example(self):
        super().other_example()
        print("child")

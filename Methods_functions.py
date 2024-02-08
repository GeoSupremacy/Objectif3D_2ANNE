value =8
def first_method(a,b):
    c =(a +b)

def last_method(value,b,c):
    return value+b, c


def third_method(self,a,b):
    self.value = 3


first_method(5,7)
print(last_method(10,5,"true")[1])
print(last_method(10,5,"true")[0])
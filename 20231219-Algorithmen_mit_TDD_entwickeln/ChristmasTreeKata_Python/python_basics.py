# Python 1x1

# PYthon Language Reference https://docs.python.org/3/reference/index.html
# Python Standard Library https://docs.python.org/3/library/index.html

# formatting and indentation is significant
# dynamic typing (a value/object has a type, a variable does not have a type)

def aSimpleFunction(x):
    return 0

def functionWithSimpleForLoop():
    sum = 0
    for i in range(5): # i in {0,1,2,3,4}
        sum += i
    return sum

def functionWithIfStatement():
    a = 1
    if a==0:
        return
    
    if a==1:
        return
    elif a==2:
        return
    else:
        return

def aFunctionUsingLists():
    list = [-4, -2, 0, 2, 4]
    list.append(6)
    list.pop(0)
    list.pop()
    for i in list:
        print(i)

def functionUsingStrings():
    s = "A ' '"
    s += "\n"+' "A"'
    s2 = """

"""
    print(s+"B"+s2)

class MyClass: 
    i = 12345
    
    def __init__(self):
        self.data = [1]

    def f(self):
        return 'hello world'

def aFunctionUsingMyClass():
    x = MyClass()
    print(len(x.data))
    print(x.f())

functionWithSimpleForLoop()
functionWithIfStatement()
functionUsingStrings()
aFunctionUsingLists()
aFunctionUsingMyClass()
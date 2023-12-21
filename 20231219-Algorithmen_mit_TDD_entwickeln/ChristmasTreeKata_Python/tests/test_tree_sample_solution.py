"""
Christmas Tree Kata

Write a function that generates Christmas trees.

For example a tree with a height of 2 looks like this:
 X 
XXX
 | 

And a tree with a height of 3 looks like this:
  X  
 XXX 
XXXXX
  |  

"""

import string

def tree(size: int):
    return top(size)+trunk(size)

def trunk(size: int):
    if size>1:
        return " "+trunk(size-1)+" "
    return "|"

def test_tree_of_size_1():
    assert tree(1) == "X\n|"

def test_trunk_of_tree_of_size_1():
    assert trunk(1) == "|"

def test_trunk_of_tree_of_size_2():
    assert trunk(2) == " | "

def test_trunk_of_tree_of_size_3():
    assert trunk(3) == "  |  "

def top(number_of_lines: int):
    top =""
    for i in range(number_of_lines):
        top += line(number_of_lines,i+1)
    return top

def line(number_of_lines,line_number):
    spaces_for_line = number_of_lines-line_number
    number_of_xs = 1+(line_number-1)*2
    return " "*spaces_for_line+"X"*number_of_xs+" "*spaces_for_line+"\n"

def test_top_of_tree_of_size_1():
    assert top(1) == "X\n"

def test_top_of_tree_of_size_2():
    assert top(2) == " X \nXXX\n"

def test_top_of_tree_of_size_3():
    assert top(3) == "  X  \n XXX \nXXXXX\n"

def test_tree_of_size_2():
    assert tree(2) == " X \nXXX\n | "

def test_tree_of_size_3():
    assert tree(3) == "  X  \n XXX \nXXXXX\n  |  "
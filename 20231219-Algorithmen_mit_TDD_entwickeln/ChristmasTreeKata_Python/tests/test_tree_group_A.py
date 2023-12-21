import pytest

"""
Christmas Tree Kata

Write a function that generates Christmas trees.

For example a tree with a height of 1 looks like this:
X
|

And a tree with a height of 2 looks like this:
 X 
XXX
 | 

And a tree with a height of 3 looks like this:
  X  
 XXX 
XXXXX
  |  

"""

def tree(height: int) -> str: 
    result = ''

    for i in range(height):
        result += crown_line(height, i) + '\n'

    return result + trunk(height)


def trunk(height: int) -> str:  # done
    spaces = ' ' * (height - 1)
    return spaces + '|' + spaces

def crown_line(height, line) -> str:
    spaces = ' ' * (height - line -1)
    xs = 'X' * (2 * line + 1)
    return spaces + xs + spaces 

def test_tree_of_size_1():
    assert tree(1) == "X\n|"

def test_tree_of_size_2():
    assert tree(2) == " X \nXXX\n | "

def test_trunk_size_1():
    assert trunk(1) == '|'

def test_trunk_size_4():
    assert trunk(4) == '   |   '

def test_crown_size_1():
    assert crown_line(1, 0) == 'X'

@pytest.mark.skip # sentimental value
def test_crown_size_2():
    assert crown_line(2, 0) == ' X '
    assert crown_line(2, 1) == 'XXX'

def test_crown_size_3():
    assert crown_line(3, 0) == '  X  '
    assert crown_line(3, 1) == ' XXX '
    assert crown_line(3, 2) == 'XXXXX'

def test_tree_of_size_3():
    assert tree(3) == "  X  \n XXX \nXXXXX\n  |  "

def test_just_draw_it():
    for i in range(1, 10):
        print(f'Tree for {i}')
        print(tree(i))

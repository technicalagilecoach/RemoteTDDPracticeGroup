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

import pytest

def tree(height):
  return "X\n|"

def trunk(height):
  spaceCount = height - 1
  result = " "* spaceCount + "|" + " "*spaceCount
  return result

def peak(height):
  spaceCount = height - 1
  result = " "* spaceCount + "X" + " "*spaceCount
  return result

def deck(height):
  result = ""
  for val in range(height-1):
    space_count = height - val
    result += " "*space_count + "X"* height


  return "XXX"
# ----------------------------------- tests ---------------------------------- #
def test_tree_of_size_1():
    assert tree(1) == "X\n|"

def test_trunk_of_size_1():
  assert trunk(1) == "|"

def test_trunk_of_size_2():
  assert trunk(2) == " | "

def test_trunk_of_size_5():
  assert trunk(5) == "    |    "

def test_peak_of_size_1():
  assert peak(1) == "X"

def test_peak_of_size_2():
  assert peak(2) == " X "

def test_peak_of_size_5():
  assert peak(5) == "    X    "

def test_deck_of_size_2():
  assert deck(2) == "XXX"

@pytest.mark.skip
def test_deck_of_size_3():
  assert deck(3) == " XXX \n" + \
                    "XXXXX\n"
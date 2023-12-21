# pytest basics

# https://pytest.org/

# rename file to test_*.py or *_test.py then pytest can find and execute the tests

# test cases are functions whose names start with test_ in files of the form test_*.py or *_test.py?)
def f():
    return 3

def test_function():
    assert f() == 3 # standard Python assertions can be used

def test_assertion():
    a = 8
    assert a % 2 == 0, "value was odd, should be even" # standard Python assertions can be used

# parametrized tests https://docs.pytest.org/en/7.4.x/how-to/parametrize.html
import pytest

@pytest.mark.parametrize("test_input,expected", [("3+5", 8), ("2+4", 6), ("6*7", 42)])
def test_eval(test_input, expected):
    assert eval(test_input) == expected

# fixtures https://docs.pytest.org/en/7.4.x/how-to/fixtures.html
@pytest.fixture
def expected_list():
    return [5, 2, 3]

def test_we_are(expected_list):
    assert expected_list[0] == 5
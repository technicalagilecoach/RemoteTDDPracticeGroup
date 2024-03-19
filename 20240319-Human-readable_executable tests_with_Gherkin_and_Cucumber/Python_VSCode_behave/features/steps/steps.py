# write the step definitions here to translate the scenarios into Python code

from behave import *
from calculator import *

@given(u'we have two numbers {x:d} and {y:d}')
def step_impl(context, x, y):
    context.x = x
    context.y = y

@when(u'they are added')
def step_impl(context):
    context.result = add(context.x, context.y)

@when(u'they are multiplied')
def step_impl(context):
    context.result = multiply(context.x, context.y)

@then(u'the result should be {z:d}.')
def step_impl(context, z):
    assert context.result == z




# Calculator Kata
We will write a simplistic calculator to add or multiply two integers.

## tools and resources
- syntax for scenarios and feature files: https://cucumber.io/docs/gherkin/reference/
- behave (Cucumber in Python) - map scenarios to Python code and execute them: https://behave.readthedocs.io/en/latest/tutorial/
- library to capture arguments in step definitions: https://pypi.org/project/parse/
- run behave using pywatch (PowerShell): ptw.exe --ext=* --runner "python C:\Python312\Lib\site-packages\behave\ --color --summary"

## Addition
- write scenario(s) for addition of two integers in features/addition.feature
- write the required step definitions in features/steps/steps.py
  - run behave - it will suggest skeletons for the required step definitions
  - adapt code to capture the arguments in the step definitions
  - call the actual production code for actual tests
- complete the production code as required to pass the tests

## Multiplication
- write scenario(s) for multiplication of two integers in features/multiplication.feature
  - use a parametric scenario this time ("Scenario Outline")
- add step definitions as required in features/steps/steps.py including calls of production code
- complete the production code as required to pass the tests
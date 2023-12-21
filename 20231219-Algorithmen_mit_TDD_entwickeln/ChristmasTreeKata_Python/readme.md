# Rudimentary Python template for usage with Visual Studio Code

## pytest 
* test framework for Python
* run tests manually on command line with: `python -m pytest`

## pytest-watch
* command line tool to rerun tests automatically when files are changed
* install with: `python -m pip install pytest-watch`
* start in terminal: `ptw`

## Python Test Explorer for Visual Studio Code
* package to detect and run pytest tests using the Visual Studio Code Test Explorer
* after installing this extension there will be two entries calles "Test Explorer" when Testing is selected in the sidebar (one from this extension and one from the dependency "Test Explorer UI")
* this extension does not automatically rerun the tests when files are changed

### Run It On
* extension for Visual Studio Code
* runs terminal or VSCode commands on save or when watched files change
* see .vscode/settings.json on how to configure it to run the Test Explorer whenever files are changed


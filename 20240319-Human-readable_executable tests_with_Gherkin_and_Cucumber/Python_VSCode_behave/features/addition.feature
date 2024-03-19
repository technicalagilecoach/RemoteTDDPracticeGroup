Feature: Addition

  Addition of integers

  Scenario Outline: <a> + <b>
    Given we have two numbers <a> and <b>
    When they are added 
    Then the result should be <answer>.

  Examples:
      | a | b | answer |
      | 1 | 3 | 4      |
      | -1| 3 | 2      |
      | -7| -2| -9     |
      | 0 | 42 | 42    |
Feature: Multiplication

    Multiply two integers

    Scenario Outline: <a> * <b>
        Given we have two numbers <a> and <b>
        When they are multiplied
        Then the result should be <answer>.

        Examples:
        | a | b | answer |
        | 2 | 3 | 6 |
        | 3 | 2 | 6 | 
        | -1 | 2 | -2 | 
        | 0 | 0 | 0 |
        | -10 | -10 | 100 |
        |  1 | 100 | 100 |
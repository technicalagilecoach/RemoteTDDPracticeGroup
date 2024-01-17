/*
Your Task
  You’re part of the team that explores Mars by sending remotely controlled vehicles to the surface of the planet. 
  Develop an API that translates the commands sent from earth to instructions that are understood by the rover.

Requirements
  You are given the initial starting point (x,y) of a rover and the direction (N,S,E,W) it is facing.
  The rover receives a character array of commands.
  Implement commands that move the rover forward/backward (f,b).
  Implement commands that turn the rover left/right (l,r).

Remarks
  Implement one requirement after the other.
  Do not implement more than necessary to fulfill each requirement.
  Switch roles regularly!
  Do not forget to refactor!

Resources
  https://google.github.io/googletest/primer.html
  https://en.cppreference.com/w/cpp/language
  https://en.cppreference.com/w/cpp/standard_library
*/      

#include "gtest/gtest.h"

TEST(TheMarsRover, TestName) {
  ASSERT_EQ(1, 1);
  ASSERT_TRUE(true);
}

int main(int argc, char **argv) {
  testing::InitGoogleTest(&argc, argv);
  return RUN_ALL_TESTS();
}

int x,y;

void initializeRover(int local_x, int local_y, char direction) {
  x=local_x;
  y=local_y;
}

void executeCommands(std::vector<char> commands){
  if (commands.empty())
    return;

  if (commands[0] == 'f')
  {
    x++;
  }
  else if (commands[0] == 'b')
  {
    x--;
  }
}

//You are given the initial starting point (x,y) 
//of a rover and the direction (N,S,E,W) it is facing.
TEST(TheMarsRover, InitialPositionTest) {
  initializeRover(1, 0, 'N');
  ASSERT_EQ(x,1);
}

//The rover receives a character array of commands.
TEST(TheMarsRover, PassCommandsArrayTest){
  std::vector<char> commands{};
  executeCommands(commands);
}

// Implement commands that move the rover forward/backward (f,b).
TEST(TheMarsRover, MovesOneForward){
  //Arrange
  initializeRover(0, 0, 'N');
  //Act
  executeCommands(std::vector<char> {'f'});
  //Assert
  ASSERT_EQ(x, 1);
}

TEST(TheMarsRover, MovesOneBackward){
  //Arrange
  initializeRover(0, 0, 'N');
  //Act
  executeCommands(std::vector<char> {'b'});
  //Assert
  ASSERT_EQ(x, -1);
}
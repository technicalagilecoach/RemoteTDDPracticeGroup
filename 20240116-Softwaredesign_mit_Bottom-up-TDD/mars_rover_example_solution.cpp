#include "gtest/gtest.h"

/*
Your Task
  You’re part of the team that explores Mars by sending remotely controlled vehicles to the surface of the planet. Develop an API that translates the commands sent from earth to instructions that are understood by the rover.

Requirements
  You are given the initial starting point (x,y) of a rover and the direction (N,S,E,W) it is facing.
  The rover receives a character array of commands.
  Implement commands that move the rover forward/backward (f,b).
  Implement commands that turn the rover left/right (l,r).
  //Implement wrapping at edges. But be careful, planets are spheres.
  //Implement obstacle detection before each move to a new square. If a given sequence of commands encounters an obstacle, the rover moves up to the last possible point, aborts the sequence and reports the obstacle.
*/

typedef std::pair<int,int> Position;
typedef char Direction;

typedef std::vector<char> Commands;
typedef char Command;

class Rover {
public:
  Rover(int x, int y, Direction direction) {
    this->position = Position(x,y);
    InitializeDirection(direction);
  }

  Rover(Position& position, Direction direction) {
    this->position = position;
    InitializeDirection(direction);
  }

  Direction GetDirection() {
    return direction;
  }

  Position& GetPosition() {
    return position;
  }

  void ReceiveCommands(Commands& commands) {
    for (auto command:commands) {
      switch (command) {
        case 'f':
          MoveForward(); break;
        case 'b':
          MoveBackward(); break;     
        case 'r':
          TurnRight(); break;
        case 'l':
          TurnLeft(); break;
      }
    }
  }

private:
  void InitializeDirection(Direction direction)
  {
    bool isPossibleDirection = direction == 'N' || direction == 'S' || direction == 'E' || direction == 'W';
    if (isPossibleDirection)
      this->direction = direction;
    else
      throw std::exception();
  }

  void MoveForward()
  {
    Move();
  }

  void MoveBackward()
  {
    Move(true);
  }

  void Move(bool backward=false)
  {
    int dir = 1;
    if (backward)
      dir=-1;

    switch (direction)
    {
    case 'E':
      position.first = position.first + 1 * dir;
      break;
    case 'S':
      position.second = position.second - 1 * dir;
      break;
    case 'W':
      position.first = position.first - 1 * dir;
      break;
    case 'N':
      position.second = position.second + 1 * dir;
      break;
    }
  }



  void TurnRight()
  {
    switch (direction) {
      case 'E':
        direction = 'S'; break;
      case 'S':
        direction = 'W'; break;
      case 'W':
        direction = 'N'; break;
      case 'N':
        direction = 'E'; break;
    }
  }

  void TurnLeft()
  {
    switch (direction) {
      case 'E':
        direction = 'N'; break;
      case 'S':
        direction = 'E'; break;
      case 'W':
        direction = 'S'; break;
      case 'N':
        direction = 'W'; break;
    }
  }

  Position position;
  Direction direction;
};

//You are given the initial starting point (x,y) of a rover and the direction (N,S,E,W) it is facing.
TEST(TheMarsRover, CanBeInitializedWithStartingPointAndDirection) {
  Rover r(1,1,'N');
}

TEST(TheMarsRover, StoresStartingPointAndDirectionOnInitialization) {
  auto actualPosition = Position(2,2);
  Rover r(actualPosition,'N');
  EXPECT_EQ(r.GetPosition(),actualPosition);
  EXPECT_EQ(r.GetDirection(),'N');
}

TEST(TheMarsRover, CanOnlyBeInitializedWithValidDirections) {
  Rover r1(1,1,'N');
  Rover r2(1,1,'S');
  Rover r3(1,1,'E');
  Rover r4(1,1,'W');
  EXPECT_THROW(
    Rover r5(1,1,'X'),
    std::exception
  );
}

//The rover receives a character array of commands.
TEST(TheMarsRover, CanReceiveACharacterArrayOfCommands) {
  auto actualPosition = Position(0,0);
  Rover r(actualPosition,'E');
  Commands commands{'a','b'};
  r.ReceiveCommands(commands);
}

Rover TestCommand(Position position, Direction direction, Command command) {
  Rover r(position,direction);
  Commands commands{command};
  r.ReceiveCommands(commands);
  return r;
}

//Implement commands that move the rover forward/backward (f,b).
//forward movements
TEST(TheMarsRover, MovesRightWhenFacingEastAndMovingForward) {
  Rover r = TestCommand(Position(0,0),'E','f');
  auto expectedPosition = Position(1,0);
  EXPECT_EQ(r.GetPosition(),expectedPosition);
}

TEST(TheMarsRover, MovesDownWhenFacingSouthAndMovingForward) {
  Rover r = TestCommand(Position(0,0),'S','f');
  auto expectedPosition = Position(0,-1);
  EXPECT_EQ(r.GetPosition(),expectedPosition);
}

TEST(TheMarsRover, MovesUpWhenFacingNorthAndMovingForward) {
  Rover r = TestCommand(Position(0,0),'N','f');
  auto expectedPosition = Position(0,1);
  EXPECT_EQ(r.GetPosition(),expectedPosition);
}

TEST(TheMarsRover, MovesLeftWhenFacingWestAndMovingForward) {
  Rover r = TestCommand(Position(0,0),'W','f');
  auto expectedPosition = Position(-1,0);
  EXPECT_EQ(r.GetPosition(),expectedPosition);
}

//backward movements
TEST(TheMarsRover, MovesLeftWhenFacingEastAndMovingBackward) {
  Rover r = TestCommand(Position(0,0),'E','b');
  auto expectedPosition = Position(-1,0);
  EXPECT_EQ(r.GetPosition(),expectedPosition);
}

TEST(TheMarsRover, MovesUpWhenFacingSouthAndMovingBackward) {
  Rover r = TestCommand(Position(0,0),'S','b');
  auto expectedPosition = Position(0,1);
  EXPECT_EQ(r.GetPosition(),expectedPosition);
}

TEST(TheMarsRover, MovesDownWhenFacingNorthAndMovingBackward) {
  Rover r = TestCommand(Position(0,0),'N','b');
  auto expectedPosition = Position(0,-1);
  EXPECT_EQ(r.GetPosition(),expectedPosition);
}

TEST(TheMarsRover, MovesRightWhenFacingWestAndMovingBackward) {
  Rover r = TestCommand(Position(0,0),'W','b');
  auto expectedPosition = Position(1,0);
  EXPECT_EQ(r.GetPosition(),expectedPosition);
}

TEST(TheMarsRover, ReturnsToPreviousPositionWhenMovingForwardAndThenBackward) {
  auto position = Position(0,0);
  Rover r(position,'W');
  Commands commands{'f','b'};
  r.ReceiveCommands(commands);
  EXPECT_EQ(r.GetPosition(),position);
}

//Implement commands that turn the rover left/right (l,r).
//turning right
TEST(TheMarsRover, IsFacingSouthWhenTurningRightAfterFacingEast) {
  Rover r = TestCommand(Position(0,0),'E','r');
  EXPECT_EQ(r.GetDirection(),'S');
}

TEST(TheMarsRover, IsFacingWestWhenTurningRightAfterFacingSouth) {
  Rover r = TestCommand(Position(0,0),'S','r');
  EXPECT_EQ(r.GetDirection(),'W');
}

TEST(TheMarsRover, IsFacingNorthWhenTurningRightAfterFacingWest) {
  Rover r = TestCommand(Position(0,0),'W','r');
  EXPECT_EQ(r.GetDirection(),'N');
}

TEST(TheMarsRover, IsFacingEastWhenTurningRightAfterFacingNorth) {
  Rover r = TestCommand(Position(0,0),'N','r');
  EXPECT_EQ(r.GetDirection(),'E');
}

//turning left
TEST(TheMarsRover, IsFacingNorthWhenTurningLeftAfterFacingEast) {
  Rover r = TestCommand(Position(0,0),'E','l');
  EXPECT_EQ(r.GetDirection(),'N');
}

TEST(TheMarsRover, IsFacingEastWhenTurningLeftAfterFacingSouth) {
  Rover r = TestCommand(Position(0,0),'S','l');
  EXPECT_EQ(r.GetDirection(),'E');
}

TEST(TheMarsRover, IsFacingSouthWhenTurningLeftAfterFacingWest) {
  Rover r = TestCommand(Position(0,0),'W','l');
  EXPECT_EQ(r.GetDirection(),'S');
}

TEST(TheMarsRover, IsFacingWestWhenTurningLeftAfterFacingNorth) {
  Rover r = TestCommand(Position(0,0),'N','l');
  EXPECT_EQ(r.GetDirection(),'W');
}


int main(int argc, char **argv) {
  testing::InitGoogleTest(&argc, argv);
  return RUN_ALL_TESTS();
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Trivia
{
    public record Question(QuestionType type, string text)
    {
        public string toString()
        {
            return this.text;
        }
    };

    public enum QuestionType
    {
        Pop, Science, Sports, Rock,
    }

    public class Game
    {
        List<string> players = new List<string>();

        int[] places = new int[6];
        int[] purses = new int[6];

        bool[] inPenaltyBox = new bool[6];

        LinkedList<Question> popQuestions = new LinkedList<Question>();
        LinkedList<Question> scienceQuestions = new LinkedList<Question>();
        LinkedList<Question> sportsQuestions = new LinkedList<Question>();
        LinkedList<Question> rockQuestions = new LinkedList<Question>();

        int currentPlayer = 0;
        bool isGettingOutOfPenaltyBox;

        StringBuilder stringBuilder = new StringBuilder();
        StringWriter stringWriter = null;

        public Game()
        {
            stringWriter = new StringWriter(stringBuilder);

            for (int i = 0; i < 50; i++)
            {
                popQuestions.AddLast(new Question(QuestionType.Pop, "Pop Question " + i));
                scienceQuestions.AddLast(new Question(QuestionType.Science, "Science Question " + i));
                sportsQuestions.AddLast(new Question(QuestionType.Sports, "Sports Question " + i));
                rockQuestions.AddLast(new Question(QuestionType.Rock, "Rock Question " + i));
            }
        }

        public void addPlayer(String playerName)
        {
            players.Add(playerName);
            places[howManyPlayers()] = 0;
            purses[howManyPlayers()] = 0;
            inPenaltyBox[howManyPlayers()] = false;

            stringWriter.WriteLine(playerName + " was added");
            stringWriter.WriteLine("They are player number " + players.Count);
        }

        public int howManyPlayers()
        {
            return players.Count;
        }

        public void roll(int roll)
        {
            stringWriter.WriteLine(players[currentPlayer] + " is the current player");
            stringWriter.WriteLine("They have rolled a " + roll);

            if (inPenaltyBox[currentPlayer])
            {
                isGettingOutOfPenaltyBox = roll % 2 != 0;

                if (isGettingOutOfPenaltyBox)
                {
                    stringWriter.WriteLine(players[currentPlayer] + " is getting out of the penalty box");

                    // execute move
                    MoveForward(roll);
                    PrintLocationAndCategory();
                    askQuestion();
                }
                else
                {
                    stringWriter.WriteLine(players[currentPlayer] + " is not getting out of the penalty box");
                }
            }
            else
            {
                // execute move
                MoveForward(roll);
                PrintLocationAndCategory();
                askQuestion();
            }

        }

        private void PrintLocationAndCategory()
        {
            stringWriter.WriteLine(players[currentPlayer]
                    + "'s new location is "
                    + places[currentPlayer]);
            stringWriter.WriteLine("The category is " + currentCategory());
        }

        private void MoveForward(int roll)
        {
            places[currentPlayer] = places[currentPlayer] + roll;
            if (places[currentPlayer] > 11) places[currentPlayer] = places[currentPlayer] - 12;
        }

        private void askQuestion()
        {
            if (currentCategory() == "Pop")
            {
                stringWriter.WriteLine(popQuestions.First().toString());
                popQuestions.RemoveFirst();
            }
            if (currentCategory() == "Science")
            {
                stringWriter.WriteLine(scienceQuestions.First().toString());
                scienceQuestions.RemoveFirst();
            }
            if (currentCategory() == "Sports")
            {
                stringWriter.WriteLine(sportsQuestions.First().toString());
                sportsQuestions.RemoveFirst();
            }
            if (currentCategory() == "Rock")
            {
                stringWriter.WriteLine(rockQuestions.First().toString());
                rockQuestions.RemoveFirst();
            }
        }


        private String currentCategory()
        {
            if (places[currentPlayer] == 0) return "Pop";
            if (places[currentPlayer] == 4) return "Pop";
            if (places[currentPlayer] == 8) return "Pop";
            if (places[currentPlayer] == 1) return "Science";
            if (places[currentPlayer] == 5) return "Science";
            if (places[currentPlayer] == 9) return "Science";
            if (places[currentPlayer] == 2) return "Sports";
            if (places[currentPlayer] == 6) return "Sports";
            if (places[currentPlayer] == 10) return "Sports";
            return "Rock";
        }

        public void printCorrectAnswer()
        {
            stringWriter.WriteLine("Answer was correct!!!!");
            purses[currentPlayer]++;
            stringWriter.WriteLine(players[currentPlayer]
                    + " now has "
                    + purses[currentPlayer]
                    + " Gold Coins.");
        }
        
        public bool wasCorrectlyAnswered()
        // returns True if there is no winner
        // returns False if there is a winner
        {
            if (inPenaltyBox[currentPlayer] && !isGettingOutOfPenaltyBox)
            {
                nextPlayer();
                return true;
            }

            printCorrectAnswer();

            bool winner = didPlayerWin();
            nextPlayer();
            return winner;
        }

        public void nextPlayer()
        {
            currentPlayer++;
            if (currentPlayer == players.Count) currentPlayer = 0;
        }

        public bool wrongAnswer()
        {
            stringWriter.WriteLine("Question was incorrectly answered");
            stringWriter.WriteLine(players[currentPlayer] + " was sent to the penalty box");
            inPenaltyBox[currentPlayer] = true;

            nextPlayer();
            return true;
        }


        private bool didPlayerWin()
        {
            return !(purses[currentPlayer] == 6);
        }

        public string GetLog()
        {
            return stringWriter.ToString();
        }
    }
}

using System;

namespace Trivia
{
    public class GameRunner
    {

        private static bool notAWinner;

        public static void Main(String[] args)
        {
            Game aGame = new Game();

            Play(aGame);

            Console.Write(aGame.GetLog());
        }

        public static void Play(Game aGame)
        {
            aGame.addPlayer("Chet");
            aGame.addPlayer("Pat");
            aGame.addPlayer("Sue");

            Random rand = new Random(1);

            do
            {
                aGame.roll(rand.Next(5) + 1);

                if (rand.Next(9) == 7)
                {
                    notAWinner = aGame.wrongAnswer();
                }
                else
                {
                    notAWinner = aGame.wasCorrectlyAnswered();
                }
            } while (notAWinner);
        }
    }
}


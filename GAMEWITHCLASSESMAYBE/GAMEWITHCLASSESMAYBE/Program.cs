using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;
using System.Runtime.InteropServices;

namespace GAMEWITHCLASSESMAYBE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //variables
            bool playGame = false;
            int GDIWidth = 800;
            int GDIHeight = 600;
            string name;
            double lives;
            int situationCounter = 0;



            //other stuff
            Player player1 = new Player();
            //CDrawer canvas = new CDrawer(GDIWidth, GDIHeight, false);

            //doing things
            
            //get player name from player
            name = player1.name = getName();

            do
            {
                playGame = startGame(name);


            } while (playGame == false);


            lives = 5;
            do
            {
                lifeDisplay(lives);

                switch (situationCounter)
                {
                    case 0:
                        lives = lives - situationOne(lives, name);
                        situationCounter++;
                        break;
                    
                    case 1:
                        break;

                    case 2:
                        break;

                    case 3:
                        break;
                }





            } while (playGame);










            Console.ReadLine();
        }
        


        //METHODS


        //gets a player name from the player

        static string getName()
        {
            bool success = true;
            string userName;

            do
            {
                bool notAllowed = false;
                string askName = "What is your name? ";
                string wrongName = "I don't think your parents named you that...";

                
                foreach (char c in askName)
                {
                    Console.Write(c);
                    System.Threading.Thread.Sleep(5);
                }

                userName = Console.ReadLine();

                foreach (char c in userName)
                {
                    if ((char.IsDigit(c) || char.IsSymbol(c) || char.IsPunctuation(c)) && !notAllowed)
                    {
                        notAllowed = true;
                        foreach (char d in wrongName)
                        {
                            Console.Write(d);
                            System.Threading.Thread.Sleep(5);


                        }
                        Console.WriteLine("");
                        success = false;

                    }
                    else if (notAllowed == false && success == false)
                    {
                        success = true;
                    }
                }

            } while (!success);

            return userName;
        }


        //starting game
        static bool startGame(string playerName)
        {
            string firstDialogue = $"Ah... {playerName}... It is nice to meet you.";
            string secondDialogue = "Your challenge is to go about your day. You will make choices and face the consequences.";
            string thirdDialogue = "For each person you hurt, you will lose a heart. To win, you must end the day without losing all your hearts.";
            string fourthDialogue = "Are you ready to begin? Y/N: ";
            string userAnswer = "";
            int textCounter = 0;
            int GDIWidth = 800;
            int GDIHeight = 600;
            bool getAnswer = false;

            //CDrawer canvas = new CDrawer(GDIWidth, GDIHeight, false);

            Console.WriteLine();

            if (textCounter == 0)
            {

                foreach (char c in firstDialogue)
                {
                    Console.Write(c);
                    System.Threading.Thread.Sleep(5);
                }
                Console.WriteLine();
                textCounter++;

            }

            if (textCounter == 1)
            {

                foreach (char c in secondDialogue)
                {
                    Console.Write(c);
                    System.Threading.Thread.Sleep(5);
                }
                Console.WriteLine();
                textCounter++;
            }

            if (textCounter == 2)
            {
                //canvas.Render();

                foreach (char c in thirdDialogue)
                {
                    Console.Write(c);
                    System.Threading.Thread.Sleep(5);
                }
                Console.WriteLine();
                textCounter++;
            }


            while (!getAnswer)
            {
                foreach (char c in fourthDialogue)
                {
                    Console.Write(c);
                    System.Threading.Thread.Sleep(5);
                }

                userAnswer = Console.ReadLine().ToLower();

                if (userAnswer != "y" && userAnswer != "n")
                {
                    foreach (char c in "Sorry, I don't accept that answer.")
                    {
                        Console.Write(c);
                        System.Threading.Thread.Sleep(5);

                    }

                }

                if (userAnswer == "y" || userAnswer == "n")
                {
                    getAnswer = true;
                }

            }

            if (userAnswer == "y")
            {
                return true;
            }
            else
            {
                return false;
            }

            Console.ReadLine();
        }

        //show lives and such
        static void lifeDisplay(double currentLives)
        {
            int consolePosition;
            string textToDisplay = $"You have {currentLives} lives.";
            Console.Clear();

            consolePosition = Console.WindowWidth / 2;
            Console.CursorLeft = consolePosition - textToDisplay.Length / 2;
            Console.Write(textToDisplay);
            Console.WriteLine();


        }


        //situation 1

        static double situationOne(double lives, string playerName)
        {
            string oneOne = "You get to school and see your friend, Brad, looks disheveled.";
            string oneTwo = "What do you say?";
            string twoOne = "Brad : 'My dog died last night :( '";
            string threeOneOne = "Brad : '... I loved Trevor ;-; '";
            string threeOneTwo = $"Brad : 'You're an awful friend, {playerName}!'";
            string threeTwoOne = $"Brad : 'Not really, but its nice to know you're here for me, {playerName} '";
            string threeThreeOne = "Brad : 'Oh ...'";

            string optionsOneOne = "A : 'Hey Brad! Are you ok?' ";
            string optionsOneTwo = "B : 'You look disgusting. What happened?' ";
            string optionsOneThree = "C : I say nothing and walk by.";
            string optionsTwoOne = "A : Good. That was one ugly dog.";
            string optionsTwoTwo = "B : I'm so sorry! Is there anything I can do to help you?";
            string optionsTwoThree = "C : That sucks. I have a hamster.";
            //string optionsOneThree = "C : Hey, Brad, Are "


            string userChoice;

            int dialogueCounter = 0;
            int x = 0;
            int situation3 = 0;
            int consolePosition;
            bool pass1 = false;
            bool pass2 = false;
            bool pass3 = false;
            double badChoices = 0.0;

            do
            {


                if (dialogueCounter == 0)
                {
                    slowWrite(oneOne);
                    Console.WriteLine();
                    slowWrite(oneTwo);
                    Console.WriteLine();

                    while (x <= 2)
                    {
                        consolePosition = Console.WindowWidth / 6;
                        switch (x)
                        {
                            case 0:
                                slowWrite(optionsOneOne);
                                break;
                            case 1:
                                slowWrite(optionsOneTwo);
                                break;
                            case 2: 
                                slowWrite(optionsOneThree);
                                break;

                        }
                        x++;
                        Console.WriteLine();


                    }
                    dialogueCounter++;
                }

                userChoice = Console.ReadLine().ToLower();
                if (userChoice != "a" && userChoice != "b" && userChoice != "c")
                {
                    slowWrite("That was not a valid choice. Try again!");
                    Console.WriteLine();
                    pass1 = false;
                }
                else if (userChoice == "a")
                {
                    pass1 = true;
                }
                else if (userChoice == "b")
                {
                    badChoices = badChoices + 1;
                    pass1 = true;
                }
                else if (userChoice == "c")
                {
                    slowWrite("You weren't a very good friend to Brad. His dog just died.");
                    badChoices++;
                    Console.WriteLine();
                    slowWrite($"You lost {badChoices} life this round.");
                    Console.ReadLine();
                    return badChoices;
                }

            } while (pass1 == false);

            do
            {
                if (dialogueCounter == 1)
                {
                    slowWrite(twoOne);
                    Console.WriteLine();
                    while (x <= 5)
                    {
                        switch (x)
                        {
                            case 3:
                                slowWrite(optionsTwoOne);
                                x++;
                                break;
                            case 4:
                                slowWrite(optionsTwoTwo);
                                x++;
                                break;
                            case 5:
                                slowWrite(optionsTwoThree);
                                x++;
                                break;
                        }
                        Console.WriteLine();
                    }
                }
                userChoice = Console.ReadLine().ToLower();
                if (userChoice != "a" && userChoice != "b" && userChoice != "c")
                {
                    slowWrite("That was not a valid choice. Try again!");
                    Console.WriteLine();
                    pass2 = false;
                }
                else if (userChoice == "a")
                {
                    badChoices++;
                    pass2 = true;
                    situation3 = 1;
                }
                else if(userChoice == "b")
                {
                    pass2 = true;
                    situation3 = 2;
                }
                else if (userChoice == "c")
                {
                    badChoices = badChoices + 0.5;
                    pass2 = true;
                    situation3 = 3;
                }


            } while (!pass2);

            
            
            switch (situation3)
            {
                case 1:
                    slowWrite(threeOneOne);
                    Console.WriteLine();
                    slowWrite(threeOneTwo);
                    break;
                case 2:
                    slowWrite(threeTwoOne);
                    break;
                case 3:
                    slowWrite(threeThreeOne);
                    break;
            }


            Console.WriteLine();
            Console.WriteLine($"You lost {badChoices} lives this round.");
            Console.ReadLine();
            
            return badChoices;
        }


        //do the slow text
        static void slowWrite(string textToDisplay)
        {

            foreach (char c in textToDisplay)
            {

                Console.Write(c);
                System.Threading.Thread.Sleep(5);
            }

        }






        





    }
}

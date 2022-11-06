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
            bool alwaysTrue = true;


            //other stuff
            /*Player player1 = new Player();*/
            //CDrawer canvas = new CDrawer(GDIWidth, GDIHeight, false);

            //doing things
            
            //get player name from player
            slowWrite("...A new player approaches...");
            Console.WriteLine();
            name = /*player1.name =*/ getName();

            do
            {
                playGame = startGame(name);


            } while (playGame == false);

            do
            { 

                lives = 3;
                do
                {
                    lifeDisplay(lives);
                    if (lives >= 0)
                    { 
                        switch (situationCounter)
                        {
                            case 0:
                                lives = lives - situationOne(lives, name);
                                situationCounter++;
                                break;
                    
                            case 1:
                                lives = lives - situationTwo(lives, name);
                                situationCounter++;
                                break;

                            case 2:
                                lives = lives - situation3(lives, name);
                                situationCounter++;
                                break;

                            case 3:
                                playGame = false;
                                break;
                        }
                        slowWrite("Press any key to continue");
                        Console.ReadLine();
                    }
                    else if (lives <0)
                    {
                        playGame = false;
                    }



                } while (playGame);

                do
                {
                    playGame = endGame(lives);



                } while (!playGame);



            } while (alwaysTrue);




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
            string secondDialogue = "Your challenge is to make it through these everyday situations. You will make choices and face the consequences.";
            string thirdDialogue = "For every faux pas you will lose a life. To win, you must end the day without losing all of your lives.";
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
                slowWrite(firstDialogue);
                Console.WriteLine();
                textCounter++;
            }

            if (textCounter == 1)
            {
                slowWrite(secondDialogue);
                Console.WriteLine();
                textCounter++;
            }

            if (textCounter == 2)
            {
                //canvas.Render();
                slowWrite(thirdDialogue);
                Console.WriteLine();
                textCounter++;
            }


            while (!getAnswer)
            {
                slowWrite(fourthDialogue);
                Console.WriteLine();
                slowWrite("Your selection is: ");
                userAnswer = Console.ReadLine().ToLower();

                if (userAnswer != "y" && userAnswer != "n")
                {
                    slowWrite("Sorry, I don't accept that answer.");

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
                        switch (x)
                        {
                            case 0:
                                indentText();
                                slowWrite(optionsOneOne);
                                break;
                            case 1:
                                indentText();
                                slowWrite(optionsOneTwo);
                                break;
                            case 2: 
                                indentText();
                                slowWrite(optionsOneThree);
                                break;

                        }
                        x++;
                        Console.WriteLine();


                    }
                    dialogueCounter++;
                }
                Console.WriteLine();
                slowWrite("Your selection is: ");
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
                    return badChoices;
                }

            } while (pass1 == false);

            do
            {
                if (dialogueCounter == 1)
                {
                    slowWrite(twoOne);
                    Console.WriteLine();
                    slowWrite(oneTwo);
                    Console.WriteLine();
                    while (x <= 5)
                    {
                        switch (x)
                        {
                            case 3:
                                indentText();
                                slowWrite(optionsTwoOne);
                                x++;
                                break;
                            case 4:
                                indentText();
                                slowWrite(optionsTwoTwo);
                                x++;
                                break;
                            case 5:
                                indentText();
                                slowWrite(optionsTwoThree);
                                x++;
                                break;
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    slowWrite("Your selection is: ");
                    dialogueCounter++;
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
            
            return badChoices;
        }

        //situation 2
        static double situationTwo(double playerLives, string playerName)
        {
            string userAnswer = "";
            string howRespond = "How do you respond?";
            string oneOne = "You have an interview with a fast food restaurant.";
            string oneTwo = "Today you will be meeting with Lindsay, who will be interviewing you for a cashier position.";
            string oneThree = "Lindsay: 'How are you doing?' "; 

            string optionsOneOne = "A: I tell her about the conversation I had with Brad and ask her for advice.";
            string optionsOneTwo = "B: I ignore the question and tell her how many other jobs I could get. ";
            string optionsOneThree = "C: I say, 'I’m doing okay. How are you?' ";

            string reactionsOneOne = "Lindsay : 'Let’s stick to the interview questions.'";
            string reactionsOneTwo = "Lindsay : 'You sound very confident.' ";
            string reactionsOneTwoTwo = "Lindsay : 'Unfortunately, I don’t think you’re the right fit for our team right now. Thank you for your time.'";
            string reactionsOneThree = "Lindsay smiles and nods.";
            string reactionsOneThreeOne = "Lindsay : 'I’m good, thank you for asking.' ";

            string outcomesOneOne = "A few weeks have gone by since your interview, and you still haven’t heard from Lindsay about the job.";
            string outcomesOneTwo = "When you talk to your parents about it,your mom says that your answer was too personal and might have made Lindsay feel uncomfortable.";
            string outcomesTwoOne = "You ignored Lindsay’s question and made a bad impression. You will not be able to reapply to this restaurant";
            string outcomesThreeOne = "Lindsay thought you were very friendly and, based on your interview performance, would make a good cashier. "; 
            string outcomesThreeTwo = "She has recommended you for the job.";

            bool pass1 = false;

            int dialogueCounter = 1;
            int consolePosition;
            int x = 0;
            int badChoices = 0;
            int spacingCounter= 0;

            do
            {
                slowWrite(oneOne);
                Console.WriteLine();
                slowWrite(oneTwo);
                Console.WriteLine();
                Console.WriteLine();
                slowWrite(oneThree);
                Console.WriteLine();


                if(dialogueCounter == 1)
                {
                    while (x <=2)
                    {

                        
                        //slowWrite(either questionSay or questionDo);
                        switch (x)
                        {
                            case 0:
                                indentText();
                                slowWrite(optionsOneOne);
                                break;
                            case 1:
                                indentText();
                                slowWrite(optionsOneTwo);
                                break;
                            case 2: 
                                indentText();
                                slowWrite(optionsOneThree);
                                break;

                        }
                        x++;
                        Console.WriteLine();
                    }
                    dialogueCounter++;
                        
                }
                    
                Console.WriteLine();
                
                dialogueCounter++;
                slowWrite(howRespond);
                Console.WriteLine();
                slowWrite("Your selection is : ");
                userAnswer = Console.ReadLine().ToLower();
                if(userAnswer != "a" && userAnswer != "b" && userAnswer !="c")
                {
                    slowWrite("That was not a valid choice. Try again!");
                    Console.WriteLine();
                    pass1 = false; 

                }
                else if (userAnswer == "a")
                {
                    slowWrite(reactionsOneOne);
                    pass1 = true;

                    badChoices++;
                }
                else if (userAnswer == "b")
                {
                    slowWrite(reactionsOneTwo);
                    Console.WriteLine();
                    slowWrite(reactionsOneTwoTwo);
                    pass1 = true;
                    badChoices = badChoices + 2;


                }
                else if (userAnswer == "c")
                {
                    slowWrite(reactionsOneThree);
                    Console.WriteLine();
                    slowWrite(reactionsOneThreeOne);
                    pass1 = true;
                    badChoices = badChoices;
                }
            } while (!pass1);


            Console.WriteLine();

            while (spacingCounter < Console.WindowWidth)
            {
                Console.Write("~");
                spacingCounter++;
            }

            if (userAnswer == "a")
            {
                slowWrite(outcomesOneOne);
                Console.WriteLine();
                slowWrite(outcomesOneTwo);
                Console.WriteLine();
            }
            else if (userAnswer == "b")
            {
                slowWrite(outcomesTwoOne);
                Console.WriteLine();

            }
            else if (userAnswer == "c")
            {                    
                slowWrite(outcomesThreeOne);
                Console.WriteLine();
                slowWrite(outcomesThreeTwo);
                Console.WriteLine();

            }

            Console.WriteLine($"You lost {badChoices} lives this round.");
            return badChoices;

        }

        //situation 3
        static double situation3(double lives, string playerName)
        {
            string oneOne = "While you’re out picking up groceries you see your friend Alex.";
            string oneTwo = "You’ve had a crush on them for a while, and you think they might like you back.";
            string oneThree = "You’d like to compliment Alex. What do you say?";
            string question = "What do you do?";
            string displayAnswer = "Your selection : ";

            string optionOne = "A : 'You look really good in those jeans. We should hang out sometime.'";
            string optionTwo = "B : 'Hey Alex! What a nice surprise running into you here. You look great.'";
            string optionThree = "C : They look busy. Maybe another time.";

            string reactionOne = "Alex frowns. 'Sorry this isn’t a good time.'";
            string reactionTwo = $"Alex smiles. 'Thanks, {playerName}. I really needed that today.'";

            string outcomeOne = "Alex didn’t recognize you and your words made them uncomfortable. Next time you should start by introducing yourself.";
            string outcomeTwo = "Alex is politely telling you they are not interested, but because you used good manners they didn’t feel uncomfortable ";
            string outcomeTwoTwo = "and it will be easy to remain friends.";
            string outcomeThree = "Alex saw you and is hurt that you didn’t say hi. They were having a hard day and could’ve used a friend.";

            string userAnswer = "";
            bool play1 = false;
            int dialogueCounter = 1;
            int x = 0;
            double badChoices = 0;
            int spaceCounter = 0;

            do
            {



                if (dialogueCounter == 1)
                    {
                    slowWrite(oneOne);
                    Console.WriteLine();
                    slowWrite(oneTwo);
                    Console.WriteLine();
                    Console.WriteLine();
                    slowWrite(oneThree);
                    Console.WriteLine();
                    slowWrite(question);
                    Console.WriteLine();
                    while (x <=2)
                    {
                        switch (x)
                        {
                            case 0:
                                indentText();
                                slowWrite(optionOne);
                                break;

                            case 1:
                                indentText();
                                slowWrite(optionTwo);
                                break;
                            case 2:
                                indentText();
                                slowWrite(optionThree);
                                break;


                        }
                        x++;
                        Console.WriteLine();
                    }

                    dialogueCounter++;

                }
                slowWrite(displayAnswer);
                userAnswer = Console.ReadLine().ToLower();
                if (userAnswer != "a" && userAnswer != "b" && userAnswer != "c")
                {
                    
                    slowWrite("That was not a valid choice. Try again!");
                    Console.WriteLine();
                    play1 = false; 
                }

                if (userAnswer =="a")
                {
                    slowWrite(reactionOne);
                    Console.WriteLine();
                    badChoices = badChoices + 0.5;
                    play1 = true;
                }
                if (userAnswer == "b")
                {
                    slowWrite(reactionTwo);
                    Console.WriteLine();
                    badChoices = badChoices;
                    play1 = true;
                }
                if (userAnswer == "c")
                {
                    badChoices++;
                    slowWrite(outcomeThree);
                    Console.WriteLine();
                    return badChoices;
                }





            } while (!play1);

            while (spaceCounter < Console.WindowWidth)
            {
                Console.Write("~");
                spaceCounter++;
            }
            Console.WriteLine();
            if (userAnswer == "a")
            {
                slowWrite(outcomeOne);
                Console.WriteLine();
            }
            if (userAnswer == "b")
            {
                slowWrite(outcomeTwo);
                Console.WriteLine();
                slowWrite(outcomeTwoTwo);
            }


            Console.WriteLine();
            return badChoices;




        }

        //end the game
        static bool endGame(double playerLives)
        {
            string oneOne = "You made it through alive.";
            string oneTwo = $"You have {playerLives} left. Good job!";
            string badOutCome = "Oh no! You died!";
            string two = "Want to play again? Y/N: ";
            string userAnswer = "";

            bool goodAnswer = false;

            slowWrite(oneOne);
            Console.WriteLine();
            slowWrite(oneTwo);
            Console.WriteLine();
            Console.WriteLine();

            if (playerLives <= 0)
            {
                slowWrite(badOutCome);
                Console.WriteLine();
                
            }
            else
            {
                slowWrite(two);
                Console.WriteLine();

            }

            userAnswer = Console.ReadLine().ToLower();
            Console.WriteLine();

            do
            {

                if (userAnswer != "y")
                {
                    if (userAnswer == "n")
                    {
                        return false;
                    }
                    else if (userAnswer != "a" && userAnswer != "n")
                    {
                        slowWrite("Sorry, that is not a valid selection");
                        goodAnswer =false;
                    }
                }
                else if (userAnswer == "y")
                {
                    return true;
                }
                else
                {
                    return false;
                }


            } while (!goodAnswer);
            return true;

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


        //do the indents on the options
        static void indentText()
        {
            int consolePosition;
            consolePosition = Console.WindowWidth / 12;
            Console.CursorLeft = consolePosition;
        }



        





    }
}

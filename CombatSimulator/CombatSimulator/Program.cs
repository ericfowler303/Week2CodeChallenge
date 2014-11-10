using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatSimulator
{
    class Program
    {
         static List<string> billQuote = new List<string>() {
        "Umm yea...I'm gonna need those TPS Reports....ASAP...",
        "Umm yea...Did you read the memo about the TPS Reports",
        "Ah, ah, I almost forgot... I'm also going to need you to go ahead and come in on Sunday, too. We, uhhh, lost some people this week and we sorta need to play catch-up. Mmmmmkay? Thaaaaaanks.",
        "....So, if you could do that, that would be great...",
        "Hello Peter, what's happening? Listen, are you gonna have those TPS reports for us this afternoon?",
        "Oh, and next Friday is Hawaiian shirt day.......So, you know, if you want to you can go ahead and wear a Hawaiian shirt and jeans."};
        static bool smashedPrinter = false;
        static bool accountingVirusRunning = false;
        static double enemyMoney = 200.0;
        static double yourMoney = 100.0;
        static double virusMoney = 0.0;
        static Random rng;
        static bool isPlaying;

        static void Main(string[] args)
        {
            InitGame();
        }
        static void InitGame()
        {
            // Reset variables
            smashedPrinter = false;
            accountingVirusRunning = false;
            enemyMoney = 200.0;
            yourMoney = 100.0;
            virusMoney = 0.0;
            rng = new Random();
            isPlaying = true;

            // Now that everything is reset we can play the game
            PlayGame();
        }

        static void PlayGame()
        {
            // Start the game off
            // Print out an ASCII Art version of the Initech Logo
            Console.WriteLine(".................,+++,..................");
            Console.WriteLine("...............,+++++++=,...............");
            Console.WriteLine("............,+++++++++++++,.............");
            Console.WriteLine("...........,+++++,,,,,+++++,,...........");
            Console.WriteLine("...........,,,,,   I,,,,+,  ,...........");
            Console.WriteLine("...........,,,,    I,,,,,   ,...........");
            Console.WriteLine("........,:,,,,,    ,,,,,,   ,,,.........");
            Console.WriteLine("......,+++++,,, I,++++,,, ,+++++,,......");
            Console.WriteLine("...,~+++++++++,=++++++++,++++++++++,....");
            Console.WriteLine(".,+++++++,,++++++++++++++++++,,++++++,..");
            Console.WriteLine(".,,:++,, ,,,,+++, ,, ,,,++,~ ,,,,+++, ,.");
            Console.WriteLine(".,,,,    ,,,,,,   ,: ,,,,    ,,,,,,   ,.");
            Console.WriteLine(".,,,,    ,,,,,7   ,, ,,,,    ,,,,,,   ,.");
            Console.WriteLine(".,,,,   ,+,,,,7   ,,,,,,,   ,+,,,,,   ,.");
            Console.WriteLine(".,,,, ,+++++,,7   ...,,,,7,+++++,,,   ,.");
            Console.WriteLine(".,,,,,,++++++,    ...,,,,,++++++,,    ,.");
            Console.WriteLine(".,,,,,,,,+,      ,...,,,,,,,,+,       ,.");
            Console.WriteLine("...,,,,,,      ,.......,,,,,,      ,....");
            Console.WriteLine(".....,,,,    ,...........,,,,    ,......");
            Console.WriteLine("........,?,,...............,,  ,........");
            Console.WriteLine("..........Welcome To Initech.,..........");
            Console.WriteLine("      What's good for the COMPANY?\n");

            Console.WriteLine("Press any key to get to work.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Office Space\n");
            PrintCurrentGame();

            // Play the game
            while (isPlaying)
            {
                // Check to see if either side has lost
                if(yourMoney <= 0 || enemyMoney <=0 ) 
                {
                    // See who has lost and print proper ending
                    if (yourMoney <= 0)
                    {
                        // Enemy has won
                        EndingCondition(true);
                    }
                    else
                    {
                        // Enemy has lost
                        EndingCondition(false);
                    }
                } else {
                    // Game is still going on


                    // Get the user weapon choice
                    string userChoice = Console.ReadLine();             

                    // Display results of attack
                    PrintAttackScreen(userChoice);
                }
            }

            // End of game
            // ask if they want to play again
            if("y" == Console.ReadLine().ToLower())
            { InitGame(); }
        }
        /// <summary>
        /// Function to determine the random damage that the enemy might cause
        /// </summary>
        /// <returns></returns>
        static double CalcEnemyDamage()
        {
            // Has a 80% chance of hitting
            if (rng.NextDouble() >= 0.2)
            {
                // A hit, between $5-$15 loss for the player
                return rng.Next(5, 16);
            }
            else
            {
                return 0.0;
            }
        }

        static double CalcPlayerDamage(string weaponChoice)
        {
            switch (weaponChoice)
            {
                // Tetris at Work
                case "1":
                    if (rng.NextDouble() >= 0.3) { return rng.Next(20, 36); }
                    break;

                // Burn TPS reports
                case "2":
                    return rng.Next(10, 16);

                // Grab a beer at Chotchkie's with Joanna
                case "3":
                    // update $ due to healing
                    yourMoney += rng.Next(10, 21);
                    // Healing doesn't hurt the enemy
                    return -1;

                // smashed printer
                case "4":
                    // If the player can attack with the printer piece, it has a 50% chance of hitting with between 20-35 times a critical damage enhancement
                    if (smashedPrinter) { if (rng.NextDouble() >= 0.5) { return rng.Next(20, 36) * (rng.NextDouble() + 1); } else { return -3; } }
                    else { smashedPrinter = true; return -4; } // Miss a turn to smash the printer

                // accounting virus
                case "5":
                    // Make the intial value of money stolen to be used the next time the program is run
                    virusMoney = rng.Next(1, 9);
                    // Start the penny stealer
                    accountingVirusRunning = true;

                    // status code for the virus
                    return -2;
            }

            // invalid choice
            return -5;
        }

        private static void VirusRunner()
        {
            // Steal money from the company, a fraction of a penny at a time, which happens to be surprisingly more then expected
            double virusTemp = virusMoney * (rng.NextDouble() + 2.1);
            virusMoney = virusTemp;
            // Give the play the extra stolen money
            yourMoney += virusTemp;
           
        }
        /// <summary>
        /// Prints out the attack summmary screen
        /// </summary>
        static void PrintAttackScreen(string userInput)
        {
            Console.Clear();
            Console.WriteLine("Office Space\n");

            // Print enemy attack results
            double enemyDamage = CalcEnemyDamage();
            yourMoney -= enemyDamage;
            if (enemyDamage != 0)
            {
                // Enemy hit
                Console.WriteLine(billQuote[rng.Next(billQuote.Count)]); // Print random Bill Lubergh Quote
                Console.WriteLine("Bill Lumbergh hit you with a $" + enemyDamage + " fine");
            }
            else
            {
                // Enemy missed
                Console.WriteLine("Bill Lumbergh somehow missed your desk in his rounds today");
            }
            // Print your attack
            // printing is included in function
            double playerDamage = CalcPlayerDamage(userInput);
            if (playerDamage > 0)
            {
                // Player hit Bill
                enemyMoney -= playerDamage;
                Console.WriteLine("You hit Bill Lumbergh for $" + playerDamage + " of wasted company money");
            }
            else if (playerDamage == -1)
            {
                // Player did some healing
                Console.WriteLine("Spending time with Joanna has helped you heal your wounds from your miserable cubicle life.");

            }
            else if (playerDamage == -2)
            {
                if (accountingVirusRunning)
                {
                    // Virus already running, do nothing
                }
                else
                {
                    // Virus was run
                    Console.WriteLine("The accounting virus is on the loose, hopefully it only steals a few fractions of a penny at a time.");
                }
            }
            else if (playerDamage == -3)
            {
                // Attack with the printer part missed
                Console.WriteLine("That damn printer failed you on a daily basis and how it's busted up part failed you as well.");

            } else if (playerDamage == -4) {
                // Busted up the printer but wasted a turn
                Console.WriteLine("You really showed that jammed up printer who's boss.");
            }
            else
            {
               // Player missed
                Console.WriteLine("You choked under pressure. Hope that Joanna doesn't find out.");
            }

            // If the virus is runnning, make it take money each turn
            if (accountingVirusRunning)
            {
                VirusRunner();
            }

            // Keep the attack screen on screen for 5 seconds before going back to the main menu
            System.Threading.Thread.Sleep(5000);

            PrintCurrentGame();
        }
        static void PrintCurrentGame()
        {
            Console.Write("\n");
            Console.WriteLine("Bill Lumbergh has $"+ Math.Round(enemyMoney,2));
            Console.WriteLine("You have $" +Math.Round(yourMoney,2)+ " to your name");
            Console.WriteLine("You have a few options to choose from:");
            Console.WriteLine("1. Play Tetris at Work (really hurts the boss's bottom line)");
            Console.WriteLine("2. Burn TPS Reports (wastes company money)");
            Console.WriteLine("3. Grab a beer at Chotchkie's with Joanna (heals the soul)");
            //If they have smashed the printer, they can wield a scrap of printer
            if (smashedPrinter) 
            { 
                Console.WriteLine("4. Wield a scrap of that damn printer (possible critical damage)");
            } else {
                Console.WriteLine("4. Bash that damn jammed up printer to peices (wastes a turn)");
            }
            // If they have initiated the fraction of a penny virus, add some change to the player's account
            if (accountingVirusRunning)
            {
                Console.WriteLine("5. The accounting virus is already running, it stole $" + virusMoney + " so far");
            }
            else
            {
                Console.WriteLine("5. Launch Michael Bolton's accounting virus onto the network (wastes a turn)");
            }

            // Ask for the user choice
            Console.Write("Which option do you want to perform: ");
        }

        /// <summary>
        /// Called when someone runs out of money (game over)
        /// </summary>
        /// <param name="enemyWin">true if the enemy wins</param>
        static void EndingCondition(bool enemyWin)
        {
            Console.Clear();
            // Check to see who won
            if(enemyWin)
            {
                // Bill Lumbergh Won
                Console.WriteLine("Ummmm yea....");
                System.Threading.Thread.Sleep(900);
                Console.WriteLine("I'm gonna need you to come in on Sunday and work overtime....");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("for the rest of your life");

            }
            else
            {
                // Player won
                Console.WriteLine("Congrats you've defeated Bill Lumbergh");
                Console.WriteLine("You caused his ego lots of damage and wasted plenty of company time & money in the process.");
                if (accountingVirusRunning) { Console.WriteLine("The virus stole $" + virusMoney + " while you were at work doing nothing productive."); }
                Console.WriteLine("With Joanna in tow, you finally leave the pointless cublical farm and the rat race behind.");
            }

            Console.Write("\n\n");
            Console.WriteLine("Would you like to play again? Y for yes, N for no");
            if (Console.ReadLine().ToLower() == "y")
            {
                // Restart the Game
                InitGame();
            }
        }
    }
}

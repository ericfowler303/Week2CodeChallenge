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
            PrintCurrentGame();

            // Play the game
            while (isPlaying)
            {
                // Get the user weapon choice
                string userChoice = Console.ReadLine();
                CalcPlayerDamage(userChoice);
              

                // Display results of attack
                PrintAttackScreen();
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
                    return 0;

                // smashed printer
                case "4":
                    return 0;

                // accounting virus
                case "5":
                    return 0;
            }

            // invalid choice
            return -1;
        }
        /// <summary>
        /// Prints out the attack summmary screen
        /// </summary>
        static void PrintAttackScreen()
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
                Console.WriteLine("Bill Lumbergh hit you with " + enemyDamage + "");
            }
            else
            {
                // Enemy missed
                Console.WriteLine("Bill Lumbergh somehow missed your desk in his rounds today");
            }
            // Print your attack
            // Keep the attack screen on screen for 5 seconds before going back to the main menu
            System.Threading.Thread.Sleep(5000);
            PrintCurrentGame();
        }
        static void PrintCurrentGame()
        {
            Console.Write("\n\n");
            Console.WriteLine("Bill Lumbergh Has $"+ enemyMoney);
            Console.WriteLine("You have $" +yourMoney+ " to your name");
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
                Console.WriteLine("5. Launch Michael Bolton's accounting virus onto the network (wastes 2 turns)");
            }

            // Ask for the user choice
            Console.Write("Which option do you want to perform: ");
        }
    }
}

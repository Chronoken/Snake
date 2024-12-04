using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Threading;

class Program
{

    static void Main()
    {

        Console.Clear();
        Console.CursorVisible = true;

        int screenWidth = Console.WindowWidth;
        int screenHeight = Console.WindowHeight;

        Random random = new Random();
        Pixel hoofd = new Pixel()
        {
            xPos = screenWidth / 2,
            yPos = screenHeight / 2
        };

        Obstakel obstacle = new Obstakel()
        {
            xPos = random.Next(1, screenWidth - 1),
            yPos = random.Next(1, screenHeight - 1)
        };

        List<Pixel> tail = new List<Pixel>();

        string movement = "RIGHT";

        int score = 0;

        while (true)
        {

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.White;

            // Draw borders
            for (int i = 0; i < screenWidth; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("■");
                Console.SetCursorPosition(i, screenHeight - 1);
                Console.Write("■");
            }

            for (int i = 0; i < screenHeight; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("■");
                Console.SetCursorPosition(screenWidth - 1, i);
                Console.Write("■");
            }


            // Draw obstacle
            Console.ForegroundColor = obstacle.schermKleur;
            Console.SetCursorPosition(obstacle.xPos, obstacle.yPos);
            Console.Write(obstacle.karacter);


            // Draw snake
            Console.ForegroundColor = hoofd.schermKleur;
            Console.SetCursorPosition(hoofd.xPos, hoofd.yPos);
            Console.Write(hoofd.karacter);

            foreach (var segment in tail)
            {
                Console.SetCursorPosition(segment.xPos, segment.yPos);
                Console.Write(segment.karacter);
            }


            // Draw score
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(1, 0);
            Console.Write($"Score: {score}");


            ConsoleKeyInfo info = Console.ReadKey();

            //Game Logic
            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow when movement != "DOWN":
                        movement = "UP";
                        break;
                    case ConsoleKey.DownArrow when movement != "UP":
                        movement = "DOWN";
                        break;
                    case ConsoleKey.LeftArrow when movement != "RIGHT":
                        movement = "LEFT";
                        break;
                    case ConsoleKey.RightArrow when movement != "LEFT":
                        movement = "RIGHT";
                        break;
                }
            }

            Pixel newHead = new Pixel
            {
                xPos = hoofd.xPos,
                yPos = hoofd.yPos,
                schermKleur = hoofd.schermKleur
            };

            switch (movement)
            {
                case "UP":
                    newHead.yPos--;
                    break;
                case "DOWN":
                    newHead.yPos++;
                    break;
                case "LEFT":
                    newHead.xPos--;
                    break;
                case "RIGHT":
                    newHead.xPos++;
                    break;
            }

            //Hindernis treffen

            if (hoofd.xPos == obstacleXpos /* ?? */ == obstacleYpos)

            {

                score++;

                obstacleXpos = random.Next(1, screenWidth);

                obstacleYpos = random.Next(1, screenHeight);

            }

            teljePositie.Insert(0, hoofd.xPos);

            teljePositie.Insert(1, hoofd.yPos);

            teljePositie.RemoveAt(teljePositie.Count - 1);

            teljePositie.RemoveAt(teljePositie.Count - 1);

            //Kollision mit Wände oder mit sich selbst

            if (hoofd.xPos == 0 || hoofd.xPos == screenWidth - 1 || hoofd.yPos == 0 || hoofd.yPos == screenHeight - 1)

            {

                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Red;

                Console.SetCursorPosition(screenWidth / 5, screenHeight / 2);

                Console.WriteLine("Game Over");

                Console.SetCursorPosition(screenWidth / 5, screenHeight / 2 + 1);

                Console.WriteLine("Dein Score ist: " + score);

                Console.SetCursorPosition(screenWidth / 5, screenHeight / 2 + 2);

                Environment.Exit(0);

            }

            for (int i = 0; i < telje.Count(); i += 2)

            {

                if (hoofd.xPos == telje[i] && hoofd.yPos == telje[i + 1])

                {

                    GameOver(score);

                }

            }

            Thread.Sleep(50);

        }

    }

    static void GameOver(int score)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.SetCursorPosition(Console.WindowWidth / 4, Console.WindowHeight / 2);
        Console.WriteLine($"Game Over! Final Score: {score}");
        Console.ReadKey();
        Environment.Exit(0);
    }

}





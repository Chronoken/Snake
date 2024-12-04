﻿using System;
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


        List<int> telje = new List<int>();

        List<int> teljePositie = new List<int>();

        teljePositie.Add(hoofd.xPos);

        teljePositie.Add(hoofd.yPos);

        DateTime tijd = DateTime.Now;

        //string obstacle = "*";

        int obstacleXpos = random.Next(1, screenWidth);

        int obstacleYpos = random.Next(1, screenHeight);

        while (true)

        {

            Console.Clear();

            //Draw Obstacle

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.SetCursorPosition(obstacleXpos, obstacleYpos);

            Console.Write(obstacle);



            Console.ForegroundColor = ConsoleColor.Green;

            Console.SetCursorPosition(hoofd.xPos, hoofd.yPos);

            Console.Write("■");



            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < screenWidth; i++)

            {

                Console.SetCursorPosition(i, 0);

                Console.Write("■");

            }

            for (int i = 0; i < screenWidth; i++)

            {

                Console.SetCursorPosition(i, screenHeight - 1);

                Console.Write("■");

            }

            for (int i = 0; i < screenHeight; i++)

            {

                Console.SetCursorPosition(0, i);

                Console.Write("■");

            }

            for (int i = 0; i < screenHeight; i++)

            {

                Console.SetCursorPosition(screenWidth - 1, i);

                Console.Write("■");

            }

            Console.ForegroundColor =  /* ?? */;

            Console.WriteLine("Score: " + score);

            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("H");

            for (int i = 0; i < telje.Count(); i++)

            {

                Console.SetCursorPosition(telje[i], telje[i + 1]);

                Console.Write("■");

            }

            //Draw Snake

            Console.SetCursorPosition(hoofd.xPos, hoofd.yPos);

            Console.Write("■");

            Console.SetCursorPosition(hoofd.xPos, hoofd.yPos);

            Console.Write("■");

            Console.SetCursorPosition(hoofd.xPos, hoofd.yPos);

            Console.Write("■");

            Console.SetCursorPosition(hoofd.xPos, hoofd.yPos);

            Console.Write("■");



            ConsoleKeyInfo info = Console.ReadKey();

            //Game Logic

            switch (info.Key)

            {

                case ConsoleKey.UpArrow:

                    movement = "UP";

                    break;

                case ConsoleKey.DownArrow:

                    movement = "DOWN";

                // ???

                case ConsoleKey.LeftArrow:

                    movement = "LEFT";

                    break;

                case ConsoleKey.RightArrow:

                    movement = "RIGHT";

                    break;

            }

            if (movement == "UP")

                hoofd.yPos--;

            if (movement == "DOWN")

                hoofd.yPos++;

            if (movement == "LEFT")

                hoofd.xPos--;

            if (movement == "RIGHT")

                hoofd.xPos++;

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

                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.SetCursorPosition(screenWidth / 5, screenHeight / 2);

                    //???

                    Console.SetCursorPosition(screenWidth / 5, screenHeight / 2 + 1);

                    Console.WriteLine("Dein Score ist: " + score);

                    Console.SetCursorPosition(screenWidth / 5, screenHeight / 2 + 2);

                    Environment.Exit(0);

                }

            }

            Thread.Sleep(50);

        }

    }

}





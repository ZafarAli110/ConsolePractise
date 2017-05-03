﻿using System;
using System.Drawing;

namespace ConsolePractise
{
    class Program
    {
        static void Main(string[] args)
        {
            //ICar[] cars = {
            //                new BMW { Color = Color.Black },
            //                new Toyota { Color = Color.Silver}
            //              };

            //foreach (ICar car in cars)
            //{
            //    PrintCarInfo(car);
            //    car.Start();
            //    car.PressAccelator(5);
            //    car.PressBrake(6);
            //}

            var keyStrokeHandler = new KeyStrokeHandler();
            keyStrokeHandler.OnKey += GotKey;  
            keyStrokeHandler.OnQuitting += Quitting;

            var bob = new QuitTracker { Name = "bob" };
            keyStrokeHandler.OnQuitting += bob.QuitHandler;  

            var sandy = new QuitTracker { Name = "sandy" };
            keyStrokeHandler.OnQuitting += sandy.QuitHandler;

            keyStrokeHandler.OnQuitting -= Quitting;  

            // To overcome our previous problems with public delegate now we introduce events by using event now the public api of our class no
            // supports to set the value of our delegate we can only add or the delegate but we cannot set them to null to we cannot directly
            // invoke the delegate.

            keyStrokeHandler.Run();
        }

        static void GotKey(char key)
        {
            Console.WriteLine($"Got a key : {key}");
        }

        static void Quitting()
        {
            Console.WriteLine("Quitting.....");
        }

        static void PrintCarInfo(ICar car)
        {
            Console.WriteLine($"Here is a {car.Color.Name} {car.CompanyName}, {car.Model}({car.ModelYear})");
        }
    }
}

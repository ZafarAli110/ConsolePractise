using System;
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
        //  keyStrokeHandler.OnKey = new KeyPressDelegate(GotKey);
            keyStrokeHandler.OnKey = GotKey;  //just a shorter syntax..doing same thing as above
            keyStrokeHandler.OnQuitting = Quitting;

            var bob = new QuitTracker { Name = "bob" };
            keyStrokeHandler.OnQuitting += bob.QuitHandler;  //adding to the delegate invokation list

            var sandy = new QuitTracker { Name = "sandy" };
            keyStrokeHandler.OnQuitting += sandy.QuitHandler;

            keyStrokeHandler.OnQuitting -= Quitting;  //removing from the delegate invokation list

            keyStrokeHandler.OnQuitting(); //invoking OnQuitting delegate which will invoke all the methods which are added in our delegate invokation list

            keyStrokeHandler.OnQuitting = null;  //setting delegate invokation list to null which means,now it contains no methods 

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

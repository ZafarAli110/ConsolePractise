using System;

namespace ConsolePractise
{
    public class QuitTracker
    {
        public string Name { get; set; }

        public void QuitHandler()
        {
            Console.WriteLine($"Hi My Name is {Name} and i just got a quit notification.");
        }
    }
}

using System;

namespace ConsolePractise
{
    public delegate void KeyPressDelegate(char key);
    public delegate void QuitDelegate();
    public class KeyStrokeHandler
    {
        public KeyPressDelegate OnKey;
        public QuitDelegate OnQuitting;
        public void Run() {
            Console.WriteLine("KeyStroke Handler is running.Plz press 'q' to quit.");
            
            while (true)
            {
                var key = Console.ReadKey(true).KeyChar;
                if (key=='q'|| key=='Q')
                {
                    if (OnQuitting != null)
                    {
                        OnQuitting(); //invoking a delegate
                    }
                    break;
                }

                if (OnKey != null) //if the delegate is instantiated
                {
                    OnKey(key); //invoking a delegate
                }

            }
        }
    }
}

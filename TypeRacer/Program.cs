using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WindowsInput;
using WindowsInput.Native;

namespace TypeRacer
{
    class Program
    {
        static void Main(string[] args)
        {
            InputSimulator input = new InputSimulator();
            int speed = 100;
            //string outSpeed;
            bool run = true;
            while (run)
            {
                Console.Write("What speed do you want to write in: ");
                bool inputType = int.TryParse(Console.ReadLine(), out speed);
                if (inputType == false)
                {
                    run = false;
                    break;
                }
                Console.WriteLine("Your sentence: ");
                string sentence = Console.ReadLine();
                if (sentence.ToUpper() == "CLEAR")
                {
                    Console.Clear();
                }
                else if (sentence.ToUpper() == "EXIT")
                {
                    break;
                }
                else
                {
                    Thread.Sleep(2000);
                    TypeRacer(sentence, speed);
                }
            }

            Console.WriteLine("Good Bye!");
            Thread.Sleep(2000);
        }

        // TypeRacer fusket ^^
        // Håll in escape om du vill avbryta tangent trycken
        static void TypeRacer(string text, int typeDelay = 100)
        {
            InputSimulator input = new InputSimulator();
            string[] textArr = text.Split(' ');

            foreach (var line in textArr)
            {
                char[] word = line.ToCharArray();

                foreach (var item in word)
                {
                    input.Keyboard.TextEntry(item).Sleep(typeDelay);
                    if (input.InputDeviceState.IsKeyDown(VirtualKeyCode.ESCAPE))
                    {
                        return;
                    }
                }
                input.Keyboard.KeyPress(VirtualKeyCode.SPACE);
            }
        }
    }
}

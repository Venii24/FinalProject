using libs;

using System;
using System.Threading;

class Program
{
 static void Main(string[] args)
 {
     //Setup
     Console.CursorVisible = false;
     var engine = GameEngine.Instance;
     var inputHandler = InputHandler.Instance;

     // Show menu
     engine.ShowMenu();

     // Main game loop
     while (true)
     {
         engine.Render();

         // Handle keyboard input
         if(Console.KeyAvailable){
             ConsoleKeyInfo keyInfo = Console.ReadKey(true);
             inputHandler.Handle(keyInfo);
         }

         //game logic updates or delays to reduce cpu usage
         Thread.Sleep(100);
     }
 }

}
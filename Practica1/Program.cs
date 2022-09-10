using System;
using OpenTK.Mathematics;
using Practica1.Game;
namespace BasicOpenTK
{
    class program
    { 
        static void Main(string[] args)
        {
            using (Game game = new Game())
            {
                game.Run();                
            }
        }
    }
}
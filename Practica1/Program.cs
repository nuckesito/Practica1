using System;

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
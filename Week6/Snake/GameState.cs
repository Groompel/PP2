using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Snake
{
    class GameState
    {
        
        public static bool GameOver = false;
        int time = 200;
        Worm worm = new Worm('Z');
        Wall wall = new Wall('#');
        ConsoleKeyInfo consoleKeyInfo;
        Food food = new Food('8');
        Dir dir = Dir.RIGHT;
        enum Dir
        {
            UP,
            RIGHT,
            DOWN,
            LEFT,
        }


        public GameState()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(40, 40);
            Console.SetBufferSize(40, 40);
            
            Thread thread = new Thread(new ThreadStart(Move));
            thread.Start();
        }
        public void Move()
        {
            while (!GameOver)
            {
                switch (dir)
                {
                    case Dir.UP:
                        worm.Move(0, -1);
                    break;
                    case Dir.DOWN:
                        worm.Move(0, 1);
                        break;
                    case Dir.RIGHT:
                        worm.Move(1, 0);
                        break;
                    case Dir.LEFT:
                        worm.Move(-1, 0);
                        break;

                }
                Thread.Sleep(time);
            }

        }
        public void Run()
        {
            CheckCollision();
            food.Draw();
            worm.Draw();
            wall.Draw();
            consoleKeyInfo = Console.ReadKey();
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    dir = Dir.UP;
                    break;
                case ConsoleKey.DownArrow:
                    dir = Dir.DOWN;
                    break;
                case ConsoleKey.LeftArrow:
                    dir = Dir.LEFT;
                    break;
                case ConsoleKey.RightArrow:
                    dir = Dir.RIGHT;
                    break;
            }
            
        }
        
        public void CheckCollision()
        {

            if (worm.CheckIntersection(food.body))
            {
                worm.Eat(food.body);
                food.Generate();
            }
            if (worm.CheckIntersection(wall.body))
            {
                //GameOver = true;
            }
            

        }

    }
}

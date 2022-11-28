//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using System.Windows.Input;

//namespace Digger
//{
//    //Напишите здесь классы Player, Terrain и другие.
//    public class Terrain : ICreature
//    {
//        private string imageName = @"Terrain.png";
//        public CreatureCommand Act(int x, int y)
//        {
//            return new CreatureCommand { DeltaX = 0, DeltaY = 0 };
//        }

//        public bool DeadInConflict(ICreature conflictedObject)
//        {
//            return true;
//        }

//        public int GetDrawingPriority()
//        {
//            return 0;
//        }

//        public string GetImageFileName()
//        {
//            return imageName;
//        }
//    }

//    public class Player : ICreature
//    {
//        private string imageName = @"Digger.png";
//        public CreatureCommand Act(int x, int y)
//        {
//            if (Game.KeyPressed == Keys.Right && !(x + 1 < 0 || x + 1 >= Game.MapWidth || y + 0 < 0 || y + 0 >= Game.MapHeight))
//            {
//                if (Game.Map[x + 1, y] is Sack)
//                {
//                    return new CreatureCommand { DeltaX = 0, DeltaY = 0 };
//                }
//                return new CreatureCommand { DeltaX = 1, DeltaY = 0 };
//            }

//            if (Game.KeyPressed == Keys.Left && !(x - 1 < 0 || x - 1 >= Game.MapWidth || y + 0 < 0 || y + 0 >= Game.MapHeight))
//            {
//                if (Game.Map[x - 1, y] is Sack)
//                {
//                    return new CreatureCommand { DeltaX = 0, DeltaY = 0 };
//                }
//                return new CreatureCommand { DeltaX = -1, DeltaY = 0 };
//            }

//            if (Game.KeyPressed == Keys.Up && !(x + 0 < 0 || x + 0 >= Game.MapWidth || y - 1 < 0 || y - 1 >= Game.MapHeight))
//            {
//                if (Game.Map[x, y - 1] is Sack)
//                {
//                    return new CreatureCommand { DeltaX = 0, DeltaY = 0 };
//                }
//                return new CreatureCommand { DeltaX = 0, DeltaY = -1 };
//            }

//            if (Game.KeyPressed == Keys.Down && !(x + 0 < 0 || x + 0 >= Game.MapWidth || y + 1 < 0 || y + 1 >= Game.MapHeight))
//            {
//                if (Game.Map[x, y + 1] is Sack)
//                {
//                    return new CreatureCommand { DeltaX = 0, DeltaY = 0 };
//                }
//                return new CreatureCommand { DeltaX = 0, DeltaY = 1 };
//            }

//            return new CreatureCommand { DeltaX = 0, DeltaY = 0 };
//        }

//        public bool DeadInConflict(ICreature conflictedObject)
//        {
//            if (conflictedObject is Monster)
//            {
//                return true;
//            }
//            return false;
//        }

//        public int GetDrawingPriority()
//        {
//            return 0;
//        }

//        public string GetImageFileName()
//        {
//            return imageName;
//        }
//    }

//    public class Sack : ICreature
//    {
//        private string imgName = @"Sack.png";
//        private int flyTicks = 0;
//        public CreatureCommand Act(int x, int y)
//        {
//            if (!(y + 1 < 0 || y + 1 >= Game.MapHeight))
//            {
//                if (Game.Map[x, y + 1] is null)
//                {
//                    flyTicks++;
//                    return new CreatureCommand { DeltaX = 0, DeltaY = 1 };
//                }
//                if (Game.Map[x, y + 1] is Player && flyTicks > 0)
//                {
//                    flyTicks = 0;
//                    Game.Map[x, y + 1] = null;
//                    Game.IsOver = true;
//                    return new CreatureCommand { DeltaX = 0, DeltaY = 1 };
//                }
//            }
//            if (flyTicks >= 2)
//            {
//                return new CreatureCommand { DeltaX = 0, DeltaY = 0, TransformTo = new Gold() };

//            }
//            flyTicks = 0;
//            return new CreatureCommand { DeltaX = 0, DeltaY = 0 };
//        }

//        public bool DeadInConflict(ICreature conflictedObject)
//        {
//            return false;
//        }

//        public int GetDrawingPriority()
//        {
//            return 0;
//        }

//        public string GetImageFileName()
//        {
//            return imgName;
//        }
//    }

//    public class Gold : ICreature
//    {
//        private string imgName = @"Gold.png";
//        public CreatureCommand Act(int x, int y)
//        {
//            return new CreatureCommand { DeltaX = 0, DeltaY = 0 };
//        }

//        public bool DeadInConflict(ICreature conflictedObject)
//        {
//            Game.Scores += 10;
//            return true;
//        }

//        public int GetDrawingPriority()
//        {
//            return 0;
//        }

//        public string GetImageFileName()
//        {
//            return imgName;
//        }
//    }
//    public class Monster : ICreature
//    {
//        private string imgName = @"Monster.png";
//        static private int[,] warmMap = new int[Map.GetLength(1), Game.Map.GetLength(2)];
//        static private int[] playerKey = new int[2];
//        private void FindPlayer()
//        {
//            for (int i = 0; i < Game.MapHeight; i++)
//            {
//                for (int j = 0; j < Game.MapWidth; j++)
//                {
//                    if (Game.Map[i, j] is Player)
//                    {
//                        warmMap[i, j] = 0;
//                        playerKey[0] = i;
//                        playerKey[1] = j;
//                    }
//                }
//            }
//        }
//        //private CreatureCommand MoveToPlayerAlgoritm() 
//        //{ //https://ru.wikipedia.org/wiki/%D0%90%D0%BB%D0%B3%D0%BE%D1%80%D0%B8%D1%82%D0%BC_%D0%9B%D0%B8

//        //    return null;
//        //}

//        public CreatureCommand Act(int x, int y)
//        {

//            return new CreatureCommand { DeltaX = 0, DeltaY = 0 };
//        }

//        public bool DeadInConflict(ICreature conflictedObject)
//        {
//            return false;
//        }

//        public int GetDrawingPriority()
//        {
//            return 0;
//        }

//        public string GetImageFileName()
//        {
//            return imgName;
//        }
//    }
//}
using System.Windows.Forms;

namespace Digger
{
    public class Terrain : ICreature
    {
        public CreatureCommand Act(int x, int y)
        {
            return new CreatureCommand { };
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return true;
        }

        public int GetDrawingPriority()
        {
            return 0;
        }

        public string GetImageFileName()
        {
            return "Terrain.png";
        }
    }

    public class Player : ICreature
    {
        public static int xPos = 0;
        public static int yPos = 0;

        private bool CanMove(int x, int y)
        {
            return Game.Map[x, y] == null || Game.Map[x, y].GetImageFileName() != "Sack.png";
        }

        public CreatureCommand Act(int x, int y)
        {
            xPos = x;
            yPos = y;

            Keys key = Game.KeyPressed;

            switch (key)
            {
                case Keys.Down:
                    if (y < Game.MapHeight - 1 && CanMove(x, y + 1)) return new CreatureCommand { DeltaX = 0, DeltaY = 1 };
                    break;

                case Keys.Up:
                    if (y >= 1 && CanMove(x, y - 1)) return new CreatureCommand { DeltaX = 0, DeltaY = -1 };
                    break;

                case Keys.Right:
                    if (x < Game.MapWidth - 1 && CanMove(x + 1, y)) return new CreatureCommand { DeltaX = 1, DeltaY = 0 };
                    break;

                case Keys.Left:
                    if (x >= 1 && CanMove(x - 1, y)) return new CreatureCommand { DeltaX = -1, DeltaY = 0 };
                    break;
            }

            return new CreatureCommand { DeltaX = 0, DeltaY = 0 };
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            if (conflictedObject.GetImageFileName() == "Gold.png")
                Game.Scores += 10;

            return conflictedObject.GetImageFileName() == "Sack.png" || conflictedObject.GetImageFileName() == "Monster.png";
        }

        public int GetDrawingPriority()
        {
            return 1;
        }

        public string GetImageFileName()
        {
            return "Digger.png";
        }
    }

    public class Sack : ICreature
    {
        private int _falling = 0;

        public CreatureCommand Act(int x, int y)
        {
            int below = Game.MapHeight - 1;

            while (y != below)
            {
                if (Game.Map[x, y + 1] == null || ((Game.Map[x, y + 1].GetImageFileName() == "Digger.png" || Game.Map[x, y + 1].GetImageFileName() == "Monster.png") && _falling > 0))
                {
                    _falling++;
                    return new CreatureCommand { DeltaX = 0, DeltaY = 1 };
                }
                else if (_falling > 1)
                    return new CreatureCommand { DeltaX = 0, DeltaY = 0, TransformTo = new Gold() };
                else
                {
                    _falling = 0;
                    return new CreatureCommand { };
                }
            }

            if (_falling > 1)
                return new CreatureCommand { DeltaX = 0, DeltaY = 0, TransformTo = new Gold() };
            else
            {
                _falling = 0;
                return new CreatureCommand { };
            }
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return false;
        }

        public int GetDrawingPriority()
        {
            return 2;
        }

        public string GetImageFileName()
        {
            return "Sack.png";
        }
    }

    public class Gold : ICreature
    {
        public CreatureCommand Act(int x, int y)
        {
            return new CreatureCommand { };
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return true;
        }

        public int GetDrawingPriority()
        {
            return 3;
        }

        public string GetImageFileName()
        {
            return "Gold.png";
        }
    }

    public class Monster : ICreature
    {
        public CreatureCommand Act(int x, int y)
        {
            int xTo = 0;
            int yTo = 0;

            if (FindPlayer())
            {
                if (Player.xPos == x)
                {
                    if (Player.yPos < y) yTo = -1;
                    else if (Player.yPos > y) yTo = 1;
                }
                else if (Player.yPos == y)
                {
                    if (Player.xPos < x) xTo = -1;
                    else if (Player.xPos > x) xTo = 1;
                }
                else
                {
                    if (Player.xPos < x) xTo = -1;
                    else if (Player.xPos > x) xTo = 1;
                }
            }
            else
                return new CreatureCommand() { DeltaX = 0, DeltaY = 0 };

            if (!(x + xTo >= 0 && x + xTo < Game.MapWidth && y + yTo >= 0 && y + yTo < Game.MapHeight))
                return new CreatureCommand() { DeltaX = 0, DeltaY = 0 };

            var map = Game.Map[x + xTo, y + yTo];
            if (map != null && (map.ToString() == "Digger.Terrain" || map.ToString() == "Digger.Sack" || map.ToString() == "Digger.Monster"))
                return new CreatureCommand() { DeltaX = 0, DeltaY = 0 };

            return new CreatureCommand() { DeltaX = xTo, DeltaY = yTo };
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            string fuck = conflictedObject.GetImageFileName();
            return fuck == "Sack.png" || fuck == "Monster.png";
        }

        public int GetDrawingPriority()
        {
            return 0;
        }

        public string GetImageFileName()
        {
            return "Monster.png";
        }

        static private bool FindPlayer()
        {
            for (int i = 0; i < Game.MapWidth; i++)
            {
                for (int j = 0; j < Game.MapHeight; j++)
                {
                    if (Game.Map[i, j] != null && Game.Map[i, j].GetImageFileName() == "Digger.png")
                    {
                        Player.xPos = i;
                        Player.yPos = j;
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
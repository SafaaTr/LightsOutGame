using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace endlightout
{
    internal class LightsOutGame
    {
        private LightsOutGame game; //  تعريف المتغير لجميع الدوال 

        public bool[,] Grid { get; private set; } 

        private int gridSize;
        private Random random = new Random();

        public void SetInitialWinningState()
        {
            //  شبكة أولية قابلة للفوز 
            Grid = new bool[gridSize, gridSize];

            //   الفوز خلال أقل من 10 خطوات
            Grid[0, 1] = true;
            Grid[1, 2] = true;
            Grid[2, 0] = true;
            Grid[2, 2] = true;
        }


        public LightsOutGame(int size)
        {
            gridSize = size;
            Grid = new bool[size, size]; //  تهيئة الشبكة
            GenerateRandomGrid();
        }

        private void GenerateRandomGrid()//توليد شبكة عشوائية
        {
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    Grid[i, j] = random.Next(2) == 0; //تحديد القيم  
                }
            }
        }
        public bool CheckForWin()
        {
            if (game == null || game.Grid == null) return false;
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    if (game.Grid[i, j]) //  إذا كان هناك ضوء واحد على الأقل، لم يفز اللاعب بعد
                        return false;
                }
            }
            return true; // كل الأضواء مطفأة
        }









    }
}

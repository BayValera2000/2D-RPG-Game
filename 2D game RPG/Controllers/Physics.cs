using _2D_game_RPG.Controllers;
using _2D_game_RPG.Entites;
using AreneWar.Entites;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AreneWar.Controllers
{
    public static class PhysicsController
    {
        public static void IsCollide(Entity entity)
        {
            for (int j = entity.posX / MapController.cellSize; j < (entity.posX + MapController.cellSize) / MapController.cellSize; j++)
            {
                for (int i = entity.posY / MapController.cellSize; i < (entity.posY + MapController.cellSize) / MapController.cellSize; i++)
                {
                    ddif (MapController.map[i, j] != 0)
                    {
                        if (entity.dirY > 0)
                        {
                            entity.dirY -= 10;
                        }
                        else if (entity.dirY < 0)
                        {
                            entity.dirY += 10;
                        }
                        if (entity.dirX > 0)
                        {
                            entity.dirX -= 10;
                        }
                        else if (entity.dirX < 0)
                        {
                            entity.dirX += 10;
                        }
                    }
                    Console.WriteLine(MapController.map[i, j]);
                }
            }
        }
    }
}

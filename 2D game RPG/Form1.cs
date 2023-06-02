using _2D_game_RPG.Entites;
using _2D_game_RPG.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using _2D_game_RPG.Controllers;
using AreneWar.Controllers;

namespace _2D_game_RPG
{
    public partial class Form1 : Form
    {
        public Image dwarfSheet;
        public Image gladilatorSheet;
        public Entity player;
        public Form1()
        {
            InitializeComponent();

            timer1.Interval = 50;
            timer1.Tick += new EventHandler(Update);

            KeyDown += new KeyEventHandler(OnPress);
            KeyUp += new KeyEventHandler(OnKeyUp);

            Init();
        }

        public void OnPress(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    player.dirY = -2;
                    player.IsMoving = true;
                    player.SetAnimationConfiguration(1);
                    break;
                case Keys.A:
                    player.dirX = -2;
                    player.IsMoving = true;
                    player.flip = -1;
                    player.SetAnimationConfiguration(1);
                    break;
                case Keys.S:
                    player.dirY = 2;
                    player.IsMoving = true;
                    player.SetAnimationConfiguration(1);
                    break;
                case Keys.D:
                    player.dirX = 2;
                    player.IsMoving = true;
                    player.flip = 1;
                    player.SetAnimationConfiguration(1);
                    break;
                case Keys.Space:
                    player.dirX = 0;
                    player.dirX = 0;
                    player.IsMoving = false;
                    player.SetAnimationConfiguration(2);
                    break;
            }
        }

        public void OnKeyUp(object sender, KeyEventArgs e)
        {
            player.dirX = 0;
            player.dirY = 0;
            player.IsMoving = false;
            player.SetAnimationConfiguration(0 );
        }

        public void Init()
        {
            MapController.Init();

            this.Width = MapController.GetWidth();
            this.Height = MapController.GetHeight();

            dwarfSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Srites\\Dwarf.png"));

            player = new Entity(310, 310, Hero.idleFrames, Hero.runFrames, Hero.attackFrames, Hero.deathFrames, dwarfSheet);
            timer1.Start();
        }

        public void Update(object sender, EventArgs e)
        {
            //PhysicsController.IsCollide(player);
            if (player.IsMoving == true)
                player.Move();
            Invalidate();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            MapController.DrawMap(g);
            player.PlayAnimation(g);
        }
    }
}

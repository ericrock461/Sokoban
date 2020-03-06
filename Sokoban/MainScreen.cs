using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sokoban
{
    public partial class MainScreen : UserControl
    {
        // TODO don't forget to make the keys compatible with the arcade machines


        //TODO boxes move when moved by character

        //TODO game win when all dots are covered

        //TODO in-game timer (try to beat the record!)
        // if (newRecord > oldRecord) label = "New Record!" (and show time big on screen)

        //button control keys
        Boolean leftArrowDown, rightArrowDown, upArrowDown, downArrowDown;

        //used to draw hero to screen
        SolidBrush heroBrush = new SolidBrush(Color.Brown);
        //used to draw boxes to screen
        SolidBrush boxBrush = new SolidBrush(Color.Sienna);
        //used to draw dots to the screem
        SolidBrush dotBrush = new SolidBrush(Color.Red);


        int timer;
        int secondCount;


        //create a list to hold all boxes on screen     
        List<Box> boxes = new List<Box>();

        //create a list to hold all dots on screen
        List<Dot> dots = new List<Dot>();



        //create "hero" box 
        Box hero;


        public MainScreen()
        {
            InitializeComponent();
            OnStart();
        }

        public void OnStart()
        {
            //set game start values
            //load 5 dots upon loading game
            Dot d = new Dot(30, 115, 20);
            dots.Add(d);

            d = new Dot(110, 255, 20);
            dots.Add(d);
            d = new Dot(185, 400, 20);
            dots.Add(d);
            d = new Dot(400, 75, 20);
            dots.Add(d);
            d = new Dot(400, 400, 20);
            dots.Add(d);


            //spawn 5 boxes upon loading the game. Their initial positions
            //are always the same
            Box b = new Box(150, 225, 75);
            boxes.Add(b);

            b = new Box(300, 300, 75);
            boxes.Add(b);
            b = new Box(225, 75, 75);
            boxes.Add(b);
            b = new Box(75, 150, 75);
            boxes.Add(b);
            b = new Box(75, 300, 75);
            boxes.Add(b);

           
            //set initial hero box values / variables
            hero = new Box(0, 0, 75);

        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //button presses
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //button releases
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
            }
        }

        private void gameLoop_Tick(object sender, EventArgs e)
        {
            //move hero            
            if (leftArrowDown)
            {
                hero.x = hero.x - 75;

                //by setting the bool to false after pressing button,
                //we stop the hero from reaching mach speeds in an instant
                leftArrowDown = false;
            }
            if (rightArrowDown)
            {
                hero.x = hero.x + 75;

                rightArrowDown = false;
            }
            if (upArrowDown)
            {
                hero.y = hero.y - 75;

                upArrowDown = false;
            }
            if (downArrowDown)
            {
                hero.y = hero.y + 75;

                downArrowDown = false;
            }

            //how to make sure hero cannot move diagonally?
            /*if (upArrowDown && rightArrowDown)
            {
                upArrowDown = false;
            }
           /* if (upArrowDown && leftArrowDown)
            {
                hero.x = hero.x + 0;
            }
            if (downArrowDown && rightArrowDown)
            {
                hero.x = hero.x + 0;
            }
            if (downArrowDown && leftArrowDown)
            {
                hero.x = hero.x + 0;
            }*/


            //collision
            foreach (Box b in boxes)
            {
                if (b.Collision(hero))
                {
                    gameLoop.Enabled = false;
                }
            }

            //counts in-game seconds
            timer++;
            if (timer == 1000)
            {
                secondCount++;
                secondCounter.Text = "" + secondCount;

                timer = 0;
            }

            Refresh();
        }

        /*public void Move(string direction)
        {
            if (direction == "left")
            {
                x = x - 5;
            }
            if (direction == "right")
            {
                x = x + 5;
            }*/



        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //draw boxes to screen
            foreach (Box b in boxes)
            {
                e.Graphics.FillRectangle(boxBrush, b.x, b.y, b.size, b.size);
            }


            //draw the "hero" to the screen
            e.Graphics.FillRectangle(heroBrush, hero.x, hero.y, hero.size, hero.size);


            //draw dots to the screen
            foreach (Dot d in dots)
            {
                e.Graphics.FillRectangle(dotBrush, d.x, d.y, d.size, d.size);
            }

        }

    }
}

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


        //TODO game win when all dots are covered

        //TODO move counter (try to beat the record!)
        // if (newRecord > oldRecord) label = "New Record!" (and show move count big on screen)




        //button control keys
        Boolean leftArrowDown, rightArrowDown, upArrowDown, downArrowDown;

        //used to draw hero to screen
        SolidBrush heroBrush = new SolidBrush(Color.Brown);
        //used to draw boxes to screen
        SolidBrush boxBrush = new SolidBrush(Color.Sienna);
        //used to draw dots to the screem
        SolidBrush dotBrush = new SolidBrush(Color.Blue);
        //used to walls to the screen
        SolidBrush wallBrush = new SolidBrush(Color.Black);




        //create a list to hold all boxes on screen     
        List<Box> boxes = new List<Box>();

        //create a list to hold all dots on screen
        List<Dot> dots = new List<Dot>();

        //create a list to hold all wall "blocks" on screen
        List<Wall> walls = new List<Wall>();

        //create "hero" box 
        Box hero;


        //counts number of moves
        int moveCount;


        //this counter will track which dots are currently being covered by boxes.
        //if the counter reaches 5 (all dots covered), the game will end.
        int dotCovered = 0;

        public MainScreen()
        {
            InitializeComponent();
            OnStart();
        }

        public void OnStart()
        {
            //set game start values

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


            //load 5 dots upon loading game
            Dot d = new Dot(30, 110, 20);
            dots.Add(d);

            d = new Dot(104, 250, 20);
            dots.Add(d);
            d = new Dot(185, 400, 20);
            dots.Add(d);
            d = new Dot(402, 100, 20);
            dots.Add(d);
            d = new Dot(400, 400, 20);
            dots.Add(d);


            /*
            //load walls upon loading game
            Wall w = new Wall(50, 0, 75);

            w = new Wall(100, 0, 75);
            */


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
                hero.Move("left");

                //adds to moveCount
                moveCount++;
            }
            if (rightArrowDown)
            {
                hero.Move("right");
                moveCount++;
            }
            if (upArrowDown)
            {
                hero.Move("up");
                moveCount++;
            }
            if (downArrowDown)
            {
                hero.Move("down");
                moveCount++;
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
                    if (leftArrowDown)
                    {
                        b.Move("left");
                    }
                    else if (upArrowDown)
                    {
                        b.Move("up");
                    }
                    else if (rightArrowDown)
                    {
                        b.Move("right");
                    }
                    else if (downArrowDown)
                    {
                        b.Move("down");
                    }
                }
            }

            //by setting the bools to false after pressing button,
            //we stop the hero from reaching mach speed in an instant
            leftArrowDown = rightArrowDown = upArrowDown = downArrowDown = false;

            moveCounter.Text = "Moves: " + moveCount;


            //foreach dot in dots if a box is colliding increase a counter. If counter is 5, stop game
            //I feel like maybe I was close with this, but I couldn't figure out how to make "box" exist
            
            /*
            foreach (Dot d in dots)
            {
                if (d.Collision(box))
                {
                    dotCovered++;
                }
                else
                {
                    dotCovered = 0;
                }
            }*/

            if (dotCovered == 5) 
            {
                gameLoop.Enabled = false;
            }

            Refresh();
        }


        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //draw dots to the screen
            foreach (Dot d in dots)
            {
                e.Graphics.FillRectangle(dotBrush, d.x, d.y, d.size, d.size);
            }

            //draw boxes to screen
            foreach (Box b in boxes)
            {
                e.Graphics.FillRectangle(boxBrush, b.x, b.y, b.size, b.size);
            }

            //draw the walls to the screen
            foreach (Wall w in walls)
            {
                e.Graphics.FillRectangle(wallBrush, w.x, w.y, w.size, w.size);
            }

            //draw the "hero" to the screen
            e.Graphics.FillRectangle(heroBrush, hero.x, hero.y, hero.size, hero.size);

        }

    }
}

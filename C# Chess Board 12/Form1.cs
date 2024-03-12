using ClassBoardModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//--------------------------- C# Chess Board 10 gui controls -------------------------------------------------
//ref link:https://www.youtube.com/watch?v=cTNtnS6BSN0&list=PLhPyEFL5u-i0YDRW6FLMd1PavZp9RcYdF&index=10&t=1s

// add label(Prop:Text:Select a piece from the drop down menu.....), comboBox(Prop:items->...->Bishop/Rook...)(Prop:Appearance->DropDownStyle->DropDownList), Panel(Prop:SizeWidth500Height500),Form1(Prop:Text:Chess Piece Moves)

//--------------------------- C# Chess Board 11 placebuttons ----------------------------------------------------
//ref link:https://www.youtube.com/watch?v=f3QRYl3o5Ak&list=PLhPyEFL5u-i0YDRW6FLMd1PavZp9RcYdF&index=11

//--------------------------- C# Chess Board 12 button text ---------------------------------------------------
//ref link:https://www.youtube.com/watch?v=l7N4kCi9UhQ&list=PLhPyEFL5u-i0YDRW6FLMd1PavZp9RcYdF&index=12

namespace C__Chess_Board_10
{
    public partial class Form1 : Form
    {
        //------------START------------- C# Chess Board 11 placebuttons ----------------------------------------------------
        // reference to the class Board. Contains the value of the board.
        static Board myBoard = new Board(8);

        // 2D array of buttons whose values are determined by myBoard.
        public Button[,] btnGrid = new Button[myBoard.Size, myBoard.Size];

        //------------END------------- C# Chess Board 11 placebuttons ----------------------------------------------------

        public Form1()
        {
            InitializeComponent();
            //------------START------------- C# Chess Board 11 placebuttons ----------------------------------------------------
            populateGrid();
            //------------END------------- C# Chess Board 11 placebuttons ----------------------------------------------------

        }
        //------------START------------- C# Chess Board 11 placebuttons ----------------------------------------------------
        private void populateGrid()
        {
            // create buttons and plaze them into panel1

            int buttonSize = panel1.Width / myBoard.Size;

            // make the panel a perfect square.
            panel1.Height = panel1.Width;

            // nested loops. create buttons and print them to the screen.
            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    btnGrid[i, j] = new Button();

                    btnGrid[i, j].Height = buttonSize;
                    btnGrid[i, j].Width = buttonSize;

                    // add a click event to each button.
                    btnGrid[i, j].Click += Grid_Button_Click;

                    panel1.Controls.Add(btnGrid[i, j]);

                    // set the location of the new button.
                    btnGrid[i, j].Location = new Point(i * buttonSize, j * buttonSize);

                    btnGrid[i, j].Text = i + "|" + j;
                    //-----------START-------------- C# Chess Board 12 button text ---------------------------------------------------
                    btnGrid[i, j].Tag = new Point(i, j);
                    //-----------END-------------- C# Chess Board 12 button text ---------------------------------------------------

                }
            }
        }

        private void Grid_Button_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("You clicked a button!");

            //-----------START-------------- C# Chess Board 12 button text ---------------------------------------------------
            // get the row and col number of the button clicked
            Button clickedButton = (Button)sender;
            Point location = (Point)clickedButton.Tag;

            int x = location.X;
            int y = location.Y;

            Cell currentCell = myBoard.theGrid[x, y];


            // determine legal next moves
            myBoard.MarkNextLegalMoves(currentCell, "Knight");

            // update the text on each button
            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    btnGrid[i, j].Text = "";

                    if (myBoard.theGrid[i, j].LegalNextMove == true)
                    {
                        btnGrid[i, j].Text = "Legal";
                    }
                    else if (myBoard.theGrid[i, j].CurrentlyOccupied == true)
                    {
                        btnGrid[i, j].Text = "Knight";
                    }
                }
            }

            //-----------END-------------- C# Chess Board 12 button text ---------------------------------------------------

        }
        //------------END------------- C# Chess Board 11 placebuttons ----------------------------------------------------

    }
}

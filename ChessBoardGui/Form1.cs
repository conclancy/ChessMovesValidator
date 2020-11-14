using ChessBoardModel;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChessBoardGui
{
    public partial class Form1 : Form
    {
        static Board myBoard = new Board(8);

        // 2D array of buttons representing the board
        public Button[,] btnGrid = new Button[myBoard.Size, myBoard.Size];

        public Form1()
        {
            InitializeComponent();
            populateGrid();
        }

        private void populateGrid()
        {
            // create buttons and populate them into form panel

            int buttonSize = panel1.Width / myBoard.Size;

            // ensure the panel is a square
            panel1.Height = panel1.Width;

            // create buttons and print them to the screen
            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    btnGrid[i, j] = new Button();

                    btnGrid[i, j].Height = buttonSize;
                    btnGrid[i, j].Width = buttonSize;

                    // add a click event to each button
                    btnGrid[i, j].Click += GridButtonClick;

                    panel1.Controls.Add(btnGrid[i, j]);
                    btnGrid[i, j].Location = new Point(i * buttonSize, j * buttonSize);

                    btnGrid[i, j].Text = i + "|" + j;
                    btnGrid[i, j].Tag = new Point(i, j);
                }
            }
        }

        private void GridButtonClick(object sender, EventArgs e)
        {
            // get the row and col numbers of the button clicked 
            Button clickedButton = (Button)sender;
            Point location = (Point)clickedButton.Tag;

            int x = location.X;
            int y = location.Y;

            Cell currentCell = myBoard.theGrid[x, y];

            // dermine legal next moves
            //string piece = "knight";
            string piece = comboBox1.Text;
            myBoard.MarkNextLegalMoves(currentCell, piece);

            // update the text on each button
            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    btnGrid[i, j].Text = "";
                    if(myBoard.theGrid[i, j].LegalNextMove)
                    {
                        btnGrid[i, j].Text = "+";
                    }

                    if(myBoard.theGrid[i, j].CurrentlyOccupied)
                    {
                        btnGrid[i, j].Text = piece;
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

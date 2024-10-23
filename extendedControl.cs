using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tic_tac_2
{
    public partial class extendedControl : UserControl
    {
        // Boolean to track which player's turn it is (true for Player 1, false for Player 2)
        bool player1 = true;
        // 2D array to store the buttons representing the game board
        Button[,] button = new Button[3, 3];

        int win1 = 0;
        int win2 = 0;

        public extendedControl()
        {
            InitializeComponent();
            button[0, 0] = b1;
            button[0, 1] = b2;
            button[0, 2] = b3;
            button[1, 0] = b4;
            button[1, 1] = b5;
            button[1, 2] = b6;
            button[2, 0] = b7;
            button[2, 1] = b8;
            button[2, 2] = b9;
        }
        // Method to highlight the buttons that form the winning line
        private void highlightWinningLine(Button[] winningButtons)
        {
            foreach (Button btn in winningButtons)
            {
                btn.BackColor = Color.Beige; // Change the background color of the winning buttons
            }
        }
        private bool checkWin()
        {
            //Check each row for a win
            for (int i = 0; i < 3; i++)
            {
                if (button[i, 0].Text == button[i, 1].Text && button[i, 1].Text == button[i, 2].Text && button[i, 0].Text != "" && button[i, 0].Enabled == false)
                {
                    highlightWinningLine(new Button[] { button[i, 0], button[i, 1], button[i, 2] });
                    
                    return true;
                }
            }
            //Check each column for a win
            for (int i = 0; i < 3; i++)
            {
                if (button[0, i].Text == button[1, i].Text && button[1, i].Text == button[2, i].Text && button[0, i].Text != "" && button[0, i].Enabled == false)
                {
                    highlightWinningLine(new Button[] { button[0, i], button[1, i], button[2, i] });
                    return true;
                }
            }

            if (button[0, 0].Text == button[1, 1].Text &&
        button[1, 1].Text == button[2, 2].Text &&
        button[0, 0].Text != "" && button[0, 0].Enabled == false)
            {
                highlightWinningLine(new Button[] { button[0, 0], button[1, 1], button[2, 2] });
                return true;
            }

            if (button[0, 2].Text == button[1, 1].Text &&
                button[1, 1].Text == button[2, 0].Text &&
                button[0, 2].Text != "" && button[0, 2].Enabled == false)
            {
                highlightWinningLine(new Button[] { button[0, 2], button[1, 1], button[2, 0] });
                return true;
            }
            return false;
        }
        // Method to reset the board for a new game
        private void resetBoard()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    button[i, j].Text = "";
                    button[i, j].Enabled = true;
                    button[i, j].BackColor = Color.White;

                }
            player1 = true;
            turn.Text = "Turn Player 1(X)";
        }



        private void b2_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;// Get the button that was clicked
            if (player1 == true)
            {

                player1 = false;
                b.Text = "X";
                turn.Text = "Turn Player 2(O)";
            }
            else
            {

                player1 = true;
                b.Text = "O";
                turn.Text = "Turn Player 1(X)";
            }
            b.Enabled = false;
            // Check if there's a winner after the current move
            if (checkWin())
            {
                if (player1 == false)
                {
                    MessageBox.Show("Winner Player 1(X)", "Winner");
                    win1++;
                    w1.Text = $"{win1}";
                }
                else
                {
                    MessageBox.Show("Winner Player 2(O)", "Winner");
                    win2++;
                    w2.Text = $"{win2}";
                }
                // Ask the user if they want to play again
                DialogResult result = MessageBox.Show("Do you want to play again?", "Restart Game", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    resetBoard();
                }
                else
                {

                    this.FindForm().Close();

                }

            }
            // If all buttons are disabled and there's no winner, it's a draw
            else if (b1.Enabled == false && b2.Enabled == false && b3.Enabled == false && b4.Enabled == false && b5.Enabled == false && b6.Enabled == false && b7.Enabled == false && b8.Enabled == false && b9.Enabled == false)
            {
                {
                    MessageBox.Show("It's a draw!", "No Winner");
                    resetBoard();
                }
            }
        }

        private void tictac_Load(object sender, EventArgs e)
        {

        }
    }
}

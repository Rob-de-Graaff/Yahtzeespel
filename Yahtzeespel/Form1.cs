#region Using Statements

using System;
using System.Drawing;
using System.Windows.Forms;

#endregion Using Statements

namespace Yahtzeespel
{
    public partial class Form1 : Form
    {
        #region Declaration

        private Image[] diceImages;
        private Player player1, player2;
        private int player1_Dice1, player1_Dice2, player1_Dice3, player1_Dice4, player1_Dice5;
        private int player2_Dice1, player2_Dice2, player2_Dice3, player2_Dice4, player2_Dice5;

        #endregion Declaration

        #region Initialization

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //player1_Dice = new int[5] { 0, 0, 0, 0, 0 };
            //player2_Dice = new int[5] { 0, 0, 0, 0, 0 };

            player1 = new Player("Player 1");
            //player1.Name = "Rob";
            player2 = new Player("Player 2");

            label_P1Name.Text = player1.Name;
            label_P2Name.Text = player2.Name;

            diceImages = new Image[7];
            diceImages[0] = Properties.Resources.Dice_Blank;
            diceImages[1] = Properties.Resources.Dice_1;
            diceImages[2] = Properties.Resources.Dice_2;
            diceImages[3] = Properties.Resources.Dice_3;
            diceImages[4] = Properties.Resources.Dice_4;
            diceImages[5] = Properties.Resources.Dice_5;
            diceImages[6] = Properties.Resources.Dice_6;

            panel_P1.Hide();
            panel_P2.Hide();
        }

        #endregion Initialization

        #region Private Methods

        private void Button_P1RollDice_Click(object sender, EventArgs e)
        {
            if (!player1.Played)
            {
                if (player1.Turns != 0)
                {
                    player1.RollDice();
                    
                    CheckboxChecked(player1.Name);

                    player1.SetResults(player1_Dice1, player1_Dice2, player1_Dice3, player1_Dice4, player1_Dice5);

                    label_P1Dice1.Image = diceImages[player1_Dice1];
                    label_P1Dice2.Image = diceImages[player1_Dice2];
                    label_P1Dice3.Image = diceImages[player1_Dice3];
                    label_P1Dice4.Image = diceImages[player1_Dice4];
                    label_P1Dice5.Image = diceImages[player1_Dice5];
                    label_P1Results.Text = player1.Result;

                    if (player1.Turns != 1)
                    {
                        player1.ResetResults();
                    }

                    player1.Played = true;
                    player2.Played = false;

                    if (player1.Turns == 3)
                    {
                        panel_P1.Show();
                    }
                    player1.Turns--;
                }

                if (player1.Turns == 0 && player2.Turns == 0)
                {
                    player2.Played = true;
                    CheckWinner();
                }
            }
            else
            {
                label_WinnerResult.Text = "waiting for " + player2.Name + " to roll";
            }
        }

        private void Button_P2RollDice_Click(object sender, EventArgs e)
        {
            if (!player2.Played)
            {
                if (player2.Turns != 0)
                {
                    player2.RollDice();

                    CheckboxChecked(player2.Name);

                    player2.SetResults(player2_Dice1, player2_Dice2, player2_Dice3, player2_Dice4, player2_Dice5);

                    label_P2Dice1.Image = diceImages[player2_Dice1];
                    label_P2Dice2.Image = diceImages[player2_Dice2];
                    label_P2Dice3.Image = diceImages[player2_Dice3];
                    label_P2Dice4.Image = diceImages[player2_Dice4];
                    label_P2Dice5.Image = diceImages[player2_Dice5];
                    label_P2Results.Text = player2.Result;

                    if (player2.Turns != 1)
                    {
                        player2.ResetResults();
                    }

                    player2.Played = true;
                    player1.Played = false;

                    if (player2.Turns == 3)
                    {
                        panel_P2.Show();
                    }
                    player2.Turns--;
                }

                if (player2.Turns == 0 && player1.Turns == 0)
                {
                    player1.Played = true;
                    CheckWinner();
                }
            }
            else
            {
                label_WinnerResult.Text = "waiting for " + player1.Name + " to roll";
            }
        }

        private void CheckboxChecked(string playerName)
        {
            if (playerName == player1.Name)
            {
                if (!checkbox_P1Dice1.Checked)
                {
                    player1_Dice1 = player1.Dice[0];
                }
                if (!checkbox_P1Dice2.Checked)
                {
                    player1_Dice2 = player1.Dice[1];
                }
                if (!checkbox_P1Dice3.Checked)
                {
                    player1_Dice3 = player1.Dice[2];
                }
                if (!checkbox_P1Dice4.Checked)
                {
                    player1_Dice4 = player1.Dice[3];
                }
                if (!checkbox_P1Dice5.Checked)
                {
                    player1_Dice5 = player1.Dice[4];
                }
            }
            else if (playerName == player2.Name)
            {
                if (!checkbox_P2Dice1.Checked)
                {
                    player2_Dice1 = player2.Dice[0];
                }
                if (!checkbox_P2Dice2.Checked)
                {
                    player2_Dice2 = player2.Dice[1];
                }
                if (!checkbox_P2Dice3.Checked)
                {
                    player2_Dice3 = player2.Dice[2];
                }
                if (!checkbox_P2Dice4.Checked)
                {
                    player2_Dice4 = player2.Dice[3];
                }
                if (!checkbox_P2Dice5.Checked)
                {
                    player2_Dice5 = player2.Dice[4];
                }
            }
        }

        private void CheckWinner()
        {
            if (player1.Played && player2.Played)
            {
                if (player1.HandRank > player2.HandRank)
                {
                    label_WinnerResult.Text = player1.Name + " WINS!";
                }
                else if (player1.HandRank < player2.HandRank)
                {
                    label_WinnerResult.Text = player2.Name + " WINS!";
                }
                else if (player1.HandRank == 8 && player2.HandRank == 8)
                {
                    if (player1.Mod1 > player2.Mod1 && player1.Mod1 > player2.Mod2)
                    {
                        label_WinnerResult.Text = player1.Name + " WINS!";
                    }
                    else if (player1.Mod2 > player2.Mod1 && player1.Mod2 > player2.Mod2)
                    {
                        label_WinnerResult.Text = player1.Name + " WINS!";
                    }
                    else if (player1.Mod1 == player2.Mod2 && player1.Mod2 == player2.Mod2 || player1.Mod2 == player2.Mod1 && player1.Mod1 == player2.Mod2)
                    {
                        if (player1.Mod3 > player2.Mod3)
                        {
                            label_WinnerResult.Text = player1.Name + " WINS!";
                        }
                        else if (player1.Mod3 < player2.Mod3)
                        {
                            label_WinnerResult.Text = player2.Name + " WINS!";
                        }
                        else
                        {
                            label_WinnerResult.Text = player1.Name + " Ties " + player2.Name;
                        }
                    }
                }
                else if (player1.HandRank == player2.HandRank)
                {
                    if (player1.Mod1 > player2.Mod1)
                    {
                        label_WinnerResult.Text = player1.Name + " WINS!";
                    }
                    else if (player1.Mod1 < player2.Mod1)
                    {
                        label_WinnerResult.Text = player2.Name + " WINS!";
                    }
                    else if (player1.Mod1 == player2.Mod1)
                    {
                        if (player1.Mod2 > player2.Mod2)
                        {
                            label_WinnerResult.Text = player1.Name + " WINS!";
                        }
                        else if (player1.Mod2 < player2.Mod2)
                        {
                            label_WinnerResult.Text = player2.Name + " WINS!";
                        }
                        else if (player1.Mod2 == player2.Mod2)
                        {
                            if (player1.Mod3 > player2.Mod3)
                            {
                                label_WinnerResult.Text = player1.Name + " WINS!";
                            }
                            else if (player1.Mod3 < player2.Mod3)
                            {
                                label_WinnerResult.Text = player2.Name + " WINS!";
                            }
                            else if (player1.Mod3 == player2.Mod3)
                            {
                                label_WinnerResult.Text = player1.Name + " Ties " + player2.Name;
                            }
                        }
                    }
                }
                player1.ResetPlayer();
                player2.ResetPlayer();
            }
            else if (player1.Played && !player2.Played)
            {
                label_WinnerResult.Text = "waiting for " + player2.Name + " to roll";
            }
            else if (player2.Played && !player1.Played)
            {
                label_WinnerResult.Text = "waiting for " + player1.Name + " to roll";
            }
        }

        #endregion Private Methods
    }
}
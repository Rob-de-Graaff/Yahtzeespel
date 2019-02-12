# region Using Statements

using System;

# endregion

namespace Yahtzeespel
{
    public class Player
    {
        #region Declaration

        private static Random rand;
        private int[] dice;
        private int[] dice2;
        private int[] diceResults;
        private int handRank, mod1, mod2, mod3;

        //generator
        private bool played = false;

        private string result, name;
        private int turns;

        #endregion Declaration

        #region Properties

        public int[] Dice
        {
            get { return dice; }
        }

        public int[] Dice2
        {
            get { return dice2; }
        }

        public int HandRank
        {
            get { return handRank; }
        }

        public int Mod1
        {
            get { return mod1; }
        }

        public int Mod2
        {
            get { return mod2; }
        }

        public int Mod3
        {
            get { return mod3; }
        }

        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        public bool Played
        {
            set { played = value; }
            get { return played; }
        }

        public string Result
        {
            get { return result; }
        }

        public int Turns
        {
            set { turns = value; }
            get { return turns; }
        }

        #endregion Properties

        #region Initialization

        public Player(string PlayerName)
        {
            name = PlayerName;

            dice = new int[5] { 0, 0, 0, 0, 0 };

            dice2 = new int[5] { 0, 0, 0, 0, 0 };

            diceResults = new int[6] { 0, 0, 0, 0, 0, 0 };

            result = "Roll the Dice";

            rand = new Random();

            played = false;

            turns = 3;

            handRank = 0;
            mod1 = 0;
            mod2 = 0;
            mod3 = 0;
        }

        #endregion Initialization

        #region Public Methods

        public void CheckboxChecked(string playerName, bool p1cb1, bool p1cb2, bool p1cb3, bool p1cb4, bool p1cb5, bool p2cb1, bool p2cb2, bool p2cb3, bool p2cb4, bool p2cb5)
        {
            if (playerName == "Player 1")
            {
                if (!p1cb1)
                {
                    Dice2[0] = Dice[0];
                }
                if (!p1cb2)
                {
                    Dice2[1] = Dice[1];
                }
                if (!p1cb3)
                {
                    Dice2[2] = Dice[2];
                }
                if (!p1cb4)
                {
                    Dice2[3] = Dice[3];
                }
                if (!p1cb5)
                {
                    Dice2[4] = Dice[4];
                }
            }
            else
            {
                if (!p2cb1)
                {
                    Dice2[0] = Dice[0];
                }
                if (!p2cb2)
                {
                    Dice2[1] = Dice[1];
                }
                if (!p2cb3)
                {
                    Dice2[2] = Dice[2];
                }
                if (!p2cb4)
                {
                    Dice2[3] = Dice[3];
                }
                if (!p2cb5)
                {
                    Dice2[4] = Dice[4];
                }
            }
        }

        public void ResetPlayer()
        {
            for (int i = 0; i < diceResults.Length; i++)
            {
                diceResults[i] = 0;
            }

            for (int i = 0; i < dice.Length; i++)
            {
                dice[i] = 0;
            }

            played = false;

            turns = 3;

            //handRank = 0;
            mod1 = 0;
            mod2 = 0;
            mod3 = 0;
        }

        public void ResetResults()
        {
            for (int i = 0; i < diceResults.Length; i++)
            {
                diceResults[i] = 0;
            }

            for (int i = 0; i < dice.Length; i++)
            {
                dice[i] = 0;
            }
        }

        public void RollDice()
        {
            for (int i = 0; i < dice.Length; i++)
            {
                dice[i] = rand.Next(1, 7);
            }
            //SetResults(dice);
            //GetResults();
        }

        public void SetResults(int int1, int int2, int int3, int int4, int int5)
        {
            int[] dice_Array = new int[5] { int1, int2, int3, int4, int5 };
            dice = dice_Array;

            for (int i = 0; i < dice.Length; i++)
            {
                switch (dice[i])
                {
                    case 1:
                        diceResults[0]++;
                        break;

                    case 2:
                        diceResults[1]++;
                        break;

                    case 3:
                        diceResults[2]++;
                        break;

                    case 4:
                        diceResults[3]++;
                        break;

                    case 5:
                        diceResults[4]++;
                        break;

                    case 6:
                        diceResults[5]++;
                        break;

                    default:
                        break;
                }
            }
            GetResults();
        }

        #endregion Public Methods

        #region Private Methods

        private void GetResults()
        {
            bool fiveKind = false, fourKind = false, highStraight = false,
                lowStraight = false, fullHouse = false, threekind = false,
                twoPair = false, onePair = false, haveSix = false, haveFive = false,
                haveFour = false, haveThree = false, haveTwo = false, haveOne = false;

            for (int i = 0; i < diceResults.Length; i++)
            {
                if (diceResults[i] == 5)
                {
                    fiveKind = true;
                    mod1 = i;
                }
                else if (diceResults[i] == 4)
                {
                    fourKind = true;
                    mod1 = i;
                }
                else if (diceResults[1] == 1 && diceResults[2] == 1 && diceResults[3] == 1 && diceResults[4] == 1 && diceResults[5] == 1)
                {
                    highStraight = true;
                }
                else if (diceResults[0] == 1 && diceResults[1] == 1 && diceResults[2] == 1 && diceResults[3] == 1 && diceResults[4] == 1)
                {
                    lowStraight = true;
                }
                else if (diceResults[i] == 3)
                {
                    threekind = true;
                    mod1 = i;

                    for (int j = 0; j < diceResults.Length; j++)
                    {
                        if (diceResults[j] == 2)
                        {
                            fullHouse = true;
                            mod2 = j;
                        }
                    }
                }
                else if (diceResults[i] == 2)
                {
                    onePair = true;
                    if (mod1 == 0)
                    {
                        mod1 = i;
                    }

                    for (int j = i + 1; j < diceResults.Length; j++)
                    {
                        if (diceResults[j] == 2)
                        {
                            twoPair = true;
                            if (mod2 == 0)
                            {
                                mod2 = j;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < dice.Length; i++)
            {
                switch (dice[i])
                {
                    case 6:
                        haveSix = true;
                        mod3 += 6;
                        break;

                    case 5:
                        haveFive = true;
                        mod3 += 5;
                        break;

                    case 4:
                        haveFour = true;
                        mod3 += 4;
                        break;

                    case 3:
                        haveThree = true;
                        mod3 += 3;
                        break;

                    case 2:
                        haveTwo = true;
                        mod3 += 2;
                        break;

                    case 1:
                        haveOne = true;
                        mod3 += 1;
                        break;

                    default:
                        break;
                }
            }

            if (fiveKind)
            {
                result = "Five of a Kind";
                handRank = 14;
            }
            else if (fourKind)
            {
                result = "Four of a Kind";
                handRank = 13;
            }
            else if (highStraight)
            {
                result = "High Straight";
                handRank = 12;
            }
            else if (lowStraight)
            {
                result = "Low Straight";
                handRank = 11;
            }
            else if (fullHouse)
            {
                result = "Full House";
                handRank = 10;
            }
            else if (threekind)
            {
                result = "Three of a Kind";
                handRank = 9;
            }
            else if (twoPair)
            {
                result = "Two Pair";
                handRank = 8;
            }
            else if (onePair)
            {
                result = "One Pair";
                handRank = 7;
            }
            else if (haveSix)
            {
                result = "Six High";
                handRank = 6;
            }
            else if (haveFive)
            {
                result = "Five High";
                handRank = 5;
            }
            else if (haveFour)
            {
                result = "Four High";
                handRank = 4;
            }
            else if (haveThree)
            {
                result = "Three high";
                handRank = 3;
            }
            else if (haveTwo)
            {
                result = "Two High";
                handRank = 2;
            }
            else if (haveOne)
            {
                result = "One High";
                handRank = 1;
            }
        }

        #endregion Private Methods
    }
}
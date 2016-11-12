using System;
using System.Collections.Generic;
using System.Text;

namespace LANStuffs.Games
{
    class TicToeStateManager
    {
        static Turns turn = 0;
        static Turns starting_turn = 0;
        static WinStates winstate = WinStates.None;
        static bool[,] has_image = new bool[3, 3];
        public static int row, col;
        public static int received_row, received_col;
        public static bool opened = false;
        static String[,] image = new String[3, 3];

        static int number_of_matches = 1;
        static int received_number_of_matches = 1;
        static int matches_played = 0;
        static int total_wins = 0;
        static int total_lose = 0;
        static int total_draw = 0;
        public static void initialize()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    has_image[i, j] = false;
                    image[i, j] = "none";
                }
            }
            row = -1;
            col = -1;
        }
        public static Turns Turn
        {
            get
            {
                return turn;
            }
            set
            {
                turn = value;
            }
        }
        public static Turns StartingTurn
        {
            get
            {
                return starting_turn;
            }
            set
            {
                starting_turn = value;
            }
        }
        public enum Turns
        {
            Mine = 1,
            His = 2,
        }

        public static WinStates WinState
        {
            get
            {
                return winstate;
            }
            set
            {
                winstate = value;
            }
        }
        public enum WinStates
        {
            None = 1,
            Win = 2,
            Lose = 3,
            Draw = 4,
        }

        public static int NumberOfMatches
        {
            get
            {
                return number_of_matches;
            }
            set
            {
                number_of_matches = value;
            }
        }

        public static int ReceivedNumberOfMatches
        {
            get
            {
                return received_number_of_matches;
            }
            set
            {
                received_number_of_matches = value;
            }
        }

        public static int MatchesPlayed
        {
            get
            {
                return matches_played;
            }
            set
            {
                matches_played = value;
            }
        }

        public static int TotalWins
        {
            get
            {
                return total_wins;
            }
            set
            {
                total_wins = value;
            }
        }

        public static int TotalLose
        {
            get
            {
                return total_lose;
            }
            set
            {
                total_lose = value;
            }
        }

        public static int TotalDraw
        {
            get
            {
                return total_draw;
            }
            set
            {
                total_draw = value;
            }
        }

        public static bool getHasImage(int i,int j)
        {
            if(has_image[i,j])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void setHasImage()
        {
            has_image[row,col] = true;
        }
        public static string getImage(int i, int j)
        {
            return image[i, j];
        }
        public static void setImage(string str)
        {
            image[row, col] = str;
        }
        public static void parse(String str)
        {
            System.Collections.ArrayList list = new System.Collections.ArrayList();
            char[] c = str.Trim().ToCharArray();
            for (int i = 0, j = 0, start_index = 0; i < c.Length; i++)
            {
                if (c[i].Equals(','))
                {
                    list.Add(str.Substring(start_index, i - start_index));
                    j++;
                    start_index = i + 1; 
                }
            }
            received_row = Convert.ToInt32(list[0]);
            received_col = Convert.ToInt32(list[1]);
            ReceivedNumberOfMatches = Convert.ToInt32(list[2]);
            row = received_row;
            col = received_col;
            setImage("circle");
            setHasImage();
        }
    }
}

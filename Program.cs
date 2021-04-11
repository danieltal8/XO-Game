using System;
using System.Threading;

namespace XO_Game
{
    class XOBoard
    {
        char[] table = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public int player = 1;
        public int place = 0;
        public int count = 0;
        public static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                // Check and write who Turn is it.
                if (player == 1)
                {
                    Console.WriteLine("X Turn");
                }
                else
                {
                    Console.WriteLine("O Turn");
                }
                // 
                Console.WriteLine("\n");
                Display();
                Console.WriteLine("Please enter a number");
                Console.WriteLine("\n");
                place = int.Parse(Console.ReadLine());
                Put(place);
                Status();
            } while (Status().Equals("None") && count < table.Length());
        }

        public static void Display()
        {
            //Console.Clear();
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", table[1], table[2], table[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", table[4], table[5], table[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", table[7], table[8], table[9]);
            Console.WriteLine("     |     |      ");
        }

        public static void Put(int n)
        {
            if (table[n] != 'X' && table[n] != 'O') // Checking if this place is not taken
            {
                if (player == 1)
                {
                    table[n] = 'X';
                    Status();
                    player++;
                    count++;
                }
                else
                {
                    table[n] = 'O';
                    Status();
                    player--;
                    count++;
                }
            }
            else
            {
                Console.WriteLine("This slot is already taken");
                Console.WriteLine("\n");
                Thread.Sleep(2000);
            }
        }

        public static string Status()
        {
            String stat = "None";
            int flag = 0;
            #region Horzontal Winning Condtion
            //Winning Condition For First Row   
            if (table[1] == table[2] && table[2] == table[3])
            {
                flag = 1;
            }
            //Winning Condition For Second Row   
            else if (table[4] == table[5] && table[5] == table[6])
            {
                flag = 1;
            }
            //Winning Condition For Third Row   
            else if (table[7] == table[8] && table[8] == table[9])
            {
                flag = 1;
            }
            #endregion

            #region vertical Winning Condtion
            //Winning Condition For First Column       
            else if (table[1] == table[4] && table[4] == table[7])
            {
                flag = 1;
            }
            //Winning Condition For Second Column  
            else if (table[2] == table[5] && table[5] == table[8])
            {
                flag = 1;
            }
            //Winning Condition For Third Column  
            else if (table[3] == table[6] && table[6] == table[9])
            {
                flag = 1;
            }
            #endregion

            #region Diagonal Winning Condition
            else if (table[1] == table[5] && table[5] == table[9])
            {
                flag = 1;
            }
            else if (table[3] == table[5] && table[5] == table[7])
            {
                flag = 1;
            }
            #endregion

            #region Checking For Draw
            else if (table[1] != '1' && table[2] != '2' && table[3] != '3' && table[4] != '4' && table[5] != '5' && table[6] != '6' && table[7] != '7' && table[8] != '8' && table[9] != '9')
            {
                flag = -1;
            }
            #endregion

            if (flag == 1)
                if (player == 1)
                {
                    stat = "X is the winner";
                }
                else
                {
                    stat = "O is the winner";
                }
            if (flag == -1)
            {
                stat = "Draw";
            }
            return stat;
        }
    }
}
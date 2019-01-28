using System;

namespace ConsoleApp1
{
    class Program
    {
        /// <summary>
        /// Objective is to determine minimum number of tries to find out the threshold
        /// floor from where if the egg is thrown breaks
        /// </summary>
        /// <param name="n"></param>
        /// <param name="e"></param>
        static void eggDrop(int n, int e)
        {

            // Array to store the mimimum tries for each floor and egg combination
            int[,] result = new int[n + 1, e + 1];

            // if we are only first floor we need only 1 try to determine threshold
            for (int i = 1; i < e + 1; i++)
            {
                result[1, i] = 1;
            }

            // if we have only 1 egg we have to use worst case by starting from 1st floor
            // and try dropping the egg until it breaks so n tries 
            for (int i = 1; i < n + 1; i++)
            {
                result[i, 1] = i;
            }

            // We have already figured out the tries with 1 egg any floors and any eggs with 1st floor.
            // so start from 2
            for (int i = 2; i < n + 1; i++)
            {
                for (int j = 2; j < e + 1; j++)
                {
                    result[i, j] = int.MaxValue;

                    // For each floor from 1st to current (i) find the min number of try
                    // on the max value between survival and broken
                    for (int x = 1; x < i ; x++)
                    {
                        // if it survived then we are left with evaluating of i - x floors and have still j eggs
                        int survived = result[i - x, j];
                        // if it broke then we have to evaulated x - 1 floors and have j - 1 eggs 
                        int broke = result[x - 1, j - 1];
                        int overall = Math.Max(survived, broke) + 1;  // + 1 for our current throw

                        // if this overall number of tries ( which is the worst case) is less than 
                        // the previously calculated worst case then assign this 
                        if ( overall < result[i,j])
                        {
                             result[i, j] = overall;
                        }
                    }
                }
           }


            for (int i = 1; i< n +1; i++)
            {
                for(int j = 1; j < e + 1; j++)
                {
                    Console.Write(result[i, j] + " ");
                }
                Console.WriteLine();
            }


        }

        static void main(String[] args)
        {
            eggDrop(8,4);
            Console.ReadLine();
        }
    }
}
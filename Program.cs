using System;

namespace assnmt_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Q1
            //Here in this question I'm letting user pass input.
            //Method is called by passing the input string
            Console.WriteLine("Q1: Enter the string:");
            string s = Console.ReadLine();
            string final_string = RemoveVowels(s);
            Console.WriteLine("Final string after removing the Vowels: {0}", final_string);
            Console.WriteLine();
            
            //Q2:
            string[] bulls_string1 = new string[] { "University", "of", "SouthFlorida" };
            string[] bulls_string2 = new string[] { "univerSityofSouthFlorida" };
            bool flag = ArrayStringsAreEqual(bulls_string1, bulls_string2);
            Console.WriteLine("Q2");
            if (flag)
            {
                Console.WriteLine("Yes, Both the array’s represent the same string");
            }
            else
            {
                Console.WriteLine("No, Both the array’s don’t represent the same string ");
            }
            Console.WriteLine();
            

            //Q3:
            int[] bull_bucks = new int[] { 1, 2, 3, 4, 5};
            int unique_sum = SumOfUnique(bull_bucks);
            Console.WriteLine("Q3:");
            Console.WriteLine("Sum of Unique Elements in the array is : {0}", unique_sum);
            Console.WriteLine();
            

            //Q5:
            Console.WriteLine("Q5:");
            String bulls_string = "aiohn";
            int[] indices = { 3, 1, 4, 2, 0 };
            String rotated_string = RestoreString(bulls_string, indices);
            Console.WriteLine("The  Final string after rotation is "+ rotated_string);
            Console.WriteLine();
            

            //Q6:
            string bulls_string6 = "zimmermanschoolofadvertising";
            char ch = 'x';
            string reversed_string = ReversePrefix(bulls_string6, ch);
            Console.WriteLine("Q6:");
            Console.WriteLine("Resultant string are reversing the prefix: {0}", reversed_string);
            Console.WriteLine();

            //Q4:
            int[,] bulls_grid = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            Console.WriteLine("Q4:");
            int diagSum = DiagonalSum(bulls_grid);
            Console.WriteLine("The sum of diagonal elements in the bulls grid is: {0}", diagSum);
            Console.WriteLine();
        }

        private static int DiagonalSum(int[,] bulls_grid)
        {
            try
            {
                int sum = 0;
                if (bulls_grid.GetLength(0) == bulls_grid.GetLength(1))
                {
                    if (bulls_grid.GetLength(0) % 2 != 0)
                    {
                        int repeat = (bulls_grid.GetLength(0) - 1) / 2;
                        sum -= bulls_grid[repeat, repeat];
                    }
                    for (int i = 0; i < bulls_grid.GetLength(0); i++)
                    {
                        for (int j = 0; j < bulls_grid.GetLength(1); j++)
                        {
                            if (i == j)
                            {
                                sum = sum + bulls_grid[i, j];
                            }
                            if (i + j == bulls_grid.GetLength(0) - 1)
                            {
                                sum = sum + bulls_grid[i, j];
                            }
                            //Counting the values of the counter diagonal values

                        }
                    }

                }
                return sum;
            }
            catch (Exception e)
            {

                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }

        }

        private static string ReversePrefix(string bulls_string6, char ch)
        {
            try
            {
                char[] x = bulls_string6.ToCharArray();
                char[] y = new char[bulls_string6.Length];
                bool flag = true;
                for (int i = 0; i < bulls_string6.Length; i++)
                {
                    if (flag)
                    {
                        if (x[i] == ch)
                        {
                            int k = 0;
                            for (int l = i; l >= 0; l--)
                            {
                                y[k] = x[l];
                                k = k + 1;
                            }
                            flag = false;
                            i = i + 1;

                        }
                        //Reversing the index of ther characters when it finds the 1st occurance
                    }
                    //Run stops after checking the 1st occurance of the given character
                    y[i] = x[i];
                    //continuing with the same characters after reversing the given values

                }
                string z = "";
                for (int m = 0; m < bulls_string6.Length; m++)
                {
                    z = z + y[m];
                }

                String prefix_string = z;
                return prefix_string;
            }
            catch (Exception)
            {

                throw;
            }

        }
        private static string RestoreString(string bulls_string, int[] indices)
        {
            try
            {//here I did alligning all the characters in the string as per the given indices
                char[] x = bulls_string.ToCharArray();
                char[] y = new char[bulls_string.Length];
                for (int i = 0; i < bulls_string.Length; i++)
                {
                    y[indices[i]] = x[i];
                }
                string z = "";
                for (int m = 0; m < bulls_string.Length; m++)
                {
                    z = z + y[m];
                }
                return z;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        private static int SumOfUnique(int[] bull_bucks)
        {
            try
            {
                int[] initialArray = new int[bull_bucks.Length];
                int sum = 0;

                for (int l = 0; l < bull_bucks.Length; l++)
                {
                    initialArray[l] = -1;
                }
                //Storing -1 to a new intial array x and having lenth of the input array

                for (int i = 0; i < bull_bucks.Length; i++)
                {
                    sum = sum + bull_bucks[i];

                    int value = 1;
                    for (int j = i + 1; j < bull_bucks.Length; j++)
                    {
                        if (bull_bucks[i] == bull_bucks[j])
                        {
                            value = value +1;
                            initialArray[j] = 0;
                        }

                    }
                    //Checking for the unique elements
                    if (initialArray[i] != 0)
                    {
                        initialArray[i] = value;
                    }
                    // Finding how many times an element is repeated

                }
                for (int k = 0; k < bull_bucks.Length; k++)
                {
                    if (initialArray[k] > 1)
                    {
                        sum -= (initialArray[k] * bull_bucks[k]);
                    }
                }
                //Here I'm eliminatimng the repeated values and adding the unique values
                return sum;

            }
            catch (Exception)
            {
                throw;
            }
        }
        private static bool ArrayStringsAreEqual(string[] bulls_string1, string[] bulls_string2)
        {
            //Here intially the code reads an array and all the characters in the array are  added to the new string and finally converted everything to lower case as to get rid of uppercase difficulties
            try
            {
                string newString1 = "";
                for (int j=0; j  < bulls_string1.Length; j++)
                {
                    foreach(char i in bulls_string1[j])
                    {
                        newString1 = newString1 + i;
                    }
                }

                string newString2 = "";
                for (int k = 0; k < bulls_string2.Length; k++)
                {
                    foreach (char l in bulls_string2[k])
                    {
                        newString2 = newString2 + l;
                    }
                }
                if (newString1.ToLower() == newString2.ToLower())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
            throw;
            }

        }
        private static string RemoveVowels(string s)
        {
            try
            {
                // Here the logic is intially I'm trying to check for each value in the string with the vowels and if that doesn't match it just adds an empty string
                String final_string1 = "";
                foreach (char i in s)
                {
                    if (i == 'a' || i == 'i' || i == 'e' || i == 'o' || i == 'u' || i == 'A' || i == 'I' || i == 'E' || i == 'O' || i == 'U')
                    {
                        final_string1 = final_string1 + "";
                    }
                    else
                    {
                        final_string1 = final_string1 + i;
                    }

                }


                return final_string1;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}


//SELF REFLECTION:

   // Question1:
//Time taken: 30  minutes
// Learnings: This is my first time encountering all these new things. Using method, Foreach and if statements. Intially moving from kattis this has made it difficult but with continuous work on it made it easy eventually
//Recommendation: This is easy with logic, No complains on this

//Question2:
//time taken: 20minutes
//learnings: Got used to try and catch

//Question3
//Time taken: 25minutes
//Learnings: Got much insights in using arrays

//Question4
// Time taken: 20 minutes
//Learnings: Found a function to find number of rows aand columns easily

// Question 5
//Time taken: 30 minutes
//Learnings: Found an easy way of alligning characters 

// Question 6
// Time taken: 40 minutes
// Learnings: Occurance of a given character in a given string using method
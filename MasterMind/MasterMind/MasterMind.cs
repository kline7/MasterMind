using System;

namespace MasterMind
{
    /// <summary>
    /// MasterMind game class
    /// </summary>
    class Program
    {
        #region variables
        // int array to hold the answer
        private static int[] key;
        // int array to hold users guess
        private static int[] guess;
        // char array to hold hint for user
        private static char[] response;
        private static int attempts = 10;
        private static int key_len = 4;
        #endregion

        /// <summary>
        /// This is a helper function to generate the key number to be guessed.
        /// 4 Digits in length range for each digit is 1-6.
        /// </summary>
        /// <returns> 1 on success</returns>
        public static int generateKey()
        {
            for (int i = 0; i < key_len; i++)
            {
                Random rand = new Random();
                int randInt = rand.Next(1, 7);
                key[i] = randInt;
            }
            return 1;
        }

        /// <summary>
        /// This is a helper function to validate the users string.
        /// </summary>
        /// <param name="str"></param>
        /// <returns> 1 if error. 0 if success.</returns>
        public static int validateUserString(string str)
        {
            if (str == null || str.Length < 4 || str.Length > 4)
            {
                return 1;
            }

            for(int i = 0; i < key_len; i++)
            {
                if (!Char.IsDigit(str[i]))
                {
                    // char is not a digit
                    return 1;
                }

                // validate each int falls in the range
                if (validateInt((int)Char.GetNumericValue(str[i])) == 0)
                {
                    // valid number
                    guess[i] = (int)Char.GetNumericValue(str[i]);
                }
                else
                {
                    return 1;
                }
            }
            return 0;
        }

        /// <summary>
        /// This is a helper function to generate the response hint for the guess.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="guess"></param>
        public static void generateHint(int[] key, int[] guess)
        {
            for (int i = 0; i < key_len; i++)
            {
                // check if guess is in key
                int index = indexOfNum(guess[i], i);
                if (index != -1)
                {
                    // the number is in the key check if it is the correct position
                    if (index == i)
                    {
                        response[i] = '+';
                    }
                    else
                    {
                        response[i] = '-';
                    }
                }
                else
                {
                    // the number is not in the key assign a 0 for wrong number
                    response[i] = '0';
                }
            }
        }

        #region extra helper functions
        /// <summary>
        /// This is a helper function to validate that the int falls within the 1-6 range.
        /// </summary>
        /// <param name="i"></param>
        /// <returns>-1 if the number is < 1. 1 if the number is > 6. 0 if within 1-6.</returns>
        public static int validateInt(int i)
        {
            if (i < 1)
            {
                return -1;
            }else if(i > 6)
            {
                return 1;
            }
            return 0;
        }

        /// <summary>
        /// This is a helper function to compare the guess with the key.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="guess"></param>
        /// <returns>1 if no match. 0 if a match.</returns>
        public static int compareGuess(int[] key, int[] guess)
        {
            for (int i = 0; i < 4; i++)
            {
                if (key[i] != guess[i])
                {
                    return 1;
                }
            }
            return 0;
        }

        /// <summary>
        /// This is a helper function to find the index of a number in the key array.
        /// </summary>
        /// <param name="num"></param>
        /// <returns>-1 if not found. index of number</returns>
        public static int indexOfNum(int num, int index)
        {
            int retIndex = -1;
            for (int i = 0; i < 4; i++)
            {
                if (key[i] == num)
                {
                    // if this is lower then the index check if there is another number
                    retIndex = i;
                    if (retIndex < index)
                    {
                        // continue looking for number
                    }
                    else
                    {
                        return i;
                    }

                }
            }

            return retIndex;
        }

        #endregion

        static void Main(string[] args)
        {
            string guess_string = "";
            key = new int[4];
            guess = new int[4];
            response = new char[4];
            Boolean win = false;
            Console.WriteLine("Welcome to MasterMind!");
            // generate an answer key for the game.
            generateKey();

            // allow user to have ten attempts for guess the key
            for (int i = 0; i < attempts; i++)
            {
                // prompt for guess and press enter
                Console.WriteLine("Enter guess:");

                // create a string variable to get user input from
                guess_string = Console.ReadLine();

                // validate that the string is valid
                if (validateUserString(guess_string) == 0)
                {
                    // print the guess and attempt number
                    Console.WriteLine("Guess is: " + guess_string + " attempt #" + (i + 1));

                    // first check if it matches
                    if (compareGuess(key, guess) == 0)
                    {
                        Console.WriteLine("YOU WIN! The guess matched!.");
                        win = true;
                        break;
                    }
                    else
                    {
                        // the guess doesn't match. create the hint print out.
                        generateHint(key, guess);

                        // now print the hint
                        // first print out the + for each position
                        for(int k = 0; k < key_len; k++)
                        {
                            if (response[k] == '+')
                            {
                                Console.Write("[ " + guess[k] + " ] : + ");
                            }
                        }
                        Console.WriteLine("");
                        // second print out the - for each position
                        for(int k = 0; k < key_len; k++)
                        {
                            if (response[k] == '-')
                            {
                                Console.Write("[ " + guess[k] + " ] : - ");
                            }
                        }
                        Console.WriteLine("");
                    }
                }
                else
                {
                    // invalid input an attempt is lost.
                    Console.WriteLine("Invalid Input! Attempt #" + (i + 1));
                }
            }
            
            if (win == false)
            {
                Console.WriteLine("YOU LOST! You ran out of attempts.");
            }
        }
    }
}

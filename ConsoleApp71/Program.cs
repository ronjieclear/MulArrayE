using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp71
{
    internal class Program
    {
        public static void Shuffle(Random random, string[,] arr)
        {
            int height = arr.GetUpperBound(0) + 1; // Y same as getlen
            int width = arr.GetUpperBound(1) + 1; // X
            for (int i = 0; i < height; i++) //loop Y Questions
            {
                int randomRow = random.Next(i, height); //select a random number
                for (int j = 0; j < width; ++j) //retrieve Y and add the to new array
                {
                    string tmp = arr[i, j]; //select rows
                    arr[i, j] = arr[randomRow, j];//add new rows
                    arr[randomRow, j] = tmp; //save to the new array rows
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Multidimensional Array");
            //Create a MD Array
            string[,] questions = new string[3, 2];
            //To assign value in MD Array
            questions[0, 0] = "Q1";
            questions[1, 0] = "Q2";
            questions[2, 0] = "Q3";
            //        Y   X
            questions[0, 1] = "A";
            questions[1, 1] = "B";
            questions[2, 1] = "C";

            //Display the value of MD Array
            Console.WriteLine(questions[0,0]); //Show Q1 question
            Console.WriteLine(questions[0, 1]); //Show Q1 Answer

            //Create a dynamic array with initialization
            string[,] QCA = new string[,] 
            {    //question , choices A B C D , last element is the answer
                {"Q1","A","B","C","D","A" },
                {"Q2","A","B","C","D","B" },
                {"Q3","A","B","C","D","C" },
                {"Q4","A","B","C","D","D" },
                {"Q5","A","B","C","D","D" },
                {"Language use in Prog2","Python","C","C#","HTML","C#" }
            };
            Random rnd = new Random(); //declare a randomizer
            Shuffle(rnd, QCA); //function call send array to shuffle class

            //check array size
            int AH = QCA.GetLength(0); //row - h
            int AW = QCA.GetLength(1); // cols - w

            string cans = "";//this will hold the correct answer    
            string uans = "";//user answer will be stored here

            //show the questions using a loop
            for(int i=0; i<AH;i++) //loop that shows the questions
            { 
                Console.WriteLine(QCA[i,0]); //show questions
                for (int c=1;c<AW;c++)//loop that show the choices
                {
                    if (c==5)//this holds the correct answer
                    {
                        cans = QCA[i, c]; //retrieve the correct answer and save to cans
                    }
                    else
                    {
                        Console.Write(" " + QCA[i, c] + " "); //show choices
                    }
                    
                }//end of loop choices
                Console.WriteLine(); //add new line after showing all the choices
                //ask the answer from the user
                Console.Write("Enter your answer: ");
                uans = Console.ReadLine();

                //Determing if the answer is correct
                if (uans == cans)
                {
                    Console.WriteLine("Correct!");
                }
                else
                {
                    Console.WriteLine($"The correct answer is {cans}");
                }
            }//end of loop questions

            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class TaskSearching
    {
        public void FindElementsForSum(List<uint> list, ulong sum, out int start, out int end)
        {     
            /* 
            Searching for subsequence from "start" to "end". The amount of detailed comments
            I made for better understanding each step of cycle.
             */

            //Checking incoming data           
            if (list is null) // if(list.count == 0)
            {
                throw new ArgumentNullException();
            }
           
            /*if (sum <= 0)
            *{
            *    throw new ArgumentException(String.Format("Некорректно введены данные:{0}", sum));
            }*/

            start = 0;
            end = 0;
            //Initializations of variables from received arguments
         

            //Create variable which contains the amount of numbers
            int amountOfNumbersInList = list.Count;
            //There is no data to work with
            if (amountOfNumbersInList == 0) return; 

            ulong sumNow = list[start];
            end++;

            /*
            Creating a cycle for searching through the list
            Need to write down all possible scenarios
            */
            for (;;)
            {                
               
                //If "sumNow" is less than "sum" there will be two ways
                if  (sumNow < sum)
                {
                    //The first way is that all numbers were iterated and as a result 
                    //It's summing turned out to be less than requested "sum"
                    if (end == amountOfNumbersInList)
                    {
                        break; //The exit from cycle
                    }
                    //The second way is just to continue the process: to increment variable "end" 
                    //Inside of "list" and add the value (from index) to "sumNow"
                    else
                    {
                        sumNow += list[end++];
                    }
                }

                //Additional condition: in the process 
                else if (sumNow > sum)
                {
                    if (start + 1 == end)
                    {
                        //It could be near to the end of the List, hence
                        //There is no way to move and no sense to continue
                        if (end == amountOfNumbersInList)
                        {
                            break; //The exit from cycle
                        }
                        //The List has a continuation, if the "start" and "end" are closed to each other
                        //And between them there is no number - just replace "start" on the "end" place
                        //And continue the search
                        else
                        {
                            start = end;
                            sumNow = list[start];
                            end++;
                        }
                    }
                    //Delete the number from the beggining to continue moving forward
                    else
                    {
                        sumNow -= list[start++];
                    }
                } 
                
                else if (sumNow == sum)
                {
                    return;
                }
                //If everything is okay and the variable "sumNow" is equal to "sum"

            }

            start = 0;
            end = 0;
        }

        public string FindElementsForSumWithAnalyse(List<uint> list, ulong sum, out int start, out int end)
        {
            /* 
            Searching for subsequence from "start" to "end". Additional task from me:
            Analyse numbers during the searching. Find the sum from the smallest ones during the linear 
            process of searching, excluding big numbers if it's sum is bigger then requested one.
            Saving the index/indexes or it's sequence that was matched.
             */
           
            if (list is null) 
            {
                throw new ArgumentNullException();
            }

            start = 0;
            end = 0;
            //adding new lists to fix the numbers from iteration
            var NoMatchedNumbers = new List<uint>();
            var Indexes = new List<uint>();
            //and variables
            int indexCounterInNoMatchNumbers = 0;
            int indexCounterInIndexes = 0;
            int amountOfNumbersInNoMatchedNumbersList = NoMatchedNumbers.Count;

            int amountOfNumbersInList = list.Count;
            if (amountOfNumbersInList == 0) return("Лист пуст");

            ulong sumNow = list[start];
            end++;

            for (; ; )
            {
                if (sumNow < sum)
                {
                    if (end == amountOfNumbersInList)
                    {
                        break; 
                    }
                    else
                    {
                        sumNow += list[end++];
                    }
                }

                else if (sumNow > sum)
                {
                    if (start + 1 == end)
                    { 
                        if (end == amountOfNumbersInList)
                        {
                            break; 
                        }

                        //analyse these 2 numbers
                        else if (start < end)
                        {
                            //saving "End" number into NoMatch list, cause its the biggest number in that subsequence
                            //saving "Start" number(index) into a list for fixing match
                            NoMatchedNumbers.Add(list[end]);
                            Indexes.Add(list[start]);
                            end++;

                            for (int i = 0; i < amountOfNumbersInNoMatchedNumbersList; i++)
                            {
                                if (list[end] == NoMatchedNumbers[i])
                                {
                                    start = end;
                                    end++;
                                }
                                else
                                {
                                    start++;
                                }
                            }
                            start = end;
                            end++;
                        }

                        else
                        {
                            start = end;
                            sumNow = list[start];
                            end++;
                        }
                    }
                    else
                    {
                        sumNow -= list[start++];
                    }
                }

                else if (sumNow == sum)
                {
                    return("Сумма найдена");
                }
            }

            start = 0;
            end = 0;

            return string();
        }

        static void Main (string[] args)
        {

        }
    }

  
}

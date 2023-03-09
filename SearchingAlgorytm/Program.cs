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
        static void Main (string[] args)
        {

        }
    }

  
}

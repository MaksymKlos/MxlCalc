using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Models
{
    public static class Combinations
    {
        public static string[] ResponseList { get; private set; }
        public static double Result { get; set; }
        public static string TypeOfConfigure { get; set; }

        public static void CreateList(int maxCountOfAnswers)
        {
            ResponseList = new string[maxCountOfAnswers];
        }
        public static void AddToList(int index, string answer)
        {
            ResponseList[index] = answer;
            
        }
    }
}

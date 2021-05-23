using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MxlCalc.Models;

namespace Services
{
    public class OperationsService
    {
        private List<char> _setA;
        private List<char> _setB;
        public List<char> Result { get; set; }

        public OperationsService(string setA, string setB, string operation, string type)
        {
            if (type == "digital")
            {
                DigitalToList(setA, setB);
            }
            else
            {
                AlphabeticToList(setA, setB);
            }

            Set firstSet = new Set(_setA);
            Set secondSet = new Set(_setB);
            Result = DoOperation(firstSet, secondSet, operation);
        }

        private void DigitalToList(string setA, string setB)
        {
            _setA = setA.Where(c => c >= 48 && c <= 57).ToList();
            _setB = setB.Where(c => c >= 48 && c <= 57).ToList();
        }

        private void AlphabeticToList(string setA, string setB)
        {
            _setA = setA.Where(c => (c >= 65 && c <= 90) || (c >= 97 && c <= 122)).ToList();
            _setB = setB.Where(c => (c >= 65 && c <= 90) || (c >= 97 && c <= 122)).ToList();
        }
        private List<char> DoOperation(Set firstSet, Set secondSet, string operation)
        {
            List<char> result = new List<char>();
            switch (operation)
            {
                case "intersect":
                    result = firstSet.Intersect(secondSet);
                    break;
                case "setdiff":
                    result = firstSet.SetDiff(secondSet);
                    break;
                case "union":
                    result = firstSet.Union(secondSet);
                    break;
                case "setxor":
                    result = firstSet.SetXor(secondSet);
                    break;
            }
            result.Sort();
            return result;
        }

        public override string ToString()
        {
            string answer = "";
            foreach (var item in Result)
            {
                answer += item;
                answer += ", ";
            }

            if (answer == "") return "∅";
            return String.Format("{0}", answer.Remove(answer.Length - 2));
        }
    }
}

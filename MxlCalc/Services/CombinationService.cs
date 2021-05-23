using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public class CombinationService
    {
        private int _maxCountOfAnswers;
        private int _n;
        private int _m;
        private List<int> _k;

        public double Result { get; private set; }
        public string TypeOfConfigure { get; set; }
        public string Form { get; private set; }

        public CombinationService(string answer)
        {
            Form = ReturnProperForm(answer);
        }

        public CombinationService(string n, bool isOnlyN)
        {
            if (isOnlyN)
            {
                _n = int.Parse(n);
                TakeResultView();
                Form = "result.cshtml";
            }
        }

        public CombinationService(string n, string m)
        {
            _n = int.Parse(n);
            _m = int.Parse(m);
            TakeResultView();
            Form = "result.cshtml";
        }

        public CombinationService(string m, string k, bool hasList)
        {
            if (hasList)
            {
                _m = int.Parse(m);
                DigitalToList(k);
                TakeResultView();
                Form = "result.cshtml";
            }
        }
            

        private string ReturnProperForm(string answer)
        {
            
            switch (answer)
            {
                case "yes1":
                    _maxCountOfAnswers = 3;
                    Combinations.CreateList(_maxCountOfAnswers);
                    Combinations.AddToList(0,"y");
                    return "form2.cshtml";
                case "no1":
                    _maxCountOfAnswers = 2; 
                    Combinations.CreateList(_maxCountOfAnswers);
                    Combinations.AddToList(0,"n");
                    return "form3.cshtml";

                case "yes2_2":
                    Combinations.AddToList(1,"y");
                    return "form2_1.cshtml";
                case "no2_2":
                    Combinations.AddToList(1,"n");
                    return "form2_1.cshtml";

                case "yes3":
                    Combinations.AddToList(2,"y");
                    break;
                case "no3":
                    Combinations.AddToList(2,"n");
                    break;

                case "yes2_3":
                    Combinations.AddToList(1,"y");
                    break;
                case "no2_3":
                    Combinations.AddToList(1,"n");
                    break;
            }
            
            return TakeType();
        }

        private string TakeType()
        {
            if (Combinations.ResponseList[0] == "y")
            {
                if (Combinations.ResponseList[1] == "y")
                {
                    if (Combinations.ResponseList[2] == "y")
                    {
                        Combinations.TypeOfConfigure = "перестановки с повторениями из n элементов по m с заданной спецификацией (k1,k2...kn)";
                        return "result3.cshtml";
                    }
                    else
                    {
                        Combinations.TypeOfConfigure = "перестановки без повторений из n элементов.";
                        return "result2.cshtml";
                    }
                }
                else
                {
                    if (Combinations.ResponseList[2] == "y")
                    {
                        Combinations.TypeOfConfigure = "размещения с повторениями из n элементов по m";
                        return "result1.cshtml";
                    }
                    else
                    {
                        Combinations.TypeOfConfigure = "размещения без повторений из n элементов по m";
                        return "result1.cshtml";
                    }
                }
            }
            else
            {
                if (Combinations.ResponseList[1] == "y")
                {
                    Combinations.TypeOfConfigure = "сочетания с повторениями из n элементов по m";
                    return "result1.cshtml";
                }
                else
                {
                    Combinations.TypeOfConfigure = "сочетания без повторениями из n элементов по m";
                    return "result1.cshtml";
                }
            }
        }
        private void TakeResultView()
        {
            switch (Combinations.TypeOfConfigure)
            {
                case "перестановки с повторениями из n элементов по m с заданной спецификацией (k1,k2...kn)":
                    Combinations.Result = SolveConfigureWithK();
                    break;
                case "перестановки без повторений из n элементов.":
                    Combinations.Result = Fact(_n);
                    break;
                case "размещения с повторениями из n элементов по m":
                    Combinations.Result = Math.Pow(_n, _m);
                    break;
                case "размещения без повторений из n элементов по m":
                    Combinations.Result = Fact(_n) / Fact(_n - _m);
                    break;
                case "сочетания с повторениями из n элементов по m":
                    Combinations.Result = Fact(_n + _m - 1) / (Fact(_m) * Fact(_n - 1));
                    break;
                case "сочетания без повторениями из n элементов по m":
                    Combinations.Result = Fact(_n) / (Fact(_m) * Fact(_n - _m));
                    break;

            }
        }
        private static double Fact(int n)
        {
            if (n < 0) return 0;
            if (n == 0) return 1;
            return n * Fact(n - 1);
        }
        private void DigitalToList(string k)
        {
            
            _k = k.Where(c => c >= 48 && c <= 57).ToList().Select(c => (int)char.GetNumericValue(c)).ToList();
        }

        private double SolveConfigureWithK()
        {
            double numerator = Fact(_m);
            double denominator = 1;
            foreach (var item in _k)
            {
                denominator *= Fact(item);
            }

            return numerator / denominator;
        }
    }
}

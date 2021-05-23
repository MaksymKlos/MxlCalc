using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MxlCalc.Models
{
    public class Set
    {
        public List<char> SetList;
        private List<char> _result;

        public Set(List<char> set)
        {
            SetList = set;
        }
        public List<char> Intersect(Set second_set)
        {
            _result = new List<char>();
            for (int i = 0; i < SetList.Count; i++)
            {
                for (int j = 0; j < second_set.SetList.Count; j++)
                {
                    if (SetList[i] == second_set.SetList[j])
                    {
                        _result.Add(SetList[i]);
                    }
                }
            }
            return _result;
        }
        public List<char> SetDiff(Set second_set)
        {
            _result = new List<char>();
            for (int i = 0; i < SetList.Count; i++)
            {
                if (!second_set.SetList.Contains(SetList[i]))
                {
                    _result.Add(SetList[i]);
                }
            }
            return _result;
        }
        public List<char> Union(Set second_set)
        {
            _result = SetList;
            for (int i = 0; i < second_set.SetList.Count; i++)
            {
                if (!SetList.Contains(second_set.SetList[i]))
                {
                    _result.Add(second_set.SetList[i]);
                }
            }
            return _result;
        }
        public List<char> SetXor(Set second_set)
        {
            _result = new List<char>();
            for (int i = 0; i < SetList.Count; i++)
            {
                if (!second_set.SetList.Contains(SetList[i]))
                {
                    _result.Add(SetList[i]);
                }
            }
            for (int i = 0; i < second_set.SetList.Count; i++)
            {
                if (!SetList.Contains(second_set.SetList[i]))
                {
                    _result.Add(second_set.SetList[i]);
                }
            }
            return _result;
        }

    }
}

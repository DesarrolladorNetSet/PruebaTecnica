using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BibliotecaClases_Operati
{
    public class ClassOperati
    {
        public bool TreeConstructor(string[] strArr)
        {
            if (strArr.Length == 0) return false;

            List<string> parent = new List<string>();
            List<string> child = new List<string>();

            for (var i = 0; i < strArr.Length; i++)
            {
                string[] value = strArr[i].Split(',');

                parent.Add(value[1]);
                child.Add(value[0]);
            }
            
            var groupParent = parent.GroupBy(g => g);
            foreach(var value in parent.Distinct())
            {
                var total = parent.Where(w => w == value).Count();
                if(total > 2)
                {
                    return false;
                }
            }

            foreach (var value in child.Distinct())
            {
                var total = child.Where(w => w == value).Count();
                if (total > 1)
                {
                    return false;
                }
            }

            return true;
        }

        public int FarthestNodes(string[] strArr)
        {
            if (strArr.Length == 0) return 0;

            List<List<string>> nodes = new List<List<string>>();
            for(var i=0; i<strArr.Length; i++)
            {
                string[] value = strArr[i].Split('-');
                var existFirst = nodes.Where(w => w.First() == value[0] || w.First() == value[1]).ToList();
                foreach(var first in existFirst)
                {
                    if (first.First() == value[0])
                    {
                        first.Insert(0, value[1]);
                    }
                    else if (first.First() == value[1])
                    {
                        first.Insert(0, value[0]);
                    }
                }

                var existLast = nodes.Where(w => w.Last() == value[0] || w.Last() == value[1]).ToList();
                foreach (var last in existLast)
                {
                    if (last.Last() == value[0])
                    {
                        last.Insert(last.Count, value[1]);
                    }
                    else if (last.Last() == value[1])
                    {
                        last.Insert(last.Count, value[0]);
                    }
                }
                if (existFirst.Count == 0 && existLast.Count == 0) nodes.Add(new List<string> { value[0], value[1] });
            }

            var totalNodes = nodes.Select(s => s.Count - 1).OrderByDescending(o => o).ToList();
            return totalNodes.First();
        }
    }
}

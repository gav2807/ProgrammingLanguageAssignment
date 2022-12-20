using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageAssignment
{
    public class Variable 
    {
        public string variableName = "";
        public int variableValue = 0;
        
        public void set(params string[] list)
        {
           if (list[0].GetType() == typeof(string) && (list.Count() == 3) )
           {
                this.variableName = list[0];
                this.variableValue = Int32.Parse(list[2]);
           }
        }
    }
}

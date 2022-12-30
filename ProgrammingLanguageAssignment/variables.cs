using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageAssignment
{
    public class Variable
    {
        private string[] variableName = new string[100];
        private int[] variableValue = new int[100];

        public void set(int value, string name, int index)
        {
            if (!this.variableName.Contains(name))
            {
                this.variableName[index] = name;
                this.variableValue[index] = value;
            }
        }

        public string[] getVariableName()
        {
            return this.variableName;
        }

        public int[] getVariableValue()
        {
            return this.variableValue;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageAssignment
{
    public class Conditional
    {
        public bool If, IfLogic = false;
        public string IfOperator;
        public int IfValue, IfVariable;

        public void set(bool If, int Variable, int Value, string Operator)
        {
            this.If = If;
            this.IfVariable = Variable;
            this.IfValue = Value;
            this.IfOperator = Operator;
        }

        public bool checkIfLogic()
        {
            switch (this.IfOperator)
            {
                case ">":
                    this.IfLogic = (this.IfVariable > this.IfValue);
                    break;
                case "<":
                    this.IfLogic = (this.IfVariable < this.IfValue);
                    break;
                case ">=":
                    this.IfLogic = (this.IfVariable >= this.IfValue);
                    break;
                case "<=":
                    this.IfLogic = (this.IfVariable <= this.IfValue);
                    break;
                case "==":
                    this.IfLogic = (this.IfVariable == this.IfValue);
                    break;
                case "!=":
                    this.IfLogic = (this.IfVariable != this.IfValue);
                    break;
                default:
                    this.IfLogic = false;
                    break;
            }
            return this.IfLogic;

        }

    }
}

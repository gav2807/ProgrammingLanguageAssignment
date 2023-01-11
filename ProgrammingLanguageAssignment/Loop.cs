using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageAssignment
{
    public class Loop
    {
        public bool loop, loopLogic = false;
        public string loopOperator;
        public int loopValue, loopVariable;

        public void set(bool loop, int Variable, int Value, string Operator)
        {
            this.loop = loop;
            this.loopVariable = Variable;
            this.loopValue = Value;
            this.loopOperator = Operator;
        }

        public bool checkLoopLogic()
        {
            switch (this.loopOperator)
            {
                case ">":
                    this.loopLogic = (this.loopVariable > this.loopValue);
                    break;
                case "<":
                    this.loopLogic = (this.loopVariable < this.loopValue);
                    break;
                case ">=":
                    this.loopLogic = (this.loopVariable >= this.loopValue);
                    break;
                case "<=":
                    this.loopLogic = (this.loopVariable <= this.loopValue);
                    break;
                case "==":
                    this.loopLogic = (this.loopVariable == this.loopValue);
                    break;
                case "!=":
                    this.loopLogic = (this.loopVariable != this.loopValue);
                    break;
                default:
                    this.loopLogic = false;
                    break;
            }
            return this.loopLogic;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAlgebraSystem
{
    public class Term
    {
        public Variable Var { get; private set; }
        public float Coefficient { get; private set; }
        public int TermOperation { get; private set; }
        public int Power { get; private set; }
        public bool HasBeenOperated { get; set; }

        public Term(Variable var, float coefficient, int termOperation, int power, bool HasBeenOperated = false)
        {
            Var = var;
            Coefficient = coefficient;
            TermOperation = termOperation;
            Power = power;
        }

        public Term()
        {
            Var = new Variable();
            Coefficient = 1;
            TermOperation = 1;
            Power = 1;
        }

        public string ReturnString()
        {
            var s = "";

            string operation = "";
            switch (TermOperation)
            {
                case 1:
                    operation = "+";
                    break;
                case 2:
                    operation = "-";
                    break;
                case 3:
                    operation = "*";
                    break;
                case 4:
                    operation = "/";
                    break;
                default:
                    break;

            }
            s = operation + "(" + Coefficient + Var.ReturnString() + ")";
            if (Power != 1)
                s += "^" + Power + " ";

            return s;
        }

        public void NullOperation()
        {
            TermOperation = 0;
        }

        public void NullToAdd()
        {
            if (TermOperation == 0)
                TermOperation = 1;
        }

        public void SubToNegAdd()
        {
            if(TermOperation == 2)
            {
                NegTerm();
                TermOperation = 1;
            }
        }

        public void NegTerm()
        {
            Coefficient = -1 * Coefficient;
        }
}
}

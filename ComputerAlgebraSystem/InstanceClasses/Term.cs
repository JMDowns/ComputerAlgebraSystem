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
        public int TermOperationSwitch { get; private set; }
        public int Power { get; private set; }
        public bool HasBeenAdded { get; set; }

        public Term(Variable var, float coefficient, int termOperationSwitch, int power)
        {
            Var = var;
            Coefficient = coefficient;
            TermOperationSwitch = termOperationSwitch;
            Power = power;
        }

        public void Print()
        {
            string operation = "";
            switch (TermOperationSwitch)
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

            Console.Write(operation + "(" + Coefficient);
            Var.Print();
            Console.Write(")");
        }
    }
}

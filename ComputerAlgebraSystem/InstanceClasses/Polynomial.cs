using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAlgebraSystem
{
    public class Polynomial
    {
        public List<Term> Terms { get; private set; }
        public int PolynomialOperationSwitch { get; private set; }
        public int Power { get; private set; }

        public Polynomial(List<Term> terms, int polynomialOperationSwitch, int power)
        {
            Terms = terms;
            PolynomialOperationSwitch = polynomialOperationSwitch;
            Power = power;
        }

        public void Print()
        {
            string operation = "";
            switch (PolynomialOperationSwitch)
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

            Console.Write(operation + "(");
            foreach(var term in Terms)
                term.Print();
            Console.Write(")");
        }
    }
}

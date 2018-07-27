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
        public int PolynomialOperation { get; private set; }
        public int Power { get; private set; }

        public Polynomial(List<Term> terms, int polynomialOperation, int power)
        {
            Terms = terms;
            PolynomialOperation = polynomialOperation;
            Power = power;
        }

        public string ReturnString()
        {
            var s = "";

            string operation = "";
            switch (PolynomialOperation)
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

            s = operation + "(";
            foreach(var term in Terms)
                s += term.ReturnString();
            s += ")";

            return s;
        }

        public void NullToAdd()
        {
            if (PolynomialOperation == 0)
                PolynomialOperation = 1;
        }

        public void SubToNegAdd()
        {
            if (PolynomialOperation == 2)
            {
                foreach (Term t in Terms)
                    t.NegTerm();
                PolynomialOperation = 1;
            }
        }
    }
}

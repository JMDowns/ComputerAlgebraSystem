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
        public bool HasBeenOperated { get; set; }

        public Polynomial(List<Term> terms, int polynomialOperation, int power, bool HasBeenOperated = false)
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

        public void NullOperation()
        {
            PolynomialOperation = 0;
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

        public int GreatestPower()
        {
            var maxPower = 0;
            foreach(Term t in Terms)
            {
                if (t.ReturnPower() > maxPower)
                    maxPower = t.ReturnPower();
            }
            return maxPower;
        }

        public void Sort()
        {
            Terms = Terms.OrderBy(x => x.ReturnPower()).ToList();
            Terms.Reverse();
        }
    }
}

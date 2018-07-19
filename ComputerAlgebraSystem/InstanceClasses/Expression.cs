using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAlgebraSystem
{
    public class Expression
    {
        public List<Polynomial> PolynomialList { get; private set; }

        public Expression(List<Polynomial> polynomialList)
        {
            PolynomialList = polynomialList;
        }

        public void Print()
        {
            Console.Write("(");
            foreach (var polynomial in PolynomialList)
                polynomial.Print();
            Console.WriteLine(")");
        }
    }
}

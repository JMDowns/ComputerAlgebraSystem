using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAlgebraSystem
{
    public class Expression
    {
        public List<Polynomial> Polynomials { get; private set; }

        public Expression(List<Polynomial> polynomials)
        {
            Polynomials = polynomials;
        }

        public string ReturnString()
        {
            var s = "";
            foreach (var polynomial in Polynomials)
                s += polynomial.ReturnString();
            return s;
        }
    }
}

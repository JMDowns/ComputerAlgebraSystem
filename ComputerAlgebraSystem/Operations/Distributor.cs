using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAlgebraSystem.Operations
{
    static class Distributor
    {
        static public Polynomial Distribute(Polynomial polynomial1, Polynomial polynomial2)
        {
            var newTerms = new List<Term>();
            foreach(Term term1 in polynomial1.Terms)
            {
                foreach(Term term2 in polynomial2.Terms)
                {
                    newTerms.Add(Multiplier.Multiply(term1, term2));
                }
            }
            return new Polynomial(newTerms, 1, 1);
        }
    }
}

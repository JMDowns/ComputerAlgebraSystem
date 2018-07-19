using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAlgebraSystem.Operations
{
    static class Subtractor
    {
        static public Term Subtract(Term term1, Term term2)
        {
            var subtractedCoefficient = term1.Coefficient - term2.Coefficient;
            return new Term(term1.Var, subtractedCoefficient, 1, 1);
        }
    }
}

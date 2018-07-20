using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAlgebraSystem.Operations
{
    static class Subtractor
    {
        static public Term Subtract(Term t2, Term t1)
        {
            var subtractedCoefficient = t1.Coefficient - t2.Coefficient;
            return new Term(t1.Var, subtractedCoefficient, 1, 1);
        }
    }
}

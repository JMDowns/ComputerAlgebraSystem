using ComputerAlgebraSystem.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAlgebraSystem.Setup
{
    class Operator
    {
        public Expression Operate(Expression expression)
        {
            var newPolynomials = new List<Polynomial>();
            foreach (Polynomial polynomial in expression.PolynomialList)
            {
                var newTerms = new List<Term>();
                for(int i = 0; i < polynomial.Terms.Count; i++)
                {
                    if (polynomial.Terms[i].TermOperationSwitch == 3)
                    {
                        if (i > 0)
                        {
                            Verifier.VerifyMultiply(polynomial.Terms[i], polynomial.Terms[i - 1]);
                        }
                    }
                }
            }

            return expression;
        }
    }
}

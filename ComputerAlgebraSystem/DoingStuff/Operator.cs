using ComputerAlgebraSystem.Operations;
using ComputerAlgebraSystem.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAlgebraSystem.DoingStuff
{
    class Operator
    {
        public Expression Operate(Expression expression)
        {
            PolynomialOperator PO = new PolynomialOperator();
            var newPolynomials = new List<Polynomial>();
            foreach (Polynomial p in expression.Polynomials)
            {
                newPolynomials.Add(PO.PolynomialOperate(p));
            }

            return new Expression(newPolynomials);
        }
    }
}

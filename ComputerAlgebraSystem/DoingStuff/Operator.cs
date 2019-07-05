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
        public Expression Analyze_And_Simplify(Expression expression)
        {
            var PO = new PolynomialOperator();
            var EO = new ExpressionOperator();
            var newPolynomials = new List<Polynomial>();
            var finalPolynomials = new List<Polynomial>();

            foreach (Polynomial p in expression.Polynomials)
            {
                newPolynomials.Add(PO.Automatic_Operation_On_Polynomials(p));
            }

            var newExpression = EO.Automatic_Operation_On_Expression(new Expression(newPolynomials));

            foreach (Polynomial p in newExpression.Polynomials)
            {
                finalPolynomials.Add(PO.Automatic_Operation_On_Polynomials(p));
            }

            finalPolynomials[0].Terms[0].NullOperation();

            return new Expression(finalPolynomials);
        }
    }
}

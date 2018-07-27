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
        public Expression Analyze_And_Simplify(Expression expression) // Change to better name (ie Analyze_And_Simplify)
        {
            var PO = new PolynomialOperator();
            var EO = new ExpressionOperator();
            var newPolynomials = new List<Polynomial>();

            foreach (Polynomial p in expression.Polynomials)
            {
                newPolynomials.Add(PO.Automatic_Operation_On_Polynomials(p));
            }

            EO.Automatic_Operation_On_Polynomial_List(newPolynomials);

            return new Expression(newPolynomials);
        }
    }
}

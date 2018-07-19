using ComputerAlgebraSystem.Operations;
using ComputerAlgebraSystem.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAlgebraSystem.DoingStuff
{
    static class Operator
    {
        static public Expression Operate(Expression expression)
        {
            var newPolynomials = new List<Polynomial>();
            foreach (Polynomial polynomial in expression.Polynomials)
            {
                var endPolynomial = polynomial;
                Polynomial tempPolynomial;
                do
                {
                    tempPolynomial = endPolynomial;
                    var newTerms = new List<Term>();

                    for (int i = 1; i < tempPolynomial.Terms.Count; i++)
                    {
                        if (tempPolynomial.Terms[i].TermOperation == 4)
                        {
                            if (Verifier.VerifyDivide(polynomial.Terms[i], polynomial.Terms[i - 1]))
                            {
                                newTerms.Add(Divider.Divide(polynomial.Terms[i], polynomial.Terms[i - 1]));
                                tempPolynomial.Terms[i].HasBeenOperated = true;
                                tempPolynomial.Terms[i-1].HasBeenOperated = true;
                                break;
                            }
                        }
                    }

                    foreach(Term t in tempPolynomial.Terms)
                    {
                        if (!t.HasBeenOperated)
                            newTerms.Add(t);
                    }

                    endPolynomial = new Polynomial(newTerms, polynomial.PolynomialOperation, polynomial.Power);
                    tempPolynomial.Print();
                    endPolynomial.Print();
                    var dummytext = Console.ReadLine();
                } while (false);
                newPolynomials.Add(endPolynomial);
            }

            return new Expression(newPolynomials);
        }
    }
}


//if (polynomial.Terms[i].TermOperation == 3 &&
//    Verifier.VerifyMultiply(polynomial.Terms[i], polynomial.Terms[i - 1]))
//{
//    newTerms.Add(Multiplier.Multiply(polynomial.Terms[i], polynomial.Terms[i - 1]));
//    tempPolynomial.Terms[i].HasBeenOperated = true;
//    tempPolynomial.Terms[i - 1].HasBeenOperated = true;
//    break;
//}

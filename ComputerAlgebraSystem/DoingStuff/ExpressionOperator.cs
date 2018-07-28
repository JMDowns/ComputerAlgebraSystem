using ComputerAlgebraSystem.Operations;
using ComputerAlgebraSystem.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAlgebraSystem.DoingStuff
{
    class ExpressionOperator
    {
        public Expression Automatic_Operation_On_Expression (Expression e)
        {
            foreach (Polynomial p in e.Polynomials)
            {
                p.NullToAdd();
                p.SubToNegAdd();
            }
            var peExpression = PE(e);
            var mdExpression = MD(peExpression);
            var endExpression = AS(mdExpression);
            Console.WriteLine("End");
            return endExpression;
        }

        static Expression PE(Expression e)
        {
            var endExpression = e;
            Expression tempExpression;
            do
            {
                tempExpression = endExpression;
                var Polynomials = tempExpression.Polynomials;
                var editedPolynomials = new Dictionary<int, Polynomial>();
                var oldPolynomials = new List<Polynomial>();
                var reconstructedPolynomialList = new List<Polynomial>();

                for (int i = 0; i < Polynomials.Count; i++)
                {
                    Polynomial p = Polynomials[i];
                    if (p.Power > 1)
                    {
                        editedPolynomials.Add(i, Raiser.Raise(p, p.Power));
                        p.HasBeenOperated = true;
                        break;
                    }

                    if (p.Power == 0)
                    {
                        editedPolynomials.Add(i, new Expression().Polynomials[0]);
                        p.HasBeenOperated = true;
                        break;
                    }
                }

                foreach (Polynomial p in Polynomials)
                {
                    if (!p.HasBeenOperated)
                        oldPolynomials.Add(p);
                }


                // In case of a lone polynomial, which will cause the for loop in the future to skip over
                if (oldPolynomials.Count == 0)
                    reconstructedPolynomialList.Add(editedPolynomials[0]);

                /* This bit is different from the other methods so raising a term doesn't mess with the order of the terms.
                 * */
                int numberOfRaisedAdded = 0;

                for (int i = 0; i < oldPolynomials.Count + numberOfRaisedAdded; i++)
                {
                    if (editedPolynomials.ContainsKey(i))
                    {
                        reconstructedPolynomialList.Add(editedPolynomials[i]);
                        numberOfRaisedAdded++;
                    }
                    else
                    {
                        reconstructedPolynomialList.Add(oldPolynomials[i - numberOfRaisedAdded]);
                    }
                }

                endExpression = new Expression(reconstructedPolynomialList);
                Console.WriteLine(endExpression.ReturnString());
            } while (tempExpression.ReturnString() != endExpression.ReturnString());

            Console.WriteLine("End of PE");
            return endExpression;
        }

        static Expression MD(Expression e)
        {
            var endExpression = e;
            Expression tempExpression;
            do
            {
                tempExpression = endExpression;
                var Polynomials = tempExpression.Polynomials;
                var newPolynomials = new List<Polynomial>();

                for (int i = 1; i < Polynomials.Count; i++)
                {
                    //if (Polynomials[i].PolynomialOperation == 4)
                    //{
                    //    if (Verifier.VerifyDivide(Polynomials[i], Polynomials[i - 1]))
                    //    {
                    //        int j = i;
                    //        newPolynomials.Add(Divider.Divide(Polynomials[i], Polynomials[i - 1]));
                    //        Polynomials[i].HasBeenOperated = true;
                    //        Polynomials[i - 1].HasBeenOperated = true;
                    //        while (Polynomials[j + 1].PolynomialOperation == 3 || Polynomials[j + 1].PolynomialOperation == 4)
                    //        {
                    //            if (Polynomials[j + 1].PolynomialOperation == 3)
                    //            {
                    //                newPolynomials[0] = Multiplier.Multiply(Polynomials[j + 1], newPolynomials[0]);
                    //                Polynomials[j + 1].HasBeenOperated = true;
                    //            }

                    //            if (Polynomials[j + 1].PolynomialOperation == 4)
                    //            {
                    //                newPolynomials[0] = Divider.Divide(Polynomials[j + 1], newPolynomials[0]);
                    //                Polynomials[j + 1].HasBeenOperated = true;
                    //            }

                    //            j++;
                    //        }

                    //        break;
                    //    }
                    //}

                    if (Polynomials[i].PolynomialOperation == 3)
                    {
                        if (Verifier.VerifyMultiply(Polynomials[i], Polynomials[i - 1]))
                        {
                            int j = i;
                            newPolynomials.Add(Multiplier.Multiply(Polynomials[i], Polynomials[i - 1]));
                            Polynomials[i].HasBeenOperated = true;
                            Polynomials[i - 1].HasBeenOperated = true;
                            try
                            {
                                while (Polynomials[j + 1].PolynomialOperation == 3 || Polynomials[j + 1].PolynomialOperation == 4)
                                {
                                    if (Polynomials[j + 1].PolynomialOperation == 3)
                                    {
                                        newPolynomials[0] = Multiplier.Multiply(Polynomials[j + 1], newPolynomials[0]);
                                        Polynomials[j + 1].HasBeenOperated = true;
                                    }

                                    //if (Polynomials[j + 1].PolynomialOperation == 4)
                                    //{
                                    //    newPolynomials[0] = Divider.Divide(Polynomials[j + 1], newPolynomials[0]);
                                    //    Polynomials[j + 1].HasBeenOperated = true;
                                    //}

                                    j++;
                                }
                            }
                            catch ( ArgumentOutOfRangeException) { }

                            break;
                        }
                    }

                }

                foreach (Polynomial p in Polynomials)
                {
                    if (!p.HasBeenOperated)
                        newPolynomials.Add(p);
                }

                endExpression = new Expression(newPolynomials);
                Console.WriteLine(endExpression.ReturnString());
                //var dummytext = Console.ReadLine();
            } while (endExpression.ReturnString() != tempExpression.ReturnString());

            Console.WriteLine("End of MD");
            return endExpression;
        }

        static Expression AS(Expression e)
        {
            var endExpression = e;
            Expression tempExpression;
            do
            {
                tempExpression = endExpression;
                var Polynomials = tempExpression.Polynomials;

                var newTerms = new List<Term>();

                for (int i = Polynomials.Count - 1; i > 0; i--)
                {
                    if (Polynomials[i].PolynomialOperation == 1)
                    {
                        Polynomial p = Polynomials[i];
                        Polynomial po = Polynomials[i - 1];

                        foreach (Term t in p.Terms)
                            newTerms.Add(t);
                        foreach (Term t in po.Terms)
                            newTerms.Add(t);
                    }
                }

                if (Polynomials.Count > 1)
                    endExpression = new Expression(new List<Polynomial>() { new Polynomial(newTerms, 1, 1) });

                Console.WriteLine(endExpression.ReturnString());

            } while (endExpression.ReturnString() != tempExpression.ReturnString());

            endExpression.Polynomials[0].NullOperation();
            Console.WriteLine("End of AS");
            return endExpression;
        }
    }
}

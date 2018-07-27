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
            //var mdExpression = MD(peExpression);
            var endExpression = AS(peExpression);
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
                var editedPolynomials = new Dictionary<int, Polynomial>();
                var oldPolynomials = new List<Polynomial>();
                var reconstructedPolynomialList = new List<Polynomial>();

                for (int i = 0; i < tempExpression.Polynomials.Count; i++)
                {
                    Polynomial p = tempExpression.Polynomials[i];
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

                foreach (Polynomial p in tempExpression.Polynomials)
                {
                    if (!p.HasBeenOperated)
                        oldPolynomials.Add(p);
                }

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

        //static Expression MD(Expression e)
        //{
        //    var endExpression = e;
        //    Expression tempExpression;
        //    do
        //    {
        //        tempExpression = endExpression;
        //        var newPolynomials = new List<Polynomial>();

        //        for (int i = 1; i < tempExpression.Polynomials.Count; i++)
        //        {
        //            if (tempExpression.Polynomials[i].PolynomialOperation == 4)
        //            {
        //                if (Verifier.VerifyDivide(tempExpression.Polynomials[i], tempExpression.Polynomials[i - 1]))
        //                {
        //                    int j = i;
        //                    newPolynomials.Add(Divider.Divide(tempExpression.Polynomials[i], tempExpression.Polynomials[i - 1])); //TODO: Change tempExpression.Polynomials[0] to a more friendly name
        //                    tempExpression.Polynomials[i].HasBeenOperated = true;
        //                    tempExpression.Polynomials[i - 1].HasBeenOperated = true;
        //                    while (tempExpression.Polynomials[j + 1].PolynomialOperation == 3 || tempExpression.Polynomials[j + 1].PolynomialOperation == 4)
        //                    {
        //                        if (tempExpression.Polynomials[j + 1].PolynomialOperation == 3)
        //                        {
        //                            newPolynomials[0] = Multiplier.Multiply(tempExpression.Polynomials[j + 1], newPolynomials[0]);
        //                            tempExpression.Polynomials[j + 1].HasBeenOperated = true;
        //                        }

        //                        if (tempExpression.Polynomials[j + 1].PolynomialOperation == 4)
        //                        {
        //                            newPolynomials[0] = Divider.Divide(tempExpression.Polynomials[j + 1], newPolynomials[0]);
        //                            tempExpression.Polynomials[j + 1].HasBeenOperated = true;
        //                        }

        //                        j++;
        //                    }

        //                    break;
        //                }
        //            }

        //            if (tempExpression.Polynomials[i].PolynomialOperation == 3)
        //            {
        //                if (Verifier.VerifyMultiply(tempExpression.Polynomials[i], tempExpression.Polynomials[i - 1]))
        //                {
        //                    int j = i;
        //                    newPolynomials.Add(Multiplier.Multiply(tempExpression.Polynomials[i], tempExpression.Polynomials[i - 1]));
        //                    tempExpression.Polynomials[i].HasBeenOperated = true;
        //                    tempExpression.Polynomials[i - 1].HasBeenOperated = true;
        //                    while (tempExpression.Polynomials[j + 1].PolynomialOperation == 3 || tempExpression.Polynomials[j + 1].PolynomialOperation == 4)
        //                    {
        //                        if (tempExpression.Polynomials[j + 1].PolynomialOperation == 3)
        //                        {
        //                            newPolynomials[0] = Multiplier.Multiply(tempExpression.Polynomials[j + 1], newPolynomials[0]);
        //                            tempExpression.Polynomials[j + 1].HasBeenOperated = true;
        //                        }

        //                        if (tempExpression.Polynomials[j + 1].PolynomialOperation == 4)
        //                        {
        //                            newPolynomials[0] = Divider.Divide(tempExpression.Polynomials[j + 1], newPolynomials[0]);
        //                            tempExpression.Polynomials[j + 1].HasBeenOperated = true;
        //                        }

        //                        j++;
        //                    }

        //                    break;
        //                }
        //            }

        //        }

        //        foreach (Polynomial p in tempExpression.Polynomials)
        //        {
        //            if (!p.HasBeenOperated)
        //                newPolynomials.Add(p);
        //        }

        //        endExpression = new Expression(newPolynomials);
        //        Console.WriteLine(endExpression.ReturnString());
        //        //var dummytext = Console.ReadLine();
        //    } while (endExpression.ReturnString() != tempExpression.ReturnString());

        //    Console.WriteLine("End of MD");
        //    return endExpression;
        //}

        static Expression AS(Expression e)
        {
            var endExpression = e;
            Expression tempExpression;
            do
            {
                tempExpression = endExpression;

                var newTerms = new List<Term>();

                for (int i = tempExpression.Polynomials.Count - 1; i > 0; i--)
                {
                    if (tempExpression.Polynomials[i].PolynomialOperation == 1)
                    {
                        Polynomial p = tempExpression.Polynomials[i];
                        Polynomial po = tempExpression.Polynomials[i - 1];

                        foreach (Term t in p.Terms)
                            newTerms.Add(t);
                        foreach (Term t in po.Terms)
                            newTerms.Add(t);
                    }
                }

                //foreach (Polynomial p in tempExpression.Polynomials)
                //{
                //    if (!p.HasBeenOperated)
                //        newPolynomials.Add(p);
                //}
                if (tempExpression.Polynomials.Count > 1)
                    endExpression = new Expression(new List<Polynomial>() { new Polynomial(newTerms, 1, 1) });

                Console.WriteLine(endExpression.ReturnString());

            } while (endExpression.ReturnString() != tempExpression.ReturnString());

            endExpression.Polynomials[0].NullOperation();
            Console.WriteLine("End of AS");
            return endExpression;
        }
    }
}

using System;
using System.Collections.Generic;
using ComputerAlgebraSystem.Operations;
using ComputerAlgebraSystem.Setup;

namespace ComputerAlgebraSystem.DoingStuff
{
    class PolynomialOperator
    {
        public Polynomial Automatic_Operation_On_Polynomials(Polynomial polynomial)
        {
            foreach (Term term in polynomial.Terms)
            {
                term.NullToAdd();
                term.SubToNegAdd();
            }
            var pePolynomial = PE(polynomial);
            var mdPolynomial = MD(pePolynomial);
            var endPolynomial = AS(mdPolynomial);
            Console.WriteLine("End");
            return endPolynomial;
        }

        static Polynomial PE(Polynomial polynomial)
        {
            var endPolynomial = polynomial;
            Polynomial tempPolynomial;
            do
            {
                tempPolynomial = endPolynomial;
                var Terms = tempPolynomial.Terms;
                var editedTerms = new Dictionary<int, Term>();
                var oldTerms = new List<Term>();
                var reconstructedTermList = new List<Term>();

                for(int i = 0; i < Terms.Count; i++)
                {
                    Term t = Terms[i];
                    if (t.Power > 1)
                    {
                        editedTerms.Add(i, Raiser.Raise(t, t.Power));
                        t.HasBeenOperated = true;
                        break;
                    }
                    if (t.Power == 0)
                    {
                        editedTerms.Add(i, new Term());
                        t.HasBeenOperated = true;
                        break;
                    }
                }

                foreach (Term t in Terms)
                {
                    if (!t.HasBeenOperated)
                        oldTerms.Add(t);
                }

                /* This bit is different from the other methods so raising a term doesn't mess with the order of the terms.
                 * */
                int numberOfRaisedAdded = 0;

                for (int i = 0; i < oldTerms.Count + numberOfRaisedAdded; i++)
                {
                    if (editedTerms.ContainsKey(i))
                    {
                        reconstructedTermList.Add(editedTerms[i]);
                        numberOfRaisedAdded++;
                    }
                    else
                    {
                        reconstructedTermList.Add(oldTerms[i - numberOfRaisedAdded]);
                    }
                }

                endPolynomial = new Polynomial(reconstructedTermList, polynomial.PolynomialOperation, polynomial.Power);
                Console.WriteLine(endPolynomial.ReturnString());
            } while (tempPolynomial.ReturnString() != endPolynomial.ReturnString());

            Console.WriteLine("End of PE");
            return endPolynomial;
        }

        static Polynomial MD(Polynomial polynomial)
        {
            var endPolynomial = polynomial;
            Polynomial tempPolynomial;
            do
            {
                tempPolynomial = endPolynomial;
                var newTerms = new List<Term>();
                var Terms = tempPolynomial.Terms;

                for (int i = 1; i < Terms.Count; i++)
                {
                    if (Terms[i].TermOperation == 4)
                    {
                        if (Verifier.VerifyDivide(Terms[i], Terms[i - 1]))
                        {
                            
                            int j = i;
                            newTerms.Add(Divider.Divide(Terms[i], Terms[i - 1]));
                            Terms[i].HasBeenOperated = true;
                            Terms[i - 1].HasBeenOperated = true;
                            try
                            {
                                while (Terms[j + 1].TermOperation == 3 || Terms[j + 1].TermOperation == 4)
                                {
                                    if (Terms[j + 1].TermOperation == 3)
                                    {
                                        newTerms[0] = Multiplier.Multiply(Terms[j + 1], newTerms[0]);
                                        Terms[j + 1].HasBeenOperated = true;
                                    }

                                    if (Terms[j + 1].TermOperation == 4)
                                    {
                                        newTerms[0] = Divider.Divide(Terms[j + 1], newTerms[0]);
                                        Terms[j + 1].HasBeenOperated = true;
                                    }

                                    j++;
                                }
                            }
                            catch (ArgumentOutOfRangeException) { }

                            break;
                        }
                    }

                    if (Terms[i].TermOperation == 3)
                    {
                        if (Verifier.VerifyMultiply(Terms[i], Terms[i - 1]))
                        {
                            int j = i;
                            newTerms.Add(Multiplier.Multiply(Terms[i], Terms[i - 1]));
                            Terms[i].HasBeenOperated = true;
                            Terms[i - 1].HasBeenOperated = true;
                            try
                            {
                                while (Terms[j + 1].TermOperation == 3 || Terms[j + 1].TermOperation == 4)
                                {
                                    if (Terms[j + 1].TermOperation == 3)
                                    {
                                        newTerms[0] = Multiplier.Multiply(Terms[j + 1], newTerms[0]);
                                        Terms[j + 1].HasBeenOperated = true;
                                    }

                                    if (Terms[j + 1].TermOperation == 4)
                                    {
                                        newTerms[0] = Divider.Divide(Terms[j + 1], newTerms[0]);
                                        Terms[j + 1].HasBeenOperated = true;
                                    }

                                    j++;
                                }
                            }
                            catch (ArgumentOutOfRangeException) { }

                            break;
                        }
                    }
                }

                foreach (Term t in Terms)
                {
                    if (!t.HasBeenOperated)
                        newTerms.Add(t);
                }

                endPolynomial = new Polynomial(newTerms, polynomial.PolynomialOperation, polynomial.Power);
                Console.WriteLine(endPolynomial.ReturnString());
                //var dummytext = Console.ReadLine();
            } while (endPolynomial.ReturnString() != tempPolynomial.ReturnString());

            Console.WriteLine("End of MD");
            return endPolynomial;
        }

        static Polynomial AS(Polynomial polynomial)
        {
            var endPolynomial = polynomial;
            Polynomial tempPolynomial;
            do
            {
                tempPolynomial = endPolynomial;
                var Terms = tempPolynomial.Terms;

                var newTerms = new List<Term>();

                for (int i = Terms.Count - 1; i > 0; i--)
                {
                    if (Terms[i].TermOperation == 1)
                    {
                        Term t = Terms[i];
                        foreach (Term te in Terms)
                        {
                            if (!te.HasBeenOperated)
                            {
                                var likeTerms = new List<Term>() { };
                                if (te.Var.IsEqual(t.Var))// && !te.Equals(t) && t.HasBeenOperated == false)
                                {
                                    if (!te.Equals(t))
                                    {
                                        if (t.HasBeenOperated == false)
                                        {
                                            likeTerms.Add(t);
                                            t.HasBeenOperated = true;
                                            te.HasBeenOperated = true;
                                        }
                                    }

                                }

                                Term addedTerm = te;

                                foreach (Term term in likeTerms)
                                {
                                    addedTerm = Adder.Add(addedTerm, term);
                                }

                                if (likeTerms.Count > 0)
                                {
                                    newTerms.Add(addedTerm);
                                    break;
                                }
                            }
                        }
                    }
                }

                foreach (Term t in Terms)
                {
                    if (!t.HasBeenOperated)
                        newTerms.Add(t);
                }
                endPolynomial = new Polynomial(newTerms, polynomial.PolynomialOperation, polynomial.Power);
                Console.WriteLine(endPolynomial.ReturnString());

            } while (endPolynomial.ReturnString() != tempPolynomial.ReturnString());

            Console.WriteLine("End of AS");
            endPolynomial.Sort();
            return endPolynomial;
        }
    }
}

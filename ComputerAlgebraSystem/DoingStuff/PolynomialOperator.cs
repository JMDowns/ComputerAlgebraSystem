using System;
using System.Collections.Generic;
using ComputerAlgebraSystem.Operations;
using ComputerAlgebraSystem.Setup;

namespace ComputerAlgebraSystem.DoingStuff
{
    class PolynomialOperator
    {
        public Polynomial PolynomialOperate(Polynomial polynomial)
        {
            foreach (Term term in polynomial.Terms)
            {
                term.NullToAdd();
                term.SubToNegAdd(term);
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
                var editedTerms = new Dictionary<int, Term>();
                tempPolynomial = endPolynomial;
                var oldTerms = new List<Term>();
                var reconstructedTermList = new List<Term>();

                for(int i = 0; i < tempPolynomial.Terms.Count; i++)
                {
                    Term t = tempPolynomial.Terms[i];
                    if (t.Power > 1)
                    {
                        editedTerms.Add(i, Raiser.Raise(t, t.Power));
                        t.HasBeenOperated = true;
                        break;
                    }
                }

                foreach (Term t in tempPolynomial.Terms)
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

                for (int i = 1; i < tempPolynomial.Terms.Count; i++)
                {
                    if (tempPolynomial.Terms[i].TermOperation == 4)
                    {
                        if (Verifier.VerifyDivide(tempPolynomial.Terms[i], tempPolynomial.Terms[i - 1]))
                        {
                            int j = i;
                            newTerms.Add(Divider.Divide(tempPolynomial.Terms[i], tempPolynomial.Terms[i - 1]));
                            tempPolynomial.Terms[i].HasBeenOperated = true;
                            tempPolynomial.Terms[i - 1].HasBeenOperated = true;
                            while (tempPolynomial.Terms[j + 1].TermOperation == 3 || tempPolynomial.Terms[j + 1].TermOperation == 4)
                            {
                                if (tempPolynomial.Terms[j + 1].TermOperation == 3)
                                {
                                    newTerms[0] = Multiplier.Multiply(tempPolynomial.Terms[j + 1], newTerms[0]);
                                    tempPolynomial.Terms[j + 1].HasBeenOperated = true;
                                }

                                if (tempPolynomial.Terms[j + 1].TermOperation == 4)
                                {
                                    newTerms[0] = Divider.Divide(tempPolynomial.Terms[j + 1], newTerms[0]);
                                    tempPolynomial.Terms[j + 1].HasBeenOperated = true;
                                }

                                j++;
                            }

                            break;
                        }
                    }

                    if (tempPolynomial.Terms[i].TermOperation == 3)
                    {
                        if (Verifier.VerifyMultiply(tempPolynomial.Terms[i], tempPolynomial.Terms[i - 1]))
                        {
                            int j = i;
                            newTerms.Add(Multiplier.Multiply(tempPolynomial.Terms[i], tempPolynomial.Terms[i - 1]));
                            tempPolynomial.Terms[i].HasBeenOperated = true;
                            tempPolynomial.Terms[i - 1].HasBeenOperated = true;
                            while (tempPolynomial.Terms[j + 1].TermOperation == 3 || tempPolynomial.Terms[j + 1].TermOperation == 4)
                            {
                                if (tempPolynomial.Terms[j + 1].TermOperation == 3)
                                {
                                    newTerms[0] = Multiplier.Multiply(tempPolynomial.Terms[j + 1], newTerms[0]);
                                    tempPolynomial.Terms[j + 1].HasBeenOperated = true;
                                }

                                if (tempPolynomial.Terms[j + 1].TermOperation == 4)
                                {
                                    newTerms[0] = Divider.Divide(tempPolynomial.Terms[j + 1], newTerms[0]);
                                    tempPolynomial.Terms[j + 1].HasBeenOperated = true;
                                }

                                j++;
                            }

                            break;
                        }
                    }

                }

                foreach (Term t in tempPolynomial.Terms)
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
                /*foreach loop is added because when a term has no like terms, it skips over the foreach 
                 *loop at the end of the for loop in the adding (TermOperation==1) part. In doing so, addedTerm's
                 *HasBeenOperated never resets to false (Adder.Add returns a Term with the HBO set to false).
                 *When HBO is set to True, the next time the loop iterates it won't add the term into the new polynomial, and thus
                 *will make the sole term disappear.
                 **/
                foreach (Term term in tempPolynomial.Terms)
                    term.HasBeenOperated = false;

                var newTerms = new List<Term>();

                for (int i = tempPolynomial.Terms.Count - 1; i > 0; i--)
                {
                    if (tempPolynomial.Terms[i].TermOperation == 2)
                    {
                        newTerms.Add(new Term(
                            tempPolynomial.Terms[i].Var,
                            -1 * tempPolynomial.Terms[i].Coefficient,
                            1,
                            tempPolynomial.Terms[i].Power));
                        tempPolynomial.Terms[i].HasBeenOperated = true;
                        break;
                    }

                    if (tempPolynomial.Terms[i].TermOperation == 1)
                    {
                        Term t = tempPolynomial.Terms[i];
                        foreach (Term te in tempPolynomial.Terms)
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
                                        }
                                    }

                                }

                                Term addedTerm = te;
                                te.HasBeenOperated = true;

                                foreach (Term term in likeTerms)
                                {
                                    addedTerm = Adder.Add(addedTerm, term);
                                }

                                newTerms.Add(addedTerm);
                                break;
                            }
                        }
                        break;
                    }
                }

                foreach (Term t in tempPolynomial.Terms)
                {
                    if (!t.HasBeenOperated)
                        newTerms.Add(t);
                }
                endPolynomial = new Polynomial(newTerms, polynomial.PolynomialOperation, polynomial.Power);
                Console.WriteLine(endPolynomial.ReturnString());

            } while (endPolynomial.ReturnString() != tempPolynomial.ReturnString());

            endPolynomial.Terms[0].NullOperation();
            Console.WriteLine("End of AS");
            return endPolynomial;
        }
    }
}

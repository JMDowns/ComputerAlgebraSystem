using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAlgebraSystem.Operations
{
    static class Adder
    {
        static public Term Add(Term t1, Term t2)
        {
            var addedCoefficient = t1.Coefficient + t2.Coefficient;
            return new Term(t1.Var, addedCoefficient, 1, 1);
        }

        static public Polynomial Add(Polynomial p1, Polynomial p2)
        {
            var newTerms = new List<Term>();
            foreach(Term t1 in p1.Terms)
            {
                foreach(Term t2 in p2.Terms)
                {
                    if ((t1.Var.VarPower.Keys == t2.Var.VarPower.Keys) && (t1.Var.VarPower.Values == t2.Var.VarPower.Values))
                    {
                        newTerms.Add(new Term(
                            new Variable(t1.Var.VarPower),
                            t1.Coefficient + t2.Coefficient, 
                            1, 1));
                        t1.HasBeenOperated = true;
                        t2.HasBeenOperated = true;
                    }
                }
            }

            foreach(Term t in p1.Terms)
            {
                if (!t.HasBeenOperated)
                    newTerms.Add(t);
            }
            foreach (Term t in p2.Terms)
            {
                if (!t.HasBeenOperated)
                    newTerms.Add(t);
            }

            return new Polynomial(newTerms, 1, 1);
        }
    }
}
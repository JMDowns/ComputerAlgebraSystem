using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAlgebraSystem.Operations
{
    static class Adder
    {
        static public Term Add(Term term1, Term term2)
        {
            var addedCoefficient = term1.Coefficient + term2.Coefficient;
            return new Term(term1.Var, addedCoefficient, 1, 1);
        }

        static public Polynomial Add(Polynomial polynomial1, Polynomial polynomial2)
        {
            var newTerms = new List<Term>();
            foreach(Term term in polynomial1.Terms)
            {
                foreach(Term term2 in polynomial2.Terms)
                {
                    if ((term.Var.VarPower.Keys == term2.Var.VarPower.Keys) && (term.Var.VarPower.Values == term2.Var.VarPower.Values))
                    {
                        newTerms.Add(new Term(
                            new Variable(term.Var.VarPower),
                            term.Coefficient + term2.Coefficient, 
                            1, 1));
                        term.HasBeenAdded = true;
                        term2.HasBeenAdded = true;
                    }
                }
            }

            foreach(Term term in polynomial1.Terms)
            {
                if (term.HasBeenAdded == false)
                    newTerms.Add(term);
            }
            foreach (Term term in polynomial2.Terms)
            {
                if (term.HasBeenAdded == false)
                    newTerms.Add(term);
            }

            return new Polynomial(newTerms, 1, 1);
        }
    }
}
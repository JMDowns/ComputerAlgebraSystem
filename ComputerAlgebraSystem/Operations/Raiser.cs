using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAlgebraSystem.Operations
{
    static class Raiser
    {
        static public Term Raise(Term term, int power)
        {
            var raisedCoefficient = (float)Math.Pow(term.Coefficient, power);
            var newVariable = new Dictionary<char, float>();
            var termOperationSwitch = 1;

            foreach (KeyValuePair<char, float> varPower in term.Var.VarPower)
            {
                newVariable.Add(varPower.Key, varPower.Value * power);
            }

            return new Term(new Variable(newVariable), raisedCoefficient, termOperationSwitch, 1);
        }

        static public Polynomial Raise(Polynomial polynomial, int power)
        {
            var recursivePolynomial = polynomial;
            for (int i = 0; i < power; i++)
            {
                recursivePolynomial = Distributor.Distribute(recursivePolynomial, polynomial);
            }
            return recursivePolynomial;
        }
    }
}

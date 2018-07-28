using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAlgebraSystem.Operations
{
    static class Raiser
    {
        static public Term Raise(Term t, int power)
        {
            var raisedCoefficient = (float)Math.Pow(t.Coefficient, power);
            var newVariable = new Dictionary<char, float>();
            var termOperation = 1;

            foreach (KeyValuePair<char, float> varPower in t.Var.VarPower)
            {
                newVariable.Add(varPower.Key, varPower.Value * power);
            }

            return new Term(new Variable(newVariable), raisedCoefficient, termOperation, 1);
        }

        static public Polynomial Raise(Polynomial p, int power)
        {
            var recursivePolynomial = p;
            for (int i = 1; i < power; i++)
            {
                recursivePolynomial = Distributor.Distribute(recursivePolynomial, p);
            }
            return recursivePolynomial;
        }
    }
}

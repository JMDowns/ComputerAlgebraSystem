using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAlgebraSystem.Operations
{
    static class Multiplier
    {
        static public Term Multiply(Term t1, Term t2)
        {
            float multipliedCoefficient = t1.Coefficient * t2.Coefficient;
            var newVariables = new Dictionary<char, float>(t1.Var.VarPower);
            var termOperation = 1;
            var power = 1;
            
            foreach(KeyValuePair<char, float> term2Vars in t2.Var.VarPower)
            {
                if (t1.Var.VarPower.ContainsKey(term2Vars.Key))
                {
                    newVariables[term2Vars.Key] += term2Vars.Value;
                }
                else
                {
                    newVariables.Add(term2Vars.Key, term2Vars.Value);
                }
            }

            return new Term(new Variable(newVariables), multipliedCoefficient, termOperation, power);
        }

        static public Polynomial Multiply(Polynomial p1, Polynomial p2)
        {
            return Distributor.Distribute(p1, p2);
        }
    }
}

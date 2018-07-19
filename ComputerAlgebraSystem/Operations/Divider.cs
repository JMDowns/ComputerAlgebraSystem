using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAlgebraSystem.Operations
{
    static class Divider
    {
        static public Term Divide(Term t1, Term t2)
        {
            float dividedCoefficient = t1.Coefficient / t2.Coefficient;
            var newVariables = new Dictionary<char, float>(t1.Var.VarPower);
            var termOperation = 1;
            var power = 1;

            foreach (KeyValuePair<char, float> term2Vars in t2.Var.VarPower)
            {
                if (t1.Var.VarPower.ContainsKey(term2Vars.Key))
                {
                    newVariables[term2Vars.Key] -= term2Vars.Value;
                }
                else
                {
                    newVariables.Add(term2Vars.Key, -1 * term2Vars.Value);
                }
            }

            return new Term(new Variable(newVariables), dividedCoefficient, termOperation, power);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAlgebraSystem.Operations
{
    static class Divider
    {
        static public Term Divide(Term term1, Term term2)
        {
            float dividedCoefficient = term1.Coefficient / term2.Coefficient;
            var newVariables = new Dictionary<char, float>(term1.Var.VarPower);
            var termOperationSwitch = 1;
            var power = 1;

            foreach (KeyValuePair<char, float> term2Vars in term2.Var.VarPower)
            {
                if (term1.Var.VarPower.ContainsKey(term2Vars.Key))
                {
                    newVariables[term2Vars.Key] -= term2Vars.Value;
                }
                else
                {
                    newVariables.Add(term2Vars.Key, -1 * term2Vars.Value);
                }
            }

            return new Term(new Variable(newVariables), dividedCoefficient, termOperationSwitch, power);
        }
    }
}

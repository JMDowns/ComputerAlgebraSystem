using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAlgebraSystem
{
    public class Variable
    {
        public Dictionary<char, float> VarPower { get; private set; }

        public Variable(List<char> var, List<float> powers)
        {
            VarPower = new Dictionary<char, float>();
            {
                for (int i = 0; i < var.Count; i++)
                {
                    VarPower.Add(var[i], powers[i]);
                }
            }
        }

        public Variable(Dictionary<char, float> varPower)
        {
            VarPower = varPower;
        }

        public void Print()
        {
            foreach(KeyValuePair<char, float> variable in VarPower)
            {
                if (variable.Value != 0)
                {
                    Console.Write(variable.Key + "^" + variable.Value);
                }
            }
        }
    }
}

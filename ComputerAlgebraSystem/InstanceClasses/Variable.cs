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

        public Variable()
        {
            VarPower = new Dictionary<char, float>() { { 'x', 0 } };
        }

        public string ReturnString()
        {
            var s = "";
            foreach(KeyValuePair<char, float> variable in VarPower)
            {
                if (variable.Value != 0)
                {
                     s += variable.Key + "^" + variable.Value;
                }
            }

            return s;
        }

        public bool IsEqual(Variable v)
        {
            foreach(KeyValuePair<char, float> pair in v.VarPower)
            {
                if (pair.Value != 0)
                {
                    if (!VarPower.Contains(pair))
                        return false;
                }
            }

            foreach (KeyValuePair<char, float> pair in VarPower)
            {
                if (pair.Value != 0)
                {
                    if (!v.VarPower.Contains(pair))
                        return false;
                }
            }

            return true;
        }

        public int ReturnPower()
        {
            var power = 0;
            foreach(int Value in VarPower.Values)
            {
                power += Value;
            }
            return power;
        }
    }
}

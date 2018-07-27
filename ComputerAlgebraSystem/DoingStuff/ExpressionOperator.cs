using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAlgebraSystem.DoingStuff
{
    class ExpressionOperator
    {
        public List<Polynomial> Automatic_Operation_On_Polynomial_List (List<Polynomial> pList)
        {
            foreach (Polynomial p in pList)
            {
                p.NullToAdd();
                p.SubToNegAdd();
            }

            return pList;
        }
}
}

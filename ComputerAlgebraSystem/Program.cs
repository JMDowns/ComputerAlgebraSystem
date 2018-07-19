using ComputerAlgebraSystem.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAlgebraSystem
{
    //TermOperationSwitch - An int denoting what operation is performed on the term or polynomial.
    //0 = Null (Reserved for term in front)
    //1 = Add
    //2 = Subtract
    //3 = Multiply
    //4 = Divide

    class Program
    {
        static void Main(string[] args)
        {
            Overseer overseer = new Overseer();
            overseer.Setup();
            overseer.Expression.Print();
            var mTerm = Multiplier.Multiply(overseer.Expression.PolynomialList[0].Terms[0], overseer.Expression.PolynomialList[0].Terms[1]);
            var dTerm = Divider.Divide(overseer.Expression.PolynomialList[0].Terms[0], overseer.Expression.PolynomialList[0].Terms[1]);
            var rPolynomial = Multiplier.Multiply(overseer.Expression.PolynomialList[0], overseer.Expression.PolynomialList[0]);
            var aPolynomial = Adder.Add(overseer.Expression.PolynomialList[0], overseer.Expression.PolynomialList[0]);
            mTerm.Print();
            dTerm.Print();
            rPolynomial.Print();
            aPolynomial.Print();
        }
    }
}

using ComputerAlgebraSystem.Operations;
using ComputerAlgebraSystem.Setup;
using ComputerAlgebraSystem.DoingStuff;
using System;

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
            Expression printedExpression;
            Overseer ov = new Overseer();
            Operator op = new Operator();
            ov.Setup();
            Console.WriteLine(ov.Expression.ReturnString());
            printedExpression = op.Analyze_And_Simplify(ov.Expression);
            Console.WriteLine(printedExpression.ReturnString());
        }
    }
}

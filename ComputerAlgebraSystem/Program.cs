﻿using ComputerAlgebraSystem.Operations;
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
    //TODO: Change TermOperation to an enum

    class Program
    {
        static void Main(string[] args)
        {
            Expression printedExpression;
            Overseer ov = new Overseer();
            Operator op = new Operator();
            ov.Setup();
            Console.WriteLine(ov.Expression.ReturnString()); 
            //var mTerm = Multiplier.Multiply(overseer.Expression.Polynomials[0].Terms[0], overseer.Expression.Polynomials[0].Terms[1]);
            //var dTerm = Divider.Divide(overseer.Expression.Polynomials[0].Terms[0], overseer.Expression.Polynomials[0].Terms[1]);
            //var rPolynomial = Multiplier.Multiply(overseer.Expression.Polynomials[0], overseer.Expression.Polynomials[0]);
            //var aPolynomial = Adder.Add(overseer.Expression.Polynomials[0], overseer.Expression.Polynomials[0]);
            //mTerm.Print();
            //dTerm.Print();
            //rPolynomial.Print();
            //aPolynomial.Print();
            printedExpression = op.Analyze_And_Simplify(ov.Expression);
            Console.WriteLine(printedExpression.ReturnString());
        }
    }
}

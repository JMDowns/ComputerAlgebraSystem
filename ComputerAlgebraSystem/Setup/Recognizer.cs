using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ComputerAlgebraSystem
{
    static class Recognizer
    {
        static public Expression Recognize(string verifiedInput)
        {
            //var findsPolynomials = new Regex("\(");
            //var listOfPolynomials = new List<Polynomial>();
            var listOfTerms = new List<Term>();
            Term minusTenXSquared = new Term(new Variable(new List<char>() { 'x' }, new List<float>() { 2 }), 10, 2, 1);
            Term sevenYSquared = new Term(new Variable(new List<char>() { 'y' }, new List<float>() { 2 }), 7, 0, 1);
            listOfTerms.Add(sevenYSquared);
            listOfTerms.Add(minusTenXSquared);
            Polynomial sevenYSquaredMinusTenXSquared = new Polynomial(listOfTerms, 0, 1);
            var listOfPolynomials = new List<Polynomial>() { sevenYSquaredMinusTenXSquared };
            Expression esevenYSquaredMinusTenXSquared = new Expression(listOfPolynomials);
            return esevenYSquaredMinusTenXSquared;
        }
    }
}

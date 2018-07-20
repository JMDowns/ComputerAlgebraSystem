using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ComputerAlgebraSystem.Setup
{
    static class Recognizer
    {
        static public Expression Recognize(string verifiedInput)
        {
            //var findsPolynomials = new Regex("\(");
            //var listOfPolynomials = new List<Polynomial>();
            var listOfTerms = new List<Term>();
            Term dividedByTenXSquared = new Term(new Variable(new List<char>() { 'x' }, new List<float>() { 2 }), 10, 4, 1);
            Term multipliedByTwentyXSquared = new Term(new Variable(new List<char>() { 'x' }, new List<float>() { 2 }), 20, 3, 1);
            Term sevenYSquared = new Term(new Variable(new List<char>() { 'y' }, new List<float>() { 2 }), 7, 0, 1);
            Term MinusSevenYSquared = new Term(new Variable(new List<char>() { 'y' }, new List<float>() { 2 }), 7, 2, 1);
            Term MinusEightYSquared = new Term(new Variable(new List<char>() { 'y' }, new List<float>() { 2 }), 8, 2, 1);
            Term PlusSevenXSquared = new Term(new Variable(new List<char>() { 'x' }, new List<float>() { 2 }), 7, 1, 1);
            Term TimesTwentyZCubed = new Term(new Variable(new List<char>() { 'z' }, new List<float>() { 3 }), 20, 3, 1);
            Term PlusSevenXSquaredZCubed = new Term(new Variable(new List<char>() { 'x', 'z' }, new List<float>() { 2, 3 }), 7, 1, 1);
            listOfTerms.Add(sevenYSquared);
            listOfTerms.Add(dividedByTenXSquared);
            listOfTerms.Add(MinusSevenYSquared);

            listOfTerms.Add(MinusEightYSquared);
            listOfTerms.Add(PlusSevenXSquared);
            listOfTerms.Add(multipliedByTwentyXSquared);
            listOfTerms.Add(TimesTwentyZCubed);
            listOfTerms.Add(PlusSevenXSquaredZCubed);

            var alistOfTerms = new List<Term>();
            Term adividedByTenXSquared = new Term(new Variable(new List<char>() { 'x' }, new List<float>() { 2 }), 10, 4, 1);
            Term amultipliedByTwentyXSquared = new Term(new Variable(new List<char>() { 'x' }, new List<float>() { 2 }), 20, 3, 1);
            Term asevenYSquared = new Term(new Variable(new List<char>() { 'y' }, new List<float>() { 2 }), 7, 0, 1);
            Term aMinusSevenYSquaredSquared = new Term(new Variable(new List<char>() { 'y' }, new List<float>() { 2 }), 7, 2, 2);
            Term aPlusSevenXSquared = new Term(new Variable(new List<char>() { 'x' }, new List<float>() { 2 }), 7, 1, 1);
            Term aTimesTwentyZCubed = new Term(new Variable(new List<char>() { 'z' }, new List<float>() { 3 }), 20, 3, 1);
            Term aPlusSevenXSquaredZCubed = new Term(new Variable(new List<char>() { 'x', 'z' }, new List<float>() { 2, 3 }), 7, 1, 1);
            alistOfTerms.Add(asevenYSquared);
            alistOfTerms.Add(amultipliedByTwentyXSquared);
            alistOfTerms.Add(adividedByTenXSquared);
            alistOfTerms.Add(aMinusSevenYSquaredSquared);
            alistOfTerms.Add(aPlusSevenXSquared);
            alistOfTerms.Add(aTimesTwentyZCubed);
            alistOfTerms.Add(aPlusSevenXSquaredZCubed);

            Polynomial original = new Polynomial(listOfTerms, 0, 1);
            Polynomial copy = new Polynomial(alistOfTerms, 1, 1);
            var listOfPolynomials = new List<Polynomial>() { original };
            Expression esevenYSquaredDividedByTenXSquaredMultipliedByTwentyXSquared = new Expression(listOfPolynomials);
            return esevenYSquaredDividedByTenXSquaredMultipliedByTwentyXSquared;
        }
    }
}

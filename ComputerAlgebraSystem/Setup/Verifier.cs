using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAlgebraSystem.Setup
{
    static class Verifier //TODO: Actually make Verify Methods or Decide if they're not needed
    {
        //Make Sure to add in VerifiedAdd, VerifiedSubtract, and so on that check if operation is valid before performing it
        static public string Verify(string input)
        {
            string verifiedInput = "7x^2-10x^2";
            return verifiedInput;
        }

        static public bool VerifyMultiply(Term term1, Term term2)
        {
            return true;
        }

        static public bool VerifyMultiply(Polynomial polynomial1, Polynomial polynomial2)
        {
            return true;
        }

        static public bool VerifyDivide(Term term1, Term term2)
        {
            return true;
        }

        static public bool VerifyDivide(Polynomial polynomial1, Polynomial polynomial2)
        {
            return true;
        }

        static public bool VerifyAdd(Term term1, Term term2)
        {
            return true;
        }

        static public bool VerifyAdd(Polynomial polynomial1, Polynomial polynomial2)
        {
            return true;
        }

        static public bool VerifySubtract(Term term1, Term term2)
        {
            return true;
        }

        static public bool VerifySubtract(Polynomial polynomial1, Polynomial polynomial2)
        {
            return true;
        }
    }
}

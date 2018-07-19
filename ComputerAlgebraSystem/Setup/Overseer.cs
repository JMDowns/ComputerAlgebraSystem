using ComputerAlgebraSystem.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAlgebraSystem.Setup
{
    class Overseer
    {
        public Expression Expression { get; private set; }

        public void Setup()
        {
            var input = Asker.Ask();
            var verifiedInput = Verifier.Verify(input);
            Expression = Recognizer.Recognize(verifiedInput);
        }
    }
}

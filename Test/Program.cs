using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    class Program
    {
        static StreamReader sr = new StreamReader("input.txt");

        static void Main(string[] args)
        {
            string cellsString = ReadLineWithEmptySkip();
            List<char> cells = cellsString.ToCharArray().OfType<char>().ToList();
            List<State> states = new List<State>();

            int startIndex = int.Parse(ReadLineWithEmptySkip());

            string line;
            while((line = ReadLineWithEmptySkip()) != null)
            {
                int stateId = int.Parse(line.Split(' ')[0]);
                char readSymbol = char.Parse(line.Split(' ')[1]);
                char writeSymbol = char.Parse(line.Split(' ')[2]);
                char direction = char.Parse(line.Split(' ')[3]);
                int transitionStateId = int.Parse(line.Split(' ')[4]);

                Instruction newInstruction = new Instruction()
                {
                    Change = writeSymbol,
                    IsForward = direction == 'R' ? true : false,
                    TransitionStateId = transitionStateId
                };

                if (!states.Any(s => s.Id == stateId))
                {
                    states.Add(new State()
                    {
                        Id = stateId,
                        Instructions = new Dictionary<char, Instruction>()
                        {
                            { readSymbol, newInstruction }
                        }
                    });
                }
                else
                {
                    states.First(s => s.Id == stateId)
                        .Instructions.Add(readSymbol, newInstruction);
                }
            }

            TM machine = new TM(cells, states, startIndex);

            machine.Start();

        }

        static string ReadLineWithEmptySkip()
        {
            while(true)
            {
                string line = sr.ReadLine();
                if (line != string.Empty)
                {
                    return line;
                }
            }
        }
    }
}

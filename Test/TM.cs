using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Test
{
    public class TM
    {
        private List<char> cells;
        private List<State> states;
        private int currentStateId;
        private int instructionPointer;

        public TM(List<char> cells, List<State> states, int startIndex)
        {
            this.cells = cells;
            this.states = states;
            this.currentStateId = 0; // pradine busena 0.
            this.instructionPointer = startIndex;
        }

        public void Start()
        {
            try
            {
                while (true)
                {
                    MoveInstructionPointer();
                    Console.WriteLine(string.Join(" ", cells));
                }
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Pabaiga");
            }

        }

        private void MoveInstructionPointer()
        {
            State currentState = states.First(s => s.Id == currentStateId);

            char currentSymbol = cells[instructionPointer]; // dabartinis simbolis

            char changeTo = currentState.Instructions[currentSymbol].Change;

            cells[instructionPointer] = changeTo; // keicia i nauja simboli

            if (currentState.Instructions[currentSymbol].IsForward)
            {
                instructionPointer++;
            }
            else
            {
                instructionPointer--;
            }

            currentStateId = currentState.Instructions[currentSymbol].TransitionStateId;

        }




    }
}

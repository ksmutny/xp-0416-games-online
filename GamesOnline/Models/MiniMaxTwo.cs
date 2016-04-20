using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesOnline.Models
{
    public class MiniMaxTwo<T>
    {
        private Func<T, double> evaluate;
        private Func<T, List<T>> generate;


        public MiniMaxTwo(Func<T, double> evaluate, Func<T, List<T>> generate)
        {

            this.evaluate = evaluate;
            this.generate = generate;
        }

        //https://cs.wikipedia.org/wiki/Minimax_(algoritmus)

        public Tuple<T, double> NextState(T state, int depth, bool takeMax)
        {
            Tuple<T, double> res = null;

            if (depth > 0)
            {
                var states = this.generate(state);
                var stateValues = states.Select(x => NextState(x, depth--, !takeMax)).OrderBy(x => x.Item2).ToList();

                if (stateValues.Count > 0)
                {
                    res = stateValues[takeMax ? stateValues.Count - 1 : 0];
                }
            }
            else
            {
                res = new Tuple<T, double>(state, evaluate(state));
            }

            return res;

        }
    }
}

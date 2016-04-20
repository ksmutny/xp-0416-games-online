using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamesOnline.AI
{
    public class Minimax<T>
    {
        private Func<T, double> evaluate;
        private Func<T, List<T>> generate;
        private int depth;

        public Minimax(int depth, Func<T, double> evaluate, Func<T, List<T>> generate)
        {
            this.depth = depth;
            this.evaluate = evaluate;
            this.generate = generate;
        }

        public T NextState(T state, int actDepth)
        {
            if (actDepth == 0)
            {
                
            }

            var maxState = double.MinValue;
            var states = this.generate(state);
            foreach (var item in states)
            {
                NextState(item, actDepth - 1);
            }


            //var values = states.Select(this.evaluate);
            //var maxState = states.GroupBy(s => s, s => this.evaluate(s)).Max(s => s.Key); 
            


            var val = takeMax ? values.Max() : values.Min();

            var result = states.First(x => this.evaluate(x) == val);

            return result;
        }
    }
}
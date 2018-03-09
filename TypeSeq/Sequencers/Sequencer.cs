using System;

namespace TypeSeq.Sequencers
{
    public abstract class Sequencer<T>
    {
        protected T State { get; set; }

        public Sequencer()
        {
            State = GetInitialState();
        }

        public T Next()
        {
            var next = State;
            State = GenerateNext();
            return next;
        }

        protected abstract T GenerateNext();

        protected virtual T GetInitialState()
        {
            return default(T);
        }
    }
}

namespace TypeSeq.Sequencers
{
    public class IntSequencer : Sequencer<int>, ISequencer<int>
    {
        protected override int GenerateNext()
        {
            return ++State;
        }
    }
}

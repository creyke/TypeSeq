namespace TypeSeq.Sequencers
{
    public class UIntSequencer : Sequencer<uint>, ISequencer<uint>
    {
        protected override uint GenerateNext()
        {
            return ++State;
        }
    }
}

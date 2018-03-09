namespace TypeSeq.Sequencers
{
    public interface ISequencer
    {
    }

    public interface ISequencer<T> : ISequencer
    {
        T Next();
    }
}

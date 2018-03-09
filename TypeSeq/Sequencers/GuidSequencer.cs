using System;

namespace TypeSeq.Sequencers
{
    public class GuidSequencer : Sequencer<Guid>, ISequencer<Guid>
    {
        private Int64 intState;

        protected override Guid GenerateNext()
        {
            intState++;
            var bytes = new byte[16];
            var intBytes = BitConverter.GetBytes(intState);
            Array.Copy(intBytes, 0, bytes, 0, 8);
            return new Guid(bytes);
        }
    }
}

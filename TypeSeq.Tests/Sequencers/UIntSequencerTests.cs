using Xunit;

namespace TypeSeq.Tests.Sequencers
{
    public class UIntSequencerTests
    {
        private Seq seq;

        public UIntSequencerTests()
        {
            seq = new Seq();
        }

        [Fact]
        public void CanSequence()
        {
            Assert.Equal(0, (int)seq.Next<uint>());
            Assert.Equal(1, (int)seq.Next<uint>());
            Assert.Equal(2, (int)seq.Next<uint>());
        }
    }
}

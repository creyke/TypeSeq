using Xunit;

namespace TypeSeq.Tests.Sequencers
{
    public class IntSequencerTests
    {
        private Seq seq;

        public IntSequencerTests()
        {
            seq = new Seq();
        }

        [Fact]
        public void CanSequence()
        {
            Assert.Equal(0, seq.Next<int>());
            Assert.Equal(1, seq.Next<int>());
            Assert.Equal(2, seq.Next<int>());
        }
    }
}

using System;
using Xunit;

namespace TypeSeq.Tests.Sequencers
{
    public class GuidSequencerTests
    {
        private Seq seq;

        public GuidSequencerTests()
        {
            seq = new Seq();
        }

        [Fact]
        public void CanSequence()
        {
            Assert.Equal(Guid.Parse("00000000-0000-0000-0000-000000000000"), seq.Next<Guid>());
            Assert.Equal(Guid.Parse("00000001-0000-0000-0000-000000000000"), seq.Next<Guid>());
            Assert.Equal(Guid.Parse("00000002-0000-0000-0000-000000000000"), seq.Next<Guid>());
        }
    }
}

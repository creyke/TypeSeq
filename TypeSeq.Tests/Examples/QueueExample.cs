using System;
using System.Collections.Generic;
using Xunit;

namespace TypeSeq.Tests.Examples
{
    public class QueueExample
    {
        private Queue<Guid> testSubject = new Queue<Guid>();
        private Seq seq = new Seq();

        [Theory]
        [InlineData(3)]
        public void Can(int count)
        {
            for (int i = 0; i < count; i++)
            {
                testSubject.Enqueue(seq.Next<Guid>());
            }

            for (int i = 0; i < count; i++)
            {
                Assert.Equal(seq.NextAssert<Guid>(), testSubject.Dequeue());
            }
        }
    }
}

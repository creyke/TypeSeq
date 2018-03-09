# TypeSeq
Deterministic type sequencing for unit tests

# Example usage
```csharp
public class QueueExample
{
    private Queue<Guid> testSubject = new Queue<Guid>();
    private Seq seq = new Seq();

    [Theory]
    [InlineData(3)]
    public void CanEnqueueAndDequeue(int count)
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
```

using CodeChallenges.Solutions.DataStructures;

namespace CodeChallenges.UnitTests.DataStructures;



public class MaxHeapTests
{
    [Fact]
    public void Insert_SingleElement_PlacesItAtRoot() =>
        HeapFrom(10).Should().Equal(10);

    [Fact]
    public void Insert_AscendingOrder_MaintainsMaxAtRoot() =>
        HeapFrom(1, 2, 3).First().Should().Be(3);

    [Fact]
    public void Insert_DescendingOrder_MaintainsMaxAtRoot() =>
        HeapFrom(3, 2, 1).First().Should().Be(3);

    [Fact]
    public void Insert_MultipleElements_SatisfiesHeapProperty()
    {
        var items = HeapFrom(5, 3, 8, 1, 10, 2, 7);

        items.Should().HaveCount(7);
        items.First().Should().Be(10);
        AssertMaxHeapProperty(items);
    }

    [Fact]
    public void Insert_WithDuplicates_MaintainsHeapProperty()
    {
        var items = HeapFrom(4, 4, 4, 1, 7, 7);

        items.First().Should().Be(7);
        AssertMaxHeapProperty(items);
    }

    [Fact]
    public void Insert_NegativeValues_MaintainsHeapProperty()
    {
        var items = HeapFrom(-5, -1, -10, -3);

        items.First().Should().Be(-1);
        AssertMaxHeapProperty(items);
    }

    [Fact]
    public void ArrayConstructor_EmptyArray_CreatesEmptyHeap() =>
        GetInternalHeap(new MaxHeap<int>(Array.Empty<int>())).Should().BeEmpty();

    [Fact]
    public void ArrayConstructor_SingleElement_PlacesItAtRoot() =>
        GetInternalHeap(new MaxHeap<int>([42])).Should().Equal(42);

    [Fact]
    public void ArrayConstructor_UnsortedArray_HeapifiesCorrectly()
    {
        var items = GetInternalHeap(new MaxHeap<int>([3, 1, 6, 5, 2, 4]));

        items.First().Should().Be(6);
        AssertMaxHeapProperty(items);
    }

    [Fact]
    public void ArrayConstructor_SortedAscending_HeapifiesCorrectly()
    {
        var items = GetInternalHeap(new MaxHeap<int>([1, 2, 3, 4, 5]));

        items.First().Should().Be(5);
        AssertMaxHeapProperty(items);
    }

    [Fact]
    public void ArrayConstructor_AllDuplicates_MaintainsHeapProperty()
    {
        var items = GetInternalHeap(new MaxHeap<int>([7, 7, 7, 7]));

        items.First().Should().Be(7);
        AssertMaxHeapProperty(items);
    }

    [Fact]
    public void ArrayConstructor_PreservesAllElements()
    {
        int[] input = [9, 1, 5, 3, 8, 2];
        var items = GetInternalHeap(new MaxHeap<int>(input));

        items.Should().BeEquivalentTo(input);
    }

    [Fact]
    public void PeekMaxOrDefault_EmptyHeap_ReturnsDefault() =>
        new MaxHeap<int>().PeekMaxOrDefault().Should().Be(0);

    [Fact]
    public void PeekMaxOrDefault_EmptyHeap_ReturnsCustomDefault() =>
        new MaxHeap<int>().PeekMaxOrDefault(-1).Should().Be(-1);

    [Fact]
    public void PeekMaxOrDefault_NonEmptyHeap_ReturnsMaxWithoutRemoving()
    {
        var heap = InsertAll(5, 10, 3);

        heap.PeekMaxOrDefault().Should().Be(10);
        heap.PeekMaxOrDefault().Should().Be(10);
        GetInternalHeap(heap).Should().HaveCount(3);
    }

    [Fact]
    public void PopMaxOrDefault_EmptyHeap_ReturnsDefault() =>
        new MaxHeap<int>().PopMaxOrDefault().Should().Be(0);

    [Fact]
    public void PopMaxOrDefault_EmptyHeap_ReturnsCustomDefault() =>
        new MaxHeap<int>().PopMaxOrDefault(-1).Should().Be(-1);

    [Fact]
    public void PopMaxOrDefault_SingleElement_ReturnsAndRemovesIt()
    {
        var heap = InsertAll(42);

        heap.PopMaxOrDefault().Should().Be(42);
        GetInternalHeap(heap).Should().BeEmpty();
    }

    [Fact]
    public void PopMaxOrDefault_MultipleElements_ReturnsMaxAndMaintainsHeapProperty()
    {
        var heap = InsertAll(5, 3, 8, 1, 10, 2, 7);

        heap.PopMaxOrDefault().Should().Be(10);

        var items = GetInternalHeap(heap);
        items.Should().HaveCount(6);
        AssertMaxHeapProperty(items);
    }

    [Fact]
    public void PopMaxOrDefault_ConsecutivePops_ReturnsSortedDescending()
    {
        var heap = InsertAll(4, 1, 7, 3, 9);

        heap.PopMaxOrDefault().Should().Be(9);
        heap.PopMaxOrDefault().Should().Be(7);
        heap.PopMaxOrDefault().Should().Be(4);
        heap.PopMaxOrDefault().Should().Be(3);
        heap.PopMaxOrDefault().Should().Be(1);
        heap.PopMaxOrDefault().Should().Be(0);
    }

    [Fact]
    public void PopMaxOrDefault_FromArrayConstructor_ReturnsSortedDescending()
    {
        var heap = new MaxHeap<int>([6, 2, 8, 1, 5]);

        heap.PopMaxOrDefault().Should().Be(8);
        heap.PopMaxOrDefault().Should().Be(6);
        heap.PopMaxOrDefault().Should().Be(5);
        heap.PopMaxOrDefault().Should().Be(2);
        heap.PopMaxOrDefault().Should().Be(1);
    }

    [Fact]
    public void PopMax_EmptyHeap_ThrowsInvalidOperationException()
    {
        var heap = new MaxHeap<int>();

        var act = () => heap.PopMax();

        act.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void PopMax_SingleElement_ReturnsAndRemovesIt()
    {
        var heap = InsertAll(42);

        heap.PopMax().Should().Be(42);
        GetInternalHeap(heap).Should().BeEmpty();
    }

    [Fact]
    public void PopMax_ConsecutivePops_ReturnsSortedDescending()
    {
        var heap = InsertAll(4, 1, 7, 3, 9);

        heap.PopMax().Should().Be(9);
        heap.PopMax().Should().Be(7);
        heap.PopMax().Should().Be(4);
        heap.PopMax().Should().Be(3);
        heap.PopMax().Should().Be(1);
    }

    [Fact]
    public void PopMax_AfterDraining_ThrowsInvalidOperationException()
    {
        var heap = InsertAll(1);
        heap.PopMax();

        var act = () => heap.PopMax();

        act.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void InsertAfterPop_MaintainsHeapProperty()
    {
        var heap = InsertAll(5, 10, 3);

        heap.PopMaxOrDefault();
        heap.Insert(8);

        heap.PeekMaxOrDefault().Should().Be(8);
        AssertMaxHeapProperty(GetInternalHeap(heap));
    }

    [Fact]
    public void InsertAfterDrainingHeap_WorksCorrectly()
    {
        var heap = InsertAll(1);
        heap.PopMaxOrDefault();

        heap.Insert(99);

        heap.PeekMaxOrDefault().Should().Be(99);
    }

    private static MaxHeap<int> InsertAll(params int[] values)
    {
        var heap = new MaxHeap<int>();
        foreach (var value in values)
            heap.Insert(value);
        return heap;
    }

    private static List<int> HeapFrom(params int[] values) =>
        GetInternalHeap(InsertAll(values));

    private static List<T> GetInternalHeap<T>(MaxHeap<T> heap) where T : IComparable<T> =>
        (List<T>)typeof(MaxHeap<T>)
            .GetField("_heap", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)!
            .GetValue(heap)!;

    private static void AssertMaxHeapProperty<T>(List<T> items) where T : IComparable<T>
    {
        for (var i = 0; i < items.Count; i++)
        {
            var left = 2 * i + 1;
            var right = 2 * i + 2;

            if (left < items.Count)
                items[i].CompareTo(items[left]).Should().BeGreaterOrEqualTo(0,
                    $"parent at [{i}]={items[i]} should be >= left child at [{left}]={items[left]}");

            if (right < items.Count)
                items[i].CompareTo(items[right]).Should().BeGreaterOrEqualTo(0,
                    $"parent at [{i}]={items[i]} should be >= right child at [{right}]={items[right]}");
        }
    }
}

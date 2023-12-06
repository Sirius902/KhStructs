using System.Runtime.CompilerServices;

namespace KhStructs.Interop;

public static class SpanExtensions {
    /// <summary>
    /// Gets a pointer to the span element at index.
    /// </summary>
    public static unsafe T* GetPointer<T>(this Span<T> span, int index) where T : unmanaged {
        return (T*)Unsafe.AsPointer(ref span[index]);
    }

    /// <summary>
    /// Enumerates the elements of a Span{T} as pointers.
    /// </summary>
    public unsafe ref struct SpanPointerEnumerator<T> where T : unmanaged {
        private int currentIndex;
        private readonly Span<T> items;

        public SpanPointerEnumerator(Span<T> span) {
            this.items = span;
            this.currentIndex = -1;
        }

        public bool MoveNext() => ++this.currentIndex < this.items.Length;
        public readonly T* Current => (T*)Unsafe.AsPointer(ref this.items[this.currentIndex]);
        public SpanPointerEnumerator<T> GetEnumerator() => new(this.items);
    }

    /// <summary>
    /// Gets a pointer enumerator for this span.
    /// This allows enumeration over the span as a pointer type, T*, rather than T.
    /// </summary>
    public static SpanPointerEnumerator<T> PointerEnumerator<T>(this Span<T> span) where T : unmanaged => new(span);
}

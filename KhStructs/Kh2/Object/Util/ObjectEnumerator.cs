using System.Collections;

namespace KhStructs.Kh2.Object.Util;

public sealed unsafe class ObjectEnumerator<T>(delegate*<T*, T*> iterate) : IEnumerator<Pointer<T>>,
    IEnumerable<Pointer<T>> where T : unmanaged {
    public Pointer<T> Current { get; private set; } = null;

    object IEnumerator.Current => this.Current;

    public bool MoveNext() {
        this.Current = iterate(this.Current);
        return this.Current.Value is not null;
    }

    public void Reset() {
        this.Current = null;
    }

    public IEnumerator<Pointer<T>> GetEnumerator() {
        var copy = new ObjectEnumerator<T>(iterate);
        copy.Current = this.Current;
        return copy;
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return this.GetEnumerator();
    }

    public void Dispose() {
    }
}

namespace KhStructs.Kh2;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct Hash {
    public uint Value;

    /// <summary>
    /// Looks up an address inside the global address table by its hash.
    /// </summary>
    /// <param name="hash">The hash of the address to lookup.</param>
    /// <returns>The pointer that was hashed if it was inserted in the table, zero if the hash was zero, -1 otherwise.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 8B 3B")]
    public static partial void* Lookup(Hash hash);

    /// <summary>
    /// Inserts a pointer into the global address table if not already inserted and returns its hash.
    /// </summary>
    /// <param name="ptr">The pointer whose address will be inserted into the table.</param>
    /// <returns>The hash of the pointer's address.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 89 46 14")]
    public static partial Hash GetOrInsert(void* ptr);
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct Hash<T>(Hash hash) where T : unmanaged {
    public Hash TypeErased = hash;

    public Hash(void* ptr) : this(Hash.GetOrInsert(ptr)) {
    }

    /// <summary>
    /// Looks up an address inside the global address table by its hash.
    /// </summary>
    /// <returns>The pointer that was hashed if it was inserted in the table, zero if the hash was zero, -1 otherwise.</returns>
    public Pointer<T> Lookup() => (Pointer<T>)Hash.Lookup(this.TypeErased);
}

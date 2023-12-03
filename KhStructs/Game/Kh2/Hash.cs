namespace KhStructs.Game.Kh2;

public unsafe partial struct Hash {
    /// <summary>
    /// Looks up an address inside the global address table by its hash.
    /// </summary>
    /// <param name="hash">The hash of the address to lookup.</param>
    /// <returns>The pointer that was hashed if it was inserted in the table, zero if the hash was zero, -1 otherwise.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 8B 3B")]
    public static partial void* Lookup(int hash);

    /// <summary>
    /// Inserts a pointer into the global address table and returns its hash.
    /// </summary>
    /// <param name="ptr">The pointer whose address will be inserted into the table.</param>
    /// <returns>The hash of the pointer's address.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 89 46 14")]
    public static partial int Insert(void* ptr);
}

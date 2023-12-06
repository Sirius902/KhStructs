namespace KhStructs.Interop;

public class Address {
    public Address(string name, string @namespace, string @string, ulong[] bytes, ulong[] mask, nuint value) {
        this.Name = name;
        this.String = @string;
        this.Bytes = bytes;
        this.Mask = mask;
        this.Value = value;
        this.Namespace = @namespace;

        this.CacheKey = this.String;
    }

    public readonly string Name;
    public readonly string String;
    public readonly ulong[] Bytes;
    public readonly ulong[] Mask;
    public readonly string Namespace;
    public nuint Value;
    public string CacheKey;
}

public sealed class StaticAddress : Address {
    public StaticAddress(string name, string @namespace, string @string, ulong[] bytes, ulong[] mask, nuint value,
        int offset, int instructionSize) : base(name, @namespace, @string, bytes, mask, value) {
        this.Offset = offset;
        this.InstructionSize = instructionSize;

        this.CacheKey = $"{this.String}+0x{this.Offset:X}";
    }

    public int Offset;
    public int InstructionSize;
}

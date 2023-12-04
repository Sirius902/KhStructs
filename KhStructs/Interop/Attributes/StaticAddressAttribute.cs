namespace KhStructs.Interop.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public class StaticAddressAttribute : Attribute {
    public StaticAddressAttribute(string signature, int offset, bool isPointer = false, int instructionSize = 4) {
        Signature = signature;
        Offset = offset;
        IsPointer = isPointer;
        InstructionSize = instructionSize;
    }

    public string Signature { get; }
    public int Offset { get; }
    public bool IsPointer { get; }
    public int InstructionSize { get; }
}

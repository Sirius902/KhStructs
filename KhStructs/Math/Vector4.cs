namespace KhStructs.Math;

[StructLayout(LayoutKind.Sequential)]
public struct Vector4 {
    public float X;
    public float Y;
    public float Z;
    public float W;

    public Vector4(float x, float y, float z, float w) {
        this.X = x;
        this.Y = y;
        this.Z = z;
        this.W = w;
    }

    public static implicit operator System.Numerics.Vector4(Vector4 vec) => new(vec.X, vec.Y, vec.Z, vec.W);
    public static implicit operator Vector4(System.Numerics.Vector4 vec) => new(vec.X, vec.Y, vec.Z, vec.W);
}

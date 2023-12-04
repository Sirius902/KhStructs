namespace KhStructs.Math;

[StructLayout(LayoutKind.Sequential)]
public struct Vector3 {
    public float X;
    public float Y;
    public float Z;

    public Vector3(float x, float y, float z) {
        this.X = x;
        this.Y = y;
        this.Z = z;
    }

    public static implicit operator System.Numerics.Vector3(Vector3 vec) => new(vec.X, vec.Y, vec.Z);
    public static implicit operator Vector3(System.Numerics.Vector3 vec) => new(vec.X, vec.Y, vec.Z);
}

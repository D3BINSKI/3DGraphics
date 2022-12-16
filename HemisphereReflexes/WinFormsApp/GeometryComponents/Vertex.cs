using System.Numerics;

namespace WinFormsApp.GeometryComponents;

public class Vertex: Point3
{
    public Vector3 NormalVector { get; }
    public Vertex(Point3 p, int id, Vector3 normalVector) : base(p)
    {
        Id = id;
        NormalVector = Vector3.Normalize(normalVector);
    }
    public int Id { get; }

    public static Vector3 operator -(Vertex v1, Vertex v2) => 
        new Vector3((float)(v1.X - v2.X), (float)(v1.Y - v2.Y), (float)(v1.Z - v2.Z));
    
    public Vector3 Position => new Vector3((float)X, (float)Y, (float)Z);

    public void Scale(float kX, float kY, float kZ, Vector3 center)
    {
        X = (X - center.X) * kX + center.X;
        Y = (Y - center.Y) * kY + center.Y;
        Z = (Z - center.Z) * kZ + center.Y;
    }

    public void Move(float deltaX, float deltaY, float deltaZ)
    {
        X += deltaX;
        Y += deltaY;
        Z += deltaZ;
    }
    
    public bool Equals(Vertex? v)
    {
        if (v is null)
        {
            return false;
        }

        // Optimization for a common success case.
        if (ReferenceEquals(this, v))
        {
            return true;
        }

        // If run-time types are not exactly the same, return false.
        if (GetType() != v.GetType())
        {
            return false;
        }

        // Return true if the fields match.
        // Note that the base class is not invoked because it is
        // System.Object, which defines Equals as reference equality.
        return X.Equals(v.X) && Y.Equals(v.Y) && Z.Equals(v.Z);
    }
    
    public override bool Equals(object? obj)
    {
        if (obj is Vertex other)
        {
            return Equals(other);
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y, Z);
    }
    
    public void Rotate(Matrix4x4 roatationMatrix)
    {
        var vector = new Vector4((float)X, (float)Y, (float)Z, 1);
        var result = Vector4.Transform(vector, roatationMatrix);
        X = result.X;
        Y = result.Y;
        Z = result.Z;
    }
}
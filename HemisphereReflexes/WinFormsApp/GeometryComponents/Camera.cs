using System.Numerics;

namespace WinFormsApp.GeometryComponents;

public class Camera
{
    private Vector3 Position { get; set; }
    private Vector3 Target { get; set; }
    private Vector3 Up { get; set; }
    
    private float FieldOfView { get; set; }

    public Camera()
    {
        Position = new Vector3(0, 0, 0);
        Target = new Vector3(100, 100, 0);
        Up = new Vector3(0, 0, 1);
        FieldOfView = (float)(Math.PI * 0.4);
    }

    public Camera(Vector3 position, Vector3 target, Vector3 up, float fieldOfView)
    {
        Position = position;
        Target = target;
        Up = up;
        FieldOfView = fieldOfView;
    }

    public Matrix4x4 GetViewMatrix()
    {
        return Matrix4x4.CreateLookAt(Position, Target, Up);
    }
    
    public Matrix4x4 GetPerspectiveMatrix(float aspectRatio)
    {
        return Matrix4x4.CreatePerspectiveFieldOfView(FieldOfView, 1, 0.01f, 1000f);
    }
    
    public void Move(Vector3 direction)
    {
        Position += direction;
        Target += direction;
    }
    
    public void Rotate(Vector3 rotation)
    {
        var rotationMatrix = Matrix4x4.CreateFromYawPitchRoll(rotation.Y, rotation.X, rotation.Z);
        var direction = Target - Position;
        direction = Vector3.Transform(direction, rotationMatrix);
        Target = Position + direction;
    }
    
    public void Zoom(float amount)
    {
        var direction = Target - Position;
        direction *= amount;
        Position += direction;
    }
    
    public void SetPosition(Vector3 position)
    {
        Position = position;
    }

    public void SetTarget(Vector3 target)
    {
        Target = target;
    }
    
    public void SetUp(Vector3 up)
    {
        Up = up;
    }
    
    public void SetFieldOfView(float fieldOfView)
    {
        FieldOfView = fieldOfView;
    }
    
    public Image GetCameraImage(Scene scene)
    {
        var pictureBox = scene.ScenePictureBox;
        var image = new Bitmap(pictureBox.Width, pictureBox.Height);
        var graphics = Graphics.FromImage(image);
        graphics.Clear(Color.White);
        var viewMatrix = GetViewMatrix();
        var perspectiveMatrix = GetPerspectiveMatrix(1);
        foreach (var mesh in scene.Meshes)
        {
            var worldMatrix = mesh.WorldMatrix;
            var points = new List<Vector3>();

            foreach (var face in mesh.Faces)
            {
                foreach (var vertex in face.Vertices)
                {
                    var point = Vector3.Transform(vertex.Position, worldMatrix);
                    point = Vector3.Transform(point, viewMatrix);
                    point = Vector3.Transform(point, perspectiveMatrix);
                    points.Add(point);
                }
                graphics.DrawPolygon(Pens.Black, points.Select(p => new PointF(p.X, p.Y)).ToArray());
                points.Clear();
            }
        }
        return image;
    }
}
using System.Numerics;
using ObjParser;
using WinFormsApp.GraphicTools;

namespace WinFormsApp.GeometryComponents;

public struct SurfaceProperties
{
    private double _kd;
    private double _ks;
    private double _m;

    public double Kd { get => _kd; set => _kd = value; }
    public double Ks { get => _ks; set => _ks = value; }
    public double M { get => _m; set => _m = value; }

    public SurfaceProperties(double kd, double ks, double m)
    {
        _ks = kd;
        _kd = ks;
        _m = m;
    }
}

public class Render
{
    private SurfaceProperties _surface;

    private Vector3 _center;

    private Image _textureImage;
    private NormalMap _normalMap;
    private Bitmap _textureBitmap;
    private HeightMap _heightMap;
    private Matrix4x4 _modelMatrix;
    private Vector3 _rotationDirection;
    
    public Image TextureImage { get => _textureImage; set => _textureImage = value; }
    
    public NormalMap NormalMap { get => _normalMap; set => _normalMap = value; }
    
    public HeightMap HeightMap
    {
        get => _heightMap;
        set => _heightMap = value;
    }

    public Matrix4x4 WorldMatrix => _modelMatrix;

    public SurfaceProperties Surface => _surface;
    public List<Face> Faces { get; }
    public List<Vertex> Vertices { get; }
    public IEnumerable<Edge> Edges { get; }

    public Render(Obj renderedObject, Image textureImage, NormalMap? normalMap, Vector3 position, double scale,
        Vector3 rotationDirection)
    {
        Vertices = new List<Vertex>();
        Faces = new List<Face>();

        _surface = new SurfaceProperties(0.5, 0.5, 50);
        _normalMap = normalMap;

        foreach (var vertex in renderedObject.VertexList)
        {
            var faceContainingCurrentVertex =
                renderedObject.FaceList.First(face => face.VertexIndexList.Contains(vertex.Index));
            var indexOfVertexInArray = Array.IndexOf(faceContainingCurrentVertex.VertexIndexList, vertex.Index);
            var normalVectorIndex = faceContainingCurrentVertex.NormalVectorIndexList[indexOfVertexInArray];
            var normalVector = renderedObject.NormalVectorList[normalVectorIndex - 1];
            Vertices.Add(new Vertex(new Point3((float)vertex.X, (float)vertex.Y, (float)vertex.Z), vertex.Index,
                new Vector3((float)normalVector.X, (float)normalVector.Y, (float)normalVector.Z)));
        }

        foreach (var face in renderedObject.FaceList)
        {
            Faces.Add(new Face(Vertices.FindAll(v => face.VertexIndexList.Contains(v.Id))));
        }

        Edges = Faces.SelectMany(face => face.Edges).Distinct();


        _center = new Vector3((float)((renderedObject.Size.XMax + renderedObject.Size.XMin) / 2),
            (float)((renderedObject.Size.YMax + renderedObject.Size.YMin) / 2),
            (float)((renderedObject.Size.ZMax + renderedObject.Size.ZMin) / 2));

        Scale(scale);
        MoveCenter(position);

        var xSpan = 2 * Math.Max(
            Math.Abs(renderedObject.Size.XMax - _center.X),
            Math.Abs(renderedObject.Size.XMin - _center.X));

        _textureImage = textureImage;
        // _textureBitmap = new Bitmap(_textureImage, (int)xSpan, (int)_ySpan);
        _heightMap =
            new HeightMap(
                Image.FromFile(
                    @"D:\Software\Projects\Computer Graphics\hemisphere_reflexes\HemisphereReflexes\WinFormsApp\Height Map\great_lakes.jpg"),
                new Size(500, 500));

        CreateRotationMatrix(rotationDirection);
        _modelMatrix = Matrix4x4.CreateRotationX((float)(Math.PI / 2), _center);

    }

    public void SetKd(double value)
    {
        if (value is < 0 or > 1)
        {
            throw new ArgumentException($"kd surface value must be in range (0, 1). Provided kd value is {value}");
        }
        _surface.Kd = value;
    }
    
    public void SetKs(double value)
    {
        if (value is < 0 or > 1)
        {
            throw new ArgumentException($"ks surface value must be in range (0, 1). Provided ks value is {value}");
        }
        value = Math.Max(value, 0);
        value = Math.Min(value, 1);
        _surface.Ks = value;
    }
    
    public void SetM(double value)
    {
        if (value is < 1 or > 100)
        {
            throw new ArgumentException($"m surface value must be in range (1, 100). Provided m value is {value}");
        }
        value = Math.Max(value, 1);
        value = Math.Min(value, 100);
        _surface.M = value;
    }

    public void Scale(double scale)
    {
        foreach (var vertex in Vertices)
        {
            vertex.Scale((float)scale, (float)scale, (float)scale, _center);
        }
        
        // _textureBitmap = new Bitmap(_textureImage, (int)width, (int)height);
        // _normalMap?.Resize(new Size((int)width, (int)height));
        // _heightMap?.Resize(new Size((int)width, (int)height));
    }

    public void SetTexture(Bitmap newTexture)
    {
        var oldTexture = _textureBitmap;
        _textureBitmap = new Bitmap(newTexture, oldTexture.Width, oldTexture.Height);
    }
    
    //set _textureBitmap from Color
    public void SetTexture(Color color)
    {
        var oldTexture = _textureBitmap;
        _textureBitmap = new Bitmap(oldTexture.Width, oldTexture.Height);
        for (var i = 0; i < _textureBitmap.Width; i++)
        {
            for (var j = 0; j < _textureBitmap.Height; j++)
            {
                _textureBitmap.SetPixel(i, j, color);
            }
        }
        _textureImage = Image.FromHbitmap(_textureBitmap.GetHbitmap());
    }

    public void SetNormalMap(Image newNormalMapImage)
    {
        var oldNormalMap = _normalMap;
        if(oldNormalMap is not null)
        {
            _normalMap = new NormalMap(newNormalMapImage, new Size(oldNormalMap.Width, oldNormalMap.Height));
        }
        else
        {
            _normalMap = new NormalMap(newNormalMapImage, new Size(newNormalMapImage.Width, newNormalMapImage.Height));
        }
    }

    public void MoveCenter(Vector3 position)
    {
        var deltaX = position.X - _center.X;
        var deltaY = position.Y - _center.Y;
        var deltaZ = position.Z - _center.Z;

        foreach (var vertex in Vertices)
        {
            vertex.Move(deltaX, deltaY, deltaZ);
        }

        _center = position;
    }

    public void FillFaces(Painter painter, DirectBitmap bitmap, Illumination illumination, bool isVectorInterpolation, bool isVectorMapUsed)
    {
        foreach (var face in Faces)
        {
            painter.FillPolygon(face, _textureBitmap, bitmap, illumination, _surface, _normalMap, _heightMap, isVectorInterpolation, isVectorMapUsed);
        }
    }

    public void DrawMesh(DirectBitmap bitmap)
    {
        using var graphics = Graphics.FromImage(bitmap.Bitmap);
        
        foreach (var edge in Edges)
        {
            graphics.DrawLine(Pens.Black, (int)edge.V1.X, (int)edge.V1.Y, (int)edge.V2.X, (int)edge.V2.Y);
        }
        
    }
    
    private void CreateRotationMatrix(Vector3 rotationDirection)
    {
        _rotationDirection = rotationDirection;
        var rotationMatrix = Matrix4x4.Identity;
        if (_rotationDirection.X != 0)
        {
            rotationMatrix *= Matrix4x4.CreateRotationX(0, _center);
        }
        if (_rotationDirection.Y != 0)
        {
            rotationMatrix *= Matrix4x4.CreateRotationY(0, _center);
        }
        if (_rotationDirection.Z != 0)
        {
            rotationMatrix *= Matrix4x4.CreateRotationZ(0, _center);
        }
        _modelMatrix = rotationMatrix;
    }

    public void Rotate(float radians)
    {
        if (_rotationDirection.X != 0)
        {
            _modelMatrix *= Matrix4x4.CreateRotationX(radians, _center);
        }
        if (_rotationDirection.Y != 0)
        {
            _modelMatrix *= Matrix4x4.CreateRotationY(radians, _center);
        }
        if (_rotationDirection.Z != 0)
        {
            _modelMatrix *= Matrix4x4.CreateRotationZ(radians, _center);
        }
    }
    
}
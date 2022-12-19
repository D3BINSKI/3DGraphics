using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using WinFormsApp.GeometryComponents;
using WinFormsApp.GraphicTools;

namespace WinFormsApp;

public class Scene
{
    private Render _renderObj;
    private Illumination _sceneIllumination;
    private PictureBox _scenePictureBox;
    private DirectBitmap _bitmap;
    private Painter _painter;
    private Image _backgroundImage;
    public bool isVectorInterpolation;
    public bool isNormalMapUsed;
    private List<Render> _meshes;
    private Camera _camera;
    
    public PictureBox ScenePictureBox => _scenePictureBox;
    public DirectBitmap Bitmap => _bitmap;
    public Render RenderObj => _renderObj;
    public List<Render> Meshes => _meshes;

    public void SetRenderObject(Render render)
    {
        ChangeRenderObject(render);
    }
    
    public Scene(PictureBox pictureBox, List<Render> meshes, string backgroundFile, Illumination illumination, Camera camera)
    {
        _renderObj = meshes.First();
        _scenePictureBox = pictureBox;
        _backgroundImage = Image.FromFile(backgroundFile);
        _bitmap = new DirectBitmap(new Bitmap(_backgroundImage, pictureBox.Width, pictureBox.Height));
        _sceneIllumination = illumination;
        _scenePictureBox.Image = _bitmap.Bitmap;
        _painter = new Painter();
        isVectorInterpolation = true;
        _meshes = meshes;
        _camera = camera;
    }
    
    public void SetVectorInterpolation()
    {
        isVectorInterpolation = true;
    }

    public void SetColorInterpolation()
    {
        isVectorInterpolation = false;
    }

    public void SetNormalMapUsage()
    {
        isNormalMapUsed = true;
    }

    public void SetHeightMapUsage()
    {
        isNormalMapUsed = false;
    }

    public void FillRenderedObject()
    {
        // _renderObj.FillFaces(_painter, _bitmap, _sceneIllumination, isVectorInterpolation, isNormalMapUsed);

        using var graphics = Graphics.FromImage(_bitmap.Bitmap);
        _scenePictureBox.Invalidate(new Rectangle(0,0,_bitmap.Width, Bitmap.Height));
        _scenePictureBox.Update();
    }

    public void UpdateSize()
    {
        ResizeBitmap();
        // ResizeMeshes();
    }

    [SuppressMessage("ReSharper.DPA", "DPA0003: Excessive memory allocations in LOH", MessageId = "type: System.Int32[]")]
    public void ResizeBitmap()
    {
        // _bitmap = new DirectBitmap(new Bitmap(_backgroundImage, _scenePictureBox.Width, _scenePictureBox.Height));
        // _scenePictureBox.Image = _bitmap.Bitmap;
        // _scenePictureBox.Refresh();
    }
    
    public void ResizeMeshes()
    {
        // _renderObj.Scale();
    }

    public void RenderEvent(object? obj, EventArgs args)
    {
        // _renderObj.FillFaces(_painter, _bitmap, _sceneIllumination, isVectorInterpolation, isNormalMapUsed);
        // _renderObj.DrawMesh(_bitmap);
        Render();
        foreach (var mesh in _meshes)
        {
            mesh.Rotate(0.1f);
        }
        _sceneIllumination.Rotate();
    }

    public void Render()
    {
        _scenePictureBox.Image = _camera.GetCameraImage(this);
        _scenePictureBox.Invalidate(new Rectangle(0,0,_bitmap.Width, Bitmap.Height));
        _scenePictureBox.Update();
    }

    public void SetIlluminationHeight(double newHeight)
    {
        _sceneIllumination.ChangeHeight(newHeight);
    }
    
    //change _renderObject
    public void ChangeRenderObject(Render newRenderObject)
    {
        _renderObj = newRenderObject;
        // _renderObj.Scale();
        _bitmap = new DirectBitmap(new Bitmap(_backgroundImage, _scenePictureBox.Width, _scenePictureBox.Height));
        
        ResizeMeshes();
    }
    
    public void SetGlobalKd(double newKd)
    {
        foreach (var mesh in _meshes)
        {
            mesh.SetKd(newKd);
        }
    }
    
    public void SetGlobalKs(double newKs)
    {
        foreach (var mesh in _meshes)
        {
            mesh.SetKs(newKs);
        }
    }

    public void SetGlobalM(double newM)
    {
        foreach (var mesh in _meshes)
        {
            mesh.SetM(newM);
        }
    }
    
    public void SetCameraPosition(Vector3 newPosition)
    {
        _camera.SetPosition(newPosition);
    }
    
    public void SetCameraFieldOfView(float newFieldOfView)
    {
        if (newFieldOfView is > 0 and < (float)Math.PI/2)
        {
            _camera.SetFieldOfView(newFieldOfView);
        }
    }
}
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
    private GraphicTools.Painter _painter;
    private Image _choosenSceneImage;
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
    
    public Scene(PictureBox pictureBox, Render renderObj, string backgroundFile, Illumination illumination)
    {
        _renderObj = renderObj;
        _scenePictureBox = pictureBox;
        _choosenSceneImage = Image.FromFile(backgroundFile);
        _bitmap = new DirectBitmap(new Bitmap(_choosenSceneImage, pictureBox.Width, pictureBox.Height));
        _sceneIllumination = illumination;
        _scenePictureBox.Image = _bitmap.Bitmap;
        _painter = new Painter();
        isVectorInterpolation = true;
        _meshes = new List<Render>();
        _meshes.Add(_renderObj);
        _camera = new Camera(new Vector3(-100, -100, 100000), new Vector3(1, 1, 1), new Vector3(0, 0, 1));
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
        graphics.DrawLine(Pens.Black,0,0,100,100);
        _scenePictureBox.Invalidate(new Rectangle(0,0,_bitmap.Width, Bitmap.Height));
        _scenePictureBox.Update();
    }

    public void AdjustSceneDimensions()
    {
        UpdateBitmap();
        AdjustRenderSize();
    }

    [SuppressMessage("ReSharper.DPA", "DPA0003: Excessive memory allocations in LOH", MessageId = "type: System.Int32[]")]
    public void UpdateBitmap()
    {
        _bitmap = new DirectBitmap(new Bitmap(_choosenSceneImage, _scenePictureBox.Width, _scenePictureBox.Height));
        _scenePictureBox.Image = _bitmap.Bitmap;
    }
    
    public void AdjustRenderSize()
    {
        _renderObj.FitToCanvas(_bitmap.Height, _bitmap.Width, 20);
    }

    public void Render(object? obj, EventArgs args)
    {
        // _renderObj.FillFaces(_painter, _bitmap, _sceneIllumination, isVectorInterpolation, isNormalMapUsed);
        // _renderObj.DrawMesh(_bitmap);
        _scenePictureBox.Image = _camera.GetCameraImage(this);
        _renderObj.Rotate(0.1f);
        _sceneIllumination.Rotate(); 
        _scenePictureBox.Invalidate(new Rectangle(0,0,_bitmap.Width, Bitmap.Height));
        _scenePictureBox.Update();
    }

    private void Simulation()
    {
        while(true)
        {
            _renderObj.FillFaces(_painter, _bitmap, _sceneIllumination, isVectorInterpolation, isNormalMapUsed);
            _sceneIllumination.Rotate(); 
            using var graphics = Graphics.FromImage(this._bitmap.Bitmap);
            graphics.DrawLine(Pens.Black,0,0,100,100);
            _scenePictureBox.Invalidate(new Rectangle(0,0,_bitmap.Width, Bitmap.Height));
            _scenePictureBox.Update();
            Thread.Sleep(30);
        }
    }

    public void SetIlluminationHeight(double newHeight)
    {
        _sceneIllumination.ChangeHeight(newHeight);
    }
    
    //change _renderObject
    public void ChangeRenderObject(Render newRenderObject)
    {
        _renderObj = newRenderObject;
        _renderObj.FitToCanvas(_bitmap.Height, _bitmap.Width, 20);
        _bitmap = new DirectBitmap(new Bitmap(_choosenSceneImage, _scenePictureBox.Width, _scenePictureBox.Height));
        
        AdjustRenderSize();
    }
}
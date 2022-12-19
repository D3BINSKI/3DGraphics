using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using ObjParser;
using WinFormsApp.GeometryComponents;
using WinFormsApp.GraphicTools;

namespace WinFormsApp
{
    public partial class TopLevelForm : Form
    {
        static readonly System.Windows.Forms.Timer _mainTimer = new();
        private readonly List<Render> _meshes;
        private Render _renderedObject;
        private Scene _scene;
        private readonly string _projectDir;


        public TopLevelForm()
        {
            string workingDirectory = Environment.CurrentDirectory;
            _projectDir = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            InitializeComponent();

            renderPictureBox.CreateGraphics();
            
            var importedObject = new Obj();
            importedObject.LoadObj(_projectDir + @"\Models\full-torus-triangulated.obj");
            
            Render render1 = new Render(  
                importedObject, 
                Image.FromFile(_projectDir + @"\Images\2k_earth_daymap.jpg"),
                new NormalMap(Image.FromFile(_projectDir + @"\NormalMaps\2k_earth_normal_map.tif"), new Size(500, 500)),
                new Vector3(900, 300, 450),100, new Vector3(1, 0, 0));
            
            
            Render render2 = new Render(  
                importedObject, 
                Image.FromFile(_projectDir + @"\Images\2k_earth_daymap.jpg"),
                new NormalMap(Image.FromFile(_projectDir + @"\NormalMaps\2k_earth_normal_map.tif"), new Size(500, 500)),
                new Vector3(350, 500, 400), 300, new Vector3(0, 1, 0));
            

            _renderedObject = render1;
            // _renderedObject.Scale(500);
            _meshes = new List<Render> { render1, render2 };
            InitializeScene();
            _scene?.UpdateSize();

            _scene!.Render();

            InitializeTimer();

            SetDefaultComponentsValues();
        }

        private void InitializeScene()
        {
            const string backgroundFile = "Color-Green.jpg";
            var defaultBackground = Path.Join(_projectDir, @"Images", backgroundFile);

            var defaultIllumination = new Illumination(
                new Point3(400.0, 400.0, 300.0),
                Color.CadetBlue,
                new Point(renderPictureBox.Width / 2, renderPictureBox.Height / 2),
                600);
            
            var defaultCamera = new Camera();

            _scene = new Scene(
                renderPictureBox,
                _meshes,
                defaultBackground,
                defaultIllumination,
                defaultCamera); 
        }

        private void InitializeTimer()
        {
            const int timerInterval = 100;
            _mainTimer.Tick += _scene.RenderEvent;
            _mainTimer.Interval = timerInterval;
            _mainTimer.Start();
        }

        private void SetDefaultComponentsValues()
        {
            radioButton1.Checked = true;
            vectorInterpolationSetRadioBttn.Checked = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // _mainScene.RunSimulation(); //async version (only some features works)
        }

        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            _scene?.UpdateSize();
            _scene?.Render();
        }

        private void KdValueChanged(object sender, EventArgs e)
        {
            _scene.SetGlobalKd(kdTrackBar.Value * (1.0 / (kdTrackBar.Maximum - kdTrackBar.Minimum)));
            RefreshMainScene();
        }

        private void KsValueChanged(object sender, EventArgs e)
        {
            _scene.SetGlobalKs(ksTrackBar.Value * (1.0 / (ksTrackBar.Maximum - ksTrackBar.Minimum)));
            RefreshMainScene();
        }

        private void MValueChanged(object sender, EventArgs e)
        {
            _scene.SetGlobalM(mTrackBar.Value);
            RefreshMainScene();
        }

        private void RefreshMainScene()
        {
            _scene?.FillRenderedObject();
        }

        private void pauseBttn_Click(object sender, EventArgs e)
        {
            _mainTimer.Stop();
        }

        private void startBttn_Click(object sender, EventArgs e)
        {
            _mainTimer.Start();
        }

        private void ZValueTrackbarChanged(object sender, EventArgs e)
        {
            _scene.SetIlluminationHeight(zValueTrackBar.Value);
        }

        private void vectorInterpolationSetRadioBttn_CheckedChanged(object sender, EventArgs e)
        {
            if (vectorInterpolationSetRadioBttn.Checked)
            {
                colorInterpolationSetRadioBttn.Checked = false;

                _scene.SetVectorInterpolation();
            }
        }

        private void colorInterpolationSetRadioBttn_CheckedChanged(object sender, EventArgs e)
        {
            if (colorInterpolationSetRadioBttn.Checked)
            {
                vectorInterpolationSetRadioBttn.Checked = false;

                _scene.SetColorInterpolation();
            }
        }

        private void chngTextureBttn_Click(object sender, EventArgs e)
        {
            var texturesDirectory = _projectDir + "/Images";

            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = texturesDirectory;
            openFileDialog.Filter = @"png files (*.png)|*.png|jpg files (*.jpg)|*.jpg";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            _mainTimer.Stop();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                string filePath = openFileDialog.FileName;
                var image = Image.FromFile(filePath);
                _scene.RenderObj.SetTexture(new Bitmap(image));
            }

            _mainTimer.Start();
        }

        private void changeNormalMapBttn_Click(object sender, EventArgs e)
        {
            var normalMapsDir = _projectDir + "/NormalMaps";

            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = normalMapsDir;
            openFileDialog.Filter = @"jpg files (*.jpg)|*.jpg|png files (*.png)|*.png|tif files (*.tif)|*.tif";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            _mainTimer.Stop();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                string filePath = openFileDialog.FileName;
                var image = Image.FromFile(filePath);

                _scene.RenderObj.SetNormalMap(new Bitmap(image, renderPictureBox.Width, renderPictureBox.Height));
            }

            _mainTimer.Start();
        }

        private void setRenderObjectColorBttn_Click(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog();
            colorDialog.ShowDialog();
            _scene.RenderObj.SetTexture(colorDialog.Color);
        }

        private void setRenderObjectBttn_Click(object sender, EventArgs e)
        {
            string modelsDirectory = _projectDir + "/Models";

            using OpenFileDialog openFileDialog2 = new OpenFileDialog();
            openFileDialog2.InitialDirectory = modelsDirectory;
            openFileDialog2.Filter = @"obj files (*.obj)|*.obj";
            openFileDialog2.FilterIndex = 2;
            openFileDialog2.RestoreDirectory = true;

            _mainTimer.Stop();

            // if (openFileDialog2.ShowDialog() == DialogResult.OK)
            // {
            //     //Get the path of specified file
            //     string filePath = openFileDialog2.FileName;
            //     var importedObject = new Obj();
            //     importedObject.LoadObj(filePath);
            //     _renderedObject = new Render(
            //         importedObject,
            //         _renderedObject.TextureImage,
            //         _renderedObject.NormalMap, new Vector3(100, 100, 0), 100);
            //     _renderedObject.Scale(600);
            //     _scene.SetRenderObject(_renderedObject);
            //     RefreshMainScene();
            // }

            _mainTimer.Start();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radioButton2.Checked = false;
            _scene.SetNormalMapUsage();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            _scene.SetHeightMapUsage();
        }

        private void cameraYPositionNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            RefreshSceneCameraPosition();   
        }

        private void cameraXPositionNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            RefreshSceneCameraPosition();   
        }

        private void cameraZPositionNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            RefreshSceneCameraPosition();   
        }

        private void RefreshSceneCameraPosition()
        {
            _scene.SetCameraPosition(
                new Vector3(
                    (float)cameraXPositionNumericUpDown.Value, 
                    (float)cameraYPositionNumericUpDown.Value, 
                    (float)cameraZPositionNumericUpDown.Value));
        }

        private void FieldOfViewTrackBar_ValueChanged(object sender, EventArgs e)
        {
            var radians = (float)(FieldOfViewTrackBar.Value * (Math.PI / 180));
            _scene.SetCameraFieldOfView(radians);
        }
    }
}
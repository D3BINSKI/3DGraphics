using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using ObjParser;
using WinFormsApp.GeometryComponents;

namespace WinFormsApp
{
    public partial class TopLevelForm : Form
    {
        static readonly System.Windows.Forms.Timer _mainTimer = new System.Windows.Forms.Timer();
        private List<Render> _meshes;
        private Render _renderedObject;
        private Scene _mainScene;
        private Configuration _config;
        private string _projectDir;
        private Camera _camera;


        public TopLevelForm(Render renderObject)
        {
            string workingDirectory = Environment.CurrentDirectory;
            _projectDir = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            InitializeComponent();

            renderPictureBox.CreateGraphics();

            _renderedObject = renderObject;
            _meshes = new List<Render> { _renderedObject };
            InitializeScene();

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

            _mainScene = new Scene(
                renderPictureBox,
                _meshes,
                defaultBackground,
                defaultIllumination);
        }

        private void InitializeTimer()
        {
            var timerInterval = 100;
            _mainScene?.UpdateDimensions();
            if (_mainScene is not null) _mainTimer.Tick += _mainScene.Render;
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
            _mainScene?.UpdateDimensions();
            RefreshMainScene();
        }

        private void KdValueChanged(object sender, EventArgs e)
        {
            _renderedObject.SetKd(kdTrackBar.Value * (1.0 / (kdTrackBar.Maximum - kdTrackBar.Minimum)));
            RefreshMainScene();
        }

        private void KsValueChanged(object sender, EventArgs e)
        {
            _renderedObject.SetKs(ksTrackBar.Value * (1.0 / (ksTrackBar.Maximum - ksTrackBar.Minimum)));
            RefreshMainScene();
        }

        private void MValueChanged(object sender, EventArgs e)
        {
            _renderedObject.SetM(mTrackBar.Value);
            RefreshMainScene();
        }

        private void RefreshMainScene()
        {
            _mainScene?.FillRenderedObject();
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
            _mainScene.SetIlluminationHeight(zValueTrackBar.Value);
        }

        private void vectorInterpolationSetRadioBttn_CheckedChanged(object sender, EventArgs e)
        {
            if (vectorInterpolationSetRadioBttn.Checked)
            {
                colorInterpolationSetRadioBttn.Checked = false;

                _mainScene.SetVectorInterpolation();
            }
        }

        private void colorInterpolationSetRadioBttn_CheckedChanged(object sender, EventArgs e)
        {
            if (colorInterpolationSetRadioBttn.Checked)
            {
                vectorInterpolationSetRadioBttn.Checked = false;

                _mainScene.SetColorInterpolation();
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
                _mainScene.RenderObj.SetTexture(new Bitmap(image));
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

                _mainScene.RenderObj.SetNormalMap(new Bitmap(image, renderPictureBox.Width, renderPictureBox.Height));
            }

            _mainTimer.Start();
        }

        private void setRenderObjectColorBttn_Click(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog();
            colorDialog.ShowDialog();
            _mainScene.RenderObj.SetTexture(colorDialog.Color);
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

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                string filePath = openFileDialog2.FileName;
                var importedObject = new Obj();
                importedObject.LoadObj(filePath);
                _renderedObject = new Render(
                    importedObject,
                    _renderedObject.TextureImage,
                    _renderedObject.NormalMap);
                _renderedObject.FitToCanvas(renderPictureBox.Height, renderPictureBox.Width, 20);
                _mainScene.SetRenderObject(_renderedObject);
                RefreshMainScene();
            }

            _mainTimer.Start();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radioButton2.Checked = false;
            _mainScene.SetNormalMapUsage();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            _mainScene.SetHeightMapUsage();
        }
    }
}
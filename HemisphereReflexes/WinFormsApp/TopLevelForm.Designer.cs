namespace WinFormsApp
{
    partial class TopLevelForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainPanel = new System.Windows.Forms.Panel();
            this.canvasPanel = new System.Windows.Forms.Panel();
            this.renderPictureBox = new System.Windows.Forms.PictureBox();
            this.ControlsPanel = new System.Windows.Forms.Panel();
            this.controlsGroupBox = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.startBttn = new System.Windows.Forms.Button();
            this.pauseBttn = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cameraZPositionNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cameraYPositionNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cameraXPositionNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.FieldOfViewTrackBar = new System.Windows.Forms.TrackBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.setRenderObjectBttn = new System.Windows.Forms.Button();
            this.setRenderObjectColorBttn = new System.Windows.Forms.Button();
            this.chngTextureBttn = new System.Windows.Forms.Button();
            this.changeNormalMapBttn = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.vectorInterpolationSetRadioBttn = new System.Windows.Forms.RadioButton();
            this.colorInterpolationSetRadioBttn = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.zValueTrackBar = new System.Windows.Forms.TrackBar();
            this.mGroupBox = new System.Windows.Forms.GroupBox();
            this.mTrackBar = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.kdTrackBar = new System.Windows.Forms.TrackBar();
            this.ksGroupBox = new System.Windows.Forms.GroupBox();
            this.ksTrackBar = new System.Windows.Forms.TrackBar();
            this.mainPanel.SuspendLayout();
            this.canvasPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.renderPictureBox)).BeginInit();
            this.ControlsPanel.SuspendLayout();
            this.controlsGroupBox.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cameraZPositionNumericUpDown)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cameraYPositionNumericUpDown)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cameraXPositionNumericUpDown)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FieldOfViewTrackBar)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zValueTrackBar)).BeginInit();
            this.mGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mTrackBar)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kdTrackBar)).BeginInit();
            this.ksGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ksTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.canvasPanel);
            this.mainPanel.Controls.Add(this.ControlsPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(959, 671);
            this.mainPanel.TabIndex = 0;
            // 
            // canvasPanel
            // 
            this.canvasPanel.Controls.Add(this.renderPictureBox);
            this.canvasPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvasPanel.Location = new System.Drawing.Point(0, 0);
            this.canvasPanel.Name = "canvasPanel";
            this.canvasPanel.Size = new System.Drawing.Size(578, 671);
            this.canvasPanel.TabIndex = 6;
            // 
            // renderPictureBox
            // 
            this.renderPictureBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.renderPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.renderPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.renderPictureBox.Location = new System.Drawing.Point(0, 0);
            this.renderPictureBox.Name = "renderPictureBox";
            this.renderPictureBox.Size = new System.Drawing.Size(578, 671);
            this.renderPictureBox.TabIndex = 1;
            this.renderPictureBox.TabStop = false;
            this.renderPictureBox.WaitOnLoad = true;
            this.renderPictureBox.SizeChanged += new System.EventHandler(this.pictureBox1_SizeChanged);
            // 
            // ControlsPanel
            // 
            this.ControlsPanel.Controls.Add(this.controlsGroupBox);
            this.ControlsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.ControlsPanel.Location = new System.Drawing.Point(578, 0);
            this.ControlsPanel.Name = "ControlsPanel";
            this.ControlsPanel.Size = new System.Drawing.Size(381, 671);
            this.ControlsPanel.TabIndex = 4;
            // 
            // controlsGroupBox
            // 
            this.controlsGroupBox.Controls.Add(this.panel3);
            this.controlsGroupBox.Controls.Add(this.groupBox5);
            this.controlsGroupBox.Controls.Add(this.panel2);
            this.controlsGroupBox.Controls.Add(this.panel1);
            this.controlsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlsGroupBox.Location = new System.Drawing.Point(0, 0);
            this.controlsGroupBox.Margin = new System.Windows.Forms.Padding(5);
            this.controlsGroupBox.Name = "controlsGroupBox";
            this.controlsGroupBox.Size = new System.Drawing.Size(381, 671);
            this.controlsGroupBox.TabIndex = 3;
            this.controlsGroupBox.TabStop = false;
            this.controlsGroupBox.Text = "Controls";
            // 
            // panel3
            // 
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.Controls.Add(this.startBttn);
            this.panel3.Controls.Add(this.pauseBttn);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 23);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(375, 74);
            this.panel3.TabIndex = 11;
            // 
            // startBttn
            // 
            this.startBttn.Location = new System.Drawing.Point(99, 3);
            this.startBttn.Name = "startBttn";
            this.startBttn.Size = new System.Drawing.Size(191, 29);
            this.startBttn.TabIndex = 0;
            this.startBttn.Text = "Start";
            this.startBttn.UseVisualStyleBackColor = true;
            // 
            // pauseBttn
            // 
            this.pauseBttn.Location = new System.Drawing.Point(99, 40);
            this.pauseBttn.Margin = new System.Windows.Forms.Padding(5);
            this.pauseBttn.Name = "pauseBttn";
            this.pauseBttn.Size = new System.Drawing.Size(191, 29);
            this.pauseBttn.TabIndex = 1;
            this.pauseBttn.Text = "Pause";
            this.pauseBttn.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox7);
            this.groupBox5.Controls.Add(this.groupBox6);
            this.groupBox5.Location = new System.Drawing.Point(196, 103);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(174, 213);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Vision";
            // 
            // groupBox7
            // 
            this.groupBox7.AutoSize = true;
            this.groupBox7.Controls.Add(this.panel6);
            this.groupBox7.Controls.Add(this.panel5);
            this.groupBox7.Controls.Add(this.panel4);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox7.Location = new System.Drawing.Point(3, 78);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(168, 122);
            this.groupBox7.TabIndex = 11;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Camera position";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.cameraZPositionNumericUpDown);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(3, 87);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(162, 32);
            this.panel6.TabIndex = 3;
            // 
            // cameraZPositionNumericUpDown
            // 
            this.cameraZPositionNumericUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cameraZPositionNumericUpDown.Location = new System.Drawing.Point(26, 0);
            this.cameraZPositionNumericUpDown.Name = "cameraZPositionNumericUpDown";
            this.cameraZPositionNumericUpDown.Size = new System.Drawing.Size(136, 27);
            this.cameraZPositionNumericUpDown.TabIndex = 3;
            this.cameraZPositionNumericUpDown.ValueChanged += new System.EventHandler(this.cameraZPositionNumericUpDown_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(5);
            this.label3.Size = new System.Drawing.Size(26, 30);
            this.label3.TabIndex = 0;
            this.label3.Text = "z";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.cameraYPositionNumericUpDown);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(3, 55);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(162, 32);
            this.panel5.TabIndex = 2;
            // 
            // cameraYPositionNumericUpDown
            // 
            this.cameraYPositionNumericUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cameraYPositionNumericUpDown.Location = new System.Drawing.Point(26, 0);
            this.cameraYPositionNumericUpDown.Name = "cameraYPositionNumericUpDown";
            this.cameraYPositionNumericUpDown.Size = new System.Drawing.Size(136, 27);
            this.cameraYPositionNumericUpDown.TabIndex = 3;
            this.cameraYPositionNumericUpDown.ValueChanged += new System.EventHandler(this.cameraYPositionNumericUpDown_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(5);
            this.label2.Size = new System.Drawing.Size(26, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "y";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cameraXPositionNumericUpDown);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 23);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(162, 32);
            this.panel4.TabIndex = 1;
            // 
            // cameraXPositionNumericUpDown
            // 
            this.cameraXPositionNumericUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cameraXPositionNumericUpDown.Location = new System.Drawing.Point(26, 0);
            this.cameraXPositionNumericUpDown.Name = "cameraXPositionNumericUpDown";
            this.cameraXPositionNumericUpDown.Size = new System.Drawing.Size(136, 27);
            this.cameraXPositionNumericUpDown.TabIndex = 2;
            this.cameraXPositionNumericUpDown.ValueChanged += new System.EventHandler(this.cameraXPositionNumericUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5);
            this.label1.Size = new System.Drawing.Size(26, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "x";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.FieldOfViewTrackBar);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.Location = new System.Drawing.Point(3, 23);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(168, 55);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "FOV";
            // 
            // FieldOfViewTrackBar
            // 
            this.FieldOfViewTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FieldOfViewTrackBar.Location = new System.Drawing.Point(3, 23);
            this.FieldOfViewTrackBar.Maximum = 156;
            this.FieldOfViewTrackBar.Name = "FieldOfViewTrackBar";
            this.FieldOfViewTrackBar.Size = new System.Drawing.Size(162, 29);
            this.FieldOfViewTrackBar.TabIndex = 4;
            this.FieldOfViewTrackBar.Value = 50;
            this.FieldOfViewTrackBar.ValueChanged += new System.EventHandler(this.FieldOfViewTrackBar_ValueChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Controls.Add(this.setRenderObjectBttn);
            this.panel2.Controls.Add(this.setRenderObjectColorBttn);
            this.panel2.Controls.Add(this.chngTextureBttn);
            this.panel2.Controls.Add(this.changeNormalMapBttn);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Location = new System.Drawing.Point(6, 361);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(184, 306);
            this.panel2.TabIndex = 9;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioButton2);
            this.groupBox4.Controls.Add(this.radioButton1);
            this.groupBox4.Location = new System.Drawing.Point(3, 108);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(171, 85);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Vector modification";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioButton2.Location = new System.Drawing.Point(3, 47);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(165, 24);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.Text = "Height Map";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioButton1.Location = new System.Drawing.Point(3, 23);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(165, 24);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.Text = "Normal Map";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // setRenderObjectBttn
            // 
            this.setRenderObjectBttn.AutoSize = true;
            this.setRenderObjectBttn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.setRenderObjectBttn.Location = new System.Drawing.Point(0, 188);
            this.setRenderObjectBttn.Name = "setRenderObjectBttn";
            this.setRenderObjectBttn.Size = new System.Drawing.Size(184, 30);
            this.setRenderObjectBttn.TabIndex = 4;
            this.setRenderObjectBttn.Text = "Set Render Object";
            this.setRenderObjectBttn.UseVisualStyleBackColor = true;
            // 
            // setRenderObjectColorBttn
            // 
            this.setRenderObjectColorBttn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.setRenderObjectColorBttn.Location = new System.Drawing.Point(0, 218);
            this.setRenderObjectColorBttn.Name = "setRenderObjectColorBttn";
            this.setRenderObjectColorBttn.Size = new System.Drawing.Size(184, 29);
            this.setRenderObjectColorBttn.TabIndex = 3;
            this.setRenderObjectColorBttn.Text = "Set Static Color";
            this.setRenderObjectColorBttn.UseVisualStyleBackColor = true;
            // 
            // chngTextureBttn
            // 
            this.chngTextureBttn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.chngTextureBttn.Location = new System.Drawing.Point(0, 247);
            this.chngTextureBttn.Name = "chngTextureBttn";
            this.chngTextureBttn.Size = new System.Drawing.Size(184, 29);
            this.chngTextureBttn.TabIndex = 2;
            this.chngTextureBttn.Text = "Set Texture";
            this.chngTextureBttn.UseVisualStyleBackColor = true;
            // 
            // changeNormalMapBttn
            // 
            this.changeNormalMapBttn.AutoSize = true;
            this.changeNormalMapBttn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.changeNormalMapBttn.Location = new System.Drawing.Point(0, 276);
            this.changeNormalMapBttn.Name = "changeNormalMapBttn";
            this.changeNormalMapBttn.Size = new System.Drawing.Size(184, 30);
            this.changeNormalMapBttn.TabIndex = 1;
            this.changeNormalMapBttn.Text = "Set Normal Map";
            this.changeNormalMapBttn.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.vectorInterpolationSetRadioBttn);
            this.groupBox3.Controls.Add(this.colorInterpolationSetRadioBttn);
            this.groupBox3.Location = new System.Drawing.Point(10, 9);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(163, 92);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Color computation";
            // 
            // vectorInterpolationSetRadioBttn
            // 
            this.vectorInterpolationSetRadioBttn.AutoSize = true;
            this.vectorInterpolationSetRadioBttn.Checked = true;
            this.vectorInterpolationSetRadioBttn.Location = new System.Drawing.Point(3, 61);
            this.vectorInterpolationSetRadioBttn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.vectorInterpolationSetRadioBttn.Name = "vectorInterpolationSetRadioBttn";
            this.vectorInterpolationSetRadioBttn.Size = new System.Drawing.Size(161, 24);
            this.vectorInterpolationSetRadioBttn.TabIndex = 1;
            this.vectorInterpolationSetRadioBttn.TabStop = true;
            this.vectorInterpolationSetRadioBttn.Text = "vector interpolation";
            this.vectorInterpolationSetRadioBttn.UseVisualStyleBackColor = true;
            // 
            // colorInterpolationSetRadioBttn
            // 
            this.colorInterpolationSetRadioBttn.AutoSize = true;
            this.colorInterpolationSetRadioBttn.Location = new System.Drawing.Point(7, 27);
            this.colorInterpolationSetRadioBttn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.colorInterpolationSetRadioBttn.Name = "colorInterpolationSetRadioBttn";
            this.colorInterpolationSetRadioBttn.Size = new System.Drawing.Size(154, 24);
            this.colorInterpolationSetRadioBttn.TabIndex = 0;
            this.colorInterpolationSetRadioBttn.Text = "color interpolation";
            this.colorInterpolationSetRadioBttn.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.mGroupBox);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.ksGroupBox);
            this.panel1.Location = new System.Drawing.Point(13, 103);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(177, 251);
            this.panel1.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.zValueTrackBar);
            this.groupBox2.Location = new System.Drawing.Point(7, 184);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(163, 55);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "z";
            // 
            // zValueTrackBar
            // 
            this.zValueTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zValueTrackBar.Location = new System.Drawing.Point(3, 23);
            this.zValueTrackBar.Maximum = 2000;
            this.zValueTrackBar.Minimum = 1;
            this.zValueTrackBar.Name = "zValueTrackBar";
            this.zValueTrackBar.Size = new System.Drawing.Size(157, 29);
            this.zValueTrackBar.TabIndex = 4;
            this.zValueTrackBar.Value = 50;
            // 
            // mGroupBox
            // 
            this.mGroupBox.Controls.Add(this.mTrackBar);
            this.mGroupBox.Location = new System.Drawing.Point(7, 124);
            this.mGroupBox.Name = "mGroupBox";
            this.mGroupBox.Size = new System.Drawing.Size(163, 55);
            this.mGroupBox.TabIndex = 7;
            this.mGroupBox.TabStop = false;
            this.mGroupBox.Text = "m";
            // 
            // mTrackBar
            // 
            this.mTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mTrackBar.Location = new System.Drawing.Point(3, 23);
            this.mTrackBar.Maximum = 100;
            this.mTrackBar.Minimum = 1;
            this.mTrackBar.Name = "mTrackBar";
            this.mTrackBar.Size = new System.Drawing.Size(157, 29);
            this.mTrackBar.TabIndex = 4;
            this.mTrackBar.Value = 50;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.kdTrackBar);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(170, 55);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "kd";
            // 
            // kdTrackBar
            // 
            this.kdTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kdTrackBar.Location = new System.Drawing.Point(3, 23);
            this.kdTrackBar.Maximum = 100;
            this.kdTrackBar.Name = "kdTrackBar";
            this.kdTrackBar.Size = new System.Drawing.Size(164, 29);
            this.kdTrackBar.TabIndex = 4;
            this.kdTrackBar.Value = 50;
            // 
            // ksGroupBox
            // 
            this.ksGroupBox.Controls.Add(this.ksTrackBar);
            this.ksGroupBox.Location = new System.Drawing.Point(3, 63);
            this.ksGroupBox.Name = "ksGroupBox";
            this.ksGroupBox.Size = new System.Drawing.Size(167, 56);
            this.ksGroupBox.TabIndex = 6;
            this.ksGroupBox.TabStop = false;
            this.ksGroupBox.Text = "ks";
            // 
            // ksTrackBar
            // 
            this.ksTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ksTrackBar.Location = new System.Drawing.Point(3, 23);
            this.ksTrackBar.Maximum = 100;
            this.ksTrackBar.Name = "ksTrackBar";
            this.ksTrackBar.Size = new System.Drawing.Size(161, 30);
            this.ksTrackBar.TabIndex = 4;
            this.ksTrackBar.Value = 50;
            // 
            // TopLevelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 671);
            this.Controls.Add(this.mainPanel);
            this.Name = "TopLevelForm";
            this.Text = "Light Simulation";
            this.mainPanel.ResumeLayout(false);
            this.canvasPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.renderPictureBox)).EndInit();
            this.ControlsPanel.ResumeLayout(false);
            this.controlsGroupBox.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cameraZPositionNumericUpDown)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cameraYPositionNumericUpDown)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cameraXPositionNumericUpDown)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FieldOfViewTrackBar)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zValueTrackBar)).EndInit();
            this.mGroupBox.ResumeLayout(false);
            this.mGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mTrackBar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kdTrackBar)).EndInit();
            this.ksGroupBox.ResumeLayout(false);
            this.ksGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ksTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel mainPanel;
        private Panel ControlsPanel;
        private GroupBox controlsGroupBox;
        private Panel panel3;
        private Button startBttn;
        private Button pauseBttn;
        private GroupBox groupBox5;
        private GroupBox groupBox7;
        private Panel panel6;
        private Label label3;
        private Panel panel5;
        private Label label2;
        private Panel panel4;
        private Label label1;
        private GroupBox groupBox6;
        private TrackBar FieldOfViewTrackBar;
        private Panel panel2;
        private GroupBox groupBox4;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Button setRenderObjectBttn;
        private Button setRenderObjectColorBttn;
        private Button chngTextureBttn;
        private Button changeNormalMapBttn;
        private GroupBox groupBox3;
        private RadioButton vectorInterpolationSetRadioBttn;
        private RadioButton colorInterpolationSetRadioBttn;
        private Panel panel1;
        private GroupBox groupBox2;
        private TrackBar zValueTrackBar;
        private GroupBox mGroupBox;
        private TrackBar mTrackBar;
        private GroupBox groupBox1;
        private TrackBar kdTrackBar;
        private GroupBox ksGroupBox;
        private TrackBar ksTrackBar;
        private Panel canvasPanel;
        private PictureBox renderPictureBox;
        private NumericUpDown cameraZPositionNumericUpDown;
        private NumericUpDown cameraYPositionNumericUpDown;
        private NumericUpDown cameraXPositionNumericUpDown;
    }
}
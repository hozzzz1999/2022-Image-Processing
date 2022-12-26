using System.Windows.Forms;

namespace imp_pj
{
    partial class form
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label_FilePath = new System.Windows.Forms.Label();
            this.textBox_ShowHeader = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem_File = new System.Windows.Forms.ToolStripMenuItem();
            this.Open_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Save_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invisibleHeaderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.demoDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Exit_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Editor = new System.Windows.Forms.ToolStripMenuItem();
            this.alphaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.slicingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bitPlaneSlicingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.watermarkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contrastStretchingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.presetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.circleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rectangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeingLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gammaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.greyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formulaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.averageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rGBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.equlizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.magicWandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.missAlignmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.negativeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rGBToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.grayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playPoolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rGBchannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Positive_RotationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Negative_RotationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scalingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linearInterpolationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setPixelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sNRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thresholdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otsuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mirrorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xAxisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yAxisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diagonal1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diagonal2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noiseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectComponentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lowpassFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.highpassFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cleanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.status_Coordinate_Bar = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_R = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_G = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_B = new System.Windows.Forms.ToolStripStatusLabel();
            this.textBox_PixelR = new System.Windows.Forms.TextBox();
            this.textBox_PixelG = new System.Windows.Forms.TextBox();
            this.textBox_PixelB = new System.Windows.Forms.TextBox();
            this.label_R = new System.Windows.Forms.Label();
            this.label_G = new System.Windows.Forms.Label();
            this.label_B = new System.Windows.Forms.Label();
            this.label_RD = new System.Windows.Forms.Label();
            this.textBox_RD = new System.Windows.Forms.TextBox();
            this.label_Zoom = new System.Windows.Forms.Label();
            this.textBox_Zoom = new System.Windows.Forms.TextBox();
            this.label_Alpha = new System.Windows.Forms.Label();
            this.textBox_Alpha = new System.Windows.Forms.TextBox();
            this.label_ShearX = new System.Windows.Forms.Label();
            this.textBox_shearX = new System.Windows.Forms.TextBox();
            this.textBox_MAoffset = new System.Windows.Forms.TextBox();
            this.label_MAoffset = new System.Windows.Forms.Label();
            this.pictureBox_Result = new System.Windows.Forms.PictureBox();
            this.pictureBox_Source = new System.Windows.Forms.PictureBox();
            this.button_showPalette = new System.Windows.Forms.Button();
            this.pictureBox_palette = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label_SNR = new System.Windows.Forms.Label();
            this.huffmanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.status_Coordinate_Bar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Source)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_palette)).BeginInit();
            this.SuspendLayout();
            // 
            // label_FilePath
            // 
            this.label_FilePath.AutoSize = true;
            this.label_FilePath.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label_FilePath.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_FilePath.Location = new System.Drawing.Point(16, 30);
            this.label_FilePath.Name = "label_FilePath";
            this.label_FilePath.Size = new System.Drawing.Size(369, 38);
            this.label_FilePath.TabIndex = 1;
            this.label_FilePath.Text = "To start with, please selete a .pcx file\r\nFrom File -> Open";
            // 
            // textBox_ShowHeader
            // 
            this.textBox_ShowHeader.BackColor = System.Drawing.Color.Ivory;
            this.textBox_ShowHeader.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_ShowHeader.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_ShowHeader.Location = new System.Drawing.Point(1029, 36);
            this.textBox_ShowHeader.Multiline = true;
            this.textBox_ShowHeader.Name = "textBox_ShowHeader";
            this.textBox_ShowHeader.Size = new System.Drawing.Size(383, 520);
            this.textBox_ShowHeader.TabIndex = 2;
            this.textBox_ShowHeader.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_File,
            this.toolStripMenuItem_Editor,
            this.filterToolStripMenuItem,
            this.videoVToolStripMenuItem,
            this.cleanToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1424, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem_File
            // 
            this.toolStripMenuItem_File.BackColor = System.Drawing.SystemColors.Info;
            this.toolStripMenuItem_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Open_ToolStripMenuItem,
            this.Save_ToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.invisibleHeaderToolStripMenuItem,
            this.demoDToolStripMenuItem,
            this.Exit_ToolStripMenuItem});
            this.toolStripMenuItem_File.Image = global::imp_pj.Properties.Resources.folder;
            this.toolStripMenuItem_File.Name = "toolStripMenuItem_File";
            this.toolStripMenuItem_File.Size = new System.Drawing.Size(72, 24);
            this.toolStripMenuItem_File.Text = "File(&F)";
            // 
            // Open_ToolStripMenuItem
            // 
            this.Open_ToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Open_ToolStripMenuItem.Image = global::imp_pj.Properties.Resources.open;
            this.Open_ToolStripMenuItem.Name = "Open_ToolStripMenuItem";
            this.Open_ToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.Open_ToolStripMenuItem.Text = "Open(&O)";
            this.Open_ToolStripMenuItem.Click += new System.EventHandler(this.FileOpen_Click);
            // 
            // Save_ToolStripMenuItem
            // 
            this.Save_ToolStripMenuItem.BackColor = System.Drawing.SystemColors.Info;
            this.Save_ToolStripMenuItem.Enabled = false;
            this.Save_ToolStripMenuItem.Image = global::imp_pj.Properties.Resources.diskette;
            this.Save_ToolStripMenuItem.Name = "Save_ToolStripMenuItem";
            this.Save_ToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.Save_ToolStripMenuItem.Text = "Save(&S)";
            this.Save_ToolStripMenuItem.Click += new System.EventHandler(this.Save_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Image = global::imp_pj.Properties.Resources.download;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.saveAsToolStripMenuItem.Text = "Save as(&A)";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.Save_as_Click);
            // 
            // invisibleHeaderToolStripMenuItem
            // 
            this.invisibleHeaderToolStripMenuItem.BackColor = System.Drawing.SystemColors.Info;
            this.invisibleHeaderToolStripMenuItem.Enabled = false;
            this.invisibleHeaderToolStripMenuItem.Image = global::imp_pj.Properties.Resources.hidden;
            this.invisibleHeaderToolStripMenuItem.Name = "invisibleHeaderToolStripMenuItem";
            this.invisibleHeaderToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.invisibleHeaderToolStripMenuItem.Text = "Invisible Header(&I)";
            this.invisibleHeaderToolStripMenuItem.Click += new System.EventHandler(this.Invisible_Header_Click);
            // 
            // demoDToolStripMenuItem
            // 
            this.demoDToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.demoDToolStripMenuItem.Enabled = false;
            this.demoDToolStripMenuItem.Image = global::imp_pj.Properties.Resources.demo;
            this.demoDToolStripMenuItem.Name = "demoDToolStripMenuItem";
            this.demoDToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.demoDToolStripMenuItem.Text = "Demo(&D)";
            this.demoDToolStripMenuItem.Click += new System.EventHandler(this.demo_Click);
            // 
            // Exit_ToolStripMenuItem
            // 
            this.Exit_ToolStripMenuItem.BackColor = System.Drawing.SystemColors.Info;
            this.Exit_ToolStripMenuItem.Image = global::imp_pj.Properties.Resources.logout__1_;
            this.Exit_ToolStripMenuItem.Name = "Exit_ToolStripMenuItem";
            this.Exit_ToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.Exit_ToolStripMenuItem.Text = "Exit(&E)";
            this.Exit_ToolStripMenuItem.Click += new System.EventHandler(this.Exit_Click);
            // 
            // toolStripMenuItem_Editor
            // 
            this.toolStripMenuItem_Editor.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toolStripMenuItem_Editor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alphaToolStripMenuItem,
            this.slicingToolStripMenuItem,
            this.contrastStretchingToolStripMenuItem,
            this.cutToolStripMenuItem,
            this.gammaToolStripMenuItem,
            this.greyToolStripMenuItem,
            this.histogramToolStripMenuItem,
            this.magicWandToolStripMenuItem,
            this.missAlignmentToolStripMenuItem,
            this.negativeToolStripMenuItem,
            this.playPoolToolStripMenuItem,
            this.rGBchannelToolStripMenuItem,
            this.rotationToolStripMenuItem,
            this.scalingToolStripMenuItem,
            this.setPixelToolStripMenuItem,
            this.shearToolStripMenuItem,
            this.sNRToolStripMenuItem,
            this.thresholdToolStripMenuItem,
            this.mirrorToolStripMenuItem,
            this.noiseToolStripMenuItem,
            this.connectComponentToolStripMenuItem,
            this.huffmanToolStripMenuItem});
            this.toolStripMenuItem_Editor.Image = global::imp_pj.Properties.Resources.image_editing;
            this.toolStripMenuItem_Editor.Name = "toolStripMenuItem_Editor";
            this.toolStripMenuItem_Editor.Size = new System.Drawing.Size(88, 24);
            this.toolStripMenuItem_Editor.Text = "Editor(&E)";
            // 
            // alphaToolStripMenuItem
            // 
            this.alphaToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.alphaToolStripMenuItem.Enabled = false;
            this.alphaToolStripMenuItem.Image = global::imp_pj.Properties.Resources.transparency;
            this.alphaToolStripMenuItem.Name = "alphaToolStripMenuItem";
            this.alphaToolStripMenuItem.Size = new System.Drawing.Size(211, 26);
            this.alphaToolStripMenuItem.Text = "Alpha(&A)";
            this.alphaToolStripMenuItem.Click += new System.EventHandler(this.Alpha_Click);
            // 
            // slicingToolStripMenuItem
            // 
            this.slicingToolStripMenuItem.BackColor = System.Drawing.SystemColors.Info;
            this.slicingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bitPlaneSlicingToolStripMenuItem,
            this.watermarkToolStripMenuItem,
            this.grayCodeToolStripMenuItem});
            this.slicingToolStripMenuItem.Enabled = false;
            this.slicingToolStripMenuItem.Image = global::imp_pj.Properties.Resources.ham;
            this.slicingToolStripMenuItem.Name = "slicingToolStripMenuItem";
            this.slicingToolStripMenuItem.Size = new System.Drawing.Size(211, 26);
            this.slicingToolStripMenuItem.Text = "Bit Plane(&B)";
            // 
            // bitPlaneSlicingToolStripMenuItem
            // 
            this.bitPlaneSlicingToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.bitPlaneSlicingToolStripMenuItem.Name = "bitPlaneSlicingToolStripMenuItem";
            this.bitPlaneSlicingToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.bitPlaneSlicingToolStripMenuItem.Text = "Bit-Plane Slicing(&B)";
            this.bitPlaneSlicingToolStripMenuItem.Click += new System.EventHandler(this.BitPlaneSlicing_Click);
            // 
            // watermarkToolStripMenuItem
            // 
            this.watermarkToolStripMenuItem.BackColor = System.Drawing.SystemColors.Info;
            this.watermarkToolStripMenuItem.Name = "watermarkToolStripMenuItem";
            this.watermarkToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.watermarkToolStripMenuItem.Text = "Watermark(&W)";
            this.watermarkToolStripMenuItem.Click += new System.EventHandler(this.Watermark_Click);
            // 
            // grayCodeToolStripMenuItem
            // 
            this.grayCodeToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.grayCodeToolStripMenuItem.Name = "grayCodeToolStripMenuItem";
            this.grayCodeToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.grayCodeToolStripMenuItem.Text = "Gray Code(&G)";
            this.grayCodeToolStripMenuItem.Click += new System.EventHandler(this.grayCode_Click);
            // 
            // contrastStretchingToolStripMenuItem
            // 
            this.contrastStretchingToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.contrastStretchingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manualToolStripMenuItem1,
            this.presetToolStripMenuItem});
            this.contrastStretchingToolStripMenuItem.Enabled = false;
            this.contrastStretchingToolStripMenuItem.Image = global::imp_pj.Properties.Resources.contrast;
            this.contrastStretchingToolStripMenuItem.Name = "contrastStretchingToolStripMenuItem";
            this.contrastStretchingToolStripMenuItem.Size = new System.Drawing.Size(211, 26);
            this.contrastStretchingToolStripMenuItem.Text = "Contrast Stretching(&C)";
            // 
            // manualToolStripMenuItem1
            // 
            this.manualToolStripMenuItem1.BackColor = System.Drawing.SystemColors.Info;
            this.manualToolStripMenuItem1.Name = "manualToolStripMenuItem1";
            this.manualToolStripMenuItem1.Size = new System.Drawing.Size(135, 22);
            this.manualToolStripMenuItem1.Text = "manual(&m)";
            this.manualToolStripMenuItem1.Click += new System.EventHandler(this.CSmanual_Click);
            // 
            // presetToolStripMenuItem
            // 
            this.presetToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.presetToolStripMenuItem.Name = "presetToolStripMenuItem";
            this.presetToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.presetToolStripMenuItem.Text = "preset(&p)";
            this.presetToolStripMenuItem.Click += new System.EventHandler(this.CSpreset_Click);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.BackColor = System.Drawing.SystemColors.Info;
            this.cutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.circleToolStripMenuItem,
            this.rectangleToolStripMenuItem,
            this.closeingLineToolStripMenuItem});
            this.cutToolStripMenuItem.Enabled = false;
            this.cutToolStripMenuItem.Image = global::imp_pj.Properties.Resources.scissors;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(211, 26);
            this.cutToolStripMenuItem.Text = "Crop(&E)";
            // 
            // circleToolStripMenuItem
            // 
            this.circleToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.circleToolStripMenuItem.Name = "circleToolStripMenuItem";
            this.circleToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.circleToolStripMenuItem.Text = "Oval(&O)";
            this.circleToolStripMenuItem.Click += new System.EventHandler(this.Crop_Oval_Click);
            // 
            // rectangleToolStripMenuItem
            // 
            this.rectangleToolStripMenuItem.BackColor = System.Drawing.SystemColors.Info;
            this.rectangleToolStripMenuItem.Name = "rectangleToolStripMenuItem";
            this.rectangleToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.rectangleToolStripMenuItem.Text = "Rectangle(&R)";
            this.rectangleToolStripMenuItem.Click += new System.EventHandler(this.Crop_Rectangle_Click);
            // 
            // closeingLineToolStripMenuItem
            // 
            this.closeingLineToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.closeingLineToolStripMenuItem.Name = "closeingLineToolStripMenuItem";
            this.closeingLineToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.closeingLineToolStripMenuItem.Text = "Close Line(&C)";
            this.closeingLineToolStripMenuItem.Click += new System.EventHandler(this.Crop_CloseLine_Click);
            // 
            // gammaToolStripMenuItem
            // 
            this.gammaToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gammaToolStripMenuItem.Enabled = false;
            this.gammaToolStripMenuItem.Image = global::imp_pj.Properties.Resources.gamma;
            this.gammaToolStripMenuItem.Name = "gammaToolStripMenuItem";
            this.gammaToolStripMenuItem.Size = new System.Drawing.Size(211, 26);
            this.gammaToolStripMenuItem.Text = "Gamma(&W)";
            this.gammaToolStripMenuItem.Click += new System.EventHandler(this.gammaToolStripMenuItem_Click);
            // 
            // greyToolStripMenuItem
            // 
            this.greyToolStripMenuItem.BackColor = System.Drawing.SystemColors.Info;
            this.greyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formulaToolStripMenuItem,
            this.averageToolStripMenuItem});
            this.greyToolStripMenuItem.Enabled = false;
            this.greyToolStripMenuItem.Image = global::imp_pj.Properties.Resources.black_and_white;
            this.greyToolStripMenuItem.Name = "greyToolStripMenuItem";
            this.greyToolStripMenuItem.Size = new System.Drawing.Size(211, 26);
            this.greyToolStripMenuItem.Text = "Gray(&G)";
            // 
            // formulaToolStripMenuItem
            // 
            this.formulaToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.formulaToolStripMenuItem.Name = "formulaToolStripMenuItem";
            this.formulaToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.formulaToolStripMenuItem.Text = "Formula(&F)";
            this.formulaToolStripMenuItem.Click += new System.EventHandler(this.Gray_Formula_Click);
            // 
            // averageToolStripMenuItem
            // 
            this.averageToolStripMenuItem.BackColor = System.Drawing.SystemColors.Info;
            this.averageToolStripMenuItem.Name = "averageToolStripMenuItem";
            this.averageToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.averageToolStripMenuItem.Text = "Average(&A)";
            this.averageToolStripMenuItem.Click += new System.EventHandler(this.Gray_Average_Click);
            // 
            // histogramToolStripMenuItem
            // 
            this.histogramToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.histogramToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.grayLevelToolStripMenuItem,
            this.rGBToolStripMenuItem,
            this.equlizationToolStripMenuItem});
            this.histogramToolStripMenuItem.Enabled = false;
            this.histogramToolStripMenuItem.Image = global::imp_pj.Properties.Resources.histogram;
            this.histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            this.histogramToolStripMenuItem.Size = new System.Drawing.Size(211, 26);
            this.histogramToolStripMenuItem.Text = "Histogram(&H)";
            // 
            // grayLevelToolStripMenuItem
            // 
            this.grayLevelToolStripMenuItem.BackColor = System.Drawing.SystemColors.Info;
            this.grayLevelToolStripMenuItem.Name = "grayLevelToolStripMenuItem";
            this.grayLevelToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.grayLevelToolStripMenuItem.Text = "Gray Level(&G)";
            this.grayLevelToolStripMenuItem.Click += new System.EventHandler(this.Histogram_Gray_Click);
            // 
            // rGBToolStripMenuItem
            // 
            this.rGBToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.rGBToolStripMenuItem.Name = "rGBToolStripMenuItem";
            this.rGBToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.rGBToolStripMenuItem.Text = "RGB(&R)";
            this.rGBToolStripMenuItem.Click += new System.EventHandler(this.Histogram_RGB_Click);
            // 
            // equlizationToolStripMenuItem
            // 
            this.equlizationToolStripMenuItem.BackColor = System.Drawing.SystemColors.Info;
            this.equlizationToolStripMenuItem.Name = "equlizationToolStripMenuItem";
            this.equlizationToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.equlizationToolStripMenuItem.Text = "Equlization(&E)";
            this.equlizationToolStripMenuItem.Click += new System.EventHandler(this.Histogeam_Equlization_Click);
            // 
            // magicWandToolStripMenuItem
            // 
            this.magicWandToolStripMenuItem.BackColor = System.Drawing.SystemColors.Info;
            this.magicWandToolStripMenuItem.Enabled = false;
            this.magicWandToolStripMenuItem.Image = global::imp_pj.Properties.Resources.magic_wand;
            this.magicWandToolStripMenuItem.Name = "magicWandToolStripMenuItem";
            this.magicWandToolStripMenuItem.Size = new System.Drawing.Size(211, 26);
            this.magicWandToolStripMenuItem.Text = "Magic Wand(&I)";
            this.magicWandToolStripMenuItem.Click += new System.EventHandler(this.MagicWand_Click);
            // 
            // missAlignmentToolStripMenuItem
            // 
            this.missAlignmentToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.missAlignmentToolStripMenuItem.Enabled = false;
            this.missAlignmentToolStripMenuItem.Image = global::imp_pj.Properties.Resources.blur;
            this.missAlignmentToolStripMenuItem.Name = "missAlignmentToolStripMenuItem";
            this.missAlignmentToolStripMenuItem.Size = new System.Drawing.Size(211, 26);
            this.missAlignmentToolStripMenuItem.Text = "Miss Alignment(&M)";
            this.missAlignmentToolStripMenuItem.Click += new System.EventHandler(this.MissAlignment_Click);
            // 
            // negativeToolStripMenuItem
            // 
            this.negativeToolStripMenuItem.BackColor = System.Drawing.SystemColors.Info;
            this.negativeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rGBToolStripMenuItem1,
            this.grayToolStripMenuItem});
            this.negativeToolStripMenuItem.Enabled = false;
            this.negativeToolStripMenuItem.Image = global::imp_pj.Properties.Resources.negative_ion;
            this.negativeToolStripMenuItem.Name = "negativeToolStripMenuItem";
            this.negativeToolStripMenuItem.Size = new System.Drawing.Size(211, 26);
            this.negativeToolStripMenuItem.Text = "Negative(&N)";
            // 
            // rGBToolStripMenuItem1
            // 
            this.rGBToolStripMenuItem1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.rGBToolStripMenuItem1.Name = "rGBToolStripMenuItem1";
            this.rGBToolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
            this.rGBToolStripMenuItem1.Text = "RGB(&R)";
            this.rGBToolStripMenuItem1.Click += new System.EventHandler(this.RGB_Negative);
            // 
            // grayToolStripMenuItem
            // 
            this.grayToolStripMenuItem.BackColor = System.Drawing.SystemColors.Info;
            this.grayToolStripMenuItem.Name = "grayToolStripMenuItem";
            this.grayToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.grayToolStripMenuItem.Text = "Gray(&G)";
            this.grayToolStripMenuItem.Click += new System.EventHandler(this.Gray_Negative);
            // 
            // playPoolToolStripMenuItem
            // 
            this.playPoolToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.playPoolToolStripMenuItem.Image = global::imp_pj.Properties.Resources.pool;
            this.playPoolToolStripMenuItem.Name = "playPoolToolStripMenuItem";
            this.playPoolToolStripMenuItem.Size = new System.Drawing.Size(211, 26);
            this.playPoolToolStripMenuItem.Text = "Play Pool(&P)";
            this.playPoolToolStripMenuItem.Click += new System.EventHandler(this.PlayPool_Click);
            // 
            // rGBchannelToolStripMenuItem
            // 
            this.rGBchannelToolStripMenuItem.BackColor = System.Drawing.SystemColors.Info;
            this.rGBchannelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rChannelToolStripMenuItem,
            this.gChannelToolStripMenuItem,
            this.bChannelToolStripMenuItem});
            this.rGBchannelToolStripMenuItem.Enabled = false;
            this.rGBchannelToolStripMenuItem.Image = global::imp_pj.Properties.Resources.rgb;
            this.rGBchannelToolStripMenuItem.Name = "rGBchannelToolStripMenuItem";
            this.rGBchannelToolStripMenuItem.Size = new System.Drawing.Size(211, 26);
            this.rGBchannelToolStripMenuItem.Text = "RGB Channel(&R)";
            // 
            // rChannelToolStripMenuItem
            // 
            this.rChannelToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.rChannelToolStripMenuItem.Name = "rChannelToolStripMenuItem";
            this.rChannelToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rChannelToolStripMenuItem.Text = "R Channel(&R)";
            this.rChannelToolStripMenuItem.Click += new System.EventHandler(this.R_Channel_Click);
            // 
            // gChannelToolStripMenuItem
            // 
            this.gChannelToolStripMenuItem.BackColor = System.Drawing.Color.Lime;
            this.gChannelToolStripMenuItem.Name = "gChannelToolStripMenuItem";
            this.gChannelToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.gChannelToolStripMenuItem.Text = "G Channel(&G)";
            this.gChannelToolStripMenuItem.Click += new System.EventHandler(this.G_Channel_Click);
            // 
            // bChannelToolStripMenuItem
            // 
            this.bChannelToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(205)))), ((int)(((byte)(236)))));
            this.bChannelToolStripMenuItem.Name = "bChannelToolStripMenuItem";
            this.bChannelToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bChannelToolStripMenuItem.Text = "B Channel(&B)";
            this.bChannelToolStripMenuItem.Click += new System.EventHandler(this.B_Channel_Click);
            // 
            // rotationToolStripMenuItem
            // 
            this.rotationToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.rotationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Positive_RotationToolStripMenuItem,
            this.Negative_RotationToolStripMenuItem});
            this.rotationToolStripMenuItem.Enabled = false;
            this.rotationToolStripMenuItem.Image = global::imp_pj.Properties.Resources.rotate;
            this.rotationToolStripMenuItem.Name = "rotationToolStripMenuItem";
            this.rotationToolStripMenuItem.Size = new System.Drawing.Size(211, 26);
            this.rotationToolStripMenuItem.Text = "Rotation(&T)";
            // 
            // Positive_RotationToolStripMenuItem
            // 
            this.Positive_RotationToolStripMenuItem.BackColor = System.Drawing.SystemColors.Info;
            this.Positive_RotationToolStripMenuItem.Name = "Positive_RotationToolStripMenuItem";
            this.Positive_RotationToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.Positive_RotationToolStripMenuItem.Text = "Positive Rotation(&P)";
            this.Positive_RotationToolStripMenuItem.Click += new System.EventHandler(this.Positive_Rotation_Click);
            // 
            // Negative_RotationToolStripMenuItem
            // 
            this.Negative_RotationToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Negative_RotationToolStripMenuItem.Name = "Negative_RotationToolStripMenuItem";
            this.Negative_RotationToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.Negative_RotationToolStripMenuItem.Text = "Negative Rotation(&N)";
            this.Negative_RotationToolStripMenuItem.Click += new System.EventHandler(this.Negative_Rotation_Click);
            // 
            // scalingToolStripMenuItem
            // 
            this.scalingToolStripMenuItem.BackColor = System.Drawing.SystemColors.Info;
            this.scalingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.duplicationToolStripMenuItem,
            this.linearInterpolationToolStripMenuItem});
            this.scalingToolStripMenuItem.Enabled = false;
            this.scalingToolStripMenuItem.Image = global::imp_pj.Properties.Resources.scale;
            this.scalingToolStripMenuItem.Name = "scalingToolStripMenuItem";
            this.scalingToolStripMenuItem.Size = new System.Drawing.Size(211, 26);
            this.scalingToolStripMenuItem.Text = "Scaling(&S)";
            // 
            // duplicationToolStripMenuItem
            // 
            this.duplicationToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.duplicationToolStripMenuItem.Name = "duplicationToolStripMenuItem";
            this.duplicationToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.duplicationToolStripMenuItem.Text = "Duplication(&D)";
            this.duplicationToolStripMenuItem.Click += new System.EventHandler(this.Zoom_Duplication_Click);
            // 
            // linearInterpolationToolStripMenuItem
            // 
            this.linearInterpolationToolStripMenuItem.BackColor = System.Drawing.SystemColors.Info;
            this.linearInterpolationToolStripMenuItem.Name = "linearInterpolationToolStripMenuItem";
            this.linearInterpolationToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.linearInterpolationToolStripMenuItem.Text = "Linear Interpolation(&L)";
            this.linearInterpolationToolStripMenuItem.Click += new System.EventHandler(this.Zoom_linearInterpolation_Click);
            // 
            // setPixelToolStripMenuItem
            // 
            this.setPixelToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.setPixelToolStripMenuItem.Enabled = false;
            this.setPixelToolStripMenuItem.Image = global::imp_pj.Properties.Resources.pen;
            this.setPixelToolStripMenuItem.Name = "setPixelToolStripMenuItem";
            this.setPixelToolStripMenuItem.Size = new System.Drawing.Size(211, 26);
            this.setPixelToolStripMenuItem.Text = "Set Pixel(&U)";
            this.setPixelToolStripMenuItem.Click += new System.EventHandler(this.SetPixel_Click);
            // 
            // shearToolStripMenuItem
            // 
            this.shearToolStripMenuItem.BackColor = System.Drawing.SystemColors.Info;
            this.shearToolStripMenuItem.Enabled = false;
            this.shearToolStripMenuItem.Image = global::imp_pj.Properties.Resources.shear;
            this.shearToolStripMenuItem.Name = "shearToolStripMenuItem";
            this.shearToolStripMenuItem.Size = new System.Drawing.Size(211, 26);
            this.shearToolStripMenuItem.Text = "Shear(&V)";
            this.shearToolStripMenuItem.Click += new System.EventHandler(this.Shear_Click);
            // 
            // sNRToolStripMenuItem
            // 
            this.sNRToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.sNRToolStripMenuItem.Enabled = false;
            this.sNRToolStripMenuItem.Image = global::imp_pj.Properties.Resources.noise;
            this.sNRToolStripMenuItem.Name = "sNRToolStripMenuItem";
            this.sNRToolStripMenuItem.Size = new System.Drawing.Size(211, 26);
            this.sNRToolStripMenuItem.Text = "SNR(&W)";
            this.sNRToolStripMenuItem.Click += new System.EventHandler(this.SNR_Click);
            // 
            // thresholdToolStripMenuItem
            // 
            this.thresholdToolStripMenuItem.BackColor = System.Drawing.SystemColors.Info;
            this.thresholdToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.otsuToolStripMenuItem,
            this.manualToolStripMenuItem});
            this.thresholdToolStripMenuItem.Enabled = false;
            this.thresholdToolStripMenuItem.Image = global::imp_pj.Properties.Resources.wave__1_;
            this.thresholdToolStripMenuItem.Name = "thresholdToolStripMenuItem";
            this.thresholdToolStripMenuItem.Size = new System.Drawing.Size(211, 26);
            this.thresholdToolStripMenuItem.Text = "Threshold(&T)";
            // 
            // otsuToolStripMenuItem
            // 
            this.otsuToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.otsuToolStripMenuItem.Name = "otsuToolStripMenuItem";
            this.otsuToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.otsuToolStripMenuItem.Text = "Otsu(&O)";
            this.otsuToolStripMenuItem.Click += new System.EventHandler(this.Threshold_Otsu_Click);
            // 
            // manualToolStripMenuItem
            // 
            this.manualToolStripMenuItem.BackColor = System.Drawing.SystemColors.Info;
            this.manualToolStripMenuItem.Name = "manualToolStripMenuItem";
            this.manualToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.manualToolStripMenuItem.Text = "Manual(&M)";
            this.manualToolStripMenuItem.Click += new System.EventHandler(this.Threshold_Manual_Click);
            // 
            // mirrorToolStripMenuItem
            // 
            this.mirrorToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.mirrorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xAxisToolStripMenuItem,
            this.yAxisToolStripMenuItem,
            this.diagonal1ToolStripMenuItem,
            this.diagonal2ToolStripMenuItem});
            this.mirrorToolStripMenuItem.Enabled = false;
            this.mirrorToolStripMenuItem.Image = global::imp_pj.Properties.Resources.flip;
            this.mirrorToolStripMenuItem.Name = "mirrorToolStripMenuItem";
            this.mirrorToolStripMenuItem.Size = new System.Drawing.Size(211, 26);
            this.mirrorToolStripMenuItem.Text = "Mirror(&F)";
            // 
            // xAxisToolStripMenuItem
            // 
            this.xAxisToolStripMenuItem.BackColor = System.Drawing.SystemColors.Info;
            this.xAxisToolStripMenuItem.Image = global::imp_pj.Properties.Resources.minus_horizontal_straight_line;
            this.xAxisToolStripMenuItem.Name = "xAxisToolStripMenuItem";
            this.xAxisToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.xAxisToolStripMenuItem.Text = "X - Axis(&X)";
            this.xAxisToolStripMenuItem.Click += new System.EventHandler(this.xAxis_Click);
            // 
            // yAxisToolStripMenuItem
            // 
            this.yAxisToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.yAxisToolStripMenuItem.Image = global::imp_pj.Properties.Resources.line;
            this.yAxisToolStripMenuItem.Name = "yAxisToolStripMenuItem";
            this.yAxisToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.yAxisToolStripMenuItem.Text = "Y - Axis(&Y)";
            this.yAxisToolStripMenuItem.Click += new System.EventHandler(this.yAxis_Click);
            // 
            // diagonal1ToolStripMenuItem
            // 
            this.diagonal1ToolStripMenuItem.BackColor = System.Drawing.SystemColors.Info;
            this.diagonal1ToolStripMenuItem.Image = global::imp_pj.Properties.Resources.diagonal_line;
            this.diagonal1ToolStripMenuItem.Name = "diagonal1ToolStripMenuItem";
            this.diagonal1ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.diagonal1ToolStripMenuItem.Text = "Diagonal1(&1)";
            this.diagonal1ToolStripMenuItem.Click += new System.EventHandler(this.diagonal1_Click);
            // 
            // diagonal2ToolStripMenuItem
            // 
            this.diagonal2ToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.diagonal2ToolStripMenuItem.Image = global::imp_pj.Properties.Resources.diagonal_line__1_;
            this.diagonal2ToolStripMenuItem.Name = "diagonal2ToolStripMenuItem";
            this.diagonal2ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.diagonal2ToolStripMenuItem.Text = "Diagonal2(&2)";
            this.diagonal2ToolStripMenuItem.Click += new System.EventHandler(this.diagonal2_Click);
            // 
            // noiseToolStripMenuItem
            // 
            this.noiseToolStripMenuItem.BackColor = System.Drawing.SystemColors.Info;
            this.noiseToolStripMenuItem.Enabled = false;
            this.noiseToolStripMenuItem.Image = global::imp_pj.Properties.Resources.noise1;
            this.noiseToolStripMenuItem.Name = "noiseToolStripMenuItem";
            this.noiseToolStripMenuItem.Size = new System.Drawing.Size(211, 26);
            this.noiseToolStripMenuItem.Text = "Noise(&J)";
            this.noiseToolStripMenuItem.Click += new System.EventHandler(this.noise_SaltNPepper_Click);
            // 
            // connectComponentToolStripMenuItem
            // 
            this.connectComponentToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.connectComponentToolStripMenuItem.Enabled = false;
            this.connectComponentToolStripMenuItem.Image = global::imp_pj.Properties.Resources.marketing;
            this.connectComponentToolStripMenuItem.Name = "connectComponentToolStripMenuItem";
            this.connectComponentToolStripMenuItem.Size = new System.Drawing.Size(211, 26);
            this.connectComponentToolStripMenuItem.Text = "Connect Component(&Y)";
            this.connectComponentToolStripMenuItem.Click += new System.EventHandler(this.connectComponentToolStripMenuItem_Click);
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.BackColor = System.Drawing.SystemColors.Info;
            this.filterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lowpassFilterToolStripMenuItem,
            this.highpassFilterToolStripMenuItem});
            this.filterToolStripMenuItem.Image = global::imp_pj.Properties.Resources.selective;
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(80, 24);
            this.filterToolStripMenuItem.Text = "Filter(&F)";
            // 
            // lowpassFilterToolStripMenuItem
            // 
            this.lowpassFilterToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lowpassFilterToolStripMenuItem.Enabled = false;
            this.lowpassFilterToolStripMenuItem.Name = "lowpassFilterToolStripMenuItem";
            this.lowpassFilterToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.lowpassFilterToolStripMenuItem.Text = "Lowpass Filter(&L)";
            this.lowpassFilterToolStripMenuItem.Click += new System.EventHandler(this.lowpassFilter_Click);
            // 
            // highpassFilterToolStripMenuItem
            // 
            this.highpassFilterToolStripMenuItem.BackColor = System.Drawing.SystemColors.Info;
            this.highpassFilterToolStripMenuItem.Enabled = false;
            this.highpassFilterToolStripMenuItem.Name = "highpassFilterToolStripMenuItem";
            this.highpassFilterToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.highpassFilterToolStripMenuItem.Text = "Highpass Filter(&H)";
            this.highpassFilterToolStripMenuItem.Click += new System.EventHandler(this.highpassFilter_Click);
            // 
            // videoVToolStripMenuItem
            // 
            this.videoVToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.videoVToolStripMenuItem.Image = global::imp_pj.Properties.Resources.video_camera;
            this.videoVToolStripMenuItem.Name = "videoVToolStripMenuItem";
            this.videoVToolStripMenuItem.Size = new System.Drawing.Size(89, 24);
            this.videoVToolStripMenuItem.Text = "Video(&V)";
            this.videoVToolStripMenuItem.Click += new System.EventHandler(this.videoVToolStripMenuItem_Click);
            // 
            // cleanToolStripMenuItem
            // 
            this.cleanToolStripMenuItem.BackColor = System.Drawing.SystemColors.Info;
            this.cleanToolStripMenuItem.Image = global::imp_pj.Properties.Resources.brush;
            this.cleanToolStripMenuItem.Name = "cleanToolStripMenuItem";
            this.cleanToolStripMenuItem.Size = new System.Drawing.Size(87, 24);
            this.cleanToolStripMenuItem.Text = "Clean(&C)";
            this.cleanToolStripMenuItem.Click += new System.EventHandler(this.Clean_Click);
            // 
            // status_Coordinate_Bar
            // 
            this.status_Coordinate_Bar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.status_Coordinate_Bar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel_R,
            this.toolStripStatusLabel_G,
            this.toolStripStatusLabel_B});
            this.status_Coordinate_Bar.Location = new System.Drawing.Point(0, 659);
            this.status_Coordinate_Bar.Name = "status_Coordinate_Bar";
            this.status_Coordinate_Bar.Size = new System.Drawing.Size(1424, 22);
            this.status_Coordinate_Bar.TabIndex = 5;
            this.status_Coordinate_Bar.TabStop = true;
            this.status_Coordinate_Bar.Text = "statusStrip1";
            this.status_Coordinate_Bar.Visible = false;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.Cornsilk;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BackColor = System.Drawing.Color.Cornsilk;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel_R
            // 
            this.toolStripStatusLabel_R.BackColor = System.Drawing.Color.Cornsilk;
            this.toolStripStatusLabel_R.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabel_R.Name = "toolStripStatusLabel_R";
            this.toolStripStatusLabel_R.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel_G
            // 
            this.toolStripStatusLabel_G.BackColor = System.Drawing.Color.Cornsilk;
            this.toolStripStatusLabel_G.ForeColor = System.Drawing.Color.Green;
            this.toolStripStatusLabel_G.Name = "toolStripStatusLabel_G";
            this.toolStripStatusLabel_G.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel_B
            // 
            this.toolStripStatusLabel_B.BackColor = System.Drawing.Color.Cornsilk;
            this.toolStripStatusLabel_B.ForeColor = System.Drawing.Color.Blue;
            this.toolStripStatusLabel_B.Name = "toolStripStatusLabel_B";
            this.toolStripStatusLabel_B.Size = new System.Drawing.Size(0, 17);
            // 
            // textBox_PixelR
            // 
            this.textBox_PixelR.BackColor = System.Drawing.Color.Red;
            this.textBox_PixelR.Font = new System.Drawing.Font("Consolas", 12F);
            this.textBox_PixelR.ForeColor = System.Drawing.Color.White;
            this.textBox_PixelR.Location = new System.Drawing.Point(45, 432);
            this.textBox_PixelR.MaxLength = 3;
            this.textBox_PixelR.Name = "textBox_PixelR";
            this.textBox_PixelR.Size = new System.Drawing.Size(100, 26);
            this.textBox_PixelR.TabIndex = 7;
            this.textBox_PixelR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_PixelR.Visible = false;
            // 
            // textBox_PixelG
            // 
            this.textBox_PixelG.BackColor = System.Drawing.Color.Green;
            this.textBox_PixelG.Font = new System.Drawing.Font("Consolas", 12F);
            this.textBox_PixelG.ForeColor = System.Drawing.Color.White;
            this.textBox_PixelG.Location = new System.Drawing.Point(45, 467);
            this.textBox_PixelG.MaxLength = 3;
            this.textBox_PixelG.Name = "textBox_PixelG";
            this.textBox_PixelG.Size = new System.Drawing.Size(100, 26);
            this.textBox_PixelG.TabIndex = 8;
            this.textBox_PixelG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_PixelG.Visible = false;
            // 
            // textBox_PixelB
            // 
            this.textBox_PixelB.BackColor = System.Drawing.Color.Blue;
            this.textBox_PixelB.Font = new System.Drawing.Font("Consolas", 12F);
            this.textBox_PixelB.ForeColor = System.Drawing.Color.White;
            this.textBox_PixelB.Location = new System.Drawing.Point(45, 502);
            this.textBox_PixelB.MaxLength = 3;
            this.textBox_PixelB.Name = "textBox_PixelB";
            this.textBox_PixelB.Size = new System.Drawing.Size(100, 26);
            this.textBox_PixelB.TabIndex = 9;
            this.textBox_PixelB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_PixelB.Visible = false;
            // 
            // label_R
            // 
            this.label_R.AutoSize = true;
            this.label_R.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_R.ForeColor = System.Drawing.Color.Red;
            this.label_R.Location = new System.Drawing.Point(16, 435);
            this.label_R.Name = "label_R";
            this.label_R.Size = new System.Drawing.Size(27, 19);
            this.label_R.TabIndex = 10;
            this.label_R.Text = "R:";
            this.label_R.Visible = false;
            // 
            // label_G
            // 
            this.label_G.AutoSize = true;
            this.label_G.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_G.ForeColor = System.Drawing.Color.Green;
            this.label_G.Location = new System.Drawing.Point(16, 470);
            this.label_G.Name = "label_G";
            this.label_G.Size = new System.Drawing.Size(27, 19);
            this.label_G.TabIndex = 11;
            this.label_G.Text = "G:";
            this.label_G.Visible = false;
            // 
            // label_B
            // 
            this.label_B.AutoSize = true;
            this.label_B.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_B.ForeColor = System.Drawing.Color.Blue;
            this.label_B.Location = new System.Drawing.Point(16, 505);
            this.label_B.Name = "label_B";
            this.label_B.Size = new System.Drawing.Size(27, 19);
            this.label_B.TabIndex = 12;
            this.label_B.Text = "B:";
            this.label_B.Visible = false;
            // 
            // label_RD
            // 
            this.label_RD.AutoSize = true;
            this.label_RD.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_RD.Location = new System.Drawing.Point(145, 435);
            this.label_RD.Name = "label_RD";
            this.label_RD.Size = new System.Drawing.Size(135, 19);
            this.label_RD.TabIndex = 13;
            this.label_RD.Text = "Rotate Degree:";
            this.label_RD.Visible = false;
            // 
            // textBox_RD
            // 
            this.textBox_RD.BackColor = System.Drawing.Color.Lavender;
            this.textBox_RD.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_RD.Location = new System.Drawing.Point(280, 432);
            this.textBox_RD.MaxLength = 4;
            this.textBox_RD.Name = "textBox_RD";
            this.textBox_RD.Size = new System.Drawing.Size(100, 26);
            this.textBox_RD.TabIndex = 14;
            this.textBox_RD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_RD.Visible = false;
            this.textBox_RD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Rotaion_KeyDown);
            // 
            // label_Zoom
            // 
            this.label_Zoom.AutoSize = true;
            this.label_Zoom.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Zoom.Location = new System.Drawing.Point(172, 470);
            this.label_Zoom.Name = "label_Zoom";
            this.label_Zoom.Size = new System.Drawing.Size(108, 19);
            this.label_Zoom.TabIndex = 15;
            this.label_Zoom.Text = "Zoom Ratio:";
            this.label_Zoom.Visible = false;
            // 
            // textBox_Zoom
            // 
            this.textBox_Zoom.BackColor = System.Drawing.Color.Lavender;
            this.textBox_Zoom.Font = new System.Drawing.Font("Consolas", 12F);
            this.textBox_Zoom.Location = new System.Drawing.Point(280, 467);
            this.textBox_Zoom.MaxLength = 4;
            this.textBox_Zoom.Name = "textBox_Zoom";
            this.textBox_Zoom.Size = new System.Drawing.Size(100, 26);
            this.textBox_Zoom.TabIndex = 16;
            this.textBox_Zoom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Zoom.Visible = false;
            this.textBox_Zoom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Zoom_KeyDown);
            // 
            // label_Alpha
            // 
            this.label_Alpha.AutoSize = true;
            this.label_Alpha.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Alpha.Location = new System.Drawing.Point(217, 505);
            this.label_Alpha.Name = "label_Alpha";
            this.label_Alpha.Size = new System.Drawing.Size(63, 19);
            this.label_Alpha.TabIndex = 18;
            this.label_Alpha.Text = "Alpha:";
            this.label_Alpha.Visible = false;
            // 
            // textBox_Alpha
            // 
            this.textBox_Alpha.BackColor = System.Drawing.Color.Lavender;
            this.textBox_Alpha.Font = new System.Drawing.Font("Consolas", 12F);
            this.textBox_Alpha.Location = new System.Drawing.Point(280, 502);
            this.textBox_Alpha.MaxLength = 3;
            this.textBox_Alpha.Name = "textBox_Alpha";
            this.textBox_Alpha.Size = new System.Drawing.Size(100, 26);
            this.textBox_Alpha.TabIndex = 19;
            this.textBox_Alpha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Alpha.Visible = false;
            this.textBox_Alpha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Alpha_KeyDown);
            // 
            // label_ShearX
            // 
            this.label_ShearX.AutoSize = true;
            this.label_ShearX.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ShearX.Location = new System.Drawing.Point(208, 540);
            this.label_ShearX.Name = "label_ShearX";
            this.label_ShearX.Size = new System.Drawing.Size(72, 19);
            this.label_ShearX.TabIndex = 20;
            this.label_ShearX.Text = "shearX:";
            this.label_ShearX.Visible = false;
            // 
            // textBox_shearX
            // 
            this.textBox_shearX.BackColor = System.Drawing.Color.Lavender;
            this.textBox_shearX.Font = new System.Drawing.Font("Consolas", 12F);
            this.textBox_shearX.Location = new System.Drawing.Point(280, 537);
            this.textBox_shearX.MaxLength = 5;
            this.textBox_shearX.Name = "textBox_shearX";
            this.textBox_shearX.Size = new System.Drawing.Size(100, 26);
            this.textBox_shearX.TabIndex = 22;
            this.textBox_shearX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_shearX.Visible = false;
            this.textBox_shearX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ShearX_KeyDown);
            // 
            // textBox_MAoffset
            // 
            this.textBox_MAoffset.BackColor = System.Drawing.Color.Lavender;
            this.textBox_MAoffset.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_MAoffset.Location = new System.Drawing.Point(280, 569);
            this.textBox_MAoffset.MaxLength = 5;
            this.textBox_MAoffset.Name = "textBox_MAoffset";
            this.textBox_MAoffset.Size = new System.Drawing.Size(100, 26);
            this.textBox_MAoffset.TabIndex = 24;
            this.textBox_MAoffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_MAoffset.Visible = false;
            this.textBox_MAoffset.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_MAoffset_KeyDown);
            // 
            // label_MAoffset
            // 
            this.label_MAoffset.AutoSize = true;
            this.label_MAoffset.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_MAoffset.Location = new System.Drawing.Point(172, 572);
            this.label_MAoffset.Name = "label_MAoffset";
            this.label_MAoffset.Size = new System.Drawing.Size(108, 19);
            this.label_MAoffset.TabIndex = 25;
            this.label_MAoffset.Text = "RGB offset:";
            this.label_MAoffset.Visible = false;
            // 
            // pictureBox_Result
            // 
            this.pictureBox_Result.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Result.Location = new System.Drawing.Point(414, 73);
            this.pictureBox_Result.Name = "pictureBox_Result";
            this.pictureBox_Result.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_Result.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox_Result.TabIndex = 6;
            this.pictureBox_Result.TabStop = false;
            // 
            // pictureBox_Source
            // 
            this.pictureBox_Source.Location = new System.Drawing.Point(16, 73);
            this.pictureBox_Source.Name = "pictureBox_Source";
            this.pictureBox_Source.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_Source.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox_Source.TabIndex = 4;
            this.pictureBox_Source.TabStop = false;
            this.pictureBox_Source.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            this.pictureBox_Source.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Set_Pixel_Method);
            this.pictureBox_Source.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Crop_MouseDown);
            this.pictureBox_Source.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ShowCoordinateAndRGB);
            this.pictureBox_Source.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Crop_MouseUp);
            // 
            // button_showPalette
            // 
            this.button_showPalette.Font = new System.Drawing.Font("Consolas", 12F);
            this.button_showPalette.Location = new System.Drawing.Point(1072, 562);
            this.button_showPalette.Name = "button_showPalette";
            this.button_showPalette.Size = new System.Drawing.Size(297, 28);
            this.button_showPalette.TabIndex = 26;
            this.button_showPalette.Text = "Show Palette";
            this.button_showPalette.UseVisualStyleBackColor = true;
            this.button_showPalette.Visible = false;
            this.button_showPalette.Click += new System.EventHandler(this.ShowPalette_Click);
            // 
            // pictureBox_palette
            // 
            this.pictureBox_palette.Location = new System.Drawing.Point(842, 378);
            this.pictureBox_palette.Name = "pictureBox_palette";
            this.pictureBox_palette.Size = new System.Drawing.Size(160, 160);
            this.pictureBox_palette.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox_palette.TabIndex = 27;
            this.pictureBox_palette.TabStop = false;
            this.pictureBox_palette.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label_SNR
            // 
            this.label_SNR.AutoSize = true;
            this.label_SNR.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SNR.Location = new System.Drawing.Point(410, 332);
            this.label_SNR.Name = "label_SNR";
            this.label_SNR.Size = new System.Drawing.Size(45, 19);
            this.label_SNR.TabIndex = 29;
            this.label_SNR.Text = "SNR:";
            this.label_SNR.Visible = false;
            // 
            // huffmanToolStripMenuItem
            // 
            this.huffmanToolStripMenuItem.Name = "huffmanToolStripMenuItem";
            this.huffmanToolStripMenuItem.Size = new System.Drawing.Size(211, 26);
            this.huffmanToolStripMenuItem.Text = "Huffman()";
            this.huffmanToolStripMenuItem.Click += new System.EventHandler(this.huffmanToolStripMenuItem_Click);
            // 
            // form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1424, 609);
            this.Controls.Add(this.label_SNR);
            this.Controls.Add(this.pictureBox_palette);
            this.Controls.Add(this.button_showPalette);
            this.Controls.Add(this.label_MAoffset);
            this.Controls.Add(this.textBox_MAoffset);
            this.Controls.Add(this.textBox_shearX);
            this.Controls.Add(this.label_ShearX);
            this.Controls.Add(this.textBox_Alpha);
            this.Controls.Add(this.label_Alpha);
            this.Controls.Add(this.textBox_Zoom);
            this.Controls.Add(this.label_Zoom);
            this.Controls.Add(this.textBox_RD);
            this.Controls.Add(this.label_RD);
            this.Controls.Add(this.label_B);
            this.Controls.Add(this.label_G);
            this.Controls.Add(this.label_R);
            this.Controls.Add(this.textBox_PixelB);
            this.Controls.Add(this.textBox_PixelG);
            this.Controls.Add(this.textBox_PixelR);
            this.Controls.Add(this.pictureBox_Result);
            this.Controls.Add(this.status_Coordinate_Bar);
            this.Controls.Add(this.pictureBox_Source);
            this.Controls.Add(this.textBox_ShowHeader);
            this.Controls.Add(this.label_FilePath);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = global::imp_pj.Properties.Resources.image;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "form";
            this.Text = "Image Process Project";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.status_Coordinate_Bar.ResumeLayout(false);
            this.status_Coordinate_Bar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Source)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_palette)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_FilePath;
        private System.Windows.Forms.TextBox textBox_ShowHeader;
        private System.Windows.Forms.PictureBox pictureBox_Source;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_File;
        private System.Windows.Forms.ToolStripMenuItem Open_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Save_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Exit_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Editor;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip status_Coordinate_Bar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_R;
        private System.Windows.Forms.ToolStripMenuItem rGBchannelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scalingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rChannelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gChannelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bChannelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Positive_RotationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Negative_RotationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem circleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rectangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeingLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playPoolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alphaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem missAlignmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem negativeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem histogramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thresholdToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox_Result;
        private System.Windows.Forms.TextBox textBox_PixelR;
        private System.Windows.Forms.TextBox textBox_PixelG;
        private System.Windows.Forms.TextBox textBox_PixelB;
        private System.Windows.Forms.Label label_R;
        private System.Windows.Forms.Label label_G;
        private System.Windows.Forms.Label label_B;
        private System.Windows.Forms.Label label_RD;
        private System.Windows.Forms.TextBox textBox_RD;
        private System.Windows.Forms.Label label_Zoom;
        private System.Windows.Forms.ToolStripMenuItem duplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linearInterpolationToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox_Zoom;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.Label label_Alpha;
        private System.Windows.Forms.TextBox textBox_Alpha;
        private System.Windows.Forms.Label label_ShearX;
        private System.Windows.Forms.TextBox textBox_shearX;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_G;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_B;
        private System.Windows.Forms.ToolStripMenuItem setPixelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invisibleHeaderToolStripMenuItem;
        private ToolStripMenuItem greyToolStripMenuItem;
        private ToolStripMenuItem formulaToolStripMenuItem;
        private ToolStripMenuItem averageToolStripMenuItem;
        private ToolStripMenuItem cleanToolStripMenuItem;
        private TextBox textBox_MAoffset;
        private Label label_MAoffset;
        private ToolStripMenuItem otsuToolStripMenuItem;
        private ToolStripMenuItem manualToolStripMenuItem;
        private ToolStripMenuItem grayLevelToolStripMenuItem;
        private ToolStripMenuItem rGBToolStripMenuItem;
        private ToolStripMenuItem equlizationToolStripMenuItem;
        private ToolStripMenuItem slicingToolStripMenuItem;
        private ToolStripMenuItem bitPlaneSlicingToolStripMenuItem;
        private ToolStripMenuItem watermarkToolStripMenuItem;
        private ToolStripMenuItem sNRToolStripMenuItem;
        private ToolStripMenuItem magicWandToolStripMenuItem;
        private ToolStripMenuItem contrastStretchingToolStripMenuItem;
        private Button button_showPalette;
        private PictureBox pictureBox_palette;
        private Timer timer1;
        private ToolStripMenuItem filterToolStripMenuItem;
        private ToolStripMenuItem mirrorToolStripMenuItem;
        private ToolStripMenuItem xAxisToolStripMenuItem;
        private ToolStripMenuItem yAxisToolStripMenuItem;
        private ToolStripMenuItem diagonal1ToolStripMenuItem;
        private ToolStripMenuItem diagonal2ToolStripMenuItem;
        private ToolStripMenuItem grayCodeToolStripMenuItem;
        private ToolStripMenuItem noiseToolStripMenuItem;
        private Label label_SNR;
        private ToolStripMenuItem demoDToolStripMenuItem;
        private ToolStripMenuItem rGBToolStripMenuItem1;
        private ToolStripMenuItem grayToolStripMenuItem;
        private ToolStripMenuItem connectComponentToolStripMenuItem;
        private ToolStripMenuItem lowpassFilterToolStripMenuItem;
        private ToolStripMenuItem highpassFilterToolStripMenuItem;
        private ToolStripMenuItem videoVToolStripMenuItem;
        private ToolStripMenuItem manualToolStripMenuItem1;
        private ToolStripMenuItem presetToolStripMenuItem;
        private ToolStripMenuItem gammaToolStripMenuItem;
        private ToolStripMenuItem huffmanToolStripMenuItem;
    }
}


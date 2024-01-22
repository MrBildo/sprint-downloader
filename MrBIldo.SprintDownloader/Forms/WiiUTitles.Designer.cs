namespace MrBildo.SprintDownloader.Forms
{
    partial class WiiUTitles
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelMain = new Panel();
            dataGridQueued = new DataGridView();
            panelControls = new Panel();
            buttonMoveAllQueuedTitles = new Button();
            buttonMoveSelectedQueuedTitle = new Button();
            buttonMoveAllTitles = new Button();
            buttonMoveSelectedTitles = new Button();
            groupFilters = new GroupBox();
            textBoxFilter = new TextBox();
            labelFilter = new Label();
            checkBoxOther = new CheckBox();
            checkBoxDemos = new CheckBox();
            checkBoxUpdates = new CheckBox();
            checkBoxDLC = new CheckBox();
            labelCategory = new Label();
            checkBoxGames = new CheckBox();
            labelRegions = new Label();
            checkBoxJapan = new CheckBox();
            checkBoxEurope = new CheckBox();
            checkBoxUSA = new CheckBox();
            splitterMain = new Splitter();
            dataGridTitles = new DataGridView();
            buttonCancel = new Button();
            buttonOK = new Button();
            panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridQueued).BeginInit();
            panelControls.SuspendLayout();
            groupFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridTitles).BeginInit();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelMain.Controls.Add(dataGridQueued);
            panelMain.Controls.Add(panelControls);
            panelMain.Controls.Add(splitterMain);
            panelMain.Controls.Add(dataGridTitles);
            panelMain.Location = new Point(12, 12);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1915, 1035);
            panelMain.TabIndex = 0;
            // 
            // dataGridQueued
            // 
            dataGridQueued.AllowUserToAddRows = false;
            dataGridQueued.AllowUserToDeleteRows = false;
            dataGridQueued.AllowUserToResizeRows = false;
            dataGridQueued.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridQueued.Dock = DockStyle.Fill;
            dataGridQueued.Location = new Point(1104, 0);
            dataGridQueued.Name = "dataGridQueued";
            dataGridQueued.ReadOnly = true;
            dataGridQueued.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridQueued.ShowEditingIcon = false;
            dataGridQueued.Size = new Size(811, 1035);
            dataGridQueued.TabIndex = 7;
            dataGridQueued.CellDoubleClick += dataGridQueued_CellDoubleClick;
            // 
            // panelControls
            // 
            panelControls.BackColor = SystemColors.Control;
            panelControls.Controls.Add(buttonMoveAllQueuedTitles);
            panelControls.Controls.Add(buttonMoveSelectedQueuedTitle);
            panelControls.Controls.Add(buttonMoveAllTitles);
            panelControls.Controls.Add(buttonMoveSelectedTitles);
            panelControls.Controls.Add(groupFilters);
            panelControls.Dock = DockStyle.Left;
            panelControls.Location = new Point(804, 0);
            panelControls.Name = "panelControls";
            panelControls.Size = new Size(300, 1035);
            panelControls.TabIndex = 6;
            // 
            // buttonMoveAllQueuedTitles
            // 
            buttonMoveAllQueuedTitles.Location = new Point(95, 550);
            buttonMoveAllQueuedTitles.Name = "buttonMoveAllQueuedTitles";
            buttonMoveAllQueuedTitles.Size = new Size(100, 35);
            buttonMoveAllQueuedTitles.TabIndex = 4;
            buttonMoveAllQueuedTitles.Text = "<< Move All";
            buttonMoveAllQueuedTitles.UseVisualStyleBackColor = true;
            buttonMoveAllQueuedTitles.Click += OnMoveAllQueuedTitles;
            // 
            // buttonMoveSelectedQueuedTitle
            // 
            buttonMoveSelectedQueuedTitle.Location = new Point(95, 500);
            buttonMoveSelectedQueuedTitle.Name = "buttonMoveSelectedQueuedTitle";
            buttonMoveSelectedQueuedTitle.Size = new Size(100, 35);
            buttonMoveSelectedQueuedTitle.TabIndex = 3;
            buttonMoveSelectedQueuedTitle.Text = "<< Move";
            buttonMoveSelectedQueuedTitle.UseVisualStyleBackColor = true;
            buttonMoveSelectedQueuedTitle.Click += OnMoveSelectedQueuedTitle;
            // 
            // buttonMoveAllTitles
            // 
            buttonMoveAllTitles.Location = new Point(95, 450);
            buttonMoveAllTitles.Name = "buttonMoveAllTitles";
            buttonMoveAllTitles.Size = new Size(100, 35);
            buttonMoveAllTitles.TabIndex = 2;
            buttonMoveAllTitles.Text = "Move All >>";
            buttonMoveAllTitles.UseVisualStyleBackColor = true;
            buttonMoveAllTitles.Click += OnMoveAllTitles;
            // 
            // buttonMoveSelectedTitles
            // 
            buttonMoveSelectedTitles.Location = new Point(95, 400);
            buttonMoveSelectedTitles.Name = "buttonMoveSelectedTitles";
            buttonMoveSelectedTitles.Size = new Size(100, 35);
            buttonMoveSelectedTitles.TabIndex = 1;
            buttonMoveSelectedTitles.Text = "Move >>";
            buttonMoveSelectedTitles.UseVisualStyleBackColor = true;
            buttonMoveSelectedTitles.Click += OnMoveSelectedTitles;
            // 
            // groupFilters
            // 
            groupFilters.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupFilters.Controls.Add(textBoxFilter);
            groupFilters.Controls.Add(labelFilter);
            groupFilters.Controls.Add(checkBoxOther);
            groupFilters.Controls.Add(checkBoxDemos);
            groupFilters.Controls.Add(checkBoxUpdates);
            groupFilters.Controls.Add(checkBoxDLC);
            groupFilters.Controls.Add(labelCategory);
            groupFilters.Controls.Add(checkBoxGames);
            groupFilters.Controls.Add(labelRegions);
            groupFilters.Controls.Add(checkBoxJapan);
            groupFilters.Controls.Add(checkBoxEurope);
            groupFilters.Controls.Add(checkBoxUSA);
            groupFilters.Location = new Point(0, 0);
            groupFilters.Name = "groupFilters";
            groupFilters.Size = new Size(290, 356);
            groupFilters.TabIndex = 0;
            groupFilters.TabStop = false;
            groupFilters.Text = "Filters";
            // 
            // textBoxFilter
            // 
            textBoxFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxFilter.Location = new Point(15, 318);
            textBoxFilter.Name = "textBoxFilter";
            textBoxFilter.Size = new Size(260, 23);
            textBoxFilter.TabIndex = 12;
            textBoxFilter.TextChanged += OnApplyFilter;
            // 
            // labelFilter
            // 
            labelFilter.AutoSize = true;
            labelFilter.Location = new Point(15, 300);
            labelFilter.Name = "labelFilter";
            labelFilter.Size = new Size(33, 15);
            labelFilter.TabIndex = 11;
            labelFilter.Text = "Filter";
            // 
            // checkBoxOther
            // 
            checkBoxOther.AutoSize = true;
            checkBoxOther.Location = new Point(25, 261);
            checkBoxOther.Name = "checkBoxOther";
            checkBoxOther.Size = new Size(56, 19);
            checkBoxOther.TabIndex = 10;
            checkBoxOther.Text = "Other";
            checkBoxOther.UseVisualStyleBackColor = true;
            checkBoxOther.CheckedChanged += OnApplyFilter;
            // 
            // checkBoxDemos
            // 
            checkBoxDemos.AutoSize = true;
            checkBoxDemos.Location = new Point(25, 236);
            checkBoxDemos.Name = "checkBoxDemos";
            checkBoxDemos.Size = new Size(63, 19);
            checkBoxDemos.TabIndex = 9;
            checkBoxDemos.Text = "Demos";
            checkBoxDemos.UseVisualStyleBackColor = true;
            checkBoxDemos.CheckedChanged += OnApplyFilter;
            // 
            // checkBoxUpdates
            // 
            checkBoxUpdates.AutoSize = true;
            checkBoxUpdates.Location = new Point(25, 211);
            checkBoxUpdates.Name = "checkBoxUpdates";
            checkBoxUpdates.Size = new Size(69, 19);
            checkBoxUpdates.TabIndex = 8;
            checkBoxUpdates.Text = "Updates";
            checkBoxUpdates.UseVisualStyleBackColor = true;
            checkBoxUpdates.CheckedChanged += OnApplyFilter;
            // 
            // checkBoxDLC
            // 
            checkBoxDLC.AutoSize = true;
            checkBoxDLC.Location = new Point(24, 186);
            checkBoxDLC.Name = "checkBoxDLC";
            checkBoxDLC.Size = new Size(48, 19);
            checkBoxDLC.TabIndex = 7;
            checkBoxDLC.Text = "DLC";
            checkBoxDLC.UseVisualStyleBackColor = true;
            checkBoxDLC.CheckedChanged += OnApplyFilter;
            // 
            // labelCategory
            // 
            labelCategory.AutoSize = true;
            labelCategory.Location = new Point(15, 137);
            labelCategory.Name = "labelCategory";
            labelCategory.Size = new Size(63, 15);
            labelCategory.TabIndex = 6;
            labelCategory.Text = "Categories";
            // 
            // checkBoxGames
            // 
            checkBoxGames.AutoSize = true;
            checkBoxGames.Checked = true;
            checkBoxGames.CheckState = CheckState.Checked;
            checkBoxGames.Location = new Point(24, 161);
            checkBoxGames.Name = "checkBoxGames";
            checkBoxGames.Size = new Size(62, 19);
            checkBoxGames.TabIndex = 5;
            checkBoxGames.Text = "Games";
            checkBoxGames.UseVisualStyleBackColor = true;
            checkBoxGames.CheckedChanged += OnApplyFilter;
            // 
            // labelRegions
            // 
            labelRegions.AutoSize = true;
            labelRegions.Location = new Point(15, 24);
            labelRegions.Name = "labelRegions";
            labelRegions.Size = new Size(49, 15);
            labelRegions.TabIndex = 4;
            labelRegions.Text = "Regions";
            // 
            // checkBoxJapan
            // 
            checkBoxJapan.AutoSize = true;
            checkBoxJapan.Location = new Point(24, 98);
            checkBoxJapan.Name = "checkBoxJapan";
            checkBoxJapan.Size = new Size(56, 19);
            checkBoxJapan.TabIndex = 3;
            checkBoxJapan.Text = "Japan";
            checkBoxJapan.UseVisualStyleBackColor = true;
            checkBoxJapan.CheckedChanged += OnApplyFilter;
            // 
            // checkBoxEurope
            // 
            checkBoxEurope.AutoSize = true;
            checkBoxEurope.Location = new Point(24, 73);
            checkBoxEurope.Name = "checkBoxEurope";
            checkBoxEurope.Size = new Size(63, 19);
            checkBoxEurope.TabIndex = 2;
            checkBoxEurope.Text = "Europe";
            checkBoxEurope.UseVisualStyleBackColor = true;
            checkBoxEurope.CheckedChanged += OnApplyFilter;
            // 
            // checkBoxUSA
            // 
            checkBoxUSA.AutoSize = true;
            checkBoxUSA.Checked = true;
            checkBoxUSA.CheckState = CheckState.Checked;
            checkBoxUSA.Location = new Point(24, 48);
            checkBoxUSA.Name = "checkBoxUSA";
            checkBoxUSA.Size = new Size(48, 19);
            checkBoxUSA.TabIndex = 1;
            checkBoxUSA.Text = "USA";
            checkBoxUSA.UseVisualStyleBackColor = true;
            checkBoxUSA.CheckedChanged += OnApplyFilter;
            // 
            // splitterMain
            // 
            splitterMain.BackColor = SystemColors.Control;
            splitterMain.Location = new Point(794, 0);
            splitterMain.Name = "splitterMain";
            splitterMain.Size = new Size(10, 1035);
            splitterMain.TabIndex = 5;
            splitterMain.TabStop = false;
            // 
            // dataGridTitles
            // 
            dataGridTitles.AllowUserToAddRows = false;
            dataGridTitles.AllowUserToDeleteRows = false;
            dataGridTitles.AllowUserToResizeRows = false;
            dataGridTitles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridTitles.Dock = DockStyle.Left;
            dataGridTitles.Location = new Point(0, 0);
            dataGridTitles.Name = "dataGridTitles";
            dataGridTitles.ReadOnly = true;
            dataGridTitles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridTitles.ShowEditingIcon = false;
            dataGridTitles.Size = new Size(794, 1035);
            dataGridTitles.TabIndex = 4;
            dataGridTitles.CellDoubleClick += dataGridTitles_CellDoubleClick;
            dataGridTitles.CellFormatting += dataGridWiiUTitles_CellFormatting;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.Location = new Point(1852, 1063);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 1;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            buttonOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonOK.DialogResult = DialogResult.OK;
            buttonOK.Location = new Point(1771, 1063);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(75, 23);
            buttonOK.TabIndex = 2;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            // 
            // WiiUTitles
            // 
            AcceptButton = buttonOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(1939, 1098);
            ControlBox = false;
            Controls.Add(buttonOK);
            Controls.Add(buttonCancel);
            Controls.Add(panelMain);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "WiiUTitles";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Select Titles to Download";
            panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridQueued).EndInit();
            panelControls.ResumeLayout(false);
            groupFilters.ResumeLayout(false);
            groupFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridTitles).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMain;
        private DataGridView dataGridTitles;
        private Panel panelControls;
        private Splitter splitterMain;
        private DataGridView dataGridQueued;
        private GroupBox groupFilters;
        private CheckBox checkBoxUSA;
        private CheckBox checkBoxJapan;
        private CheckBox checkBoxEurope;
        private Label labelRegions;
        private CheckBox checkBoxDemos;
        private CheckBox checkBoxUpdates;
        private CheckBox checkBoxDLC;
        private Label labelCategory;
        private CheckBox checkBoxGames;
        private TextBox textBoxFilter;
        private Label labelFilter;
        private CheckBox checkBoxOther;
        private Button buttonMoveSelectedTitles;
        private Button buttonMoveAllTitles;
        private Button buttonMoveSelectedQueuedTitle;
        private Button buttonMoveAllQueuedTitles;
        private Button buttonCancel;
        private Button buttonOK;
    }
}
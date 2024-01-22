namespace MrBildo.SprintDownloader.Forms
{
    partial class MainForm
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
            mainMenu = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            menuLoadWiiU = new ToolStripMenuItem();
            menuLoadPlaystation2 = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            buttonLoadTMD = new Button();
            buttonTest = new Button();
            mainMenu.SuspendLayout();
            SuspendLayout();
            // 
            // mainMenu
            // 
            mainMenu.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            mainMenu.Location = new Point(0, 0);
            mainMenu.Name = "mainMenu";
            mainMenu.Size = new Size(1030, 24);
            mainMenu.TabIndex = 0;
            mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadToolStripMenuItem, toolStripMenuItem1, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuLoadWiiU, menuLoadPlaystation2 });
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(135, 22);
            loadToolStripMenuItem.Text = "&Load";
            // 
            // menuLoadWiiU
            // 
            menuLoadWiiU.Name = "menuLoadWiiU";
            menuLoadWiiU.Size = new Size(150, 22);
            menuLoadWiiU.Text = "&Wii U Titles...";
            menuLoadWiiU.Click += menuLoadWiiU_Click;
            // 
            // menuLoadPlaystation2
            // 
            menuLoadPlaystation2.Name = "menuLoadPlaystation2";
            menuLoadPlaystation2.Size = new Size(150, 22);
            menuLoadPlaystation2.Text = "&Playstation 2...";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(132, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            exitToolStripMenuItem.Size = new Size(135, 22);
            exitToolStripMenuItem.Text = "Exit";
            // 
            // buttonLoadTMD
            // 
            buttonLoadTMD.Location = new Point(26, 40);
            buttonLoadTMD.Name = "buttonLoadTMD";
            buttonLoadTMD.Size = new Size(75, 23);
            buttonLoadTMD.TabIndex = 2;
            buttonLoadTMD.Text = "Load TMD";
            buttonLoadTMD.UseVisualStyleBackColor = true;
            buttonLoadTMD.Click += buttonLoadTMD_Click;
            // 
            // buttonTest
            // 
            buttonTest.Location = new Point(189, 50);
            buttonTest.Name = "buttonTest";
            buttonTest.Size = new Size(75, 23);
            buttonTest.TabIndex = 3;
            buttonTest.Text = "Test";
            buttonTest.UseVisualStyleBackColor = true;
            buttonTest.Click += buttonTest_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1030, 875);
            Controls.Add(buttonTest);
            Controls.Add(buttonLoadTMD);
            Controls.Add(mainMenu);
            MainMenuStrip = mainMenu;
            Name = "MainForm";
            Text = "MainForm";
            mainMenu.ResumeLayout(false);
            mainMenu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mainMenu;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem menuLoadWiiU;
        private ToolStripMenuItem menuLoadPlaystation2;
        private ToolStripSeparator toolStripMenuItem1;
        private Button buttonLoadTMD;
        private Button buttonTest;
    }
}
namespace CustomControls.AboutBox
{
    partial class AboutDetails
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.applicationTabPage = new System.Windows.Forms.TabPage();
            this.assembliesTabPage = new System.Windows.Forms.TabPage();
            this.assemblyDetailsTabPage = new System.Windows.Forms.TabPage();
            this.applicationListView = new System.Windows.Forms.ListView();
            this.applicationKeyCol = new System.Windows.Forms.ColumnHeader();
            this.applicationValueCol = new System.Windows.Forms.ColumnHeader();
            this.assembliesListView = new System.Windows.Forms.ListView();
            this.nameCol = new System.Windows.Forms.ColumnHeader();
            this.versionCol = new System.Windows.Forms.ColumnHeader();
            this.builtCol = new System.Windows.Forms.ColumnHeader();
            this.codebaseCol = new System.Windows.Forms.ColumnHeader();
            this.assemblyNamesComboBox = new System.Windows.Forms.ComboBox();
            this.assemblyDetailsListView = new System.Windows.Forms.ListView();
            this.assemblyKeyCol = new System.Windows.Forms.ColumnHeader();
            this.assemblyValueCol = new System.Windows.Forms.ColumnHeader();
            this.tabControl.SuspendLayout();
            this.applicationTabPage.SuspendLayout();
            this.assembliesTabPage.SuspendLayout();
            this.assemblyDetailsTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.applicationTabPage);
            this.tabControl.Controls.Add(this.assembliesTabPage);
            this.tabControl.Controls.Add(this.assemblyDetailsTabPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(351, 185);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // applicationTabPage
            // 
            this.applicationTabPage.Controls.Add(this.applicationListView);
            this.applicationTabPage.Location = new System.Drawing.Point(4, 22);
            this.applicationTabPage.Name = "applicationTabPage";
            this.applicationTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.applicationTabPage.Size = new System.Drawing.Size(343, 159);
            this.applicationTabPage.TabIndex = 0;
            this.applicationTabPage.Text = "Application";
            this.applicationTabPage.UseVisualStyleBackColor = true;
            // 
            // assembliesTabPage
            // 
            this.assembliesTabPage.Controls.Add(this.assembliesListView);
            this.assembliesTabPage.Location = new System.Drawing.Point(4, 22);
            this.assembliesTabPage.Name = "assembliesTabPage";
            this.assembliesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.assembliesTabPage.Size = new System.Drawing.Size(343, 159);
            this.assembliesTabPage.TabIndex = 1;
            this.assembliesTabPage.Text = "Assemblies";
            this.assembliesTabPage.UseVisualStyleBackColor = true;
            // 
            // assemblyDetailsTabPage
            // 
            this.assemblyDetailsTabPage.Controls.Add(this.assemblyDetailsListView);
            this.assemblyDetailsTabPage.Controls.Add(this.assemblyNamesComboBox);
            this.assemblyDetailsTabPage.Location = new System.Drawing.Point(4, 22);
            this.assemblyDetailsTabPage.Name = "assemblyDetailsTabPage";
            this.assemblyDetailsTabPage.Size = new System.Drawing.Size(343, 159);
            this.assemblyDetailsTabPage.TabIndex = 2;
            this.assemblyDetailsTabPage.Text = "Assembly Details";
            this.assemblyDetailsTabPage.UseVisualStyleBackColor = true;
            // 
            // applicationListView
            // 
            this.applicationListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.applicationKeyCol,
            this.applicationValueCol});
            this.applicationListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.applicationListView.Location = new System.Drawing.Point(3, 3);
            this.applicationListView.Name = "applicationListView";
            this.applicationListView.Size = new System.Drawing.Size(337, 153);
            this.applicationListView.TabIndex = 0;
            this.applicationListView.UseCompatibleStateImageBehavior = false;
            this.applicationListView.View = System.Windows.Forms.View.Details;
            // 
            // applicationKeyCol
            // 
            this.applicationKeyCol.Text = "Application Key";
            this.applicationKeyCol.Width = 120;
            // 
            // applicationValueCol
            // 
            this.applicationValueCol.Text = "Value";
            this.applicationValueCol.Width = 211;
            // 
            // assembliesListView
            // 
            this.assembliesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameCol,
            this.versionCol,
            this.builtCol,
            this.codebaseCol});
            this.assembliesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.assembliesListView.Location = new System.Drawing.Point(3, 3);
            this.assembliesListView.MultiSelect = false;
            this.assembliesListView.Name = "assembliesListView";
            this.assembliesListView.Size = new System.Drawing.Size(337, 153);
            this.assembliesListView.TabIndex = 0;
            this.assembliesListView.UseCompatibleStateImageBehavior = false;
            this.assembliesListView.View = System.Windows.Forms.View.Details;
            this.assembliesListView.DoubleClick += new System.EventHandler(this.assembliesListView_DoubleClick);
            // 
            // nameCol
            // 
            this.nameCol.Text = "Assembly";
            this.nameCol.Width = 120;
            // 
            // versionCol
            // 
            this.versionCol.Text = "Version";
            // 
            // builtCol
            // 
            this.builtCol.Text = "Built";
            // 
            // codebaseCol
            // 
            this.codebaseCol.Text = "Code Base";
            this.codebaseCol.Width = 200;
            // 
            // assemblyNamesComboBox
            // 
            this.assemblyNamesComboBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.assemblyNamesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.assemblyNamesComboBox.FormattingEnabled = true;
            this.assemblyNamesComboBox.Location = new System.Drawing.Point(0, 0);
            this.assemblyNamesComboBox.Name = "assemblyNamesComboBox";
            this.assemblyNamesComboBox.Size = new System.Drawing.Size(343, 21);
            this.assemblyNamesComboBox.TabIndex = 0;
            this.assemblyNamesComboBox.SelectedIndexChanged += new System.EventHandler(this.assemblyNamesComboBox_SelectedIndexChanged);
            // 
            // assemblyDetailsListView
            // 
            this.assemblyDetailsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.assemblyKeyCol,
            this.assemblyValueCol});
            this.assemblyDetailsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.assemblyDetailsListView.Location = new System.Drawing.Point(0, 21);
            this.assemblyDetailsListView.Name = "assemblyDetailsListView";
            this.assemblyDetailsListView.Size = new System.Drawing.Size(343, 138);
            this.assemblyDetailsListView.TabIndex = 1;
            this.assemblyDetailsListView.UseCompatibleStateImageBehavior = false;
            this.assemblyDetailsListView.View = System.Windows.Forms.View.Details;
            // 
            // assemblyKeyCol
            // 
            this.assemblyKeyCol.Text = "Assembly Key";
            this.assemblyKeyCol.Width = 120;
            // 
            // assemblyValueCol
            // 
            this.assemblyValueCol.Text = "Value";
            this.assemblyValueCol.Width = 200;
            // 
            // AboutDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Name = "AboutDetails";
            this.Size = new System.Drawing.Size(351, 185);
            this.tabControl.ResumeLayout(false);
            this.applicationTabPage.ResumeLayout(false);
            this.assembliesTabPage.ResumeLayout(false);
            this.assemblyDetailsTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage applicationTabPage;
        private System.Windows.Forms.TabPage assembliesTabPage;
        private System.Windows.Forms.TabPage assemblyDetailsTabPage;
        private System.Windows.Forms.ListView applicationListView;
        private System.Windows.Forms.ColumnHeader applicationKeyCol;
        private System.Windows.Forms.ColumnHeader applicationValueCol;
        private System.Windows.Forms.ListView assembliesListView;
        private System.Windows.Forms.ColumnHeader nameCol;
        private System.Windows.Forms.ColumnHeader versionCol;
        private System.Windows.Forms.ColumnHeader builtCol;
        private System.Windows.Forms.ColumnHeader codebaseCol;
        private System.Windows.Forms.ListView assemblyDetailsListView;
        private System.Windows.Forms.ColumnHeader assemblyKeyCol;
        private System.Windows.Forms.ColumnHeader assemblyValueCol;
        private System.Windows.Forms.ComboBox assemblyNamesComboBox;
    }
}

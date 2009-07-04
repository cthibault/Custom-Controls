using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace CustomControls.AboutBox
{
    public partial class AboutInfo : UserControl
    {

        #region Members
        #endregion Members

        #region Properties
        public Image Picture
        {
            get { return pictureBox.Image; }
            set { pictureBox.Image = value;}
        }
        public PictureBoxSizeMode PictureSizeMode
        {
            get { return pictureBox.SizeMode; }
            set { pictureBox.SizeMode = value; }
        }
        public int PictureBoxColumnWidth
        {
            get { return pictureBox.Width; }
            set { pictureBox.Width = value; }
        }

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }
        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }
        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }
        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }
        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion Properties

        #region Constructors
        public AboutInfo()
        {
            InitializeComponent();
            this.Text = String.Format("About {0}", AssemblyTitle);
            this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
            this.labelCopyright.Text = AssemblyCopyright;
            this.labelCompanyName.Text = AssemblyCompany;
            this.textBoxDescription.Text = AssemblyDescription;
        }
        #endregion Constructors

        #region Events
        public event EventHandler OkButtonClicked;
        protected virtual void OnOkButtonClicked(EventArgs e)
        {
            if (OkButtonClicked != null)
                OkButtonClicked(this, e);
        }

        public event EventHandler MoreInfoButtonClicked;
        protected virtual void OnMoreInfoButtonClicked(EventArgs e)
        {
            if (MoreInfoButtonClicked != null)
                MoreInfoButtonClicked(this, e);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            OnOkButtonClicked(e);
        }
        private void moreInfoButton_Click(object sender, EventArgs e)
        {
            OnMoreInfoButtonClicked(e);
        }
        #endregion Events

        #region Methods
        #endregion Methods
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace CustomControls.AboutBox
{
    partial class AboutBox : Form
    {
        private enum AboutBoxDisplay { General, Detailed }

        #region Constants
        private const string GENERAL_INFORMATION = "General Information";
        private const string DETAILED_INFORMATION = "Detailed Information";
        #endregion Constants
        #region Members
        private AboutBoxDisplay _currentDisplay = AboutBoxDisplay.General;
        private TextBox _descriptionTextBox = null;
        private AboutDetails aboutDetails = null;
        #endregion Members

        #region Properties
        private TextBox GeneralInformationControl
        {
            get { return _descriptionTextBox; }
            set { _descriptionTextBox = value; }
        }
        private AboutDetails DetailedInformationControl
        {
            get 
            {
                if (aboutDetails == null)
                {
                    aboutDetails = new AboutDetails();
                    aboutDetails.Dock = DockStyle.Fill;
                    aboutDetails.Initialize();
                }
                return aboutDetails; 
            }
            set { aboutDetails = value; }
        }
        #endregion Properties

        #region Constructors
        public AboutBox()
        {
            InitializeComponent();
        }
        #endregion Constructors

        #region Events
        private void AboutBox_Load(object sender, EventArgs e)
        {
            GeneralInformationControl = aboutInfo.textBoxDescription;
        }

        private void aboutInfo_OkButtonClicked(object sender, EventArgs e)
        {
            this.Close();
        }
        private void aboutInfo_MoreInfoButtonClicked(object sender, EventArgs e)
        {
            _toggleAboutBoxDisplay();
        }
        #endregion Events

        #region Methods
        private void _toggleAboutBoxDisplay()
        {
            if (_currentDisplay == AboutBoxDisplay.General)
                _displayAboutBoxDisplayDetailed();
            else
                _displayAboutBoxDisplayGeneral();
        }
        private void _displayAboutBoxDisplayDetailed()
        {
            _currentDisplay = AboutBoxDisplay.Detailed;

            //Set More Information button Text
            aboutInfo.moreInfoButton.Text = GENERAL_INFORMATION;

            //Setup InformationPanel
            aboutInfo.infoPanel.Controls.Clear();
            aboutInfo.infoPanel.Controls.Add(DetailedInformationControl);
        }
        private void _displayAboutBoxDisplayGeneral()
        {
            _currentDisplay = AboutBoxDisplay.General;

            //Set More Information button Text
            aboutInfo.moreInfoButton.Text = DETAILED_INFORMATION;

            //Setup InformationPanel
            aboutInfo.infoPanel.Controls.Clear();
            aboutInfo.infoPanel.Controls.Add(GeneralInformationControl);
        }
        #endregion Methods
    }
}

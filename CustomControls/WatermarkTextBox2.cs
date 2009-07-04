using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace CustomControls
{
    class WatermarkTextBox2 : TextBox
    {
        #region Members
        private Font _oldFont = null;

        private bool _displayWatermarkText = false;
        private string _watermarkText = "Water Mark";
        private Color _watermarkColor = Color.Gray;
        #endregion Members

        #region Properties
        public string WatermarkText
        {
            get { return _watermarkText; }
            set
            {
                _watermarkText = value;
                Invalidate();
            }
        }
        public Color WatermarkColor
        {
            get { return _watermarkColor; }
            set
            {
                _watermarkColor = value;
                Invalidate();
            }
        }
        #endregion Properties

        #region Constructors
        public WatermarkTextBox2()
        {
            _initializeEvents();
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            _watermarkToggle(null, null);
        }
        #endregion Constructors

        #region Methods
        protected override void OnPaint(PaintEventArgs e)
        {
            Font font = new Font(Font.FontFamily, Font.Size, Font.Style, Font.Unit);
            SolidBrush brush = new SolidBrush(_watermarkColor);

            e.Graphics.DrawString((_displayWatermarkText ? _watermarkText : Text), font, brush, new PointF(0.0F, 0.0F));
            base.OnPaint(e);
        }

        private void _initializeEvents()
        {
            this.TextChanged += new EventHandler(_watermarkToggle);
            this.LostFocus += new EventHandler(_watermarkToggle);
            this.FontChanged += new EventHandler(_watermarkFontChanged);
            this.Enter += new EventHandler(_disableWatermark);
        }
        private void _watermarkToggle(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.Text))
                _enableWatermark(null, null);
            else
                _disableWatermark(null, null);
        }
        private void _watermarkFontChanged(object sender, EventArgs e)
        {
            if (_displayWatermarkText)
            {
                _oldFont = new Font(Font.FontFamily, Font.Size, Font.Style, Font.Unit);
                Refresh();
            }
        }
        private void _enableWatermark(object sender, EventArgs e)
        {
            //Save current font style
            _oldFont = new Font(Font.FontFamily, Font.Size, Font.Style, Font.Unit);

            //Enable OnPaint event
            SetStyle(ControlStyles.UserPaint, true);
            _displayWatermarkText = true;

            //Trigger OnPaint
            Refresh();
        }
        private void _disableWatermark(object sender, EventArgs e)
        {
            //Disable OnPaint event
            _displayWatermarkText = false;
            SetStyle(ControlStyles.UserPaint, false);

            //Return to previous font style
            if (_oldFont != null)
                Font = _oldFont;

            Refresh();
        }
        #endregion Methods
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace CustomControls
{
    class WatermarkTextbox : TextBox
    {
        #region Members
        private bool _displayWatermark = true;

        private Font _normalFont = null;
        private Color _normalForeColor = Control.DefaultForeColor;

        private string _watermarkText = "Watermark Text";
        private Font _watermarkFont = new Font(Control.DefaultFont.FontFamily, Control.DefaultFont.Size, FontStyle.Italic, Control.DefaultFont.Unit);
        private Color _watermarkForeColor = Color.LightGray;
        #endregion Members

        #region Properties
        [CategoryAttribute("Appearance")]
        [Description("The watermark text associated with the control.")]
        public string WatermarkText
        {
            get { return _watermarkText; }
            set
            {
                _watermarkText = value;
                Invalidate();
            }
        }
        [CategoryAttribute("Appearance")]
        [Description("The font used to display the watermark text in the control.")]
        public Font WatermarkFont
        {
            get { return _watermarkFont; }
            set
            {
                _watermarkFont = value;
                Invalidate();
            }
        }
        [CategoryAttribute("Appearance")]
        [Description("The watermark foreground color of this component, which is used to display the watermark text.")]
        public Color WatermarkForeColor
        {
            get { return _watermarkForeColor; }
            set
            {
                _watermarkForeColor = value;
                Invalidate();
            }
        }
        #endregion Properties

        #region Contructors
        public WatermarkTextbox()
        {
            _wireEvents();
        }
        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            _setStyleAndRefresh();
        }
        #endregion Contructors

        #region Methods
        protected override void OnPaint(PaintEventArgs e)
        {
            Color foreColor = (_displayWatermark ? _watermarkForeColor : _normalForeColor);
            string text = (_displayWatermark ? _watermarkText : Text);

            e.Graphics.DrawString(text, Font, new SolidBrush(foreColor), new PointF(0.0F, 0.0F));
            base.OnPaint(e);
        }

        private void _wireEvents()
        {
            this.Enter += new EventHandler(_onEnter);
            this.Leave += new EventHandler(_onLeave);
            this.TextChanged += new EventHandler(_onTextChanged);
        }


        private void _onEnter(object sender, EventArgs e)
        {
            _displayWatermark = false;
            _setStyleAndRefresh();
        }
        private void _onLeave(object sender, EventArgs e)
        {
            _displayWatermark = (string.IsNullOrEmpty(Text) || _textIsWatermarkText());
            _setStyleAndRefresh();
        }
        private void _onTextChanged(object sender, EventArgs e)
        {
            _setStyleAndRefresh();
        }

        private void _setStyleAndRefresh()
        {
            if (_displayWatermark)
                _setStyleAsWatermark();
            else
                _setStyleAsNormal();

            Refresh();
        }
        private void _setStyleAsWatermark()
        {
            Font = _watermarkFont;
            ForeColor = _watermarkForeColor;
            Text = _watermarkText;

            //Enable OnPaint event
            SetStyle(ControlStyles.UserPaint, true);
        }
        private void _setStyleAsNormal()
        {
            Font = _normalFont;
            ForeColor = _normalForeColor;

            if (_textIsWatermarkText())
                Text = string.Empty;

            //Disable OnPaint event
            SetStyle(ControlStyles.UserPaint, false);
        }

        private bool _textIsWatermarkText()
        {
            return (Text == _watermarkText);
        }
        #endregion Methods
    }
}

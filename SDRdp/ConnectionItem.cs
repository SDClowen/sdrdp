using SDRdp.Core.Configuration;
using SDUI;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace SDRdp
{
    internal class ConnectionItem : Panel
    {
        private readonly StringFormat format = new(){ LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center };
        private readonly Font font = new("Segoe UI", 40);

        private readonly string savedDir = Path.Combine(Environment.CurrentDirectory, "saved");
        public Image BackgroundImg { get; set; }
        internal string Group { get; set; }
        internal string RName { get; set; }

        public event EventHandler ConnectSavedEventHandler;
        public event EventHandler RemoveConnectionEventHandler;

        SDUI.Controls.Button buttonRemove = new();
        private int _mouseState;
        private Color _color = Color.Empty;

        internal ConnectionItem(string title, FreeRdpConfiguration config)
            : base()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor |
                      ControlStyles.OptimizedDoubleBuffer |
                        ControlStyles.AllPaintingInWmPaint |
                      ControlStyles.UserPaint, true);
            Group = config.Group;

            var fileName = Path.Combine(savedDir, $"{config.Server.Replace(":", "_")}_{config.Username}.png");

            if (File.Exists(fileName))
            {
                BackgroundImg = Bitmap.FromFile(fileName);
                _color = GetContrastingColor(GetAverageColor(BackgroundImg));
            }

            this.BackColor = Color.Transparent;
            this.Controls.Add(buttonRemove);

            buttonRemove.BringToFront();

            this.Font = new Font("Segoe UI Semibold", 11f, FontStyle.Regular, GraphicsUnit.Point, 162);
            this.Padding = new Padding(3, 8, 3, 3);
            //this.Radius = 25;
            //this.ShadowDepth = 4;
            this.Size = new Size(281, 181);
            this.Tag = config;
            this.TabStop = false;
            this.Text = title;

            RName = config.Title ?? "RDP Connection";

            this.Click += (sender, e) => ConnectSavedEventHandler?.Invoke(sender, e);

            buttonRemove.Color = Color.Red;
            buttonRemove.Font = new Font("Segoe UI", 9, FontStyle.Regular, GraphicsUnit.Point, 162);
            buttonRemove.ForeColor = Color.White;

            var measure = TextRenderer.MeasureText("✕", buttonRemove.Font);

            buttonRemove.Location = new Point(this.Size.Width - 32, 6);
            buttonRemove.Radius = 24;
            buttonRemove.ShadowDepth = 0F;
            buttonRemove.Tag = config;
            buttonRemove.Size = new Size(24, 24);
            buttonRemove.Text = "✕";
            buttonRemove.UseVisualStyleBackColor = true;
            buttonRemove.Click += (sender, e) => RemoveConnectionEventHandler?.Invoke(sender, e);

            DoubleBuffered = true;
        }

        private Color GetAverageColor(Image image)
        {
            // Resmin ortalama rengini hesapla
            using (Bitmap bitmap = new Bitmap(image))
            {
                int r = 0, g = 0, b = 0;
                int totalPixels = bitmap.Width * bitmap.Height;

                for (int x = 0; x < bitmap.Width; x++)
                {
                    for (int y = 0; y < bitmap.Height; y++)
                    {
                        Color pixel = bitmap.GetPixel(x, y);
                        r += pixel.R;
                        g += pixel.G;
                        b += pixel.B;
                    }
                }

                r /= totalPixels;
                g /= totalPixels;
                b /= totalPixels;

                return Color.FromArgb(r, g, b);
            }
        }

        private Color GetContrastingColor(Color color)
        {
            // Yazı rengini kontrastlı olacak şekilde belirle
            int brightness = (int)(color.R * 0.299 + color.G * 0.587 + color.B * 0.114);
            return brightness > 128 ? Color.Black : Color.White;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using var pen = new Pen(Color.Green, 2);
            RectangleF rect = ClientRectangle;
            //rect.Inflate(6, 6);
            using var rectPath = rect.Radius(24);


            if (BackgroundImg != null)
            {
                using var textureBrush = new TextureBrush(BackgroundImg, WrapMode.Clamp);
                float scaleX = (float)rect.Width / BackgroundImg.Width;
                float scaleY = (float)rect.Height / BackgroundImg.Height;

                var transform = new Matrix();
                transform.Scale(scaleX, scaleY);
                textureBrush.Transform = transform;
                e.Graphics.FillPath(textureBrush, rectPath);
            }

            using var brush = new SolidBrush(Color.Black.Alpha(20));
            using var hbrush = new SolidBrush(Color.Black.Alpha(70));
            using var pbrush = new SolidBrush(Color.Black.Alpha(90));
            
            switch (_mouseState)
            {
                case 1:
                    pen.Color = Color.DodgerBlue;
                    e.Graphics.FillPath(hbrush, rectPath);
                    e.Graphics.DrawPath(pen, rectPath);
                    break;

                case 2:
                    pen.Color = Color.DeepSkyBlue;
                    e.Graphics.FillPath(pbrush, rectPath);
                    e.Graphics.DrawPath(pen, rectPath);
                    break;
                default:
                    pen.Color = ColorScheme.BackColor;
                    e.Graphics.FillPath(brush, rectPath);
                    e.Graphics.DrawPath(pen, rectPath);
                    break;
            }

            using var path = new RectangleF(rect.Width / 2 - 32, rect.Height / 2 - 32, 64, 64).Radius(12);
            e.Graphics.FillPath(pbrush, path);

            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            e.Graphics.DrawString("⯈", font, Brushes.White, path.GetBounds(), format);

            rect.Inflate(0, -12);

            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            using SolidBrush textBrush = BackgroundImg != null ? _color.Brush() : ColorScheme.ForeColor.Brush();
            e.Graphics.DrawString(Text, Font, textBrush, rect, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Far});
            e.Graphics.DrawString(RName, Font, textBrush, rect, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Near});
        }


        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            _mouseState = 2;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            _mouseState = 1;
            Invalidate();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _mouseState = 1;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            _mouseState = 0;
            Invalidate();
        }
    }
}

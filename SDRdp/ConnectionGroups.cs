using SDUI;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SDRdp;

public class ConnectionGroups : UserControl
{
    private float _dpiFactor => DeviceDpi / 96.0f;

    private EventHandler<int> _onSelectedIndexChanged;
    private EventHandler _onNewPageButtonClicked;
    private EventHandler _onClosePageButtonClicked;

    public event EventHandler<int> SelectedIndexChanged
    {
        add => _onSelectedIndexChanged += value;
        remove => _onSelectedIndexChanged -= value;
    }

    public event EventHandler NewPageButtonClicked
    {
        add => _onNewPageButtonClicked += value;
        remove => _onNewPageButtonClicked -= value;
    }

    public event EventHandler ClosePageButtonClicked
    {
        add => _onClosePageButtonClicked += value;
        remove => _onClosePageButtonClicked -= value;
    }

    public ConnectionGroups()
    {
        SetStyle(ControlStyles.SupportsTransparentBackColor |
                 ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.ResizeRedraw |
                 ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.UserPaint, true);

        Padding = new Padding(0, (int)(30 * _dpiFactor), 0, 0);
    }

    protected override void OnSizeChanged(EventArgs e)
    {
        base.OnSizeChanged(e);

        Padding = new(0, (int)(30 * _dpiFactor), 0, 0);
    }

    private int _selectedIndex = -1;
    public int SelectedIndex
    {
        get => _selectedIndex;
        set
        {
            var sys = Stopwatch.StartNew();

            //if (_selectedIndex == value)
            //  return;

            if (Controls.Count > 0)
            {
                if (value < 0)
                    value = Controls.Count - 1;

                if (value > Controls.Count - 1)
                    value = 0;
            }
            else
                value = -1;

            var previousSelectedIndex = _selectedIndex;
            _selectedIndex = value;
            _onSelectedIndexChanged?.Invoke(this, previousSelectedIndex);

            for (int i = 0; i < Controls.Count; i++)
                Controls[i].Visible = i == _selectedIndex;

            Invalidate();
        }
    }

    private Point _mouseLocation;
    private int _mouseState;

    public bool _renderNewPageButton = true;
    public bool RenderNewPageButton
    {
        get => _renderNewPageButton;
        set
        {
            _renderNewPageButton = value;
            Invalidate();
        }
    }

    public bool _renderPageIcon = true;
    public bool RenderPageIcon
    {
        get => _renderPageIcon;
        set
        {
            _renderPageIcon = value;
            Invalidate();
        }
    }

    public bool _renderPageClose = true;
    public bool RenderPageClose
    {
        get => _renderPageClose;
        set
        {
            _renderPageClose = value;
            Invalidate();
        }
    }

    public T Add<T>(string text) where T : ScrollableControl
    {
        SuspendLayout();
        var newPage = Activator.CreateInstance(typeof(T)) as ScrollableControl;
        newPage.Parent = this;
        newPage.Text = text;
        newPage.Visible = false;
        newPage.AutoScroll = true;
        newPage.Padding = new(5);

        newPage.Dock = DockStyle.Fill;
        Controls.Add(newPage);

        if (Controls.Count == 1)
            SelectedIndex = 0;
        else if (Controls.Count < 1)
            SelectedIndex = -1;
        else
            Invalidate();

        ResumeLayout();

        return newPage as T;
    }

    public void Remove()
    {
        RemoveAt(SelectedIndex);
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= Controls.Count)
            return;

        SuspendLayout();

        Controls[index].Controls.Clear();
        Controls[index].Visible = false;
        Controls.RemoveAt(index);

        if (Controls.Count == 1)
            SelectedIndex = 0;
        else if (Controls.Count < 1)
            SelectedIndex = -1;
        else if (SelectedIndex == index)
            SelectedIndex = index; // run set method again
        else
            Invalidate();

        ResumeLayout();
    }

    protected override void OnDpiChangedAfterParent(EventArgs e)
    {
        Invalidate();

        base.OnDpiChangedAfterParent(e);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        GroupBoxRenderer.DrawParentBackground(e.Graphics, ClientRectangle, this);

        base.OnPaint(e);
        var graphics = e.Graphics;

        using var borderPen = new Pen(ColorScheme.BorderColor);

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        //graphics.DrawLine(borderPen, 2, _headerControlSize.Height, Width - 3, _headerControlSize.Height);

        using var bitmap = new Bitmap(Size.Width, Size.Height);
        using var gfx = Graphics.FromImage(bitmap);

        var i = 0;
        var _lastTabX = 12 * _dpiFactor;

        var clientRectangle = new RectangleF(0, 0, Width, Padding.Vertical);

        //graphics.FillRectangle(Color.Red.Alpha(150), ClientRectangle);
        //graphics.FillRectangle(ColorScheme.BackColor2, clientRectangle);

        using var linePen = ColorScheme.ForeColor.Alpha(100).Pen();
        linePen.Width = 1.5f;

        var radius = 12 * _dpiFactor;
        gfx.SmoothingMode = SmoothingMode.AntiAlias;
        foreach (Control control in Controls)
        {
            var stringSize = TextRenderer.MeasureText(control.Text, Font);
            var width = stringSize.Width + 80 * _dpiFactor;
            RectangleF rectangle = new(_lastTabX, -1, width, Padding.Vertical);
            RectangleF rectangleIcon = new(rectangle.X + 6 * _dpiFactor, rectangle.Height / 2 - 8 * _dpiFactor, 16 * _dpiFactor, 16 * _dpiFactor);

            if (i == SelectedIndex)
                gfx.FillPath(borderPen.Brush, rectangle.ChromePath(radius));

            RectangleF rectangleClose = new(rectangle.X + rectangle.Width - 24 * _dpiFactor, rectangle.Height / 2 - 8 * _dpiFactor, 16 * _dpiFactor, 16 * _dpiFactor);
            // is mouse in close button
            if (_renderPageClose)
            {
                using var closeBrush = borderPen.Color.Alpha(50).Brush();

                var isMouseHoverOnClose = rectangleClose.Contains(_mouseLocation);
                if (isMouseHoverOnClose)
                    gfx.FillPie(closeBrush, rectangleClose.X, rectangleClose.Y, rectangleClose.Width, rectangleClose.Height, 0, 360);

                using var closePen = new Pen(closeBrush.Color);

                var size = 4f * _dpiFactor;
                gfx.DrawLine(linePen,
                    rectangleClose.Left + rectangleClose.Width / 2 - size,
                    rectangleClose.Top + rectangleClose.Height / 2 - size,
                    rectangleClose.Left + rectangleClose.Width / 2 + size,
                    rectangleClose.Top + rectangleClose.Height / 2 + size);

                gfx.DrawLine(linePen,
                    rectangleClose.Left + rectangleClose.Width / 2 - size,
                    rectangleClose.Top + rectangleClose.Height / 2 + size,
                    rectangleClose.Left + rectangleClose.Width / 2 + size,
                    rectangleClose.Top + rectangleClose.Height / 2 - size);

                if (_mouseState == 2 && rectangleClose.Contains(_mouseLocation))
                {
                    _mouseState = 1;
                    _onClosePageButtonClicked?.Invoke(i, EventArgs.Empty);
                }
            }

            if (_mouseState == 2 && rectangle.Contains(_mouseLocation) && !rectangleClose.Contains(_mouseLocation))
            {
                _mouseState = 1;
                SelectedIndex = i;
            }

            //graphics.CompositingQuality = CompositingQuality.HighQuality;
            //if (_renderPageIcon)
            //graphics.DrawIcon(SystemIcons.Exclamation, rectangleIcon.ToRectangle());

            i++;
            control.DrawString(gfx, ColorScheme.ForeColor, rectangle);

            _lastTabX += rectangle.Width;
        }

        // new tab button
        if (_renderNewPageButton)
        {
            var newButtonRect = new RectangleF(_lastTabX + (4 * _dpiFactor), Padding.Vertical / 2 - 10 * _dpiFactor, 24 * _dpiFactor, 20 * _dpiFactor);
            var inBounds = newButtonRect.Contains(_mouseLocation);
            using SolidBrush newPageButtonBrush = borderPen.Brush as SolidBrush;

            switch (_mouseState)
            {
                case 1:
                    if (inBounds)
                        newPageButtonBrush.Color = ColorScheme.BackColor2.Alpha(50);
                    break;
                case 2:
                    if (inBounds)
                    {
                        newPageButtonBrush.Color = ColorScheme.BackColor2.Alpha(80);
                        _mouseState = 1;
                        _onNewPageButtonClicked?.Invoke(null, EventArgs.Empty);
                    }

                    break;
            }

            gfx.FillPath(newPageButtonBrush, newButtonRect.Radius(0, 12, 0, 12));

            var size = 6 * _dpiFactor;

            gfx.DrawLine(linePen,
                newButtonRect.Left + newButtonRect.Width / 2 - size,
                newButtonRect.Top + newButtonRect.Height / 2,
                newButtonRect.Left + newButtonRect.Width / 2 + size,
                newButtonRect.Top + newButtonRect.Height / 2);

            gfx.DrawLine(linePen,
                newButtonRect.Left + newButtonRect.Width / 2,
                newButtonRect.Top + newButtonRect.Height / 2 - size,
                newButtonRect.Left + newButtonRect.Width / 2,
                newButtonRect.Top + newButtonRect.Height / 2 + size);
        }

        //graphics.FillPath(borderPen.Brush, new RectangleF(0, Padding.Vertical, Width, 5).Radius(radius, radius));
        gfx.SmoothingMode = SmoothingMode.Default;
        e.Graphics.DrawImage(bitmap, ClientRectangle);
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);

        _mouseLocation = e.Location;
        Invalidate();
    }

    protected override void OnMouseWheel(MouseEventArgs e)
    {
        base.OnMouseWheel(e);

        SelectedIndex += e.Delta <= -120 ? -1 : 1;
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        _mouseState = 2;
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

    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);

        _mouseState = 1;
    }
}

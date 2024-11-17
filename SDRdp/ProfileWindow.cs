using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class CustomContextMenuForm : Form
{
    private CustomContextMenu contextMenu;

    public CustomContextMenuForm()
    {
        this.Text = "Dinamik Boyutlandırılmış Context Menu";
        this.Size = new Size(800, 600);
        this.BackColor = Color.White;

        // Menü öğelerini tanımla
        var menuItems = new List<CustomMenuItem>
        {
            new CustomMenuItem("Kısa Seçenek"),
            new CustomMenuItem("Çok Daha Uzun Bir Seçenek Metni"),
            new CustomMenuItem("Orta Uzunlukta")
        };

        // Click olaylarını tanımla
        menuItems[0].Click += (s, e) => MessageBox.Show("Kısa Seçenek tıklandı!");
        menuItems[1].Click += (s, e) => MessageBox.Show("Uzun Seçenek tıklandı!");
        menuItems[2].Click += (s, e) => MessageBox.Show("Orta Uzunluk tıklandı!");

        // Context Menu oluştur
        this.contextMenu = new CustomContextMenu(menuItems);
        this.contextMenu.Visible = false;
        this.Controls.Add(contextMenu);

        this.MouseDown += CustomContextMenuForm_MouseDown;
    }

    private void CustomContextMenuForm_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            contextMenu.Location = e.Location;
            contextMenu.AdjustSizeAndPosition();
            contextMenu.ShowMenu();
        }
        else
        {
            contextMenu.HideMenu();
        }
    }

    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new CustomContextMenuForm());
    }
}

public class CustomContextMenu : Control
{
    private List<CustomMenuItem> items;
    private int hoverIndex = -1;
    private int cornerRadius = 8;
    private int itemHeight = 30;
    private int maxWidth = 0;
    private Padding padding = new Padding(10); // Menü için padding

    public Padding MenuPadding
    {
        get => padding;
        set
        {
            padding = value;
            Invalidate();
        }
    }

    public CustomContextMenu(List<CustomMenuItem> items)
    {
        this.items = items;

        // ControlStyles ayarları
        this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                      ControlStyles.OptimizedDoubleBuffer |
                      ControlStyles.ResizeRedraw |
                      ControlStyles.UserPaint |
                      ControlStyles.SupportsTransparentBackColor, true);

        this.BackColor = Color.Transparent; // Arka planı saydam yap
        this.Font = new Font("Segoe UI", 10);
    }

    public void ShowMenu()
    {
        this.Visible = true;
        this.BringToFront();
    }

    public void HideMenu()
    {
        this.Visible = false;
        hoverIndex = -1;
    }

    public void AdjustSizeAndPosition()
    {
        maxWidth = 0;
        float maxHeight = 0;
        // Maksimum genişliği hesapla
        using (Graphics g = this.CreateGraphics())
        {
            var i = 0;
            foreach (var item in items)
            {
                SizeF textSize = g.MeasureString(item.Text, this.Font);
                if (textSize.Width > maxWidth)
                {
                    var yPosition = padding.Top + textSize.Height * i;
                    item.Bounds = new RectangleF(padding.Left, yPosition, maxWidth - padding.Left - padding.Right, textSize.Height + padding.Top + padding.Bottom);
                    maxWidth += (int)textSize.Width;
                    maxHeight += textSize.Height + padding.Top + padding.Bottom;
                }
                i++;
            }
        }

        // Menü boyutunu padding ile birlikte ayarla
        maxWidth += padding.Left + padding.Right;
        this.Size = new Size(maxWidth, (int)maxHeight);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.SmoothingMode = SmoothingMode.HighQuality;

        // Menü arka planını çiz
        using (GraphicsPath path = RoundedRect(ClientRectangle, cornerRadius * 2))
        {
            using (SolidBrush brush = new(Color.RebeccaPurple))
            {
                g.FillPath(brush, path);
            }

            using (Pen pen = new(Color.Gray))
            {
                g.DrawPath(pen, path);
            }
        }

        // Menü öğelerini çiz
        for (int i = 0; i < items.Count; i++)
        {
            var item = items[i];

            // Hover efekti
            if (i == hoverIndex)
            {
                using (SolidBrush hoverBrush = new(Color.LightGray))
                {
                    g.FillPath(hoverBrush, RoundedRect(item.Bounds, 8));
                }
            }

            // Menü öğesi metnini çiz
            using (SolidBrush textBrush = new(Color.Black))
            {
                var bounds = new RectangleF(item.Bounds.X + 10, item.Bounds.Y, item.Bounds.Width, item.Bounds.Height);

                g.DrawString(item.Text, this.Font, textBrush, bounds, new StringFormat(StringFormatFlags.NoWrap) { LineAlignment = StringAlignment.Center});
            }
        }
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        Point localPoint = e.Location;
        hoverIndex = -1;

        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].Bounds.Contains(localPoint))
            {
                hoverIndex = i;
                break;
            }
        }

        this.Invalidate();
    }

    protected override void OnMouseClick(MouseEventArgs e)
    {
        Point localPoint = e.Location;

        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].Bounds.Contains(localPoint))
            {
                items[i].RaiseClick();
                HideMenu();
                break;
            }
        }
    }

    private GraphicsPath RoundedRect(RectangleF bounds, int radius)
    {
        int diameter = radius * 2;
        Size size = new Size(diameter, diameter);
        var arc = new RectangleF(bounds.Location, size);
        GraphicsPath path = new();

        // Sol üst köşe
        path.AddArc(arc, 180, 90);

        // Sağ üst köşe
        arc.X = bounds.Right - diameter;
        path.AddArc(arc, 270, 90);

        // Sağ alt köşe
        arc.Y = bounds.Bottom - diameter;
        path.AddArc(arc, 0, 90);

        // Sol alt köşe
        arc.X = bounds.Left;
        path.AddArc(arc, 90, 90);

        path.CloseFigure();
        return path;
    }
}

public class CustomMenuItem
{
    public string Text { get; set; }
    public RectangleF Bounds { get; set; }
    public event EventHandler Click;

    public CustomMenuItem(string text)
    {
        this.Text = text;
    }

    public void RaiseClick()
    {
        Click?.Invoke(this, EventArgs.Empty);
    }
}

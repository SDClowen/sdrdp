using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Windows.Win32;
using Windows.Win32.Foundation;

namespace SDRdp.Core;

internal static class WindowHelper
{
    [DllImport("user32.dll")]
    private static extern IntPtr GetWindowDC(IntPtr hWnd);

    [DllImport("user32.dll")]
    private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

    [DllImport("gdi32.dll")]
    private static extern bool BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);

    [DllImport("gdi32.dll")]
    private static extern IntPtr CreateCompatibleDC(IntPtr hdc);

    [DllImport("gdi32.dll")]
    private static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);

    [DllImport("gdi32.dll")]
    private static extern IntPtr SelectObject(IntPtr hdc, IntPtr h);

    [DllImport("gdi32.dll")]
    private static extern bool DeleteDC(IntPtr hdc);

    [DllImport("gdi32.dll")]
    private static extern bool DeleteObject(IntPtr hObject);

    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

    public static IntPtr GetFreeRdpWindow(IntPtr parentWindowHandle)
    {
        var returnHandle = IntPtr.Zero;
        PInvoke.EnumChildWindows(new HWND(parentWindowHandle), (hWnd, _) =>
        {
            returnHandle = hWnd;
            var sb = new StringBuilder();
            GetClassName(hWnd, sb, 7);
            return !sb.ToString().Equals("FREERDP", StringComparison.CurrentCultureIgnoreCase);
        }, new LPARAM());

        return returnHandle;
    }

    public static void SendFocusMessage(IntPtr hWnd)
    {
        if (hWnd == IntPtr.Zero)
            return;

        PInvoke.SendMessage(new HWND(hWnd), PInvoke.WM_SETFOCUS, new WPARAM(0), new LPARAM(0));
    }

    public static void TakeScreenShot(Control control, string path)
    {
        if (File.Exists(path))
            return;

        var rect = control.RectangleToScreen(control.ClientRectangle);

        var hdcSrc = GetWindowDC(control.Handle);
        var hdcDest = CreateCompatibleDC(hdcSrc);
        var hBitmap = CreateCompatibleBitmap(hdcSrc, rect.Width, rect.Height);
        var hOldBitmap = SelectObject(hdcDest, hBitmap);

        BitBlt(hdcDest, 0, 0, rect.Width, rect.Height, hdcSrc, 0, 0, 0x00CC0020); // SRCCOPY

        using var bitmap = Image.FromHbitmap(hBitmap);
        SelectObject(hdcDest, hOldBitmap);
        DeleteObject(hBitmap);
        DeleteDC(hdcDest);
        ReleaseDC(control.Handle, hdcSrc);
        bitmap.Save(path, System.Drawing.Imaging.ImageFormat.Png);
    }
}
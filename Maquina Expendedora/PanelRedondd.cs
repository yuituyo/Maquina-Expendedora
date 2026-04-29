using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class RoundedPanel : Panel
{
    // Radio de las esquinas
    public int CornerRadius { get; set; } = 20;

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        // Configurar suavizado para que no se vea pixelado
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        // Crear el "camino" (path) para dibujar el rectángulo redondeado
        GraphicsPath path = new GraphicsPath();

        Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
        int r = CornerRadius;

        // Dibujar las esquinas
        path.AddArc(rect.X, rect.Y, r, r, 180, 90);
        path.AddArc(rect.X + rect.Width - r, rect.Y, r, r, 270, 90);
        path.AddArc(rect.X + rect.Width - r, rect.Y + rect.Height - r, r, r, 0, 90);
        path.AddArc(rect.X, rect.Y + rect.Height - r, r, r, 90, 90);
        path.CloseAllFigures();

        // Rellenar el fondo
        using (SolidBrush brush = new SolidBrush(this.BackColor))
        {
            e.Graphics.FillPath(brush, path);
        }

        // Establecer la región para que los controles hijos no se salgan del borde
        this.Region = new Region(path);
    }
}
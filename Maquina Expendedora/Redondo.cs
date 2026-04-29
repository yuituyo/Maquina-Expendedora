using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class RoundedButton : Button
{
    protected override void OnPaint(PaintEventArgs pevent)
    {
        GraphicsPath grPath = new GraphicsPath();
        grPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
        
        // Aplicamos la región para el clic
        this.Region = new Region(grPath);
        
        // Dibujamos con suavizado (AntiAlias)
        pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        pevent.Graphics.FillEllipse(new SolidBrush(this.BackColor), 0, 0, ClientSize.Width, ClientSize.Height);
        
        base.OnPaint(pevent);
    }
}
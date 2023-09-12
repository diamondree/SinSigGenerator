using SinSigGenerator.Consts;
using SinSigGenerator.Models;
using System.Drawing;
using System.Drawing.Imaging;

namespace SinSigGenerator.Services;

public class SignalGeneratorService
{
    internal ImageModel GetSin(SignalModel sig)
    {
        
        var graph = new Bitmap(Resolution.Width, Resolution.Height);


        //fill white color
        using (Graphics gfx = Graphics.FromImage(graph))
        using (SolidBrush brush = new SolidBrush(Color.FromArgb(255, 255, 255)))
        {
            gfx.FillRectangle(brush, 0, 0, graph.Width, graph.Height);
        }


        //create axes
        using (Graphics gfx = Graphics.FromImage(graph))
        using (SolidBrush brush = new SolidBrush(Color.FromArgb(0, 0, 0)))
        {
            //x axis
            gfx.FillRectangle(brush, Offset.XSmallOffset, Offset.YLargeOffset, Resolution.Width - 2 * Offset.XSmallOffset, XYLines.LineDepth);
            //x axis lines
            for (int x = Offset.XSmallOffset * 2 + Offset.LineOffset; x < Resolution.Width - Offset.XSmallOffset; x += Offset.LineOffset)
                gfx.FillRectangle(brush, x, XYLines.XAxisLine,XYLines.LineWidth, XYLines.LineHeight);

            //y axis
            gfx.FillRectangle(brush, Offset.XSmallOffset * 2, Offset.YSmallOffset, XYLines.LineDepth, Resolution.Height - Offset.XSmallOffset * 2);
            //y axis lines
            for (int y = Offset.YSmallOffset + Offset.LineOffset - 1; y < Resolution.Height - Offset.XSmallOffset - 10; y += Offset.LineOffset)
                gfx.FillRectangle(brush, Offset.XSmallOffset * 2 - XYLines.LineDepth, y, XYLines.LineHeight, XYLines.LineWidth);
        }


        // mark point on the graph
        using (Graphics gfx = Graphics.FromImage(graph))
        {
            var pen = new Pen(Color.Black, GraphLines.LineDepth);

            var points = new PointF[Resolution.Width - 3 * Offset.XSmallOffset - XYLines.LineDepth];
            for (int i = 2 * Offset.XSmallOffset + XYLines.LineDepth; i < Resolution.Width - Offset.XSmallOffset; i++)
            {
                var t = (float)i / sig.Fd;
                var x = i;
                var y = (float)(sig.A * Math.Sin(2 * Math.PI * sig.Fs * t)) + XYLines.XAxisLine +XYLines.LineDepth + 1;
                points[i - 2 * Offset.XSmallOffset - XYLines.LineDepth] = new PointF(x, y);
            }

            gfx.DrawLines(pen, points);
        }


        // make file model to send controller
        string fp = graph.GetHashCode().ToString() + ".jpg";
        graph.Save(fp, ImageFormat.Jpeg);
        return new ImageModel()
        {
            Name = graph.GetHashCode().ToString(),
            FilePath = Path.Combine(Directory.GetCurrentDirectory(), fp),
            MimeType = "image/jpeg",
            Id = Guid.NewGuid()
        };
    }
}

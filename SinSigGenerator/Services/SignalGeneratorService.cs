using SinSigGenerator.Models;
using System.Drawing;
using System.Drawing.Imaging;

namespace SinSigGenerator.Services;

public class SignalGeneratorService
{
    internal ImageModel GetSin(SignalModel sig)
    {
        
        var graph = new Bitmap(1920, 1080);

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
            gfx.FillRectangle(brush, 100, 537, 1720, 6);
            for (int x = 240; x < 1820; x += 40)
                gfx.FillRectangle(brush, x, 530,4, 20);
            gfx.FillRectangle(brush, 200, 100, 6, 880);
            for (int y = 139; y < 970; y += 40)
                gfx.FillRectangle(brush, 194, y, 20, 4);
        }










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

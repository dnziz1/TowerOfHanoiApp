using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerOfHanoi.GUI;

public class DiscVisual
{
    public int Size { get; set; }
    public int Height { get; set; }
    public Color Color { get; set; }
    public int Tower { get; set; } // 0, 1, 2
    private static Random rand = new Random();

    public DiscVisual(int size, int tower, int height)
    {
        Size = size;
        Tower = tower;
        Height = height;
        // Generates random color for discs color
        Color = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
    }

    public void Draw(Graphics g, int towerWidth, int discHeight, int baseY)
    {
        int towerCenterX = (Tower * towerWidth) + (towerWidth / 2);
        int discWidth = Size * 25;
        int x = towerCenterX - (discWidth / 2);
        int y = baseY - ((Height + 1) * discHeight);

        // Draw the disc
        using (var brush = new SolidBrush(Color))
        {
            g.FillRectangle(brush, x, y, discWidth, discHeight);
            g.DrawRectangle(Pens.Black, x, y, discWidth, discHeight);
        }

        // Draw the size number
        using (var font = new Font("Arial", 10))
        using (var textBrush = new SolidBrush(Color.Black))
        {
            string text = Size.ToString();
            var textSize = g.MeasureString(text, font);
            g.DrawString(text, font, textBrush,
                x + (discWidth - textSize.Width) / 2,
                y + (discHeight - textSize.Height) / 2);
        }

    }
}

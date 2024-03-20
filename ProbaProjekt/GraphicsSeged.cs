using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Media.Animation;

namespace VGraphicsX
{
    public class GraphicsSeged
    {
        public static Graphics AA_Graphics_From_Panel(Panel panel)
        {
            Graphics g = panel.CreateGraphics();
            g.SmoothingMode = SmoothingMode.AntiAlias;


            return g;
        }
    }
}

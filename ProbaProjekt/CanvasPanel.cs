using System.Numerics;

namespace VGraphicsX
{
    public class CanvasObject
    {
        public int x; //x position
        public int y; //y position
        public int width; //object width
        public int height; //object height
        public Color color;
        public int objectID;
    }

    public class CanvasObject3D
    {
        public int x;
        public int y; 
        public int z;

        public int width; 
        public int height; 
        public int depth; 

        public Color color;
        public int objectID;
    }

    public class CanvasPanel : Panel
    {
        private Graphics g;

        private readonly Color BLACK_COLOR = Color.Black;

        private List<CanvasObject> objects = new List<CanvasObject>();

        public CanvasPanel()
        {
            BackColor = BLACK_COLOR;
        }

        /*
         * egermozgas lekovetese:
         MouseMove += (o, e) => 
            {
                int mPosX = Control.MousePosition.X - this.Location.X;
                int mPosY = Control.MousePosition.Y - this.Location.Y;
                  
            };
        */

        private void MoveObject(int objectID, int newX, int newY, int newWidth, int newHeight)
        {
            List<CanvasObject> list = objects;
            CanvasObject newObj = new CanvasObject()
            {
                x = newX, y = newY, width = newWidth, height = newHeight
            };
            
            for (int i = 0; i < objects.Count; i++)
            {
                CanvasObject canvasObject = objects[i];

                if (canvasObject.objectID == objectID)
                {
                    objects.RemoveAt(i);
                    objects.Insert(i - 1, newObj);
                }
            }

            RenderObjects();
        }

        public void RegisterObject(int x, int y, int width, int height, Color color)
        {
            CanvasObject canvasObject = new CanvasObject();
            canvasObject.x = x;
            canvasObject.y = y;
            canvasObject.width = width;
            canvasObject.height = height;
            canvasObject.color = color;

            if (objects.Count > 0)
            {
                canvasObject.objectID = objects[objects.Count - 1].objectID + 1;
            }
            else canvasObject.objectID = 1;

            objects.Add(canvasObject);
        }

        public void RemoveObject(int x, int y, int width, int height, int objectID) 
        {
            CanvasObject canvasObject = new CanvasObject() 
            {
                x=x, y=y, width=width, height=height, objectID=objectID
            };

            objects.Remove(canvasObject);
            RenderObjects();
        }

        public void RajzolKor(int x, int y, int radius)
        {
            int d = radius * 2;

            RegisterObject(x, y, d, d, Color.LightGreen);
            RenderObjects();
        }

        public void RajzolKor(int x, int y, int radius, Color color)
        {    
            int d = radius * 2;
            RegisterObject(x, y, d, d, color);
            RenderObjects();   
        }

        private void RenderObjects()
        {
            g = GraphicsSeged.AA_CreateGraphics_From_Panel(this);
            Paint += (object sender, PaintEventArgs e) =>
            {
                g.Clear(BLACK_COLOR); //frissites

                foreach (var obj in objects)
                {
                    //kor rajz
                    g.DrawEllipse(new Pen(obj.color), obj.x, obj.y, obj.width, obj.height);
                    g.FillEllipse(new SolidBrush(obj.color), obj.x, obj.y, obj.width, obj.height);
                }
            };
        }

        /*
        public void RajzolNegyzet(int x, int y, int a)
        {
            Paint += (object sender, PaintEventArgs e) =>
            {
                RegisterObject(x, y, a, a);
                g = GraphicsSeged.AA_Graphics_From_Panel(this);

                g.DrawRectangle(defaultPen, x, y, a, a);
                g.FillRectangle(defaultBrush, x, y, a, a);
            };
        }

        public void RajzolKor(int x, int y, int radius, Color color)
        {
            Paint += (object sender, PaintEventArgs e) =>
            {
                int d = radius * 2;
                RegisterObject(x, y, d, d, color);
                g = GraphicsSeged.AA_Graphics_From_Panel(this);

                g.DrawEllipse(new Pen(color), x, y, d, d);
                g.FillEllipse(new SolidBrush(color), x, y, d, d);
            };
        }
        */
    }
}

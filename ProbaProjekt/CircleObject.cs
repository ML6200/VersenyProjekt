using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VGraphicsX
{
    /// <summary>
    /// Kör Objektum
    /// </summary>
    public class CircleObject
    {
        //koordinatak
        public int x;
        public int y;
        public int z;

        public int e; //ertek

        public CanvasObject3D ToCanvasObject3D(Color color, int objectID)
        {
            CanvasObject3D object3D = new CanvasObject3D()
            {
                x = x, 
                y = y, 
                z=z, 

                width = e, 
                height = e, 
                depth = e,

                color=color,
                objectID = objectID
            };

            return object3D;
        }
    }
}

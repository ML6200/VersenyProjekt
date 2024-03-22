using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace VGraphicsX
{
    internal class FileUtil
    {
        public static void TxtToObjList(string filePath)
        {
            StreamReader sr = new StreamReader(filePath);
            List<CircleObject> objList = new List<CircleObject>();

            string line;
            while ((line = sr.ReadLine()) != null)
            {
                if (line.Contains("X")) //if its the header
                {
                    continue;
                }

                string[] header = line.Split(";");
                CircleObject cObj = new CircleObject()
                {
                    x = Convert.ToInt32(line),
                    y = Convert.ToInt32(line),
                    z = Convert.ToInt32(line),
                    e = Convert.ToInt32(line)
                };

                objList.Add(cObj);
            }
            sr.Close();
        }

        public bool isCorrectFileExtension(string filePath)
        {
            return filePath.EndsWith(".txt"); ;
        }

        /*
        public static bool validateFileStructure(string filePath)
        {
            if (!isCorrectFileExtension(filePath))
            {
                throw new NotValidFileStructureException();
            }

            StreamReader sr = new StreamReader(filePath);
            bool error;

            string line;
            while ((line = sr.ReadLine()) != null)
            {
                if (line.Contains("X")) //if its the header
                {
                    continue;
                }

                string[] header = line.Split(";");

                if (int.TryParse(header[0])
                { 
                }
            }
            sr.Close();

        }
        */
    }

    public partial class NotValidFileStructureException : Exception
    {
        public NotValidFileStructureException(string? message) 
            : base(message)
        {
            
        }

        public NotValidFileStructureException()
            : base(null)
        { }

    }
}

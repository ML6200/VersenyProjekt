using System.IO;

namespace VGraphicsX
{
    internal class FileUtil
    {

        public List<string> ReadFileToList(string filePath)
        {
            if (!File.Exists(filePath) || !isCorrectFileExtension(filePath))
            {
                return null;
            }

            StreamReader sr = new StreamReader(filePath);
            List<string> fileLines = new List<string>();

            int c = 0;
            string line;

            while ((line = sr.ReadLine()) != null)
            {
                c++;

                //if the header is not X;Y;Z;e
                if (!line.Contains("X;Y;Z;e") && c == 1)
                {
                    throw new NotValidFileStructureException();
                }
                //if its the header
                if (line.Contains("X;Y;Z;e") && c == 1)
                {
                    continue;
                }

                fileLines.Add(line);
            }
            sr.Close();

            return fileLines;
        }

        public static List<CircleObject> ConvertListToObjectList(List<string> lines)
        {
            List<CircleObject> objList = new List<CircleObject>();

            foreach (string line in lines)
            {
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

            return objList;
        }

        private bool isCorrectFileExtension(string filePath)
        {
            return filePath.EndsWith(".txt"); ;
        }
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
/*
public static void TxtToObjList(string filePath)
{
    StreamReader sr = new StreamReader(filePath);
    List<CircleObject> objList = new List<CircleObject>();

    string line;
    while ((line = sr.ReadLine()) != null)
    {
        if (line.Contains("X;Y;Z;e")) //if its the header
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
*/
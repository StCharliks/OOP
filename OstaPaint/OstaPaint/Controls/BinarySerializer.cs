using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OstaPaint.Geometry;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Drawing;

namespace OstaPaint.Controls
{
    class BinarySerializer
    {
        private String fileName;
        private static BinarySerializer instance;
        private BinarySerializer() { }

        public String File {
            get
            {
                return fileName;
            }

            set
            {
                fileName = value;
            }
        }

        public static BinarySerializer getInstance()
        {
            if (instance == null)
            {
                instance = new BinarySerializer();
            }
            return instance;
        }

        public void serialise(List<Color> figures)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using(FileStream fs = new FileStream(File, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, figures);
            }
        }

        public List<Shape> deserialize()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(File, FileMode.Open))
            {
                return (List<Shape>)formatter.Deserialize(fs);
            }
        }
    }
}

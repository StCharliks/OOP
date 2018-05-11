using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Drawing;
using System.IO;
using OstFigures;

namespace OstaPaint.Controls
{
    class serializerJSON
    {
        private Type[] knownTypes = {typeof(Line), typeof(OstFigures.Rectangle), typeof(Ellipce), typeof(Shape), typeof(Square), typeof(Trianle), typeof(Circle) };
        private String fileName;
        private static serializerJSON instance;
        private serializerJSON() { }

        public static serializerJSON getInstance()
        {
            if (instance == null)
            {
                instance = new serializerJSON();
            }

            return instance;
        }

        public static serializerJSON getInstance(String fName)
        {
            if (instance == null)
            {
                instance = new serializerJSON();
            }

            instance.fileName = fName;
            return instance;
        }

        public void serialise(List<Shape> figures)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Shape>), knownTypes);

            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, figures);
            }
        }

        public List<Shape> deserialize()
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Shape>), knownTypes);

            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                return (List<Shape>)jsonFormatter.ReadObject(fs);
            }
        }
    }
}

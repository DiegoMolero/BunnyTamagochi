using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace bunny.src.dominio
{
    class GenerateXml
    {
        public GenerateXml(Double bar_sueño, Double bar_hambre, Double bar_caca,Double bar_diversion,int score, int cacas){
            XmlTextWriter writer = new XmlTextWriter("product.xml", System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("Data");
            createNode("bar","sueño", bar_sueño.ToString(), writer);
            createNode("bar","hambre", bar_hambre.ToString(), writer);
            createNode("bar","caca", bar_caca.ToString(), writer);
            createNode("bar", "diversion", bar_diversion.ToString(), writer);
            createNode("data","score", score.ToString(), writer);
            createNode("data","cacas", cacas.ToString(), writer);
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }
        private void createNode(string element,string name, string value, XmlTextWriter writer)
        {
            writer.WriteStartElement(element);
                 writer.WriteStartElement("name");
                    writer.WriteString(name);
                    writer.WriteEndElement();
            writer.WriteStartElement("value");
                    writer.WriteString(value);
                    writer.WriteEndElement();
            writer.WriteEndElement();
        }
    }
}

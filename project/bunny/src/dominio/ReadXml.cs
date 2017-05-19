using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace bunny.src.dominio
{
    class ReadXml
    {

        public ReadXml(ProgressBarControler progressbar_controler)
        {
            try { 
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("product.xml");
            String name= null;
            double value = 0;
            int valueInt = 0;
            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/Data/bar");
                Globals.firstGame = false;
                foreach (XmlNode node in nodeList)
            {
                name = node.SelectSingleNode("name").InnerText;
               value = Convert.ToDouble(node.SelectSingleNode("value").InnerText);
                if (name == "sueño")
                {
                    Globals.ProgressBar_sueño.Value = value;
                }
                else if(name == "hambre")
                {
                    Globals.ProgressBar_hambre.Value = value;
                }
                else if(name == "caca")
                {
                    Globals.ProgressBar_baño.Value = value;
                }
            }
            nodeList = xmlDoc.DocumentElement.SelectNodes("/Data/data");
           foreach (XmlNode node in nodeList)
                {
                    name = node.SelectSingleNode("name").InnerText;
                    valueInt = Convert.ToInt16(node.SelectSingleNode("value").InnerText);
                    if (name == "score")
                    {
                        Globals.score = valueInt;
                    }
                    else if (name == "cacas")
                    {
                        for (int i = 0; i < valueInt; i++)
                        {
                            progressbar_controler.crearCaca();
                        }
                    }
                }

            }
            catch { }
        }
    }
}

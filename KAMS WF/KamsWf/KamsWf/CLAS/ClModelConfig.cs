using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace KamsWf.CLAS
{
    class ClModelConfig
    {
        public int velWindows;                           //velocidad del mouse en windows (0-20)
        public int velApp;                             //velocidad del mouse en nuestra aplicacion (0-20)
        public int timeDoubleClick;                    //milliseconds para el doble click
        public String idioma;                         //idioma de la aplicacion
        public int sizeFont;                           //tamaño de la fuente de nuestra aplicacion
        public String typeFont;                       //tipo de fuente de nuestra aplicacion
        public String ruta = "\\XML\\xmlConfiguracio.xml";   //ruta donde se encuentra el fichero    
        public String startUpPath;
        private XmlDocument xDoc = new XmlDocument();

        public ClModelConfig(String startUpPath)
        {
            this.startUpPath = startUpPath;
        }

        public void escriuXML()
        {
            // Utilitzem objectes de System.XML
            XmlNode xNodeArrel, xNodeSpeed, xNodeFuente;
            XmlElement xVelWind, xVelApp, xTimeDoubleClick, xtypeFont, xsizeFont, xIdioma;
            XmlDeclaration xDeclaracio;
            XmlComment xComentari;

            // inserim la declaració sobre l'estàndard XML i la codificació, el "yes" indica que aquest XML no depèn d'una font externa (un arxiu d'schema DTD, XSD)
            xDeclaracio = xDoc.CreateXmlDeclaration("1.0", "utf-8", "yes");
            xDoc.InsertBefore(xDeclaracio, xDoc.DocumentElement);

            // afegim un comentari
            xComentari = xDoc.CreateComment("Configuracio");
            xDoc.InsertAfter(xComentari, xDeclaracio);


            xNodeArrel = xDoc.CreateElement("Configuracio");
            xDoc.AppendChild(xNodeArrel);

            #region ---------------  Speed  ----------------
            //afegim el node Speed
            xNodeSpeed = xDoc.CreateElement("speed");
            xNodeArrel.AppendChild(xNodeSpeed);

            //creem l'element VelWindows
            xVelWind = xDoc.CreateElement("velWindows");
            xVelWind.InnerText = velWindows.ToString();     //li donem valor
            xNodeSpeed.AppendChild(xVelWind);
            //creem l'element VelApp
            xVelApp = xDoc.CreateElement("velApp");
            xVelApp.InnerText = velApp.ToString();     //li donem valor 
            xNodeSpeed.AppendChild(xVelApp);
            //creem l'element TimeDoubleClick
            xTimeDoubleClick = xDoc.CreateElement("timeDoubleClick");
            xTimeDoubleClick.InnerText = timeDoubleClick.ToString();     //li donem valor
            xNodeSpeed.AppendChild(xTimeDoubleClick);
            #endregion

            #region ----------------  Font  --------------
            //afegim el node Font
            xNodeFuente = xDoc.CreateElement("font");
            xNodeArrel.AppendChild(xNodeFuente);

            //creem l'element sizeFont
            xsizeFont = xDoc.CreateElement("sizeFont");
            xsizeFont.InnerText = sizeFont.ToString();     //li donem valor
            xNodeFuente.AppendChild(xsizeFont);
            //creem l'element typeFont
            xtypeFont = xDoc.CreateElement("typeFont");
            xtypeFont.InnerText = typeFont;     //li donem valor 
            xNodeFuente.AppendChild(xtypeFont);
            #endregion

            //creem l'element Idioma
            xIdioma = xDoc.CreateElement("idioma");
            xIdioma.InnerText = idioma;     //li donem valor
            xNodeArrel.AppendChild(xIdioma);

            // afegim un comentari
            xComentari = xDoc.CreateComment("Fi de la llista");
            xDoc.InsertAfter(xComentari, xNodeArrel);

            xDoc.Save(startUpPath+ruta);
            
        }

        public void llegirXML()
        {
            xDoc.Load(startUpPath+ruta);

            //SPEED
            velWindows = Convert.ToInt16(xDoc.DocumentElement.ChildNodes[0].ChildNodes[0].InnerText);         //recuperamos el primer hijo del primer nodo
            velApp = Convert.ToInt16(xDoc.DocumentElement.ChildNodes[0].ChildNodes[1].InnerText);             //recuperamos el segundo hijo del primer nodo
            timeDoubleClick = Convert.ToInt16(xDoc.DocumentElement.ChildNodes[0].ChildNodes[2].InnerText);     //recuperamos el tercer hijo del primer nodo
            //FONT
            sizeFont = Convert.ToInt16(xDoc.DocumentElement.ChildNodes[1].ChildNodes[0].InnerText);       //recuperamos el primer hijo del segundo nodo
            typeFont = xDoc.DocumentElement.ChildNodes[1].ChildNodes[1].InnerText;                        //recuperamos el segundo hijo del segundo nodo
            //LANGUAGE
            idioma = xDoc.DocumentElement.ChildNodes[2].InnerText;                                        //recuperamos el tercer nodo

        }
        
        public void validarCarpeta()
        {
            if (!(Directory.Exists(startUpPath + "\\XML")))
            {
                Directory.CreateDirectory(startUpPath + "\\XML");
            }
        }

        public bool validarFichero()
        {
            return File.Exists(startUpPath + ruta);
        }
    }
}

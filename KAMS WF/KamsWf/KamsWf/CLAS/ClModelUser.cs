using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace KamsWf.CLAS
{
    class ClModelUser
    {
        public String startUpPath;
        public String foto;                            //String donde guardamos la ruta de la foto
        public String name;                            // String con el nombre del usuario
        public XmlDocument xDoc = new XmlDocument();
        public String ruta = "\\XML\\";     //ruta donde se encuentra el fichero

        public ClModelUser(String startUpPath)
        {
            this.startUpPath = startUpPath;
            validarCarpeta();
            if (!File.Exists(startUpPath + ruta + "xmlUsers.xml"))
            {
                escriuXML(xDoc, "xmlUsers.xml");
            }
        }

        public void escriuXML(XmlDocument xmlDoc, String nomFitxer)
        {
            // Utilitzem objectes de System.XML
            XmlNode xNodeArrel;
            XmlDeclaration xDeclaracio;
            XmlComment xComentari;

            // inserim la declaració sobre l'estàndard XML i la codificació, el "yes" indica que aquest XML no depèn d'una font externa (un arxiu d'schema DTD, XSD)
            xDeclaracio = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "yes");
            xmlDoc.InsertBefore(xDeclaracio, xmlDoc.DocumentElement);

            // afegim un comentari
            xComentari = xmlDoc.CreateComment("Usuaris");
            xmlDoc.InsertAfter(xComentari, xDeclaracio);


            xNodeArrel = xmlDoc.CreateElement("Users");
            xmlDoc.AppendChild(xNodeArrel);

            // afegim un comentari
            xComentari = xmlDoc.CreateComment("Fi de la llista");
            xmlDoc.InsertAfter(xComentari, xNodeArrel);

            guardarXML(xmlDoc, nomFitxer);

        }

        //funcion que carga el xml que le pasamos por parametros en el xml de la clase
        public void cargarXML(String nomFitxer)
        {
            xDoc.Load(startUpPath + ruta + nomFitxer);
        }

        public bool crearUser(String nom, String rutaFoto, XmlDocument xmlDoc, String nomFitxer)
        {

            bool correcte = false;            //variable que nos permite gestionar si se a creado correctamente o no
            XmlNode xUser;
            XmlElement xNom, xFoto;

            //comprobamos si ya existe el usuario (nom= PK)
            if (!comprobarUsers(nom, nomFitxer))
            {
                //creo el nodo User
                xUser = xmlDoc.CreateElement("user");
                xmlDoc.DocumentElement.AppendChild(xUser);

                //creamos el elemento Nom del User
                xNom = xmlDoc.CreateElement("nom");
                xNom.InnerText = nom;     //li donem valor
                xUser.AppendChild(xNom);

                //creamos el elemento Foto del User
                xFoto = xmlDoc.CreateElement("rutaFoto");
                xFoto.InnerText = rutaFoto;     //li donem valor 
                xUser.AppendChild(xFoto);

                guardarXML(xmlDoc, nomFitxer);

                correcte = true;
            }

            return correcte;
        }

        private bool comprobarUsers(String nomUser, String nomFitxer)
        {
            int n = 0;
            bool existe = false;
            String nomComparar, nomXMLComparar;

            cargarXML(nomFitxer);

            //recuperamos todos los nodos dentro de USERS
            foreach (XmlNode xnode in xDoc.DocumentElement.ChildNodes)
            {
                //pasamos a mayuscula lo que obtenemos con lo que queremos comparar 
                nomXMLComparar = xnode.ChildNodes[0].InnerText.ToUpper();
                nomComparar = nomUser.ToUpper();

                if (nomXMLComparar.Equals(nomComparar))
                {
                    existe = true;
                }

                n++;
            }

            return existe;
        }

        public bool eliminarUser(String nomUser)
        {
            bool correcte = true;
            XmlDocument xml = new XmlDocument();
            int n = 0;

            try
            {
                //creamos el fichero en el que guardaremos todos los usuarios menos el que queremos eliminar
                escriuXML(xml, "xmlUsers2.xml");
                cargarXML("xmlUsers.xml");

                foreach (XmlNode xnode in xDoc.DocumentElement.ChildNodes)
                {

                    if (!(xnode.ChildNodes[0].InnerText.ToUpper().Equals(nomUser.ToUpper())))
                    {
                        //creamos usuario en el fichero 2
                        crearUser(xnode.ChildNodes[0].InnerText, xnode.ChildNodes[1].InnerText, xml, "xmlUsers2.xml");
                    }
                    else
                    {
                        correcte = true;
                    }
                }
                //eliminamos el fichero 1
                File.Delete(startUpPath + ruta + "xmlUsers.xml");
                //le cambiamos el nombre al fichero 2 --> pasa a fichero 1
                File.Move(startUpPath + ruta + "xmlUsers2.xml", startUpPath + ruta + "xmlUsers.xml");

                guardarXML(xml, "xmlUsers.xml");
            }
            catch
            {
                correcte = false;
            }

            return correcte;
        }

        public void modificarUser(String nomUserNou, String nomUserVell, String rutaFoto)
        {
            XmlDocument xml = new XmlDocument();
            int n = 0;


            //creamos el fichero en el que guardaremos todos los usuarios menos el que queremos eliminar
            escriuXML(xml, "xmlUsers2.xml");
            cargarXML("xmlUsers.xml");

            foreach (XmlNode xnode in xDoc.DocumentElement.ChildNodes)
            {

                if (!(xnode.ChildNodes[0].InnerText.ToUpper().Equals(nomUserVell.ToUpper())))
                {
                    //creamos usuario en el fichero 2
                    crearUser(xnode.ChildNodes[0].InnerText, xnode.ChildNodes[1].InnerText, xml, "xmlUsers2.xml");
                }
                else
                {
                    if (nomUserNou != null && rutaFoto != null)
                    {
                        crearUser(nomUserNou, rutaFoto, xml, "xmlUsers2.xml");
                    }
                    else
                    {
                        if (nomUserNou == null)
                        {
                            crearUser(nomUserVell, rutaFoto, xml, "xmlUsers2.xml");
                        }
                        else
                        {
                            crearUser(nomUserNou, xnode.ChildNodes[0].InnerText, xml, "xmlUsers2.xml");
                        }
                    }
                }
                n++;
            }
            //eliminamos el fichero 1
            File.Delete(startUpPath + ruta + "xmlUsers.xml");
            //le cambiamos el nombre al fichero 2 --> pasa a fichero 1
            File.Move(startUpPath + ruta + "xmlUsers2.xml", startUpPath + ruta + "xmlUsers.xml");

            guardarXML(xml, "xmlUsers.xml");
        }
        //Metodo para encontrar la cadena de la foto del usuario
        public String findFoto(String nomUser)
        {
            String foto = "";

            foreach (XmlNode xnode in xDoc.DocumentElement.ChildNodes)
            {
                if (xnode.ChildNodes[0].InnerText.Equals(nomUser))
                {
                    foto = xnode.ChildNodes[1].InnerText;
                }
            }
            return foto;
        }

        //guardamos el xml que le pasamos con el nombre que le pasamos
        public void guardarXML(XmlDocument xmlDoc, String nomFitxer)
        {
            xmlDoc.Save(startUpPath + ruta + nomFitxer);
        }

        //validamos si existe la carpeta xml, sino la creamos
        public void validarCarpeta()
        {
            if (!(Directory.Exists(startUpPath + "\\XML")))
            {
                Directory.CreateDirectory(startUpPath + "\\XML");
            }
        }

        //validamos si existe el fichero
        public bool validarFichero()
        {
            return File.Exists(startUpPath + ruta);
        }
    }
}

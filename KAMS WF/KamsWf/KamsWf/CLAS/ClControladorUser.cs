using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace KamsWf.CLAS
{
    class ClControladorUser
    {
        ClModelUser model;
        private String nomXML="xmlUsers.xml";
        public XmlDocument xDoc = new XmlDocument();

        //Constructor
        public ClControladorUser(String startUpPath)
        {
            model = new ClModelUser(startUpPath);
            xDoc = model.xDoc;
        }

        //Escriu XML
        public void escriuXML()
        {
            model.escriuXML(model.xDoc, nomXML);
        }

        //Carga XML
        public void cargarXML()
        {
            model.cargarXML(nomXML);
        }

        //Crea User
        public bool crearUser(String nomUser, String rutaFotoUser)
        {
            return model.crearUser(nomUser, rutaFotoUser, model.xDoc, nomXML);
        }

        //Elimina User
        public bool eliminarUser(String nomUser)
        {
            return model.eliminarUser(nomUser);
        }

        //Modifica user
        public void modificaUser(String nomUser, String nomUserVell, String rutaFoto)
        {
            model.modificarUser(nomUser, nomUserVell, rutaFoto);
        }

        //Valida Carpeta
        public void validarCarpeta()
        {
            model.validarCarpeta();
        }

        //valida Fichero
        public bool validarFitxer()
        {
            return model.validarFichero();
        }
    }
}

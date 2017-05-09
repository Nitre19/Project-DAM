using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.CLASES
{
    class ClControladorConfig
    {
        ClModelConfig model;

        public ClControladorConfig(String startUpPath)
        {
            model = new ClModelConfig(startUpPath);
        }

        #region ------------- GETTERS & SETTERS ------------------
        public int VelWindows
        {
            get
            {
                return model.velWindows;
            }

            set
            {
                model.velWindows = value;
            }
        }

        public int VelApp
        {
            get
            {
                return model.velApp;
            }

            set
            {
                model.velApp = value;
            }
        }

        public int TimeDoubleClick
        {
            get
            {
                return model.timeDoubleClick;
            }

            set
            {
                model.timeDoubleClick = value;
            }
        }

        public string Idioma
        {
            get
            {
                return model.idioma;
            }

            set
            {
                model.idioma = value;
            }
        }

        public int SizeFont
        {
            get
            {
                return model.sizeFont;
            }

            set
            {
                model.sizeFont = value;
            }
        }

        public string TypeFont
        {
            get
            {
                return model.typeFont;
            }

            set
            {
                model.typeFont = value;
            }
        }
        #endregion

        public void escriureXML()
        {
            model.escriuXML();
        }
        
        public void llegirXML()
        {
            model.llegirXML();
        }

        public void validarCarpeta()
        {
            model.validarCarpeta();
        }

        //metodo que nos permitira llenar las variables del model nomes inicia la aplicacio
        public bool validarFichero()
        {
            bool existe;

            //si ja existeix el fitxer, agafem la configuracio que hi ha guardada
            if (model.validarFichero())
            {
                llegirXML();
                existe = true;
            }else //si no existeix
            {
                existe = false;     //retorna false, i a la vista afegirem els valor per defecte al model
            }

            return existe;
        }
    }
}

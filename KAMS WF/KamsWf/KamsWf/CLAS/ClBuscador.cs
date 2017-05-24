using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamsWf.CLAS
{
    class ClBuscador
    {
        //el String ruta debe ir con un @ delante si ponemos 1 \, sino hay que poner \\
        public static List<String> RecuperaEXES(String ruta)
        {
            List<String> array = new List<string>();

            DirectoryInfo directori = new DirectoryInfo(ruta);

            foreach (var file in directori.GetFiles("*.exe"))
            {
                //Console.WriteLine(file.Name);
                array.Add(file.Name);
            }

            return array;
        }
    }
}

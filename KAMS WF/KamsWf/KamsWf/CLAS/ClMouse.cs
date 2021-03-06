﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KamsWf.CLAS
{
    class ClMouse
    {
        public const UInt32 SPI_SETMOUSESPEED = 0x0071; //variable en la posicion 1 para poner velocidad al raton
        public const uint SPI_GETMOUSESPEED = 0x0070; //variable en la posicion 1 para obtener velocidad al raton
        public const uint SPIF_UPDATEINIFILE = 0x01;

        public struct PUNT
        {
            public int X;
            public int Y;
        }

        // obtenim la posició del cursor
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(ref PUNT lpPoint);       // posem static perquè la definició la tenim en una llibreria externa

        // posar la posició del cursor
        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int x, int y);

        // obtenir el darrer error 
        [DllImport("user32.dll")]
        public static extern long GetLastError();

        //Cambiar configuració del sistema
        //uiAction --> Indiquem la configuracio que volem obtenir o que volem cambiar
        // pagina amb informacio http://www.jasinskionline.com/windowsapi/ref/s/systemparametersinfo.html
        //SPI_SETMOUSE --> cambiar velocitat del mouse
        [DllImport("User32.dll")]
        public static extern Boolean SystemParametersInfo(UInt32 uiAction,UInt32 uiParam,UInt32 pvParam,UInt32 fWinIni);
        
        public static String obtenerVelocidad()
        {
            return SystemInformation.MouseSpeed.ToString();
        }

        //Boton izquierdo del mouse apretado
        public static void MouseLeftDown()
        {
            mouse_event(MouseEventFlag.LeftDown, 0, 0, 0, UIntPtr.Zero);
        }
        //Boton izquierdo del mouse soltado
        public static void MouseLeftUp()
        {
            mouse_event(MouseEventFlag.LeftUp, 0, 0, 0, UIntPtr.Zero);
        }

        //Hacer click
        public static void DoMouseClick()
        {
            mouse_event(MouseEventFlag.LeftDown | MouseEventFlag.LeftUp, 0, 0, 0, UIntPtr.Zero);
        }
        //Boton derecho del mouse apretado
        public static void MouseRightDown()
        {
            mouse_event(MouseEventFlag.RightDown, 0, 0, 0, UIntPtr.Zero);
        }
        //Boton derecho del mouse soltado
        public static void MouseRightUp()
        {
            mouse_event(MouseEventFlag.RightUp, 0, 0, 0, UIntPtr.Zero);
        }
        [DllImport("user32.dll")]
        static extern void mouse_event(MouseEventFlag flags, int dx, int dy, uint data, UIntPtr extraInfo);
        [Flags]
        enum MouseEventFlag : uint
        {
            Move = 0x0001,
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            MiddleDown = 0x0020,
            MiddleUp = 0x0040,
            XDown = 0x0080,
            XUp = 0x0100,
            Wheel = 0x0800,
            VirtualDesk = 0x4000,
            Absolute = 0x8000
        }
        /* Cambiem els controls del mouse
        [DllImport("user32.dll")]
        public static extern bool SwapMouseButton(bool cambi);
        */

        /* Cambiem la frecuencia dels clicks
        [DllImport("user32.dll")]
        public static extern bool SetDoubleClickTime(int miliseconds);
        */

        /* mirem si una determinada tecla s'ha premut
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int tecla);
        */

        /* obtenir la tecla premuda
        public static char quinaTeclaPremuda()          // si no posem static no serà accessible des de fora de la classe
        {
            int i = 0;
            char xch = '\0';

            for (i = 0; i < 256; i++)
            {
                if (GetAsyncKeyState(i) != 0)
                {
                    xch = Convert.ToChar(i);
                }
            }
            return (xch);
        }
        */
    }
}

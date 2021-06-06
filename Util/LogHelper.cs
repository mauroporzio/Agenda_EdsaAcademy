using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public class LogHelper : IDisposable
    {
        public string logPath { get; } = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigurationManager.AppSettings["logPath"]); // combina el path de donde se encuentra el dominio de la app y se le agrega desde una key del web.config el nombre del archivo a crear o modificar.

        public void log(string errorMessage) // se recibe el error a logear por parametro.
        {
            DateTime now = DateTime.Now; // se guarda la fecha y hora para luego agregarla al log.
            File.AppendAllText(logPath, string.Concat(now.ToString(), " ", errorMessage, Environment.NewLine)); // si el archivo no existe se crea, carga el error y luego se guarda, pero sino solo agrega el error al log ya creado anteriormente.
        }
        public void Dispose()
        {

        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace TP09.Models
{
    public class Usuario
    {
        [JsonProperty]
        public string Nombre { get; private set; }
        [JsonProperty]
        public int CantidadIntentos { get; private set; }
        public Usuario(string n, int ci)
        {
            this.Nombre = n;
            this.CantidadIntentos = ci;
        }
    }
}
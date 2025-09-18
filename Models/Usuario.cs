using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace TP09.Models
{
    public class Usuario
    {
        [JsonProperty]
        private string Nombre { get; set; }
        [JsonProperty]
        private int CantidadIntentos { get; set; }
        public Usuario(string n, int ci)
        {
            this.Nombre = n;
            this.CantidadIntentos = ci;
        }
    }
}
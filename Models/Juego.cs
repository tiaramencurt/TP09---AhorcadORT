using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace TP09.Models
{
    public class Juego
    {
        [JsonProperty]
        private List<string> ListaPalabras { get; set; }
        [JsonProperty]
        private List<Usuario> Jugadores { get; set; }
        [JsonProperty]
        private Usuario JugadorActual { get; set; }
    }
}
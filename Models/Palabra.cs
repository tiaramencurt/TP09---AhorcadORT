using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace TP09.Models
{
    public class Palabra
    {
        [JsonProperty]
        public string Texto { get; private set; }
        [JsonProperty]
        public int Dificultad { get; private set; }

        public Palabra(string t, int d)
        {
            this.Texto = t;
            this.Dificultad = d;
        }
    }
}
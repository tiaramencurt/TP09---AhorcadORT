using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace TP09.Models
{
    public class Palabra
    {
        [JsonProperty]
        private string Texto { get; set; }
        [JsonProperty]
        private int Dificultad { get; set; }

        public Palabra(string t, int d)
        {
            this.Texto = t;
            this.Dificultad = d;
        }
    }
}
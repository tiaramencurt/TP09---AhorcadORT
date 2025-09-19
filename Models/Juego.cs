using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace TP09.Models
{
    public class Juego
    {
        [JsonProperty]
        public List<Palabra> ListaPalabras { get; private set; }
        [JsonProperty]
        public List<Usuario> Jugadores { get; private set; }
        [JsonProperty]
        public Usuario JugadorActual { get; private set; }
        [JsonProperty]
        public Palabra PalabraActual { get; private set; }
        private void LlenarListaPalabras()
        {
            ListaPalabras = new List<Palabra>
            {
                new Palabra("casa", 1),
                new Palabra("sol", 1),
                new Palabra("gato", 1),
                new Palabra("perro", 1),
                new Palabra("flor", 1),
                new Palabra("mesa", 1),
                new Palabra("silla", 1),
                new Palabra("pan", 1),
                new Palabra("luz", 1),
                new Palabra("agua", 1),

                // Dificultad 2 (10 palabras)
                new Palabra("camion", 2),
                new Palabra("escuela", 2),
                new Palabra("montaña", 2),
                new Palabra("ciudad", 2),
                new Palabra("ventana", 2),
                new Palabra("jardin", 2),
                new Palabra("reloj", 2),
                new Palabra("guitarra", 2),
                new Palabra("pelota", 2),
                new Palabra("botella", 2),

                // Dificultad 3 (10 palabras)
                new Palabra("murcielago", 3),
                new Palabra("computadora", 3),
                new Palabra("bicicleta", 3),
                new Palabra("escritorio", 3),
                new Palabra("biblioteca", 3),
                new Palabra("television", 3),
                new Palabra("ventilador", 3),
                new Palabra("calendario", 3),
                new Palabra("electricidad", 3),
                new Palabra("microondas", 3),

                // Dificultad 4 (10 palabras)
                new Palabra("otorrinolaringologo", 4),
                new Palabra("desoxirribonucleico", 4),
                new Palabra("electroencefalograma", 4),
                new Palabra("anticonstitucionalmente", 4),
                new Palabra("paralelepipedo", 4),
                new Palabra("transustanciacion", 4),
                new Palabra("inconstitucionalidad", 4),
                new Palabra("esternocleidomastoideo", 4),
                new Palabra("clorofluorocarbonado", 4),
                new Palabra("hipopotomonstrosesquipedaliofobia", 4)
            };
        }
        public void InicializarJuego(string usuario, int dificultad)
        {
            this.JugadorActual = new Usuario(usuario, 0);
            this.Jugadores = new List<Usuario>();
            LlenarListaPalabras();
            this.PalabraActual = CargarPalabra(dificultad);
            if(this.PalabraActual == null)
            {
                this.PalabraActual = CargarPalabra(1);
            }        
        }
        private Palabra CargarPalabra(int dificultad)
        {
            List<Palabra> filtradas = new List<Palabra>();
            for (int i = 0; i < ListaPalabras.Count; i++)
            {
                if (ListaPalabras[i].Dificultad == dificultad)
                {
                    filtradas.Add(ListaPalabras[i]);
                }
            }

            if (filtradas.Count == 0)
            {
                return null;
            }
            Random rnd = new Random();
            int indice = rnd.Next(filtradas.Count);
            return filtradas[indice];
        }
        public void FinJuego()
        {
            this.Jugadores.Add(JugadorActual);
        }
        public List<Usuario> DevolverListaUsuarios()
        {
            
        }
    }
}
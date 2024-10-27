using System;

namespace EjerciciosRefuerzo
{
    internal class Ejercicio5
    {
        public static void ejercicio5()
        {
            Juego juego1 = new Juego(5);
            juego1.MuestraVidasRestantes();

            juego1.vidas--;
            juego1.MuestraVidasRestantes();

            Juego juego2 = new Juego(5);
            juego2.MuestraVidasRestantes();

            juego1.MuestraVidasRestantes();
        }

        class Juego
        {
            public int vidas;

            public Juego(int vidasIniciales)
            {
                vidas = vidasIniciales;
            }

            public void MuestraVidasRestantes()
            {
                Console.WriteLine($"Vidas restantes: {vidas}");
            }
        }
    }
}


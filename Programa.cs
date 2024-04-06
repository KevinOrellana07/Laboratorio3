using System;

public class Totito
{
    private static char[][] tablero;
    private static int turno;
    private static bool  JuegoTerminado;

    public static void Main(string[] args)
    {
        tablero = new char[3][];
        for (int i = 0; i < tablero.Length; i++)
        {
            tablero[i] = new char[3];
            for (int j = 0; j < tablero[i].Length; j++)
            {
                tablero[i][j] = ' ';
            }
        }

        turno = 1;
        JuegoTerminado = false;

        while (!juegoTerminado)
        {
            MostrarTablero();

            int fila, columna;
            do
            {
                Console.WriteLine("Es el turno del jugador {0}:", turno);
                Console.Write("Ingrese la fila (1-3): ");
                fila = int.Parse(Console.ReadLine());
                Console.Write("Ingrese la columna (1-3): ");
                columna = int.Parse(Console.ReadLine());
            } while (!PosicionValida(fila, columna));

            tablero[fila - 1][columna - 1] = (turno == 1) ? 'X' : 'O';

            if (ComprobarGanador())
            {
                MostrarTablero();
                Console.WriteLine("¡Muchas Felicidades, jugador {0} ha ganado!", turno);
                juegoTerminado = true;
            }
            else if (TableroLleno())
            {
                MostrarTablero();
                Console.WriteLine("Es un empate!");
                juegoTerminado = true;
            }

            turno = (turno == 1) ? 2 : 1;
        }
    }

    private static void MostrarTablero()
    {
        Console.WriteLine("---------");
        for (int i = 0; i < tablero.Length; i++)
        {
            Console.Write("| ");
            for (int j = 0; j < tablero[i].Length; j++)
            {
                Console.Write("{0} ", tablero[i][j]);
            }
            Console.WriteLine("|");
        }
        Console.WriteLine("---------");
    }

    private static bool PosicionValida(int fila, int columna)
    {
        return fila >= 1 && fila <= 3 && columna >= 1 && columna <= 3 && tablero[fila - 1][columna - 1] == ' ';
    }

    private static bool ComprobarGanador()
    {
        for (int i = 0; i < tablero.Length; i++)
        {
            if (tablero[i][0] == tablero[i][1] && tablero[i][1] == tablero[i][2] && tablero[i][0] != ' ')
            {
                return true;
            }
        }

        for (int i = 0; i < tablero[0].Length; i++)
        {
            if (tablero[0][i] == tablero[1][i] && tablero[1][i] == tablero[2][i] && tablero[0][i] != ' ')
            {
                return true;
            }
        }

        if (tablero[0][0] == tablero[1][1] && tablero[1][1] == tablero[2][2] && tablero[0][0] != ' ')
        {
            return true;
        }
        if (tablero[0][2] == tablero[1][1] && tablero[1][1] == tablero[2][0] && tablero[0][2] != ' ')
        {
            return true;
        }

        return false;
    }

    private static bool TableroLleno()
    {
        for (int i = 0; i < tablero.Length; i++)
        {
            for (int j = 0; j < tablero[i].Length; j++)
            {
                if (tablero[i][j] == ' ')
                {
                    return false;
                }
            }
        }

        return true;
    }
}
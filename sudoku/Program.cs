using System;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] sudoku = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    sudoku[i, j] = 0;
                }
            }

            Console.WriteLine("¡Bienvenido al juego de Sudoku!\n");

            while (!IsSudokuComplete(sudoku))
            {
                Console.Clear(); // Limpia la consola para mostrar el tablero actualizado.
                DisplaySudoku(sudoku);

                Console.WriteLine("Ingresa el número y las coordenadas (fila columna) separados por espacios (ejemplo: 5 3 2):");
                string[] input = Console.ReadLine().Split(' ');

                if (input.Length == 3)
                {
                    int num = int.Parse(input[0]);
                    int row = int.Parse(input[1]) - 1; // Resta 1 para ajustarse a índices de matriz.
                    int col = int.Parse(input[2]) - 1;

                    if (row >= 0 && row < 9 && col >= 0 && col < 9)
                    {
                        if (ValidarNumero(sudoku, row, col, num))
                        {
                            sudoku[row, col] = num;
                        }
                        else
                        {
                            Console.WriteLine("Número inválido en esa posición. Intenta de nuevo.");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Coordenadas fuera de rango. Intenta de nuevo.");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Debes ingresar el número y las coordenadas separados por espacios.");
                    Console.ReadKey();
                }
            }

            Console.Clear();
            DisplaySudoku(sudoku);
            Console.WriteLine("¡Felicidades, has completado el Sudoku!");
            Console.ReadKey();
        }

        private static bool IsSudokuComplete(int[,] sudoku)
        {
            foreach (int num in sudoku)
            {
                if (num == 0)
                {
                    return false;
                }
            }
            return true;
        }

        private static bool ValidarNumero(int[,] sudoku, int fila, int columna, int numero)
        {
            for (int i = 0; i < 9; i++)
            {
                if (sudoku[fila, i] == numero || sudoku[i, columna] == numero)
                {
                    return false;
                }
            }

            int subcuadriculaFila = (fila / 3) * 3;
            int subcuadriculaColumna = (columna / 3) * 3;

            for (int i = subcuadriculaFila; i < subcuadriculaFila + 3; i++)
            {
                for (int j = subcuadriculaColumna; j < subcuadriculaColumna + 3; j++)
                {
                    if (sudoku[i, j] == numero)
                    {
                        return false;
                    }
                }
            }

            return true; // Devolver true si el número es válido en todas las comprobaciones.
        }

        private static void DisplaySudoku(int[,] sudoku)
        {
            Console.WriteLine("Estado actual del Sudoku:\n");

            for (int i = 0; i < 9; i++)
            {
                if (i % 3 == 0 && i != 0)
                {
                    Console.WriteLine("------+-------+------");
                }

                for (int j = 0; j < 9; j++)
                {
                    if (j % 3 == 0 && j != 0)
                    {
                        Console.Write("| ");
                    }

                    Console.Write(sudoku[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}

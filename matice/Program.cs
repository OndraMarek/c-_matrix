using System;

namespace matice
{
    class Program
    {
    const int MATRIX_SIZE = 3;

        static void setMatrix(int[,] matrix) // Funkce pro nastavení hodnot matice
        {
            Random rnd = new Random();
            int num;
            for (int i = 0; i < MATRIX_SIZE; i++)
            {
                for (int j = 0; j < MATRIX_SIZE; j++)
                {
                    do {
                        //Console.Write("Zadejte hodnotu matice na indexu[{0},{1}]:", i, j);
                        //num = Convert.ToInt32(Console.ReadLine());
                        num= rnd.Next(-9,9);
                    } while (num < -9 || num>9);
                    matrix[i, j] = num;
                }
            }
            Console.WriteLine();
            return;
        }

        static void printMatrix(int[,] matrix,string a) //Funkce pro výpis matice
        {
            Console.WriteLine("{0} matice:",a);
            for (int i = 0; i < MATRIX_SIZE; i++)
            {
                for (int j = 0; j < MATRIX_SIZE; j++)
                {
                    Console.Write("{0,5}",matrix[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            return;
        }

        static void calcMatrix(int[,] one, int[,] two,int[,] result) //Funkce pro výpočet součtu a rozdílu matice
        {
            Console.Write("Zadejte znak '+' pro sočítání nebo '-' pro odčítání: ");
            string op = Console.ReadLine();
            if (op == "+" || op == "-")
            {
                for (int i = 0; i < MATRIX_SIZE; i++)
                {
                    for (int j = 0; j < MATRIX_SIZE; j++)
                    {
                        if (op == "+")
                        {
                            result[i, j] = one[i, j] + two[i, j];
                        }
                        else if (op == "-")
                        {
                            result[i, j] = one[i, j] - two[i, j];
                        }
                    }
                }
                Console.WriteLine();
            }
            else
                Console.WriteLine("Byl zadán špatný znak");
            return;
        }

        static void matrixDeterminant(int[,] matrix) //Funkce pro výpočet determintu čtvercové matice maximálně 3. stupně
        {
            int det = 0;
            if (MATRIX_SIZE == 1)
            {
                det = matrix[0, 0];
                Console.WriteLine("Determinant výsledné matice je: {0}", det);
                Console.WriteLine();
            }
            else if (MATRIX_SIZE == 2)
            {
                det = matrix[0, 0] * matrix[1, 1] - matrix[1, 0] * matrix[0, 1];
                Console.WriteLine("Determinant výsledné matice je: {0}", det);
                Console.WriteLine();
            }
            else if (MATRIX_SIZE == 3){
                det = matrix[0, 0] * matrix[1, 1] * matrix[2, 2] + matrix[1, 0] * matrix[2, 1] * matrix[0, 2] + matrix[2, 0] * matrix[0, 1] * matrix[1, 2]
                    - (matrix[0, 2] * matrix[1, 1] * matrix[2, 0] + matrix[1, 2] * matrix[2, 1] * matrix[0, 0] + matrix[2, 2] * matrix[0, 1] * matrix[1, 0]);
                Console.WriteLine("Determinant výsledné matice je: {0}", det);
                Console.WriteLine();
            }
            else{
                Console.WriteLine("Matice je stupně 4 nebo více");
                Console.WriteLine();
            }
            return;
        }

        static void bubbleSort(int[,] matrix) //Seřezení prvků matice na hlavní diagonále
        {
            int temp = 0;
            for (int j = 0; j < MATRIX_SIZE - 1; j++)
            {
                for (int i = 0; i < MATRIX_SIZE - 1; i++)
                {
                    if (matrix[i, i] > matrix[i + 1, i + 1])
                    {
                        temp = matrix[i + 1, i + 1];
                        matrix[i + 1, i + 1] = matrix[i, i];
                        matrix[i, i] = temp;
                    }
                }
            }
        }



        static void Main(string[] args)
        {
            int[,] matrixOne= new int[MATRIX_SIZE, MATRIX_SIZE];
            int[,] matrixTwo = new int[MATRIX_SIZE, MATRIX_SIZE];
            int[,] matrixResult = new int[MATRIX_SIZE, MATRIX_SIZE];

            setMatrix(matrixOne);
            setMatrix(matrixTwo);

            printMatrix(matrixOne,"1.");
            printMatrix(matrixTwo,"2.");

            calcMatrix(matrixOne, matrixTwo, matrixResult);

            printMatrix(matrixResult,"Výsledná");

            matrixDeterminant(matrixResult);

            bubbleSort(matrixResult);

            printMatrix(matrixResult,"Seřazená");


            Console.ReadLine();
        }
    }
}

using System.Diagnostics;

namespace SudokuSolver
{
    public static class SudokuSolver
    {
        /// <summary>
        /// Works for many easy and medium puzzles but may fail for difficult puzzles that require guessing or backtracking.
        /// Automatically stops after 10 seconds if unsolvable with this method.
        /// </summary>
        /// <param name="sudoku">A square Sudoku grid (9x9, 16x16, etc.)</param>
        /// <returns>The solved Sudoku board or throws exception if unsolvable within 10 seconds.</returns>
        public static int[,] SolveSudoku(int[,] sudoku)
        {
            if (sudoku == null)
                throw new ArgumentException("Sudoku is null.");

            int dimension = sudoku.GetLength(0);
            int blockSize = (int)Math.Sqrt(dimension);

            if (sudoku.GetLength(0) != sudoku.GetLength(1))
                throw new ArgumentException("Invalid Sudoku dimensions, it must be a square sudoku (matrix).");

            if (Math.Sqrt(dimension) % 1 != 0)
                throw new ArgumentException("Invalid Sudoku size, width/height must be a square number (e.g. 9, 16).");

            if (!IsInitialSudokuValid())
                throw new ArgumentException("The given Sudoku board is not valid.");

            PrintFormattedSudoku();

            Stopwatch timer = Stopwatch.StartNew();

            while (true)
            {
                bool madeProgress = false;

                for (int row = 0; row < dimension; row++)
                {
                    for (int col = 0; col < dimension; col++)
                    {
                        if (sudoku[row, col] != 0)
                            continue;

                        List<int> possibleNumbers = new List<int>();

                        for (int num = 1; num <= dimension; num++)
                        {
                            if (IsValidInRowAndColumn(num, row, col) &&
                                IsValidInBlock(num, row, col))
                            {
                                possibleNumbers.Add(num);
                            }
                        }

                        if (possibleNumbers.Count == 1)
                        {
                            sudoku[row, col] = possibleNumbers[0];
                            madeProgress = true;
                        }
                    }
                }

                if (!madeProgress)
                    break;

                if (timer.Elapsed.TotalSeconds > 10)
                    throw new TimeoutException("Sudoku could not be solved within 10 seconds.");
            }

            PrintFormattedSudoku();

            if (sudoku.Cast<int>().Contains(0))
                throw new Exception("Sudoku is unsolvable without using backtracking.");

            return sudoku;

            // LOCAL METHODS

            void PrintFormattedSudoku()
            {
                int width = dimension.ToString().Length + 1;

                for (int i = 0; i < dimension; i++)
                {
                    for (int j = 0; j < dimension; j++)
                    {
                        Console.Write(sudoku[i, j]);
                        for (int pad = sudoku[i, j].ToString().Length; pad < width; pad++)
                            Console.Write(" ");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine();
            }

            bool IsValidInRowAndColumn(int num, int row, int col)
            {
                for (int i = 0; i < dimension; i++)
                {
                    if ((sudoku[row, i] == num && i != col) ||
                        (sudoku[i, col] == num && i != row))
                        return false;
                }

                return true;
            }

            bool IsValidInBlock(int num, int row, int col)
            {
                int blockRow = row / blockSize;
                int blockCol = col / blockSize;
                int startRow = blockRow * blockSize;
                int startCol = blockCol * blockSize;

                for (int i = startRow; i < startRow + blockSize; i++)
                {
                    for (int j = startCol; j < startCol + blockSize; j++)
                    {
                        if (sudoku[i, j] == num && (i != row || j != col))
                            return false;
                    }
                }

                return true;
            }

            bool IsInitialSudokuValid()
            {
                for (int i = 0; i < dimension; i++)
                {
                    for (int j = 0; j < dimension; j++)
                    {
                        if (sudoku[i, j] == 0)
                            continue;

                        if (!(IsValidInRowAndColumn(sudoku[i, j], i, j) &&
                                IsValidInBlock(sudoku[i, j], i, j)))
                            return false;
                    }
                }

                return true;
            }
        }
    }
}


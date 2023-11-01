using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatProgLaba1
{
    public class ProblemNumber2
    {
        private int[,] GainOfProduct;
        private int SumDiff;
        private int[,] TableForSolution;
        private string Solution;
        private int FullSum;
        private int NumberOfCompanies;
        private int NumberOfIntervals;

        public ProblemNumber2(int[,] gainOfProduct, int sumDiff, int fullSum, int numberOfCompanies)
        {
            this.GainOfProduct = gainOfProduct;
            this.SumDiff = sumDiff;
            this.FullSum = fullSum;
            this.NumberOfCompanies = numberOfCompanies;
            this.NumberOfIntervals = fullSum / SumDiff + 1;
            this.TableForSolution = new int[NumberOfCompanies * 2, NumberOfIntervals];
            this.Solution = "";

        }

        public string Solve()
        {
            GenerateTable();
            int tempInterval = 0;
            Console.Write("B\\C  |");
            for (int i = 0; i < NumberOfIntervals; i++)
            {
                Console.Write($"{tempInterval,3}    ");
                tempInterval += SumDiff;
            }
            Console.WriteLine();
            Console.WriteLine("-----+--------------------------------------");
            for (int i = 0; i < TableForSolution.GetLength(0); i++)
            {
                if (i % 2 != 0)
                    Console.Write($"B{i/2,-4}|");
                else
                    Console.Write($"X*{i / 2,-3}|");
                for (int j = 0; j < TableForSolution.GetLength(1); j++)
                {
                    Console.Write($"{TableForSolution[i, j], 3}    ");
                }
                Console.WriteLine();
            }
            int PositionInTable = TableForSolution.GetLength(0) - 1;
            int LeftSum = FullSum;
            while (PositionInTable >= 0) 
            {
                Solution += "Company number "+ (PositionInTable/2 + 1).ToString() + ": " + TableForSolution[PositionInTable - 1, LeftSum / SumDiff] + "\n";
                LeftSum -= TableForSolution[PositionInTable - 1, LeftSum / SumDiff ];

                PositionInTable -= 2;
            }
            Solution += "Max gain of productivity is " + TableForSolution[NumberOfCompanies * 2 - 1, TableForSolution.GetLength(1) - 1];
            return Solution;
        }
        private void GenerateTable()
        {
            int currentInterval = 0;
            for (int i = 0; i < NumberOfIntervals; i++)
            {
                TableForSolution[0, i] = currentInterval;
                TableForSolution[1, i] = GainOfProduct[0, i];
                currentInterval += SumDiff;

            }
            for (int i = 1; i < NumberOfCompanies; i++)
            {
                int TempSum = 0;
                for (int k = 0; k < NumberOfIntervals; k++)
                {
                    int MaxProduct = 0;
                    int SumOfMaxProduct = 0;
                    currentInterval = 0;
                    for (int j = 0; j < NumberOfIntervals; j++)
                    {

                        if (TempSum - currentInterval >= 0)
                        {
                            if (TableForSolution[i * 2 - 1, (TempSum - currentInterval) / SumDiff] + GainOfProduct[i, currentInterval / SumDiff] > MaxProduct)
                            {
                                MaxProduct = TableForSolution[i * 2 - 1, (TempSum - currentInterval) / SumDiff] + GainOfProduct[i, currentInterval / SumDiff];
                                SumOfMaxProduct = currentInterval;
                            }
                        }
                        else
                        {
                            break;
                        }


                        currentInterval += SumDiff;

                    }
                    TempSum += SumDiff;
                    TableForSolution[i * 2, k] = SumOfMaxProduct;
                    TableForSolution[i * 2 + 1, k] = MaxProduct;
                }

            }
        }
    }
}

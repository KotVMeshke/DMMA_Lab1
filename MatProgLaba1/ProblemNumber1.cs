using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatProgLaba1
{
    public class ProblemNumber1
    {
        private int[] IncomePerYear;
        private int[,] TableForSolution;
        private int[,] TableForControl;
        private int n;
        private int m;
        private int EquipmentPrice;
        private int MoneyAfterSell;
        private int NumberOfYear;
        private string Solution;

        public ProblemNumber1(int[] IPY, int EP, int NOY, int MAS = 0)
        {
            TableForSolution = new int[IPY.Length, NOY];
            TableForControl = new int[IPY.Length, NOY];
            this.IncomePerYear = new int[IPY.Length];
            n = TableForSolution.GetLength(0);
            m = TableForSolution.GetLength(1);
            IPY.CopyTo(this.IncomePerYear, 0);
            this.EquipmentPrice = EP;
            this.MoneyAfterSell = MAS;
            this.NumberOfYear = NOY;
            this.Solution = "Years to change: ";
            for (int i = 0; i < n; i++)
            {
                TableForSolution[i, 0] = Math.Max(IncomePerYear[i], IncomePerYear[0] - EquipmentPrice);
                if (TableForSolution[i, 0] < 0)
                {
                    TableForControl[i, 0] = 1;
                }
                else
                {
                    TableForControl[i, 0] = 0;
                }
            }
        }

        public string Solve()
        {
            GenerateSolutionTable();
            Console.WriteLine("        Table of productivity");
            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < m; i++)
                {
                    Console.Write($"{TableForSolution[j, i],3}  ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("        Table of control");

            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < m; i++)
                {
                    Console.Write($"{TableForControl[j, i]}    ");
                }
                Console.WriteLine();
            }
            int t = 0;
            for (int i = m - 1; i >= 0; i--)
            {
                if (TableForControl[t, i] == 1)
                {
                    t = 1;
                    Solution += (m - i).ToString();
                    Solution += " ";
                }
                else
                {
                    t = t + 1;
                }
            }
            return Solution;
        }

        private void GenerateSolutionTable()
        {
            for (int i = 1; i < m; i++)
            {
                for (int t = 0; t < n; t++)
                {

                    if (t == n - 1)
                    {
                        TableForSolution[t, i] = Math.Max(IncomePerYear[t], IncomePerYear[0] - EquipmentPrice + TableForSolution[1, i - 1]);
                    }
                    else
                    {
                        TableForSolution[t, i] = Math.Max(IncomePerYear[t] + TableForSolution[t + 1, i - 1], IncomePerYear[0] - EquipmentPrice + TableForSolution[1, i - 1]);
                        
                    }
                    if (TableForSolution[t, i] <= TableForSolution[1, i - 1])
                    {
                        TableForControl[t, i] = 1;
                    }
                    else
                    {
                        TableForControl[t, i] = 0;
                    }


                }
            }
        }


    }
}

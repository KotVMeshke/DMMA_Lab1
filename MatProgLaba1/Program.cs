namespace MatProgLaba1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var year = 8;
            var EqupPrice = 11;
            var arr = new[] { 11, 10, 9, 8, 7, 5, 3, 1, 0 };
            var arr2 = new int[,] { {0,8,13,22,31,39},
                                    {0,10,12,21,38,40},
                                    {0,7,14,22,29,38},
                                    {0,10,13,23,30,41} };
            var Problem1 = new ProblemNumber1(arr, EqupPrice, year);
            var Problem2 = new ProblemNumber2(arr2, 50, 250, 4);
            Console.WriteLine("---------------Problem 1-----------------");
            Console.WriteLine(Problem1.Solve());
            Console.WriteLine("---------------Problem 2-----------------");
            Console.WriteLine(Problem2.Solve());
        }
    }
}
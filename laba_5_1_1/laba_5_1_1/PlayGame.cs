static class Ugadau 
{ 
    public static void PlayGame()
    {
        Console.WriteLine("������� a: ");
        double a = proverka.tParseDouble(2);
        Console.WriteLine("������� b: ");
        double b = proverka.tParseDouble(2);
        Console.WriteLine($"�� ����� a = {a}, b = {b}");

        double result = CalculateResult(a, b);
        if (result < 0)
        {
            Console.WriteLine("����� ��� ������ �������������! (������� �� b)");
            return;
        }

        GuessTheAnswer(result);
    }

    

    static double CalculateResult(double a, double b)
    {
        const double P = Math.PI;
        double bInRadians = b * (P / 180);
        return Math.Sqrt(Math.Cos(bInRadians)) + Math.Sin((3 * P / 4) + (a / 3));
    }

    static void GuessTheAnswer(double correctAnswer)
    {
        int attempts = 3;
        

        while (attempts > 0)
        {
            Console.Write("������� ��� �����: ");
            double userGuess = proverka.tParseDouble(0);


            if (Math.Round(userGuess, 2) == Math.Round(correctAnswer, 2))
            {
                Console.WriteLine($"�� �����! ���������: {correctAnswer:f2}");
                return;
            }
            else
            {
                attempts--;
                Console.WriteLine($"�� �� �����! ������� �������� {attempts}.");
                if (attempts == 0)
                {
                    Console.WriteLine($"�����: {correctAnswer:f2}");
                }
            }
        }
    }
}
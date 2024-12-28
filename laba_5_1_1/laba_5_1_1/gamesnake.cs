class PlaySnake
{
    public static void PlaySnakeGame()
    {
        int score = 0;
        int width = 20, height = 20;
        char[,] pole = new char[height, width];
        char snakeChar = '0', foodChar = '+', borderchar = '*';
        int snakeX = width / 2, snakeY = height / 2;
        int maxSnakeLength = 398;
        int[,] snake = new int[maxSnakeLength, 2];
        int snakeLength = 1;
        snake[0, 0] = snakeY;
        snake[0, 1] = snakeX;
        Random rand = new Random();
        int foodX = rand.Next(1, width - 1);
        int foodY = rand.Next(1, height - 1);
        bool play = true;

        while (play)
        {
            FieldCreation(pole, borderchar);
            pole[foodY, foodX] = foodChar;
            Console.Clear();

            for (int i = 0; i < snakeLength; i++)
            {
                pole[snake[i, 0], snake[i, 1]] = snakeChar;
            }

            Console.WriteLine($"Количество очков: {score}");
            FieldOutput(pole);

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.LeftArrow:
                    snakeX--;
                    break;
                case ConsoleKey.RightArrow:
                    snakeX++;
                    break;
                case ConsoleKey.UpArrow:
                    snakeY--;
                    break;
                case ConsoleKey.DownArrow:
                    snakeY++;
                    break;
            }

            if (snakeX == foodX && snakeY == foodY)
            {
                foodX = rand.Next(1, width - 1);
                foodY = rand.Next(1, height - 1);
                while (pole[foodY, foodX] == snakeChar)
                {
                    foodX = rand.Next(1, width - 1);
                    foodY = rand.Next(1, height - 1);
                }
                if (snakeLength < maxSnakeLength)
                {
                    snakeLength++;
                }
                score++;
            }
            else
            {
                if (pole[snakeY, snakeX] == '*')
                {
                    play = CloseSnakeGame(true, score, pole);
                    continue;
                }

                for (int i = 0; i < snakeLength - 1; i++)
                {
                    if (snake[i, 0] == snakeY && snake[i, 1] == snakeX)
                    {
                        play = CloseSnakeGame(true, score, pole);
                        continue;
                    }
                }

                for (int i = 0; i < snakeLength - 1; i++)
                {
                    snake[i, 0] = snake[i + 1, 0];
                    snake[i, 1] = snake[i + 1, 1];
                }
            }

            snake[snakeLength - 1, 0] = snakeY;
            snake[snakeLength - 1, 1] = snakeX;
        }
    }
    //сооздание границ поля
    static void FieldCreation(char[,] pole, char borderchar)
    {
        for (int i = 0; i < pole.GetLength(0); i++)
        {
            for (int j = 0; j < pole.GetLength(1); j++)
            {
                pole[i, j] = borderchar;
            }
        }
        for (int i = 1; i < pole.GetLength(0) - 1; i++)
        {
            for (int j = 1; j < pole.GetLength(1) - 1; j++)
            {
                pole[i, j] = ' ';
            }
        }
    }
    //вывод массивов ввиде поля
    static void FieldOutput(char[,] pole)
    {
        for (int i = 0; i < pole.GetLength(0); i++)
        {
            for (int j = 0; j < pole.GetLength(1); j++)
            {
                Console.Write(pole[i, j] + " ");
            }
            Console.Write("\n");
        }

    }
    static bool CloseSnakeGame(bool fail, int score, char[,] pole)
    {
        Console.Clear();
        if (fail == true)
        {

            Console.WriteLine("Вы проиграли ;(");
            Console.WriteLine($"Количесво очков: {score}");
        }
        else
        {
            Console.WriteLine("Вы выиграли!");
        }
        Console.WriteLine($"Количесво очков: {score}");
        FieldOutput(pole);
        return false;
    }
}
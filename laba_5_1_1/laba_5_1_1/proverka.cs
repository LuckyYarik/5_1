static class proverka
{
    public static double tParseDouble(int ver)
    {
        switch (ver)
        {
            case 1:
                double fa = 1;
                string fa_v = Console.ReadLine();
                while (!double.TryParse(fa_v, out fa) || fa == 0)
                {
                    Console.WriteLine("������� ����� �� ������ 0, ���������� ��� ���: ");
                    fa_v = Console.ReadLine();
                }
                return fa;
            case 0:
                double fb;
                string fb_v = Console.ReadLine();
                while (!double.TryParse(fb_v, out fb))
                {
                    Console.WriteLine("������� �����, ���������� ��� ���: ");
                    fb_v = Console.ReadLine();
                }
                return fb;
            case 2:
                double lj;
                while (!double.TryParse(Console.ReadLine(), out lj) || lj <= 0)
                {
                    Console.WriteLine("������� ����� �����, ������� ������ ����, ���������� ��� ���: ");
                }
                return lj;
            default:
                return 0;
        }
    }
    
}

interface IslemTip
{
    int Islem(int a, int c);
}

class Topla : IslemTip
{
    public int Islem(int a, int b)
    {
        return a + b;
    }
}

class Cikart : IslemTip
{
    public int Islem(int a, int b)
    {
        return a - b;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Func<int, int, IslemTip, int> f =
             (a, b, t) => t.Islem(a, b);

        Console.WriteLine(f(3, 4, new Topla()));
        Console.WriteLine(f(3, 4, new Cikart()));
    }
}
Eskiden delegate tanımlarken standart yazım şeklini kullanırdık:

delegate int IslemTipHandler(int a, int b, IslemTip islem);

static int DelegateCalistir(int a, int b, IslemTip islem)
{
    return islem.Islem(a, b);
}

static void Main(string[] args)
{
    IslemTipHandler ith = new IslemTipHandler(DelegateCalistir);
    Console.WriteLine(ith.Invoke(3, 4, new Topla()));
    Console.WriteLine(ith.Invoke(3, 4, new Cikart()));
}


namespace lab_rab_1_2chast_FurdinNK_BPI2302.Models;

public class ArcSin : Function
{
    public ArcSin() : base("arcsin") { }

    public override double Value(double x)
    {
        if (x < -1 || x > 1)
            throw new ArgumentOutOfRangeException(nameof(x), "x должен быть в промежутке [-1;1]");
        return Math.Asin(x);
    }

    // Перегрузка: результат можно вернуть в градусах
    public double Value(double x, bool degrees)
    {
        var rad = Value(x);
        return degrees ? rad * 180 / Math.PI : rad;
    }

    public override Function CreateDerivative()
    {
        return new AnalyticDerivative(xx => 1.0 / Math.Sqrt(1 - xx * xx), "arcsin'");
    }

    public override string Info()
    {
        return "Класс ArcSin (Info переопределён)";
    }
}

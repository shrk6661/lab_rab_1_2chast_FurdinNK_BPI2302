namespace lab_rab_1_2chast_FurdinNK_BPI2302.Models;

public class ArcCos : Function
{
    public ArcCos() : base("arccos") { }

    public override double Value(double x)
    {
        if (x < -1 || x > 1)
            throw new ArgumentOutOfRangeException(nameof(x), "x должен быть в промежутке [-1;1]");
        return Math.Acos(x);
    }

    public override Function CreateDerivative()
    {
        return new AnalyticDerivative(xx => -1.0 / Math.Sqrt(1 - xx * xx), "arccos'");
    }
    // Info() не переопределяем — используется базовый
}

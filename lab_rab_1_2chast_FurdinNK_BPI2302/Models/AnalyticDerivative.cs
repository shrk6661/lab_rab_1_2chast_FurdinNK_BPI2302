using System;

namespace lab_rab_1_2chast_FurdinNK_BPI2302.Models
{
    // Аналитическая производная через делегат
    public class AnalyticDerivative : Function
    {
        private readonly Func<double, double> _func;

        public AnalyticDerivative(Func<double, double> func, string name)
            : base(name)
        {
            _func = func;
        }

        public override double Value(double x) => _func(x);
    }
}

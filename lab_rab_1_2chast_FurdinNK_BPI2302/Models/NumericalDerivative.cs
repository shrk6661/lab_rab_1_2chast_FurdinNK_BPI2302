using System;

namespace lab_rab_1_2chast_FurdinNK_BPI2302.Functions
{
    // Численная производная через центральную разность
    public class NumericalDerivative : Function
    {
        private readonly Function _source;
        private readonly double _h;

        public NumericalDerivative(Function source, double h = 1e-5) : base($"d/dx({source})")
        {
            _source = source;
            _h = h;
        }

        public override double Value(double x) //возвр знач ф-ии в точке х
        {
            return (_source.Value(x + _h) - _source.Value(x - _h)) / (2 * _h); //если нет формулы +- вычисляем значение
        }
    }
}

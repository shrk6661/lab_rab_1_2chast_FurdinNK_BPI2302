using lab_rab_1_2chast_FurdinNK_BPI2302.Functions;

namespace lab_rab_1_2chast_FurdinNK_BPI2302.Models
{
    // Базовый класс для всех функций
    public abstract class Function : IFunction
    {
        public string Name { get; }

        protected Function(string name)
        {
            Name = name;
        }

        public abstract double Value(double x);

        // По умолчанию делаем численную производную
        public virtual Function CreateDerivative()
        {
            return new NumericalDerivative(this);
        }

        public virtual string Info()
        {
            return $"Function: {Name}";
        }
    }
}

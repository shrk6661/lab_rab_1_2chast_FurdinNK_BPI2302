namespace lab_rab_1_2chast_FurdinNK_BPI2302.Functions
{
    // Базовый абстрактный класс для всех функций
    public abstract class Function
    {
        public string Name { get; }

        protected Function(string name)
        {
            Name = name;
        }

        // Каждая функция обязана реализовать этот метод
        public abstract double Value(double x);

        // По умолчанию возвращаем численную производную
        public virtual Function CreateDerivative()
        {
            return new NumericalDerivative(this);
        }

        // Виртуальный метод: наследники могут переопределить
        public virtual string Info()
        {
            return $"Function: {Name}";
        }

        public override string ToString() => Name;
    }
}

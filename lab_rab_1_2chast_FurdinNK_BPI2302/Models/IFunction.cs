using lab_rab_1_2chast_FurdinNK_BPI2302.Models;

namespace lab_rab_1_2chast_FurdinNK_BPI2302.Functions
{
    // Интерфейс: любая функция должна уметь считать себя и свою производную
    public interface IFunction
    {
        double Value(double x);
        Function CreateDerivative();
    }
}

using WebApp_Exercise.Controllers;
namespace MyOp02Calc
{
    public class CalcService
    {
        public int Calc(int value1, int value2, int opt)
        {
            //return opt switch
            return opt switch
            {
                1 => value1 + value2,
                2 => value1 - value2,
                3 => value1 * value2,
                4 => value1 / value2,
                _ => throw new ArgumentException("無効なopt")
            };
        }
        public string OpSymbol(int value1, int value2, int opt)
        {
            return opt switch
            {
                1 => "+",
                2 => "-",
                3 => "*",
                4 => "/",
                5 => "%",
                _ => "?"
            };
        }
    }
}
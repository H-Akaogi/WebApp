using Microsoft.AspNetCore.Mvc;
/// Modelsで作成したnamespace名をusingに記入
[Route("Op01")]
public class Op01Controller : Controller
{
    [HttpGet("Calc")]
    public IActionResult Calc([FromQuery] int value1, [FromQuery] int value2, [FromQuery] int opt)
    {
        string opSymbol = opt switch
        {
            1 => "+",
            2 => "-",
            3 => "*",
            4 => "/",
            5 => "%",
            _ => "?"
        };

        int result = opt switch
        {
            1 => value1 + value2,
            2 => value1 - value2,
            3 => value1 * value2,
            4 => value1 / value2,
            5 => value1 % value2,
            _ => throw new ArgumentException("不明な計算種別です。")
        };
        return Content($"{value1} {opSymbol} {value2} = {result}");
    }
}
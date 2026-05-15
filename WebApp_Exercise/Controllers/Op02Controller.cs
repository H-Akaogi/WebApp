using Microsoft.AspNetCore.Mvc;
/// Modelsで作成したnamespace名をusingに記入
[Route("Op02")]
public class Op02Controller : Controller
{
    [HttpGet("Calc/{value1}/{value2}/{opt}")]
    public IActionResult Calc(int value1, int value2, int opt)
    {
        if (opt == 1)
        {
            var value = value1 + value2;
            return Content($"{value1} + {value2} = {value}");
        }
        else if (opt == 2)
        {
            var value = value1 - value2;
            return Content($"{value1} - {value2} = {value}");
        }
        else if (opt == 3)
        {
            var value = value1 * value2;
            return Content($"{value1} * {value2} = {value}");
        }
        else if (opt == 4)
        {
            var value = value1 / value2;
            return Content($"{value1} / {value2} = {value}");
        }
        else if (opt == 5)
        {
            var value = value1 % value2;
            return Content($"{value1} % {value2} = {value}");
        }
        return Content("不明な計算種別です。");
    }

}
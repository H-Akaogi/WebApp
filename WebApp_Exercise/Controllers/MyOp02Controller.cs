using Microsoft.AspNetCore.Mvc;
/// Modelsで作成したnamespace名をusingに記入
using MyOp02Calc;
[Route("MyOp02")]
public class MyOp02Controller : Controller
{
    private readonly CalcService _calcService;

    public MyOp02Controller()
    {
        _calcService = new CalcService();
    }
    [HttpGet("Calc/{value1}/{value2}/{opt}")]
    public IActionResult Calc(int value1, int value2, int opt)
    {
        int result = _calcService.Calc(value1, value2, opt);
        string opSymbol = _calcService.OpSymbol(value1, value2, opt);
        return Content($"{value1} {opSymbol} {value2} = {result}");
    }

}
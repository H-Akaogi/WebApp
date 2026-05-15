using Microsoft.AspNetCore.Mvc;
using WebApp_Op03.Models;
[Route("Option03")] // htmlファイルに書いてあるroute名と揃える！
public class Op03Controller : Controller
{
    [HttpPost("Calc")]
    public IActionResult Calc(Op03Form form)
    {
        if (form.Opt == 1)
        {
            var result = form.Value1 + form.Value2;
            return Content($"{form.Value1} + {form.Value2} = {result}");
        }
        else if (form.Opt == 2)
        {
            var result = form.Value1 - form.Value2;
            return Content($"{form.Value1} - {form.Value2} = {result}");
        }
        else if (form.Opt == 3)
        {
            var result = form.Value1 * form.Value2;
            return Content($"{form.Value1} * {form.Value2} = {result}");
        }
        else if (form.Opt == 4)
        {
            float result = (float)form.Value1 / form.Value2;
            // (froat)にすることで小数でも結果が出るようにした
            return Content($"{form.Value1} / {form.Value2} = {result}");
        }
        else if (form.Opt == 5)
        {
            var result = form.Value1 % form.Value2;
            return Content($"{form.Value1} % {form.Value2} = {result}");
        }
        else
        {
            return Content("不明な計算種別です。");
        }
    }
}
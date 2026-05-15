using Microsoft.AspNetCore.Mvc;
/// <summary>
/// 演習-09 HTML Formを作成するタグヘルパーを利用する
/// </summary>
[Route("Exercise09")]
public class Ex09Controller : Controller
{
    /// <summary>
    /// 入力画面を表示する
    /// </summary>
    /// <returns></returns>
    [HttpGet("Enter")]
    public ActionResult Enter()
    {
        var form = new Exercise07Form();
        return View(form);
    }

    /// <summary>
    /// [計算]ボタンクリックアクション
    /// </summary>
    /// <returns></returns>
    [HttpPost("Result")]
    public IActionResult Result(Exercise07Form form)
    {
        form.Answer = form.Value1 + form.Value2;
        return View(form);
    }

    /// <summary>
    /// [戻る]ボタンクリックアクション
    /// </summary>
    /// <returns></returns>
    [HttpGet("Back")]
    public IActionResult Back()
    {
        var form = new Exercise07Form();
        return View("Enter", form);
    }
}
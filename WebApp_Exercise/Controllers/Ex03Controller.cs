using Microsoft.AspNetCore.Mvc;
/// <summary>
/// 演習-03 ルーティング属性を利用するコントローラを実装する
/// </summary>
[Route("Exercise03")]// ルーティング設定(今回は"Exercise03")(ベースURL)
public class Ex03Controller : Controller
{
    [HttpGet("Morning")]//HttpGetでルーティング設定
    // /MorningというURLでGETアクセスされたときに呼ばれる(追加pass)
    public IActionResult Goodmorning()
    {
        return Content("おはようございます。");
    }

    [HttpGet("Hello")]
    public IActionResult Hello()
    {
        return Content("こんにちは。");
    }

    [HttpGet("Evening")]
    public IActionResult Goodevening()
    {
        return Content("こんばんは。");
    }

    [HttpGet("Night")]
    public IActionResult Goodnight()
    {
        return Content("おやすみなさい。");
    }
}
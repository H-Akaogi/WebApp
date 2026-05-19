/// 演習-27 Middlewareを実装し、動作を確認する

using Microsoft.AspNetCore.Mvc;
namespace WebApp_Exercise_Answer.Presentations.Controllers;
/// <summary>
/// システム停止中画面用コントローラ
/// </summary>
public class SystemController : Controller
{
    [HttpGet]
    public IActionResult Maintenance()
    {
        return View();
    }
}
/// 継承するclass Microsoft.AspNetCore.Mvc.のnamespace
using Microsoft.AspNetCore.Mvc;
namespace WebApp_Sample.Controllers;
/// <summary>
/// リスト2-1
/// ルーティング属性を使用しないコントローラ
/// </summary>
public class RouteSampleController : Controller
/// class Microsoft.AspNetCore.Mvc.Controllerを継承
{
    /// <summary>
    /// デフォルトアクション
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {
        return Content("/RouteSample または /RouteSample/Index");
    }

    /// <summary>
    /// SampleContentアクション
    /// </summary>
    /// <returns></returns>
    public IActionResult SampleContent()
    {
        return Content("/RouteSample/SampleContent");
    }
}
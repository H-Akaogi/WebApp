using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
/// <summary>
/// タグヘルパーを利用するコントローラ
/// </summary>
[Route("FormSample")]
public class TagHelperFormController : Controller
{
    [HttpGet("Enter")]
    public IActionResult Enter()
    {
        // SampleFormを生成する
        var form = new SampleForm();
        // Enter.cshtmlにSampleFormを渡す
        /*form.PrefecturesList = new List<SelectListItem>
        {
        new SelectListItem{ Text="--選択されていません--", Value="0" , Selected = true },
        new SelectListItem{ Text= "北海道", Value= "1" },
        new SelectListItem{ Text= "青森県", Value= "2" },
        new SelectListItem{ Text= "岩手県", Value= "3" }
        };*/
        return View(form);
    }

    /// <summary>
    /// [送信]ボタンクリックに対するアクション
    /// </summary>
    /// <param name="form">入力された値を保持するSampleForm</param>
    /// <returns></returns>
    [HttpPost("Result")]
    public IActionResult Result(SampleForm form)
    {
        return View(form);
    }

    /// <summary>
    /// [戻る]ボタンクリックに対するアクション
    /// </summary>
    /// <param name="form">入力された値を保持するSampleForm</param>
    /// <returns></returns>
    [HttpGet("Back")]
    public IActionResult Back(SampleForm form)
    {
        // 入力画面を出力する
        return View("Enter", form);
    }
}
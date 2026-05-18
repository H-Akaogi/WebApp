using Microsoft.AspNetCore.Mvc;
using WebApp_Op03.Models;
[Route("Option04")]
public class Op04Controller : Controller
{
    [HttpGet("Enter")]

    /// アクションメソッド
    /// 戻り値は通常IActionResult(またはActionResult<T>)になる
    public IActionResult Enter()
    {
        /// form用のViewModelを新規作成
        var form = new Op03Form();
        /// Enter.cshtmlにformを渡して表示する(Enter画面を開く)
        return View(form);
    }

    /// アクションメソッド
    /// 戻り値は通常IActionResult(またはActionResult<T>)になる
    [HttpPost("Result")]
    public IActionResult Result(Op03Form form)
    {
        /// ModelState.IsValid を使って入力チェック
        if (!ModelState.IsValid)
        {
            /// 入力値にエラーがある場合Enteビューを再表示する
            return View("Enter", form);
        }
        /// OptはModelsのプロパティ名と対応
        switch (form.Opt)
        {
            case 1:
                form.Answer = form.Value1 + form.Value2;
                break;
            case 2:
                form.Answer = form.Value1 - form.Value2;
                break;
            case 3:
                form.Answer = form.Value1 * form.Value2;
                break;
            case 4:
                form.Answer = form.Value1 / form.Value2;
                break;
            case 5:
                form.Answer = form.Value1 % form.Value2;
                break;
            default:
                ModelState.AddModelError("Opt", "不明な計算種別です。");
                break;
        }
        /// Result画面を開く
        return View(form);
    }

    /// <summary>
    /// [戻る]ボタンクリックアクション
    /// </summary>
    /// <returns></returns>
    [HttpGet("Back")]
    public IActionResult Back()
    {
        var form = new Op03Form();
        /// Enter画面を開く
        return View("Enter", form);
    }
}
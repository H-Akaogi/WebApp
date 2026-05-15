using Microsoft.AspNetCore.Mvc;
/// Modelsで作成したnamespace名をusingに記入
using WebApp_Exercise.Models;


/// <summary>
/// 演習-07 フォームデータを取得するコントローラを実装する
/// </summary>
/// 属性(ルーティング設定)
[Route("Exercise07")]
public class Ex07Controller : Controller
{
    /// <summary>
    /// 入力値を加算した結果を返す
    /// </summary>
    /// <param name="form">入力値を保持するViewModel</param>
    /// <returns></returns>
    [HttpPost("Calc")]/// 属性(ルーティング設定)
                      /// Modelsで作成したExercise07Form
                      /// Form fromの形であらわす
    public IActionResult Calc(Exercise07Form form)/// IActionResultは戻り値の型(インターフェース)
    {
        var result = form.Value1 + form.Value2;
        return Content($"{form.Value1} + {form.Value2} = {result}");
    }
}
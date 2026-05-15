using Microsoft.AspNetCore.Mvc;
/// <summary>
/// リクエストパラメータの型変換エラー
/// </summary>
[Route("TypeError")]// 属性(ルーティング設定)
public class TypeConversionErrorController : Controller
{
    /// <summary>
    /// リクエストパラメータを出力
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("Params")]/// 属性(ルーティング設定)
    public IActionResult RequestParameter(int id)
    // IActionResultは戻り値の型(インターフェース)
    {
        // 型変換エラー?
        if (!ModelState.IsValid)
        {
            // エラーメッセージを出力する
            // パラメータ名をキーにしてErrors配列にアクセスする
            return Content(ModelState["id"]!.Errors[0].ErrorMessage);
        }
        return Content($"リクエストパラメータ:{id}");
    }
}
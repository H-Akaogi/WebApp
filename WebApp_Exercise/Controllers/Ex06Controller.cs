using Microsoft.AspNetCore.Mvc;
/// <summary>
/// 演習-06 ルートパラメータを取得するコントローラを実装する
/// </summary>

[Route("Exercise06")]/// 属性(ルーティング設定)
public class Ex06Controller : Controller
{
    /// <summary>
    /// ルートパラメータを加算した結果を返す
    /// </summary>
    /// <param name="value1">加算対象</param>
    /// <param name="value2">加算対象</param>
    /// <returns>加算結果</returns>
    [HttpGet("Calc/{value1}/{value2}")]/// 属性(ルーティング設定)
    public IActionResult Calc(int value1, int value2)
    // IActionResultは戻り値の型(インターフェース)
    {
        if (!ModelState.IsValid) // 型変換エラー?
        {
            // value1とvalue2で型変換エラー
            if ((ModelState["value1"]?.Errors.Count ?? 0) > 0
            && (ModelState["value2"]?.Errors.Count ?? 0) > 0)
            /// エラーの数を取得する(エラーが0件より多いとき)
            /// null合体演算子
            /// ModelState["value1"]?.Errors.Countでエラーがあるかどうか
            /// エラーがない場合 == 0
            {
                // Content()メソッドでプレーンテキストを返す
                return Content("value1とvalue2は整数ではありません。");
            }
            // value1で型変換エラー
            if ((ModelState["value1"]?.Errors.Count ?? 0) > 0)
            {
                return Content("value1は整数ではありません。");
            }
            // value2で型変換エラー
            if ((ModelState["value2"]?.Errors.Count ?? 0) > 0)
            {
                return Content("value2は整数ではありません。");
            }
        }
        var result = value1 + value2;
        return Content($"{value1} + {value2} = {result}");
    }
}
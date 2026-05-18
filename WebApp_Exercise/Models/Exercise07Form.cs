/// 対応するControllerにusingでnamespaceを書く
using System.ComponentModel.DataAnnotations;
/// <summary>
/// 演習-07 フォームデータを取得するコントローラを実装する
/// 入力データを保持するViewModel
/// </summary>
public class Exercise07Form
{
    [Display(Name = "値1")]
    [Required(ErrorMessage = "{0}は入力必須です。")]
    [Range(0, 100, ErrorMessage = "{0}は{1}～{2}までの数字で入力してください。")]
    public int Value1 { get; set; } = 0;
    [Display(Name = "値2")]
    [Required(ErrorMessage = "{0}は入力必須です。")]
    [Range(0, 100, ErrorMessage = "{0}は{1}～{2}までの数字で入力してください。")]
    public int Value2 { get; set; } = 0;

    /// <summary>
    /// 演習-09 HTML Formを作成するタグヘルパーを利用する
    /// </summary>

    /// <summary>
    /// 計算結果
    /// </summary>
    /// <value></value>
    public int Answer { get; set; } = 0;
}
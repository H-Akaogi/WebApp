/// [Display]などを書くときは記述する
using System.ComponentModel.DataAnnotations;

/// List<SelectListItem>を使う時は記述する
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp_Op03.Models;

public class Op03Form
{
    /// <summary>
    /// 値1
    /// </summary>
    /// [Display]表示名を定義
    [Display(Name = "値1")]
    /// [Required]未入力を禁止(空の場合はエラー)
    [Required(ErrorMessage = "{0}は入力必須です。")]
    /// [Range]入力値の範囲制限
    /// {0}はDisplay名、{1}は最小値、{2}は最大値
    /* 
    {0} = displayName
    {1} = minimum
    {2} = maximum
    */
    [Range(0, 1000, ErrorMessage = "{0}は{1}から{2}までの数字で入力してください。")]
    public int Value1 { get; set; }

    /// <summary>
    /// 値2
    /// </summary>
    [Display(Name = "値2")]
    [Required(ErrorMessage = "{0}は入力必須です。")]
    [Range(0, 1000, ErrorMessage = "{0}は{1}から{2}までの数字で入力してください。")]
    public int Value2 { get; set; }

    /// <summary>
    /// 計算の種類
    /// </summary>
    [Display(Name = "計算の種類")]
    [Required(ErrorMessage = "{0}は入力必須です。")]
    [Range(1, 5, ErrorMessage = "{0}は{1}から{2}までの数字で入力してください。")]
    public int Opt { get; set; } = 0;

    /// <summary>
    /// プルダウン表示するリスト
    /// </summary>
    /// <value></value>
    /// List<SelectListItem>はドロップダウンリストの選択肢を示す
    public List<SelectListItem> OptList { get; set; } = new List<SelectListItem>
    {
        /// Text: ユーザーに表示される文字列
        /// Value: 送信される値
        /// Selected: 初期状態で選ばれているかどうか(true/false)
        new SelectListItem{ Text="--選択されていません--", Value="0" , Selected = true },
        new SelectListItem{ Text= "加算(+)", Value= "1" },
        new SelectListItem{ Text= "減算(-)", Value= "2" },
        new SelectListItem{ Text= "乗算(*)", Value= "3" },
        new SelectListItem{ Text= "除算(/)", Value= "4" },
        new SelectListItem{ Text= "剰余(%)", Value= "5" },
    };

    /// <summary>
    /// 計算結果
    /// </summary>
    /// <value></value>
    public int Answer { get; set; }
}
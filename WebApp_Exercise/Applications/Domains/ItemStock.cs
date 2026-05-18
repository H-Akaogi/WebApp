using WebApp_Exercise.Exceptions;
namespace WebApp_Exercise.Applications.Domains;
/// <summary>
/// 商品在庫を表すドメインオブジェクト
/// </summary>
public class ItemStock
{
    /// <summary>
    /// 在庫Id
    /// </summary>
    public int? Id { get; private set; }
    /// <summary>
    /// 在庫数
    /// </summary>
    public int Stock { get; private set; } = 0;
    /// <summary>
    /// 商品
    /// </summary>
    public Item? Item { get; private set; } = null;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="id">商品在庫Id</param>
    /// <param name="stock">商品在庫数</param>
    public ItemStock(int? id, int stock)
    {
        // 商品在庫Idのルール検証
        ValidateId(id);
        // 商品在庫数のルール検証
        ValidateStock(stock);
        Id = id;
        Stock = stock;
    }
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="stock">商品在庫数</param>
    public ItemStock(int stock) : this(null, stock) { }

    /// <summary>
    /// 商品在庫Idのルール検証
    /// </summary>
    /// <param name="id"></param>
    private void ValidateId(int? id)
    {
        if (id == null)
        {
            return;
        }
        if (id < 1)
        {
            throw new DomainException("商品在庫Idは1以上でなければなりません。");
        }
    }

    /// <summary>
    /// 商品在庫数のルール検証
    /// </summary>
    /// <param name="stock"></param>
    private void ValidateStock(int stock)
    {
        if (stock < 0)
        {
            throw new DomainException("商品在庫数は0以上でなければなりません。");
        }
    }

    /// <summary>
    /// 在庫数の変更
    /// </summary>
    public void ChangeStock(int stock)
    {
        ValidateStock(stock);
        Stock = stock;
    }

    /// <summary>
    /// 商品の変更
    /// </summary>
    /// <param name="item"></param>
    public void ChangeProduct(Item? item)
    {
        Item = item;
    }

    /// <summary>
    /// 等価性の検証
    /// 同じIdなら同じオブジェクトとして扱う
    /// ReferenceEquals(): もともと .NET（C#）に最初から用意されている標準メソッド
    /// GetHashCode()とセットで使う
    /// これがないと(下記バグ)
    /// 在庫データが重複登録される、集計が2倍になる、レポートが壊れる
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj)) return true;
        if (obj is not ItemStock other) return false;
        return Id == other.Id;
    }

    /// <summary>
    /// このオブジェクトのハッシュ値は、Idのハッシュ値を使う。Idがnullなら0を返す
    /// コレクションの正しい動作を保証するための設計
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode() => Id?.GetHashCode() ?? 0;

    public override string ToString()
    {
        var idText = Id?.ToString() ?? "未登録";
        var ItemText = Item?.ToString() ?? "";
        return $"商品在庫Id={idText},在庫数={Stock},商品={ItemText}";
    }
}
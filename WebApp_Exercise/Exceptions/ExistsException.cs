/// 演習-20 Serviceインターフェイスと実装クラスを作成する
namespace WebApp_Exercise.Exceptions;
/// <summary>
/// データが存在することを表す例外クラス
/// </summary>
public class ExistsException : Exception
{
    public ExistsException(string message)
    : base(message) { }
    public ExistsException(string message, Exception innerException)
    : base(message, innerException) { }
}
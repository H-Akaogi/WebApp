using Microsoft.EntityFrameworkCore;
using WebApp_Exercise.Infrastructures.Entities;
namespace WebApp_Exercise.Infrastructures.Context;
/// <summary>
/// アプリケーションで利用するDbContext継承クラス
/// </summary>
public class AppDbContext : DbContext
{
    /// <summary>
    /// product_categoryテーブルにアクセスするプロパティ
    /// </summary>
    public DbSet<ItemCategoryEntity> ItemCategories { get; set; }
    /// <summary>
    /// productテーブルにアクセスするプロパティ
    /// </summary>
    public DbSet<ItemEntity> Items { get; set; }
    /// <summary>
    /// product_stockテーブルにアクセスするプロパティ
    /// </summary>
    public DbSet<ItemStockEntity> ItemStocks { get; set; }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="options">
    ///  データベース接続情報 や ログ出力設定、トラッキング挙動の設定などのオプション
    /// </param>
    /// <returns></returns>
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    /// <summary>
    /// エンティティの結合
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // ItemとItemCategory:多対1リレーション(カテゴリ1つに対して商品が複数)
        modelBuilder.Entity<ItemEntity>()
            .HasOne(p => p.Category) //Itemは「Categoryを1つ持つ」
            .WithMany(c => c.Items) //Categoryは「複数のItemを持つ」
            .HasForeignKey(p => p.CategoryId) //ategoryの主キーと紐づく
                                              // 外部キーで参照されている親エンティティを削除しようとしたときに、エラーが発生して削除できない
            .OnDelete(DeleteBehavior.Restrict); //Categoryを削除してもItemは削除されない

        // ItemとItemStock:1対1リレーション
        modelBuilder.Entity<ItemEntity>()
            .HasOne(p => p.Stock)
            .WithOne(ps => ps.Product)
            .HasForeignKey<ItemStockEntity>(ps => ps.ItemId)
            // 親エンティティが削除されたときに、関連する子エンティティも自動的に削除される
            .OnDelete(DeleteBehavior.Cascade);
    }
}
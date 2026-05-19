///演習-25 DIコンテナを利用して、依存関係を構築する

using WebApp_Exercise.Presentations.Extensions;
using WebApp_Exercise.Presentations.Middlewares;
// WebApplicationBuilderのビルダーを作成し、コマンドライン引数を渡す
var builder = WebApplication.CreateBuilder(args);

// DIコンテナにMVCコントローラとビューをサポートするサービスを追加する
builder.Services.AddControllersWithViews();
// 依存定義および依存性注入
builder.Services.SettingDependencyInjection(builder.Configuration);
// WbApplicationをビルダーから構築する
var app = builder.Build();

/// 演習-27 Middlewareを実装し、動作を確認する
// IngternalExceptionをハンドリングするミドルウェアを有効化する
app.UseMiddleware<InternalExceptionLoggingMiddleware>();
/// 
// HTTPリクエストパイプラインの構成を行う
if (!app.Environment.IsDevelopment())
{
    // 開発環境でない場合は、エラーハンドラを設定する（/Home/Errorにリダイレクト）
    app.UseExceptionHandler("/Home/Error");

    // HTTP Strict Transport Security を有効にする（既定は30日間）
    // 本番環境ではHSTSの期間を調整することも推奨される
    app.UseHsts();
}

// HTTPをHTTPSへリダイレクトする
app.UseHttpsRedirection();

// 静的ファイル（CSS, JS, 画像など）を提供できるようにする
app.UseStaticFiles();

// ルーティングを有効にする（URLからコントローラやアクションを判断できるようにする）
app.UseRouting();

// 認可（Authorization）を有効にする（認証後のアクセス制御に使用）
app.UseAuthorization();

// 既定のルートパターンを設定する（例: /Home/Index）
app.MapControllerRoute(
    name: "default",                            // ルートの名前
                                                // URLパターン（省略時はHomeコントローラとIndexアクション）
    pattern: "{controller=Home}/{action=Index}/{id?}");

// アプリケーションを起動し、リクエストの受付を開始する
app.Run();
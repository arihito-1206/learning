# learning

小さな実験で、**「わからない」を「説明できる」に変える**ための学習リポジトリ。

ドキュメントを読んで理解したつもりになるのではなく、気になった仕組みを最小限のコードに切り出して、実際に動かしながら確かめる。

## Learning Loop

このリポジトリでは、だいたい次の流れで学ぶ。

1. **問いを1つ決める**  
   「結局ここはどう動くのか？」を具体的な問いにする。
2. **予想する**  
   コードを動かす前に、自分なりの結果を考える。
3. **最小の実験を作る**  
   本題と関係ない要素をできるだけ削り、Console App などで再現する。
4. **動かして観察する**  
   標準出力、戻り値、例外、実行順など、確認したいものを見える形にする。
5. **なぜそうなるか説明する**  
   API の表面的な使い方だけで終わらせず、型・ライフサイクル・内部の責務まで一段掘る。
6. **1つの発見をコミットする**  
   一度に完成させず、理解が1段進むごとにコードを残す。
7. **問いが解けたら撤収する**  
   周辺の疑問はその場で全部回収せず、必要なら次の実験に分ける。

完成度の高いアプリを作ることより、**何を確かめたくて、何が分かったのかを追えること**を優先する。

## Repository Structure

基本形は次のとおり。

```text
<technology>/<area>/<experiment>/
```

例:

```text
dotnet/
├── application-insights/
│   └── metric-dimension-limit/
├── concurrency/
│   └── actionblock-vs-channel/
├── fluent-api/
│   └── lambda-extension-method/
├── httpclient/
│   └── handler-pipeline/
└── transaction-lab/
```

- `technology`: `.NET` などの大きな技術スタック
- `area`: concurrency、HttpClient などの関心領域
- `experiment`: 1つの問いを確かめるための最小実験

## Experiments

| Path | 問い | この実験で確かめたこと |
| --- | --- | --- |
| [`dotnet/application-insights/metric-dimension-limit/`](dotnet/application-insights/metric-dimension-limit/) | Application Insights のメトリックでディメンション値が増えすぎるとどうなる？ | 101個の異なる `TenantId` を `TrackValue` し、上限を超えたときの戻り値を観察する |
| [`dotnet/concurrency/actionblock-vs-channel/`](dotnet/concurrency/actionblock-vs-channel/) | `ActionBlock` は値をどう受け取り、いつ完了する？ | `Post`、`Complete()`、`Completion` を使った最小の Producer-Consumer を作り、ライフサイクルを確認中 |
| [`dotnet/fluent-api/lambda-extension-method/`](dotnet/fluent-api/lambda-extension-method/) | ラムダ式を受け取る Fluent API はどう作られている？ | `Func` / `Action`、ラムダを受け取る拡張メソッド、method chaining、Builder へ段階的に分解して確認した |
| [`dotnet/httpclient/handler-pipeline/`](dotnet/httpclient/handler-pipeline/) | `HttpClient` の Handler と Polly はどの順番で動く？ | `Polly → ThrottlingHandler → PrimaryHandler` の実行順と、リトライ時に `SemaphoreSlim` のロックが各試行ごとに解放されることを確認した |
| [`dotnet/transaction-lab/`](dotnet/transaction-lab/) | 複数のサービス呼び出しを1つのトランザクションにするには？ | 明示的な `SqliteTransaction` の受け渡しと `TransactionScope` を比較し、トランザクション境界と伝搬の違いを確認した |

## 新しいテーマを追加するとき

大きなサンプルを最初から作らず、まず **「今回の実験で答えたい問いは何か」** を1つに絞る。

```text
1. 問いを決める
2. <technology>/<area>/<experiment>/ を作る
3. 実行可能な最小コードを書く
4. 予想と実際の挙動を比較する
5. 理解が1段進んだところでコミットする
6. README の Experiments に追加する
7. 問いが解けたら撤収する
```

新しい疑問が出ても、元の問いと独立して試せるなら別の experiment として切り出す。

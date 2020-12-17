# 20201222hol

- Azure Portal
https://portal.azure.com

- Google Chrome のインストール
https://www.google.co.jp/chrome/

- Visual Studio Code インストール
https://code.visualstudio.com/

- .NET SDK のインストール
https://dotnet.microsoft.com/download

- Microsoft Stream 
https://msit.microsoftstream.com/

- C# プロジェクト作成時のコマンド：
dotnet new console

- C# プロジェクト実行時のコマンド：
dotnet run

- DB 作成時のユーザとパスワード
user: test
pass: Microsoft2020

- DB テーブル作成
CREATE TABLE captions(
id TEXT,
captionTimeURL TEXT,
captionString NTEXT
);

- BCP コマンド
bcp captions in VTTNAME -S SERVERNAME.database.windows.net -d DBNAME -U test -P Microsoft2020 -q -c -t ,

- 変換スクリプトサンプル(exe)
https://katsujimemail.blob.core.windows.net/email/TKC様_VTTファイル変換スクリプトサンプル.zip

- DB 内の確認
SELECT * FROM captions

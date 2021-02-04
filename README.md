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

- Froms
https://forms.office.com/

- Power Automate
https://flow.microsoft.com/ja-jp/

- Azure Storage Explorer
https://azure.microsoft.com/ja-jp/features/storage-explorer/

- DB 作成時のユーザとパスワード
user: test
pass: Microsoft2021

- DB テーブル作成
CREATE TABLE captions(
id TEXT,
captionTimeURL TEXT,
captionString NTEXT
);

- BCP コマンド
bcp captions in CSVFILENAME -S SERVERNAME.database.windows.net -d DBNAME -U test -P Microsoft2021 -q -c -t ,

- DB 内の確認
SELECT * FROM captions

- sqlcmd を使う場合
sqlcmd -S server -U user -P password -d database

- Power Automate 変数の初期化
split(body('functions'),',')



- 変換スクリプトサンプル(exe)
https://katsujimemail.blob.core.windows.net/email/TKC様_VTTファイル変換スクリプトサンプル.zip

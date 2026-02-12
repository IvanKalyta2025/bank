создаем свое приложение для анализа банковского аккаунта.

dotnet new webapi -o (и сюда имя файласв )

уставнока расширений для для swagger в api.csproj

установка swagger в program.cs

установка пакета dotnet add package Microsoft.EntityFrameworkCore --version 10.0.3

потому что в более новых версиях используют Precision а не Column (но я оставлю два варианта что бы посмотреть сравнение)

установка dotnet add package Microsoft.EntityFrameworkCore.Tools --version 10.0.3 для того что бы nuget рабоал. и это нужно для тогоч то бы можно было
рабоать с данными.
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 10.0.0-preview.1.26104.118
так же ссылка для того что бы иметь подключение к серверу.
https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/10.0.0-preview.1.26104.118

интересное замечание, что я использую этот сайт для устанвоки пакетов. там так же подробно описывают как работает этот пакет

protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MyDatabase;Trusted_Connection=True;");
}

вместо того что бы использовать то что предлагает в туториалае, я попыпатаюсь поставить postgres

Step 3: Configure Connection String
In your appsettings.json file, add your PostgreSQL connection string.
json
{
"ConnectionStrings": {
"DefaultConnection": "Host=localhost;Database=todo_db;Username=postgres;Password=yourpassword"
},
"Logging": {
"LogLevel": {
"Default": "Information",
"Microsoft.AspNetCore": "Warning"
}
},
"AllowedHosts": "\*"
}

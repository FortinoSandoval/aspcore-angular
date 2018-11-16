# aspcore-angular

dotnet build

cd ClientApp && npm start

dotnet watch run

Update `appsettings.Development.json` with your connection string

```{
  "ConnectionStrings": {
    "Default": "server=server;database=dbname;uid=root;password=pwd"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Debug",
      "System": "Information",
      "Microsoft": "Information"
    }
  }
}
```

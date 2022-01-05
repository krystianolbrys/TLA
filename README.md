# TLA
TranslationLearningApplication

# Add Migration
dotnet ef migrations add Initial2 -o .\Migrations\ --startup-project ..\TLA.Api\ --no-build --context SampleDb

{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "Kestrel": {
    "Endpoints": {
      "Http": {
        "Url": "http://0.0.0.0:8080"
      }
    }
  }
}

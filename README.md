# TLA
TranslationLearningApplication

# Add Migration in TLA\TLA.BE\TLA.Persistence
dotnet ef migrations add AddUserAndQuiz -o .\Migrations\ --startup-project ..\TLA.Api\ --no-build --context TranslationDb

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

add CQRS, add Models in BE, UNIQUE in QuizNAme
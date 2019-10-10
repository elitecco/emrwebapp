FROM mcr.microsoft.com/dotnet/core/aspnet:3.0
WORKDIR /app
COPY ./publish .
COPY ./DB .
ENTRYPOINT ["dotnet", "EMRapp.dll"]
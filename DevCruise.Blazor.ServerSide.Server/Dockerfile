FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY DevCruise.Blazor.Serverside.Server/DevCruise.Blazor.Serverside.Server.csproj DevCruise.Blazor.Serverside.Server/
COPY DevCruise.Blazor.Serverside.App/DevCruise.Blazor.Serverside.App.csproj DevCruise.Blazor.Serverside.App/
COPY DevCruise.Blazor.Shared/DevCruise.Blazor.Shared.csproj DevCruise.Blazor.Shared/
COPY DevCruise.Blazor.Client.Shared/DevCruise.Blazor.Client.Shared.csproj DevCruise.Blazor.Client.Shared/
COPY BlazorRedux/BlazorRedux.csproj BlazorRedux/
RUN dotnet restore DevCruise.Blazor.Serverside.Server/DevCruise.Blazor.Serverside.Server.csproj
COPY . .
WORKDIR /src/DevCruise.Blazor.Serverside.Server
RUN dotnet build DevCruise.Blazor.Serverside.Server.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish DevCruise.Blazor.Serverside.Server.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DevCruise.Blazor.Serverside.Server.dll"]

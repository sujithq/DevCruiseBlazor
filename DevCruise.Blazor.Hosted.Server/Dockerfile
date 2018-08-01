FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src

ADD BlazorRedux BlazorRedux
ADD DevCruise.Blazor.Shared DevCruise.Blazor.Shared
ADD DevCruise.Blazor.Client.Shared DevCruise.Blazor.Client.Shared
ADD DevCruise.Blazor.Hosted.Client DevCruise.Blazor.Hosted.Client
ADD DevCruise.Blazor.Hosted.Server DevCruise.Blazor.Hosted.Server

WORKDIR /src/DevCruise.Blazor.Hosted.Server

#RUN dotnet build DevCruise.Blazor.Hosted.Server.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish DevCruise.Blazor.Hosted.Server.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DevCruise.Blazor.Hosted.Server.dll"]

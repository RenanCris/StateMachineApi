FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
COPY . /src
WORKDIR /src

RUN dotnet restore "StateMachineApi.csproj"

WORKDIR "/src/."
RUN dotnet build "StateMachineApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StateMachineApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StateMachineApi.dll"]
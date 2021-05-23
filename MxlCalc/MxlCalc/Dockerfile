#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MxlCalc/MxlCalc.csproj", "MxlCalc/"]
COPY ["Services/Services.csproj", "Services/"]
COPY ["Models/Models.csproj", "Models/"]
RUN dotnet restore "MxlCalc/MxlCalc.csproj"
COPY . .
WORKDIR "/src/MxlCalc"
RUN dotnet build "MxlCalc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MxlCalc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MxlCalc.dll"]
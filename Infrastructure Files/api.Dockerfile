FROM mcr.microsoft.com/dotnet/sdk:6.0.200-alpine3.14-amd64 AS build
RUN apk add git
RUN git clone https://github.com/IgorMrcl/FiapMicroContainersAPI.git
WORKDIR /FiapMicroContainersAPI
RUN dotnet publish -c Release --no-self-contained -o publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0.2-alpine3.14-amd64 AS prod
WORKDIR /app
COPY --from=build /FiapMicroContainersAPI/publish .
ENV DB_PASSWORD fiap1234
ENV ASPNETCORE_URLS http://+:5000
EXPOSE 5000
ENTRYPOINT ["dotnet", "notaApi.dll"]
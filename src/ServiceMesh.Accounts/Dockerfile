# Service Accounts Dockerfile

#FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

FROM mcr.microsoft.com/dotnet/core/sdk:3.1

#docker run -it --rm -p 5000:80 --name aspnetcore_sample aspnetapp

ENV appdir /app
ENV port 5097

COPY bin/Release/netcoreapp3.1/ ${appdir}

LABEL service.name="ServiceMesh.Accounts" \
      service.description="This is the service to work with accounts"

COPY . ${appdir}

#RUN dotnet build /app/ServiceMesh.Accounts.csproj -c Release

#RUN dir /app

EXPOSE ${port}/tcp

ENTRYPOINT ["dotnet", "app/ServiceMesh.Accounts.dll"]
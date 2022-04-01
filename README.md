# JaguarPortal

Download file docker.compose.yml

## Create certificate:
Creating certificate to run site on HTTPS.
```
dotnet dev-certs https -ep %USERPROFILE%\.aspnet\https\aspnetapp.pfx -p 434170d8-45f1-4045-bfd2-c18f76bee82d
dotnet dev-certs https --trust
```

## Run Docker
Download file docker-compose.yml on root this repository and execute: 
```
docker-compose up -d
```

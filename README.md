# Jaguar Portal Web
Jaguar Portal Web is a web application responsible for receiving and displaying Spectrum-based Fault Localization (SFL) information.

## Jaguar Portal
Jaguar Portal is a solution composed of a group of tools that together bring the Spectrum-based Fault Localization (SFL) functionality in a continuous integration environment:
- [Jaguar 2](https://github.com/saeg/jaguar2) - JavA coveraGe faUlt locAlization Rank 2 - Jaguar implements the Spectrum-based Fault Localization (SFL) technique for Java programs.
- [Jaguar Portal Web](https://github.com/ericksonlbs/JaguarPortal) - Web API and Web Site responsible for receiving and displaying Spectrum-based Fault Localization (SFL) information.
- [Jaguar Portal Submit](https://github.com/ericksonlbs/jaguarportal-submit) - Command Line responsible for submitting Spectrum-based Fault Localization (SFL) data to the Jaguar Portal Web API. This component is also available as a GitHub Action, for use in GitHub Actions.

## How to use?
Download file docker.compose.yml

### Create certificate:
Creating certificate to run site on HTTPS.
```
dotnet dev-certs https -ep %USERPROFILE%\.aspnet\https\aspnetapp.pfx -p 434170d8-45f1-4045-bfd2-c18f76bee82d
dotnet dev-certs https --trust
```

### Run Docker
Download file docker-compose.yml on root this repository and execute: 
```
docker-compose up -d
```

In Jaguar Portal Web, where you can view SFL information together with the code, showing suspicious lines marked with colors ranging from green (least suspicious) to red (most suspicious):
![image](https://github.com/user-attachments/assets/774e3513-c45b-4b4c-8c30-8518d55b7510)

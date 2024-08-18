# 📚 Twitter (X) Downloader 🚀
Yet another media downloader for tweets!

Powered by `Svelte`, `.NET 8`, and `C hashtag version 12`.
## 🛠️ Built With
![Svelte](https://img.shields.io/badge/svelte-%23f1413d.svg?style=for-the-badge&logo=svelte&logoColor=white)
![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
![TypeScript](https://img.shields.io/badge/typescript-%23007ACC.svg?style=for-the-badge&logo=typescript&logoColor=white)
![Vite](https://img.shields.io/badge/vite-%23646CFF.svg?style=for-the-badge&logo=vite&logoColor=white)
![TailwindCSS](https://img.shields.io/badge/tailwindcss-%2338B2AC.svg?style=for-the-badge&logo=tailwind-css&logoColor=white)
![DaisyUI](https://img.shields.io/badge/daisyui-5A0EF8?style=for-the-badge&logo=daisyui&logoColor=white)
## 🎯 To-Dos
- [ ] Select media size to download.
## 🚧 Development Setup
### Prerequisites
Before starting, ensure you have the following tools and environments set up on your machine:
- .NET 8.0 SDK
- NodeJS
### ⭐ Back-end API Setup
#### 1. Configure Application Settings
Update the configuration files located at `X.API/appsettings.json` and `X.API/appsettings.Development.json` with appropriate settings.
#### 2. Restore Dependencies
At the root directory, restore the required NuGet packages by running:
```bash
dotnet restore
```
#### 3. Run the Application
Start the API with:
```bash
dotnet run --project X.API
```

__🚀 The API will listen on:__
- HTTP: **http://localhost:5271**
- HTTPS: **https://localhost:7132**

(You can change these ports in the `launchSettings.json` file located at `X.API/Properties/launchSettings.json`)
### ⭐ Front-end Web App Setup
#### 1. Install Dependencies
At the `X.WebApp` directory, install dependencies by running:
```bash
npm install
```
#### 2. Run the Application
Launch the application locally from the `X.WebApp` directory with:
```bash
npm run dev
```

__🚀 The web app will listen on:__
**http://localhost:5173**

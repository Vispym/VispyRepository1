# Game API

A simple ASP.NET Core Web API for managing a list of games.
Using Visual Studio Code in Mac and .net CORE framework.
Below were installed after insalling Visual Studio -
1) .net 10 SDK 10.0.301 - SDK
2) .net CORE 10.0.9 - Runtime
3) C# Dev Kit
4) C# Extension
5) .net Runtime Extension

3, 4 & 5 were installed through Command Pallete

## Features
- Get all games
- Get a game by ID
- Create a new game

## Run locally
```bash
dotnet run
```

Then open:
- http://localhost:5142/
- http://localhost:5142/api/games

## Example endpoints
- GET /api/games
- GET /api/games/1
- POST /api/games

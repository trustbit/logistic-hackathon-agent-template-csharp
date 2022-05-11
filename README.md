
<p align="center">
  <a href="https://trustbit.tech">
    <img alt="Trustbit Hackathon: Sustainable Logistics Simulation" src="images/header.jpeg" >
  </a>

<h4 align="center">This is the <b>C#</b> agent template repository for the <br><a href="https://trustbit.tech/hackathon" target="_blank">Trustbit Hackathon: Sustainable Logistics Simulation</a> which you can use to get started quickly.</h4>

  <p align="center">
    <a href="LICENSE"><img src="https://img.shields.io/badge/License-MIT-yellow.svg" alt="License"></img></a>
        <a href="https://trustbit.tech"><img src="https://img.shields.io/badge/Organizer-Trustbit-%23006871" alt="Join Slack chat"></img></a>
    <a href="https://join.slack.com/t/trustbitsusta-vl26615/shared_invite/zt-17i36qlc1-h6L0GsJov2gPLLSYFaqNmw"><img src="https://img.shields.io/badge/Slack-join%20chat-green" alt="Join Slack chat"></img></a>
  </p>
</p>

**For a detailed explanation of how to make a copy of this repository and get it into the competition build system, please visit [Agent template repositories and comeptition build system](https://github.com/trustbit/logistic-hackathon-public#3-create-a-new-ssh-key-for-the-competition-build-system). All questions about the simulation and its rules are answered under [Simulation](https://github.com/trustbit/logistic-hackathon-public#simulation).**

## Prerequisites
- **IDE** - We strongly advise you to use an IDE which will help you to edit, compile and run C# code. Our recommendation is [VS Code](https://code.visualstudio.com/download) , which you can download for free.
- **.NET 6** - You will need the .NET 6 SDK installed on your machine. You can find it on [Microsoft's website](https://www.microsoft.com/net/download/sdk-list).

## Where should I add the logic of my truck agent?
- Open the project in your favorite IDE and browse to [Src/LogisticsRestApi/Controllers/TruckAgentController.cs](Src/LogisticsRestApi/Controllers/TruckAgentController.cs)
- The method `decide` will always be called by the simulation when the next decision is needed from your truck agent. The argument of this method contains all the information you need to decide for the next move. Just return an instance of [DecideRequest](Src/LogisticsRestApi/Model/DecideRequest.cs) and the simulation will take over again.

## How can I test my truck agent?
- Open the project in your favorite IDE and browse to [Test/Tests/TruckAgentControllerIntegrationTests.cs](Test/Tests/TruckAgentControllerIntegrationTests.cs)
- This is an integration test which will start your agent and will call the `decide` method with the contents of file [Test/Tests/Resources/decide.json](Test/Tests/Resources/decide.json)
- You can always change the `decide.json` file and debug your script.

## How can I run the truck agent or its tests without an IDE?
- `dotnet run -p Src/LogisticsRestApi/LogisticsRestApi.csproj ` will start the truck agent, which will then service requests on port 8080.
- `dotnet test` will execute all the tests in the project.

## Docker
### Build Docker Image
```docker build -t logistic-agent .```

### Start Docker Image
```docker run -p 8080:8080 logistic-agent```
The agent will be available on http://0.0.0.0:8080

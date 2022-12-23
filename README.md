# LiveSplit Bridge

An ACT Plugin for helping other plugins interact with [LiveSplit](https://livesplit.org/)

## Download
See the [releases](https://github.com/Makar8000/LiveSplitBridge/releases)

## Instructions
- Open LiveSplit
- Press "Connect to LiveSplit"
- Add a new [Triggernometry](https://github.com/paissaheavyindustries/Triggernometry) trigger
- Add a new action in the trigger and set the Action type to "Named callback operation"
- Set "Callback name" to `LiveSplitMessage`
- Set "Callback parameter" to the LiveSplit [command](https://github.com/LiveSplit/LiveSplit/blob/1.8.25/LiveSplit/LiveSplit.Core/Server/CommandServer.cs#L143-L336) you would like to send
- Set the trigger conditions as desired

## Software Used
 * [Microsoft .NET Framework 4.8](https://dotnet.microsoft.com/download/dotnet-framework)

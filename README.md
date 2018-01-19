# AppVeyor Dashboard

[![Build status](https://ci.appveyor.com/api/projects/status/vyau4m2ls0hqljss/branch/master?svg=true)](https://ci.appveyor.com/project/Razor/appveyordashboard/branch/master)

## Builds

![appveyor-dashboard-builds](https://raw.githubusercontent.com/razorltd/appveyordashboard/master/appveyor-dashboard-builds.gif)

`~/builds`

### Query String Parameters (optional)

- `project` (regex)
- `branch` (regex)

e.g. `~/builds?project=AppVeyor%20Dashboard&branch=master`

## Deployments

![appveyor-dashboard-deployments](https://raw.githubusercontent.com/razorltd/appveyordashboard/master/appveyor-dashboard-deployments.gif)

`~/deployments`

### Query String Parameters (optional)

- `environment` (regex)

e.g. `~/deployments?environment=Production`

## Configuration

### `AppVeyorApi:Token` 

A valid [AppVeyor API token](https://ci.appveyor.com/api-token). Store in a [user secret](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets) during development.

### `IpAddressFilter:AllowedIpAddresses`

An whitelist array of IP addresses that can access the dashboard. See [here](http://stackoverflow.com/questions/34063167/using-an-array-in-azure-web-app-settings) for configuraing an array in an Azure Web App.

### `ASPNETCORE_ENVIRONMENT` 

The current environment (e.g. `Production`).

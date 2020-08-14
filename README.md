# Signup system for SiO Athletica
This is a proof of concept developed by the summer students of Making Waves in 2020 for SiO Athletica. It is meant to replace today's signup process at Athletica's gyms. The prototype can be accessed [here](https://athleticasignup.web.app)

## Table of contents
- [Install project](#install-project)
  - [Prerequisites](#prerequisites)
  - [How to install locally](#how-to-install-locally)
    - [Create the Mock database](#create-the-mock-database)
    - [Frontend](#frontend)
- [Run project](#run-project)
    

# Install project
## Prerequisites
Install [Dotnet Core](https://dotnet.microsoft.com/download) if you don't already have it installed.

Install Dotnet EF:
```bash
dotnet tool install --global dotnet-ef
```

Install [Docker Desktop](https://www.docker.com/get-started) if you don't already have it installed.

Install Homebrew:
```bash
/bin/bash -c "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/master/install.sh)"
```

Install **node** and **webpack**:

```bash
brew install npm
npm install npm@latest -g
npm install --save-dev webpack
```

## Steps
Either follow these steps or run the setup script:
```bash
./setup.sh
```
which completes these steps automatically.

### Create the Mock database
1. Install [Docker Desktop](https://www.docker.com/get-started) if you don't already have it installed.
2. Run the following command

```bash
docker run -d --name MockServer -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD={A very secret password}' -p 1500:1433 mcr.microsoft.com/mssql/server:2019-latest
```

To check that the server is up and running, run

```bash
docker ps
```

3. To set the connection string when testing locally, add a user secret:

```bash
pushd src/Mock
dotnet user-secrets set DefaultConnection "Server=localhost,1500;Initial Catalog=MockDB;User ID=sa;Password={The very secret password}"
popd
```

Check that it worked:

```bash
dotnet user-secrets list
```

4. To create the database, run

```bash
dotnet ef database update
```


### Frontend
```bash
pushd src/frontend/MembershipSignup
cp -R buildsite build
npm install
popd
```

# Run project
Open three terminal windows.
In the first window:
```bash
cd src/Mock
dotnet run dev
```

In the second window:
```bash
cd src/Backend
dotnet run dev
```

In the third window:
```bash
cd src/frontend/MembershipSignup
npm run dev
```

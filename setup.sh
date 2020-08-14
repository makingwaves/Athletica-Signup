#!/bin/bash
echo "Creating Docker server.";
echo "Enter a strong password for the Docker server:";
read password;
docker run -d --name MockServer -e 'ACCEPT_EULA=Y' -e "SA_PASSWORD=${password}" -p 1500:1433 mcr.microsoft.com/mssql/server:2019-latest;
echo "Adding connection string to Mock project user secrets";
pushd src/Mock;
dotnet user-secrets set DefaultConnection "Server=localhost,1500;Initial Catalog=MockDB;User ID=sa;Password=${password}";
echo "Creating database";
dotnet ef database update;
popd;
echo "Command for finding the connection string:";
echo "cd src/Mock";
echo "dotnet user-secrets list";
echo ";"
echo "Installing dependencies for frontend.";
pushd src/frontend/MembershipSignup;
cp -R buildsite build;
npm install;
popd;
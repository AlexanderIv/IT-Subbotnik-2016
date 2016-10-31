echo[ && echo ### Restore "domain" project &&^
cd .\domain\ &&^
dotnet restore &&^
echo[ && echo ### Restore "data-access" project &&^
cd ..\data-access\ &&^
dotnet restore &&^
echo[ && echo ### Restore "data-access-stub" project &&^
cd ..\data-access-stub\ &&^
dotnet restore &&^
echo[ && echo ### Restore "web-app" project &&^
cd ..\web-app\ &&^
dotnet restore &&^
echo[ && echo ### Install NPM Modules &&^
cd .\client\ &&^
npm install &&^
echo[ && echo ### Run Webpack - see "build" action in package.json &&^
npm run build &&^
echo[ && echo ### Publish "data-access" project &&^
cd ..\ &&^
dotnet publish &&^
cd ..\

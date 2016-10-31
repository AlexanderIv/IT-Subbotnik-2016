# IT-Subbotnik-2016

Это демонстрационный пример, который я показывал на IT Subbotnik'е 2016.
Само приложение состоит из простой странички, которая покаывает список неких пользователей. 
Эта страница представлена в двух версиях: без пре-рендера angular2 компонентов и с пре-рендером этих компонентов на сервере.

В корневой папке есть bat-ник, который собирает всё это приложение.
Он делает следующее:
•	dotnet restore по всем проектам из которых состоит приложение
•	npm install для js’ных модулей
•	запускает webpack чтобы собрать всю статитку и положить её в wwwroot (нужно только для странички без пре-рендера)
•	dotnet publish для вебного проекта

Чтобы запустить сайтик после сборки, надо перейти из этой корневой папки в папку publish:
cd .\web-app\bin\Debug\netcoreapp1.0\publish\

далее запускаем сайт:
dotnet web-app.dll

в приложении есть 2 страницы

http://localhost:5000/home/standardapp
http://localhost:5000/home/index

Первая link’а ведёт на стандартную страницу с angular’ом без пре-рендера на сервере.
Втарая ведёт на страничку с пре-рендером. Первое обращение по ней занимает продолжительное время, потому что прямо в рантайме начинает работать webpack.


Помимо этого, можно скачать готовые примеры из гитхаба самого aspnet'а:
https://github.com/aspnet/JavaScriptServices/
Клонируем этот репозиторий или скачиваем исходники как .zip архив. Там есть папочка templates, в которой есть примеры с пре-рендером, как для Angular2, так и для других JS’ных фреймворков.

Либо можно воспользоваться генератором Yeoman:
npm install -g yo generator-aspnetcore-spa
mkdir some-empty-directory
cd some-empty-directory
yo aspnetcore-spa

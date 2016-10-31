# IT-Subbotnik-2016

Это демонстрационный пример, который я показывал на IT Subbotnik'е 2016.<br>
Само приложение состоит из простой странички, которая покаывает список неких пользователей.<br>
Эта страница представлена в двух версиях: без пре-рендера angular2 компонентов и с пре-рендером этих компонентов на сервере.<br>

В корневой папке есть bat-ник, который собирает всё это приложение.<br>
Он делает следующее:
<ul>
<li>dotnet restore по всем проектам из которых состоит приложение</li>
<li>npm install для js’ных модулей</li>
<li>запускает webpack чтобы собрать всю статитку и положить её в wwwroot (нужно только для странички без пре-рендера)</li>
<li>dotnet publish для вебного проекта</li>
</ul>

Чтобы запустить сайтик после сборки, надо перейти из этой корневой папки в папку publish:<br>
cd .\web-app\bin\Debug\netcoreapp1.0\publish\

далее запускаем сайт:<br>
dotnet web-app.dll

в приложении есть 2 страницы
http://localhost:5000/home/standardapp<br>
http://localhost:5000/home/index<br>

Первая link’а ведёт на стандартную страницу с angular’ом без пре-рендера на сервере.<br>
Втарая ведёт на страничку с пре-рендером. Первое обращение по ней занимает продолжительное время, потому что прямо в рантайме начинает работать webpack.


Помимо этого, можно скачать готовые примеры из гитхаба самого aspnet'а:<br>
https://github.com/aspnet/JavaScriptServices/<br>
Клонируем этот репозиторий или скачиваем исходники как .zip архив. Там есть папочка templates, в которой есть примеры с пре-рендером, как для Angular2, так и для других JS’ных фреймворков.

Либо можно воспользоваться генератором Yeoman:<br>
npm install -g yo generator-aspnetcore-spa<br>
mkdir some-empty-directory<br>
cd some-empty-directory<br>
yo aspnetcore-spa<br>

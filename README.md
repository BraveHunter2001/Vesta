# Vesta
*Backend*: ASP.NET 7 WEB-API, Entity Framework, Postgresql  
*Frontend*: ReactJS, Axios  

## Инструкция по запуску  
Должен быть установлен Postgresql на системе  
  
Сервер запустить можно двумя способами:  
1) Через **.exe**  
Тогда в файле `Vesta\frontent\.env.development.local` поставить `REACT_APP_IP_SERVER=http://localhost:5000`  
И запустить: `Vesta\Backend\bin\Debug\net7.0\Backend.exe`

2) Через **VisualStudio**.  
 Файле `Vesta\frontent\.env.development.local` поставить `REACT_APP_IP_SERVER=http://localhost:5140`  
 Запустить через **http**.  
*По умолчанию в `.env.development.local` стоит настройка на запуск через VisualStudio*

Клиент запустить в папке:
```
cd Vesta\frontend
npm start
```

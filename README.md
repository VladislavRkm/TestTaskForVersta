# TestTaskForVersta
## Техническое задание:
*Реализовать простое Web приложение для приемки заказа на доставку со следующим функционалом:*

*1. Форма создания нового заказа (все поля обязательны для заполнения):*
*Город отправителя
Адрес отправителя
Город получателя
Адрес получателя
Вес груза
Дата забора груза*

*2. Форма отображения списка заказов: все созданные заказы должны отображаться в отдельной форме. Помимо полей, введенных пользователем при создании заказа, должен отображаться автоматически сгенерированный номер заказа.*

*3. Форма просмотра созданного заказа в режиме чтения. Должна открываться при клике на заказ в списке заказов.*

___
## Стек технологий:

* ASP.NET 8 на backend
* Razor Pages
* Entity Framework
* PostgreSQL
* Docker
___
## Backend:
 Я решил написать данное приложение с использованием луковой(чистой) архитектуры. Как известно, всё начинается с доменных сущностей:
 
 ![image](https://github.com/VladislavRkm/TestTaskForVersta/assets/113041279/4af54062-a543-42bd-bcbb-fc0799627fb9)
 (Все слои и взаимодействия можно увидеть в структкуре проекта.)
 
 Не буду тянуть. Когда все сущности, модели, контекст, репозитории, интерфейсы, сервисы и контроллеры были написаны, я подключил базу данных PostgreSQL и поднял её в Docker-контейнере.
 ![image](https://github.com/VladislavRkm/TestTaskForVersta/assets/113041279/0785811f-eac8-4ee0-a266-43d88a19e48d)
 ![image](https://github.com/VladislavRkm/TestTaskForVersta/assets/113041279/608d291e-1f46-4b99-b3b5-e36904ec9453)
 ___
 Можно запускать проект. При запуске у нас открывается страница Swagger'a со следующими http-запросами:
 ![image](https://github.com/VladislavRkm/TestTaskForVersta/assets/113041279/b6f43d69-5cd5-4f92-9833-a6e7d51b3f41)
 ___
 Проверим их работоспособность, и первым делом создадим заказ на перевозку груза:
 ![image](https://github.com/VladislavRkm/TestTaskForVersta/assets/113041279/b6295f9b-87f5-4351-8108-d92a115f9e1b)
 ![image](https://github.com/VladislavRkm/TestTaskForVersta/assets/113041279/13440220-455c-4132-ae4b-100dd13e67c1)
 Видим код "200", радуемся жизни и отправляем GET-запрос и получаем наши заказы, дабы убедиться, что всё не зря:
 ![image](https://github.com/VladislavRkm/TestTaskForVersta/assets/113041279/79abdfb1-084a-4aba-ae17-1e00c607851f)
 Перед нами два заказа, один из которых не несёт в себе никакой содержательной информации. Удалим его и проверим работоспособность DELETE-запроса. Копируем id заказа, который хотим удалить и вставляем в поле для заполнения.
![image](https://github.com/VladislavRkm/TestTaskForVersta/assets/113041279/62a83acf-4280-4615-9302-679a4fb4e8b8)
![image](https://github.com/VladislavRkm/TestTaskForVersta/assets/113041279/81e87d2e-8e1c-4648-aeee-76e147cfe6de)
___
Теперь представим, что экспедитору попался ненадёжный заказчик и ему нужно подкорректировать детали заказа. Корректируем данные, отправляем UPDATE-запрос, а затем GET-запрос, чтобы убедиться, что внесённые изменения сохранены.
![image](https://github.com/VladislavRkm/TestTaskForVersta/assets/113041279/b179ba10-056d-48a0-a1cd-4f87aea475da)
![image](https://github.com/VladislavRkm/TestTaskForVersta/assets/113041279/e9a901ac-846b-403a-a423-bca654235a71)
![image](https://github.com/VladislavRkm/TestTaskForVersta/assets/113041279/83d16269-7291-4858-955a-db6e0e3fc1f9)
___
Наконец, убедимся, что в базе данных всё также сохраняется:
![image](https://github.com/VladislavRkm/TestTaskForVersta/assets/113041279/434803a5-0f7e-4220-b1a1-e545dc57aa44)
___

## Frontend:
Главная страница выглядит следующим образом. Мы можем увидеть кнопку для формирования нового заказа и форму для просмотра уже существующих заказов (пока что она пуста):

![image](https://github.com/user-attachments/assets/997906dc-ab77-48f9-b29e-9870da7f7b07)

Убедимся, что наша база данных также пуста и перейдём к ручному тестированию функционала страницы.

![image](https://github.com/user-attachments/assets/5b2ec1cb-35a7-4e27-8d13-a933d150d421)
___
Создадим новый заказ, нажимаем кнопку "Отправить". Возращаемся на главную станицу и видим, что заказ отобразился.
![image](https://github.com/user-attachments/assets/1cd30de6-62d4-43db-870e-eb0c99e0ba12)
![image](https://github.com/user-attachments/assets/ba0b8325-d65a-41b2-a635-03ffb5a38973)

Проверим его наличие в БД:
![image](https://github.com/user-attachments/assets/224a4216-a08d-4151-a4bb-fa5fa5285177)

Видим, что заказ отобразился и все данные совпадают с тем, что отражено на странице.
___
Перейдём к тестированию кнопок "Просмотр заказа", "Редактировать", "Удалить":

Просмотр осуществляется в режиме чтения. Открываем заказ, попробуем стереть введённые данные:
![image](https://github.com/user-attachments/assets/bf404dc5-5cee-4ffb-9ea8-9989e7076f4a)

Нажимаем кнопку закрыть и всё возвращается на свои места:
![image](https://github.com/user-attachments/assets/f5cf7bea-d3f1-4273-944c-667c6b5081ec)
___

Теперь отредактируем наш заказ:
![image](https://github.com/user-attachments/assets/bb6d4ccb-7ead-4db0-84fd-f5c43e989c4c)

Заказ отобразился, при этом заметим, что номер заказа у нас _не редактируется и не меняется_, то есть с точки зрения бизнес-логики это тот же самый заказ, в котором изменились некоторые поля.
![image](https://github.com/user-attachments/assets/ecbbc533-71b8-44b6-bd57-2e4f0ea95346)

В базе данных изменения также отображаются:
![image](https://github.com/user-attachments/assets/07975d8e-81c7-4451-b370-fc715e1b9bd8)
___

Давайте теперь удалим наш заказ. Для этого воспользуемся кнопкой "Удалить".
![image](https://github.com/user-attachments/assets/feec350c-2542-4a53-b6b8-d4585a98dc51)

Из базы данных запись удаляется соответственно:
![image](https://github.com/user-attachments/assets/2c8d6622-7766-4b8b-a012-65ff7f3dc977)
___
Теперь проверим синхронизацию бэкенда и фронтенда. Создадим какой-нибудь заказ через Swagger UI.
![image](https://github.com/user-attachments/assets/2cbc660b-5a27-46a6-ae19-ec1f84619986)
Обновим страницу и увидим заказ на нашей страничке:

![image](https://github.com/user-attachments/assets/21bf185a-d473-435b-8eca-c5408e37c556)
___
Теперь в обратную сторону, проверим как работают http-запросы с заказами, созданными через Razor Pages.
![image](https://github.com/user-attachments/assets/37ecdbee-ee90-4d59-b253-8531e0474239)
![image](https://github.com/user-attachments/assets/424f9451-5918-47b9-9deb-8d256ead09a7)

Выполняем GET-запрос в Swagger UI и он нам возвращает наши заказы.
![image](https://github.com/user-attachments/assets/caebeab5-1699-4ce3-a430-9eac87b128dc)

Остальные запросы выполнять не будем, так как очевидно, что они будут работать.
___
Подведём итоги.
Технические требования к реализации:

- [x] Форма заказа с обязательными для заполнения полями
- [x] Форма для отображения сформированных заказов с автоматически сгенерированным номером для каждого заказа
- [x] Форма для просмотра заказа в режиме чтения

Технологии:

- [x] ASP.NET 8 на backend
- [ ] React.JS (предпочтительно) на front
- [x] Razor Pages на front
- [x] Entity Framework
- [x] Docker (дополнительно)
- [x] PostgreSQL














 




 

 

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
-ASP.NET 8 на backend
-React.JS, Next.JS, Ant Design
-Entity Framework
-PostgreSQL
-Docker
___
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
 Перед нами два заказа, один из которых не несёт в себе никакой содержательной информации. Удалим его и проверим, работоспособность DELETE-запроса. Копируем id заказа, который хотим удалить и вставляем в поле для заполнения.
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






 




 

 

<h1>Проект АИС для автосервиса.</h1>
<br>Начальное окно-авторизация.<br>
![image](https://user-images.githubusercontent.com/94114655/171874850-5144a1aa-dac2-4dc7-963d-f48ea965a66b.png)

<br>Для пользователей программы разных ролей (в данном случае отличие между ролями "Администатор" и "Менеджер") меняется функциональность программы. Ниже представлено окно с возможностями для администратора: <br>
![image](https://user-images.githubusercontent.com/94114655/171874886-e4b8aaaf-441f-4aec-8e2a-2a4a4016765f.png)
![image](https://user-images.githubusercontent.com/94114655/171875485-9dfb9ef5-2343-43e3-ab55-85ef5171d45c.png)

<br>У пользователя с ролью "Менеджер" возможностей в программе больше: <br>
![image](https://user-images.githubusercontent.com/94114655/171875617-3d39c7b1-92e6-4511-ab59-f1fb5a10d4ab.png)
![image](https://user-images.githubusercontent.com/94114655/171875589-0bec212c-7820-422b-a325-6af54352aee2.png)

<br>окно со списком клиентов. Содержит в себе список клиентов, фильтр и поисковую строку для осуществения быстрого поиска необходимого клиента, значок-плюсик в верхнем правом углу для добавления нового клиента в базу.<br>
![image](https://user-images.githubusercontent.com/94114655/171876133-b16acf35-ef70-4a2e-8772-3090bcc03aa6.png)

<br>Фильтрация осуществляется по нескольким критериям: по фамилии, имени, дате рождения и почте. <br>
![image](https://user-images.githubusercontent.com/94114655/171876349-3dd383cc-3554-424b-8aaa-2101863249a0.png)
![image](https://user-images.githubusercontent.com/94114655/171876367-98380e2c-a1a0-41af-af40-24369484da13.png)
![image](https://user-images.githubusercontent.com/94114655/171876383-eaa0bbf4-c762-45ae-8e48-a6cda00c2c0d.png)
![image](https://user-images.githubusercontent.com/94114655/171876390-d946b94e-f594-44ac-bfca-53b83295e55d.png)

<br>Фильтрация клиентов по поиску происходит следующим образом: <br>
![image](https://user-images.githubusercontent.com/94114655/171876506-27ca378e-1d0b-490e-9f4b-665146d4c9be.png)
![image](https://user-images.githubusercontent.com/94114655/171876726-46693695-d011-433b-a486-70b374a12878.png)


<br>Добавление клиента. Имеет ограничения на воод записи цифр в ФИО, валидацию на правильный ввод почты (пропускает внесенные данные только с @, буквами до и после точки) <br>
![image](https://user-images.githubusercontent.com/94114655/171876946-5826d47c-01ea-4158-b58b-e820ad712100.png)
![image](https://user-images.githubusercontent.com/94114655/171877405-a2194a3a-074d-4245-b357-0cd99d99387a.png)
![image](https://user-images.githubusercontent.com/94114655/171877742-90e4093d-dad1-4a26-9933-46b72d1aa553.png)

<br>Запись о новом клиенте добавляется в список в интерфейсе программы и в базу данных.<br>
![image](https://user-images.githubusercontent.com/94114655/171877865-95a5ae8c-e23b-4d33-93c6-c169ffddd4de.png)
![image](https://user-images.githubusercontent.com/94114655/171877996-541eba35-1d33-4aa9-84a2-35b3f007d51d.png)

<br>Удаление клиента происходит с помощью клика по клиенту, которого необходимо удалить из списка и нажатием клавиши "Del"<br>
![image](https://user-images.githubusercontent.com/94114655/171878181-52e86617-e12a-41ee-b13c-4dcea1269e30.png)
![image](https://user-images.githubusercontent.com/94114655/171878248-6302ea85-0fa7-4c58-90d1-4b2d2227a0c4.png)

<br>В базе данных SQL используется мягкое удаление. После удаления из списка, в базе остаётся удалённый клиент. Выглядит так: <br>
![image](https://user-images.githubusercontent.com/94114655/171878623-61c99438-0faf-430e-bb29-04a975aef403.png)

<br>Окно списка сотрудников. Также как и в списке клиентов содержит в себе, непосредственно, список сотрудников, фильтрацию (по фамилии, имени, логину и должности), поисковую строку для быстрого поиска нужного сотрудника и иконки для добавления записи о новом сотруднике<br>
![image](https://user-images.githubusercontent.com/94114655/171879655-c609aff2-6e96-4f41-849c-32f7fbd44da0.png)
![image](https://user-images.githubusercontent.com/94114655/171879683-e1a78f81-2645-45fd-8aed-58ed7cb3b02e.png)
![image](https://user-images.githubusercontent.com/94114655/171879701-f6992dc4-ed0f-4cfc-b901-4f78d7c72311.png)
![image](https://user-images.githubusercontent.com/94114655/171879736-ba0b399d-84b5-42d3-9eed-6557a013e8e6.png)
![image](https://user-images.githubusercontent.com/94114655/171879779-cf772e02-eef1-490c-a3c5-cab6992de252.png)
![image](https://user-images.githubusercontent.com/94114655/171879972-935d51e8-5d66-4ec3-a074-78c5ec1a996d.png)
![image](https://user-images.githubusercontent.com/94114655/171880047-894b222b-bd48-44eb-8f25-bfccb8373d90.png)

<br>Добавление сотрудника в список и в базу данных работает тем же образом, что и добавление клиента:<br>
![image](https://user-images.githubusercontent.com/94114655/171880243-4d9043a7-49b4-43f5-bb45-a2faf271e9ff.png)



<br>Для того, чтобы изменить данные клиента/сотрудника/услуги необходимо кликнуть два раза по наименованию из списка, которое необходимо изменить<br>
![image](https://user-images.githubusercontent.com/94114655/171880450-5a91ab33-6df8-4087-816a-93154cab7dff.png)
![image](https://user-images.githubusercontent.com/94114655/171882189-5ecfe27b-9c7f-4ba6-8f67-2e61c3e90353.png)

<br>Имеется валидация на номер телефона(пропускает данные о номере телефона только стандартного вида из 12 чисел, а также ограничивает ввод букв и специальных символов)<br>
![image](https://user-images.githubusercontent.com/94114655/171882313-6529d8bf-cf49-4d8d-9dc8-9eda5c5a0d5d.png)

<br>Список услуг содержит в себе всё то же самое, что и в клиентах, сотрудниках. Изменение, добавление, удаление наименований услуг работает аналогичным образом. <br>
![image](https://user-images.githubusercontent.com/94114655/171882683-e86f26b9-34a8-4e4b-b1f8-cc0d095b7aeb.png)

<br>Проверка фильтра по поиску необходимого наименования услуги из списка:<br>
![image](https://user-images.githubusercontent.com/94114655/171883103-8ef8c3e5-551f-4cea-9d83-584c5e8c49a5.png)

<br>Окно изменения данных о выбранной услуге:<br>
![image](https://user-images.githubusercontent.com/94114655/171882940-157f9646-6209-41e0-aad5-b6a15ab96524.png)
![image](https://user-images.githubusercontent.com/94114655/171883028-7c48886b-0bdf-4245-91e6-4b504df46c70.png)
![image](https://user-images.githubusercontent.com/94114655/171883053-3a61be0d-0537-499e-98ce-5c927fa2d2f0.png)


<br><br>
![image](https://user-images.githubusercontent.com/94114655/171883557-90ea6f0f-7c05-48d7-aaf2-7d9ff32f58b0.png)

<br><br>
![image](https://user-images.githubusercontent.com/94114655/171883302-b4ac3e05-f9ba-41ee-bfd3-974a7da0d238.png)
![image](https://user-images.githubusercontent.com/94114655/171883324-5b681d1f-9bdd-4dbd-bf5d-20101bc39316.png)
![image](https://user-images.githubusercontent.com/94114655/171883339-6a067d7e-9df0-43a3-a099-b27c6e4c9a8a.png)
![image](https://user-images.githubusercontent.com/94114655/171883354-914a9968-2f8e-49e3-9864-49921d6578fa.png)
![image](https://user-images.githubusercontent.com/94114655/171883368-bee5fed3-c2d9-4488-8cf2-d0a0993da7ad.png)


<br><br>
![image](https://user-images.githubusercontent.com/94114655/171883708-0ef28ee5-6f3a-41d3-8d16-d8d792ce5186.png)
![image](https://user-images.githubusercontent.com/94114655/171883763-d74c8f39-cc2f-4f15-898f-01e849a85dff.png)
![image](https://user-images.githubusercontent.com/94114655/171883805-65b36d05-2f44-47d7-bb86-a92040bb578a.png)

<br><br>
![image](https://user-images.githubusercontent.com/94114655/171883946-f6b5042f-9ff7-4784-8941-700214d74935.png)

<br><br>
![image](https://user-images.githubusercontent.com/94114655/171884031-d644a7a8-ec54-499d-80f5-9459bc324026.png)

<br><br>
![image](https://user-images.githubusercontent.com/94114655/171884406-e7b85f08-4d21-4b6e-aa44-25440e5147ae.png)
![image](https://user-images.githubusercontent.com/94114655/171884426-1da1bbfe-51df-4ece-bdb5-b8ae45d4921f.png)


<br><br>
<br><br>

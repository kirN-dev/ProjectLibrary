# ProjectLibrary

Необходимо разработать приложение для учета книг библиотеки.
 
Сущности, которые должны редактироваться и храниться в БД:
1. Информация о книге. Поля:
- Название книги
- Автор
- ISBN
- Аннотация (краткое описание книги)
- Привязка к стеллажу (позиции)
 
2. Информация о стеллаже (место хранения книги в библиотеке)
- Название
- Описание
 
3. Информация о читателе
- ФИО
 
Пользовательский интерфейс должен реализовывать следующий функционал:
- Добавление/Редактирование/Удаление книги
- Добавление/Редактирование/Удаление стеллажа
- Добавление/Редактирование/Удаление читателя
- Отображение списка всех книг
- Отображение списка всех выданных книг
- Отображение списка выданных книг по конкретному читателю
- Поиск книги (по названию, автору, ISBN, читателю)
- Отображение списка всех читателей
- Отображение списка читателей, которым выданы книги
- Поиск читателя по ФИО
 
Требования к реализации:
- На выбор WinForms или WPF
- База данных на выбор MSSQL Server или Postges
- Система контроля версий GIT. Репозиторий разместить на выбор на GitHub или Bitbucket.
- Среда разработки Microsoft Visual Studio 2022

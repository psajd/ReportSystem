# ReportSystem (Приложение с многослойной архитектурой DAL - BLL - PL)

DAL - база данных SQLite
PL - консоль 
<br />
<br />

## Постановка задачи:

### - **Лабораторная 6. Система обработки сообщений**
    
    ### **Цель**
    
    Реализация многослойной архитектуры.
    
    ### Предметная область
    
    Требуется реализовать систему обработки входящих сообщений и представление агрегированного отчёта с подробной статистикой о полученных сообщениях в рамках заданного периода. В систему поступают сообщения из различных источников - SMS сообщения, сообщения из мессенджеров, электронная почта. Сотрудник входит в систему используя свой логин и пароль и запрашивает из системы сообщения с подконтрольных ему источников (Рабочая почта, телефон и прочие) для дальнейшей работы с ними. Сотрудник отвечает на входящие сообщения и завершает работу. В конце рабочего дня руководитель формирует отчёт о проделанной работе своих сотрудников.
    
    ### **Acceptance Criteria:**
    
    - Реализовать аутентификацию и авторизацию сотрудников
    - Реализовать необходимые сущности и предусмотреть возможность их расширения в дальнейшем (Например, появление новых источников сообщений)
    - Реализовать иерархическую структуру подразделения и доступов к ним. Т.е. доступ до конкретной почты есть у конкретного набора сотрудников. Отчет по подразделению доступен только руководителям.
    - Отчёт должен быть [иммутабельным](https://ru.wikipedia.org/wiki/%D0%9D%D0%B5%D0%B8%D0%B7%D0%BC%D0%B5%D0%BD%D1%8F%D0%B5%D0%BC%D1%8B%D0%B9_%D0%BE%D0%B1%D1%8A%D0%B5%D0%BA%D1%82). Т.е. даже есть объект по которому был построен отчёт изменится, сам отчёт от этого не должен
    - Создать пользовательский интерфейс (Интерактивное меню в консоли)(За реализацию полноценного UI предусмотрены дополнительные баллы)
    - Покрыть UnitTest’ами логику приложения (Application слой)
    - Возможность конфигурации приложение без изменения кода (добавление новых сотрудников и назначение подчинённых, добавление источников сообщений)
    - Система должна уметь сохранять и восстанавливать своё состояние после перезапуска.
    
    ### Сущности
    
    - Сотрудник. У сотрудника может быть руководитель либо подчиненные.
    - Сообщение (Под каждый источник и общая базовая модель)
    - Источник сообщений (Телефон, электронная почта, мессенджер)
    - Учётная запись (Может быть закреплена как за источником сообщений, так и за сотрудником)
    - Отчёт
    
    **Сообщение** может находится в одном из нескольких состояний:
    
    - Новое (Сообщение поступило на устройство, но ещё не было получено системой)
    - Полученное (Сообщение было загружено с устройства в систему)
    - Обработанное (Сообщение обработано сотрудником)
    
    Система должна поддерживать следующие сценарии работы:
    
    Сотрудник входит в систему, выбирает пункт меню получения сообщений. После загрузки сообщений в систему сотрудник может в течение продолжительного времени обрабатывать сообщения (отвечать на них, просто помечать прочитанными и т.д.). В конце работы выбирает пункт меню “Завершение сеанса”.
    
    Начальник входит в систему, выбирает пункт меню работы с отчётами. Использует поиск по дате чтобы найти уже созданные отчёты. Открывает конкретные отчёты и смотрит информацию в разрезе по устройствам, по сотрудникам, статистику (кол-во сообщений всего и т.д.). После ознакомления создаёт новый отчёт за сегодня и в конце работы завершает свою смену.
    
    **Отчёт** должен содержать в произвольном формате статистическую информацию
    
    Кол-во сообщений обработанных его подчиненными
    
    Кол-во сообщений полученных на конкретное устройство
    
    Статистика по общему кол-ву сообщений в течение запрошенного интервала (например за сутки/смену и т.д.)
    
    ### Детали реализации
    
    Для этой лабораторной необходимо использовать классическую трехслойную архитектуру.
    
    **Presentation layer (уровень представления)**: это тот уровень, с которым непосредственно взаимодействует пользователь. Этот уровень включает компоненты пользовательского интерфейса, механизм получения ввода от пользователя. Применительно к данному проекту на этом уровне расположены представления и все те компоненты, который составляют пользовательский интерфейс (если вы делаете полноценный UI), а также модели представлений, запросы и т.д.
    
    **Business layer (уровень бизнес-логики)**: содержит набор компонентов, которые отвечают за обработку полученных от уровня представлений данных, реализует всю необходимую логику приложения, все вычисления, передает уровню представления результат обработки.
    
    **Data Access layer (уровень доступа к данным)**: хранит модели, описывающие используемые сущности, также здесь размещаются специфичные классы для работы с конфигурациями, например, источники сообщений, пользователи и т.д.

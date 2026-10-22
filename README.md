# GitLab — каталог файлов журнала

Студент: Бойков К.Д., группа 714-1  
Вариант: 2 «Каталог файлов журнала»

## Назначение

Администратор оценивает объём файлов журналов перед копированием.
Программа работает с подготовленным в коде списком метаданных
(Name, SizeKb, Extension): не ищет файлы на диске, ничего не копирует
и не удаляет.

## Функции

- **Функция A** (ветка `feature/log-filter`): `Selection.Apply` оставляет
  только записи с `Extension == "log"` (с учётом регистра, `LOG` не
  подходит), файлы нулевого размера сохраняются, порядок исходный.
  Формат строки: `{Name}.{Extension}`.
- **Функция B** (ветка `feature/size-summary`): `Summary.Build` складывает
  SizeKb переданных записей и возвращает `SumKb: {сумма}`.
  Формат строки: `{Name}; size={SizeKb}`.

В `main` программа сначала отбирает записи функцией A, затем выводит их
и считает сводку B **по выбранным записям**, а не по всему каталогу.
Поэтому в `main` для основного набора `SumKb: 200`, а в отдельной ветке B
`SumKb: 220`.

## Конфликт при слиянии

Обе ветки заменили одну и ту же исходную строку `return item.Name;`
в `Formatter.cs`: A — на `item.Name + "." + item.Extension`,
B — на `item.Name + "; size=" + item.SizeKb`. При втором слиянии Git
не смог выбрать одну из версий и остановился с конфликтом.

Конфликт разрешён вручную одной строкой, объединяющей оба дополнения:

```csharp
return item.Name + "." + item.Extension + "; size=" + item.SizeKb;
```

Выбор только верхней версии (HEAD) потерял бы размер файла, только
нижней (feature/size-summary) — расширение в имени.

## Запуск

```
dotnet build
dotnet run
dotnet run -- empty
dotnet run -- zero
dotnet run -- upper
dotnet run -- custom
```

## Результаты проверок в main

| Команда | Входные данные | Ожидаемый вывод | Фактический вывод |
|---|---|---|---|
| `dotnet run` | audit/120/log, notes/20/txt, trace/80/log, empty/0/log | audit.log; size=120, trace.log; size=80, empty.log; size=0, SumKb: 200 | совпадает |
| `dotnet run -- empty` | пустой массив | SumKb: 0 | совпадает |
| `dotnet run -- zero` | zero/0/log | zero.log; size=0, SumKb: 0 | совпадает |
| `dotnet run -- upper` | x/10/LOG | только SumKb: 0 | совпадает |
| `dotnet run -- custom` | system/50/log, config/5/ini, app/300/log, backup/7/Log | system.log; size=50, app.log; size=300, SumKb: 350 | совпадает |

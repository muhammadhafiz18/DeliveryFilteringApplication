# Приложение Фильтрации Заказов Доставки

## Обзор
Это консольное приложение, которое фильтрует заказы на доставку на основе количества запросов в определенном районе Ташкента и времени запроса. Оно обрабатывает заказы из файла JSON, проверяет ввод пользователя и выводит отфильтрованные результаты в другой файл JSON.

## Функции
- Загрузка заказов из файла JSON.
- Фильтрация заказов на основе указанного района и времени первой доставки.
- Ведение журнала всех операций и ошибок в файл журнала.
- Проверка ввода пользователя для района и времени доставки.

## Начало работы

### Предварительные требования
- .NET 8.0 или выше
- Файл JSON с заказами в указанном формате (см. `orders.json`).

### Установка
1. Клонировать репозиторий:
   ```bash
   git clone https://github.com/muhammadhafiz18/DeliveryOrderFilter.git
   cd DeliveryOrderFilter
  ```
2. Запустите приложение:
```bash
dotnet run
```

### Использование
- Введите название района (например, yashnabad), когда будет предложено.
- Введите время первой доставки в формате yyyy-MM-ddTHH:mm:ss (например, 2023-10-22T15:30:00).

### Вывод
Отфильтрованные заказы будут сохранены в `filtered_orders.json`, а записи журнала будут записаны в `logs.csv`.

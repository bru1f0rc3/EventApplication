# EventApplication

## 📝 Описание

EventApplication — это desktop-приложение для управления мероприятиями, разработанное на платформе .NET. Приложение позволяет организовывать, планировать и отслеживать различные события, предоставляя удобный интерфейс для работы с базой данных мероприятий.

## 🚀 Стек технологий

- **Язык программирования:** C# 100%
- **Фреймворк:** .NET Framework / .NET Core
- **UI:** Windows Forms / WPF
- **База данных:** SQL Server / SQLite
- **IDE:** Visual Studio

## 📋 Требования

- Visual Studio 2019 или выше
- .NET Framework 4.7.2+ или .NET 6.0+
- Windows 10/11
- SQL Server (опционально, в зависимости от конфигурации)

## ⚙️ Установка и запуск

### Клонирование репозитория

```bash
git clone https://github.com/bru1f0rc3/EventApplication.git
cd EventApplication
```

### Открытие проекта

1. Откройте файл `EventApplication.sln` в Visual Studio
2. Восстановите NuGet-пакеты (автоматически при первой сборке)
3. Постройте решение: `Build > Build Solution` или `Ctrl+Shift+B`

### Запуск приложения

- Нажмите `F5` для запуска в режиме отладки
- Или `Ctrl+F5` для запуска без отладки

Альтернативно, через командную строку:

```bash
cd EventApplication
dotnet run
```

## 🧪 Тестирование

### Запуск тестов

Если в проекте присутствуют unit-тесты:

```bash
dotnet test
```

Или через Visual Studio:
- Откройте `Test Explorer` (`Test > Test Explorer`)
- Нажмите `Run All` для запуска всех тестов

### Ручное тестирование

1. Запустите приложение
2. Проверьте основные функции:
   - Создание нового мероприятия
   - Редактирование существующих событий
   - Удаление мероприятий
   - Поиск и фильтрация
   - Экспорт данных

## 📁 Структура проекта

```
EventApplication/
├── EventApplication/          # Основной проект приложения
│   ├── Forms/                # Формы пользовательского интерфейса
│   ├── Models/               # Модели данных
│   ├── Services/             # Бизнес-логика
│   └── Resources/            # Ресурсы (изображения, строки)
├── EventApplication.sln      # Файл решения Visual Studio
├── .gitattributes
├── .gitignore
└── README.md
```

## 🔧 Конфигурация

Настройки приложения находятся в файле `App.config` или `appsettings.json`. Основные параметры:

- **ConnectionString:** строка подключения к базе данных
- **LogLevel:** уровень логирования
- **Theme:** тема оформления интерфейса

## 🤝 Вклад в проект

Приветствуются любые предложения по улучшению проекта:

1. Форкните репозиторий
2. Создайте ветку для новой функции (`git checkout -b feature/AmazingFeature`)
3. Зафиксируйте изменения (`git commit -m 'Add some AmazingFeature'`)
4. Отправьте в ветку (`git push origin feature/AmazingFeature`)
5. Откройте Pull Request

## 📄 Лицензия

Этот проект распространяется под лицензией MIT License.

Copyright (c) 2024 bru1f0rc3

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

## 📞 Контакты

- GitHub: [@bru1f0rc3](https://github.com/bru1f0rc3)
- Репозиторий: [EventApplication](https://github.com/bru1f0rc3/EventApplication)

---

⭐ Если проект оказался полезным, поставьте звезду!

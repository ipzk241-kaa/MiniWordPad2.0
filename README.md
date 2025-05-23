# miniWordPad

Легка у використанні Windows Forms програма для редагування, перегляду та збереження Markdown, RTF та TXT документів.

![image](https://github.com/user-attachments/assets/c67c0cab-e6f3-4457-88bc-3c4a6dceca02)

---

## ✅ Вимоги для запуску проєкту

- **.NET Framework 4.7.2** або вище
- **Windows OS**
- **Visual Studio 2019/2022** (рекомендовано)
- Пакети NuGet:
  - *Markdig* (для рендерингу Markdown у HTML)

---

## ⚙️ Налаштування та запуск

1. **Клонувати репозиторій** або завантажити ZIP:
   ```bash
   git clone https://github.com/ipzk241-kaa/MiniWordPad2.0.git
   ```

2. **Відкрити проєкт у Visual Studio**:
   - Відкрити `.sln` файл

3. **Перевірити залежності**:
   - Якщо потрібно — встановити Markdig через NuGet Package Manager

4. **Запустити проєкт** (`F5`)

---

##  Особливості програми

- 📝 **Редагування файлів** `.txt`, `.rtf`, `.md`
- 📂 **Відкриття та збереження** документів
- 🎨 **Зміна тем** інтерфейсу: світла, темна, чорна, кастомна
- 🌐 **Markdown попередній перегляд** у вікні WebBrowser
-  **Гнучкий інтерфейс**: перетягування, ресайз, закриття
-  **Збереження змін** та перевірка на Unsaved стан
-  **Логічна архітектура** з чітким розділенням відповідальностей

---

## 🧠 Шаблони проєктування (Design Patterns)

У проєкті присутні наступні шаблони:

| Патерн          | Опис |
|-----------------|------|
| **Strategy**     | Для тем оформлення: `IThemeStrategy`, реалізації: `LightTheme`, `DarkTheme`, `CustomTheme`. |
| **Command**      | Для рендерингу Markdown через команди: `MarkdownPreviewCommand`. |
| **Bridge/Adapter** | Використання інтерфейсів `IMarkdownSource` / `IMarkdownTarget` для взаємодії між UI і логікою рендерингу. |
| **Facade**       | Головне вінко `MainForm` містить простий інтерфейс і делегує всю логіку сервісним класам (`DocumentManager`, `ThemeManager`, `MarkdownPreviewLauncher`)|
---

## 🧭 Принципи програмування (SOLID & інші)

Під час реалізації проєкту дотримано наступних принципів:

| Принцип        | Приклад реалізації |
|----------------|--------------------|
| **S (Single Responsibility)** | `DocumentManager`, `ThemeManager`, `MarkdownRenderer` — окремі класи для кожної відповідальності. |
| **O (Open/Closed)**           | `IThemeStrategy` дозволяє додавати нові теми без змін існуючих класів. |
| **L (Liskov Substitution)**   | Усі теми реалізують інтерфейс `IThemeStrategy` і можуть підставлятися одна замість іншої. |
| **I (Interface Segregation)** | Вузькі інтерфейси `IMarkdownSource`, `IMarkdownTarget`, `IMarkdownParser` |
| **D (Dependency Inversion)**  | `MarkdownPreviewCommand` залежить від абстракцій, а не конкретних класів. |
---

### DRY (Don't repeat yourself)
- Доблювання коду зменшенно завдяки розділенню функціонала на окремі класи що є частиною шаблону `Фасад`. Таким чином кожен сервіс відповідає за свою частину і не дублюється.

### KISS (Keep it simple, stupid)
- Дизайн простий, класи мають чіткі ролі, а інтерфейс містить лише базову частину для роботи з .rtf і .md файлами.

### YAGNI (You aren't gonna need it)
- Реалізовано лише основні функції (наприклад, базове форматування тексту, збереження/відкриття файлів), проте все ж таки є функція зміни теми програми яка скоріше за все зайва :D.
---

## 🔧 Техніки рефакторингу (Refactoring Techniques)

| Техніка                  | Приклад |
|--------------------------|---------|
| **Extract Class**         | Винесено теми з `MainForm` у `ThemeManager` і стратегії |
| **Extract Method**        | Логіка збереження винесена з кнопки в `DocumentManager` |
| **Replace Conditional with Polymorphism** | Стратегії тем заміняють умовні конструкції |
| **Encapsulate Field**     | Всі поля зроблені `private`, доступ через властивості |
| **Move Method**           | Логіку рендерингу Markdown перенесено у `MarkdownRenderer` |
---

## 📁 Структура проєкту

![image](https://github.com/user-attachments/assets/50b6d155-3479-4761-9a3b-7f037ab8d733)

---

## Скріншоти

![image](https://github.com/user-attachments/assets/c14d0742-8ea2-4cbb-ace9-5e6fc63ce349)

![image](https://github.com/user-attachments/assets/62dd0492-b0d5-41f6-9edc-d38568cc59c3)

![image](https://github.com/user-attachments/assets/5fe07520-8f12-40ea-9a52-183ea3a3fec9)

---
## 📌 Автор

**miniWordPad2.0** — лабораторна робота 6.

Розробив студент ІПЗк-24-1 Кухар Артем Андрійович.

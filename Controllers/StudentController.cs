using WtLab3.Models;
using WtLab3.Views;

namespace WtLab3.Controllers;

public class StudentController
{
    private readonly List<Student> students;
    private readonly StudentView view;

    public StudentController()
    {
        students = new List<Student>
        {
            new Student { Id = 1, FullName = "Иванов Иван Иванович",     Group = "ПИ-21", AverageGrade = 4.5, EnrollmentYear = 2021 },
            new Student { Id = 2, FullName = "Петрова Анна Сергеевна",   Group = "ПИ-21", AverageGrade = 4.8, EnrollmentYear = 2021 },
            new Student { Id = 3, FullName = "Смирнов Дмитрий Олегович", Group = "ПИ-22", AverageGrade = 4.2, EnrollmentYear = 2022 },
            new Student { Id = 4, FullName = "Кузнецова Мария Игоревна", Group = "ПИ-22", AverageGrade = 4.9, EnrollmentYear = 2022 },
            new Student { Id = 5, FullName = "Попов Артём Владимирович", Group = "ПИ-23", AverageGrade = 3.8, EnrollmentYear = 2023 }
        };
        view = new StudentView();
    }

    // ==== Базовые операции ====

    public void Index()
    {
        view.ShowStudents(students);
    }

    public void Show(int id)
    {
        var s = students.FirstOrDefault(x => x.Id == id);
        if (s == null)
        {
            view.ShowMessage("Студент не найден.");
            return;
        }
        view.ShowStudent(s);
    }

    public void Add(Student s)
    {
        students.Add(s);
        view.ShowMessage("Студент успешно добавлен.");
    }

    public void Delete(int id)
    {
        var s = students.FirstOrDefault(x => x.Id == id);
        if (s == null)
        {
            view.ShowMessage("Студент не найден.");
            return;
        }
        students.Remove(s);
        view.ShowMessage("Студент успешно удалён.");
    }

    // ==== Дополнительная операция: поиск по ФИО ====

    public void Search(string text)
    {
        var result = students
            .Where(s => s.FullName.Contains(text, StringComparison.OrdinalIgnoreCase))
            .ToList();
        view.ShowStudents(result);
    }

    // ==== Меню ====

    public void Run()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("=== МЕНЮ ===");
            Console.WriteLine("1. Показать всех студентов");
            Console.WriteLine("2. Найти студента по ID");
            Console.WriteLine("3. Добавить студента");
            Console.WriteLine("4. Удалить студента");
            Console.WriteLine("5. Поиск по ФИО");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите действие: ");

            var command = Console.ReadLine();

            switch (command)
            {
                case "1": Index(); break;
                case "2": ShowByIdInput(); break;
                case "3": AddByInput(); break;
                case "4": DeleteByIdInput(); break;
                case "5": SearchByInput(); break;
                case "0":
                    view.ShowMessage("До свидания!");
                    return;
                default:
                    view.ShowMessage("Неизвестная команда.");
                    break;
            }
        }
    }

    // ==== Обработка пользовательского ввода ====

    private void ShowByIdInput()
    {
        Console.Write("Введите ID студента: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            view.ShowMessage("Некорректный ID.");
            return;
        }
        Show(id);
    }

    private void DeleteByIdInput()
    {
        Console.Write("Введите ID студента для удаления: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            view.ShowMessage("Некорректный ID.");
            return;
        }
        Delete(id);
    }

    private void AddByInput()
    {
        Console.Write("Введите ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            view.ShowMessage("Некорректный ID.");
            return;
        }

        Console.Write("Введите ФИО: ");
        var fullName = Console.ReadLine() ?? "";

        Console.Write("Введите группу: ");
        var group = Console.ReadLine() ?? "";

        Console.Write("Введите средний балл: ");
        if (!double.TryParse(Console.ReadLine(), out double avg))
        {
            view.ShowMessage("Некорректный средний балл.");
            return;
        }

        Console.Write("Введите год поступления: ");
        if (!int.TryParse(Console.ReadLine(), out int year))
        {
            view.ShowMessage("Некорректный год.");
            return;
        }

        Add(new Student
        {
            Id = id,
            FullName = fullName,
            Group = group,
            AverageGrade = avg,
            EnrollmentYear = year
        });
    }

    private void SearchByInput()
    {
        Console.Write("Введите текст для поиска по ФИО: ");
        var text = Console.ReadLine() ?? "";
        Search(text);
    }
}
using WtLab3.Models;

namespace WtLab3.Views;

public class StudentView
{
    public void ShowStudents(List<Student> students)
    {
        Console.WriteLine("=== СПИСОК СТУДЕНТОВ ===");
        if (students.Count == 0)
        {
            Console.WriteLine("(пусто)");
            return;
        }

        foreach (var s in students)
        {
            Console.WriteLine(
                $"{s.Id}. {s.FullName} | {s.Group} | " +
                $"Ср. балл: {s.AverageGrade:F2} | Год: {s.EnrollmentYear}");
        }
    }

    public void ShowStudent(Student s)
    {
        Console.WriteLine("=== СТУДЕНТ ===");
        Console.WriteLine($"ID: {s.Id}");
        Console.WriteLine($"ФИО: {s.FullName}");
        Console.WriteLine($"Группа: {s.Group}");
        Console.WriteLine($"Средний балл: {s.AverageGrade:F2}");
        Console.WriteLine($"Год поступления: {s.EnrollmentYear}");
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine($">>> {message}");
    }
}
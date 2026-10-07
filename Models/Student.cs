namespace WtLab3.Models;

public class Student
{
    public int Id { get; set; }
    public string FullName { get; set; } = "";
    public string Group { get; set; } = "";
    public double AverageGrade { get; set; }
    public int EnrollmentYear { get; set; }
}
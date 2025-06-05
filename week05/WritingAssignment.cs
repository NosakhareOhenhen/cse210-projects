// WritingAssignment.cs
public class WritingAssignment : Assignment
{
    // private member variable
    private string _title;

    // Constructor
    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        _title = title;
    }

    // Method to get writing information
    public string GetWritingInformation()
    {
        return $"{_title} by {GetStudentName()}";
    }
}
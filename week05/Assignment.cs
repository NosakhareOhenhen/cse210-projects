// Assignment.cs
public class Assignment
{
    // Private variables
    private string _studentName;
    private string _topic;

    // Constructor
    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    // Method to return summary
    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }

    // Protected getter for student name to allow derived classes to access it
    protected string GetStudentName()
    {
        return _studentName;
    }
}
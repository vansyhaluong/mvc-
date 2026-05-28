namespace mvc3.Models
{
    public class StudentService
    {
        private List<Student> students = new List<Student>
        {
            new Student{Id=1,Name="Alice",Age=20},
            new Student{Id=2,Name="Bob",Age=22},
            new Student{Id=3,Name="Charlie",Age=21}
        };
        public List<Student> GetAllStudents()
        {
            return students;
        }
        public void addStudent(Student student)
        {
            students.Add(student);
        }
        public void removeStudent(int id)
        {
            var student=students.FirstOrDefault(x=>x.Id==id);
            if(student!=null)
            {
                students.Remove(student);
            }
        }
        public Student? GetStudentById(int id)
        {
            return students.FirstOrDefault(x=>x.Id==id);
        }
        public void updateStudent(Student student)
        {
            var existingStudent=students.FirstOrDefault(x=>x.Id==student.Id);
            if(existingStudent!=null)
            {
                existingStudent.Name=student.Name;
                existingStudent.Age=student.Age;
            }
        }
    }
}

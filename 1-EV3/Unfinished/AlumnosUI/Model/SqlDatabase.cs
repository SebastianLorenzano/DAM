﻿
namespace Model
{
    public class SqlDatabase : IDatabase
    {
        private static SqlDatabase _database = new();

        public static SqlDatabase Instance => _database;
        //public int StudentCount => _students.Count;

        public long AddStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public long GetIdWithStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public Student? GetStudentAt(int index)
        {
            throw new NotImplementedException();
        }

        public Student? GetStudentWithId(long id)
        {
            throw new NotImplementedException();
        }

        public void RemoveStudent(long id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateStudent(long id, Student student)
        {
            throw new NotImplementedException();
        }
    }
}

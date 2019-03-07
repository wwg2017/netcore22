using ABaseCore;
using AModel;
using BaseCore;
using IARepository;
using IAService;
using Model;
using Repository;
using System;

namespace Service
{
    public class StudentService: IStudentService
    {
        public IStudentRepository stRetory = null;
        public StudentService()
        {
            stRetory = new StudentRepository();
        }
        public int Insert(Student model)
        {
            return stRetory.Insert(model);
        }
    }
}

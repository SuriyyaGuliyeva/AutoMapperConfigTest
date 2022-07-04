using AutoMapper;
using System;

namespace AutoMapperConfiguration
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee
            {
                Name = "Qabil",
                Salary = 2200,
                Address = "Baku",
                Department = "IT"
            };

            var mapper = InitializeAutomapper();
            var empDTO = mapper.Map<EmployeeDTO>(emp);

            Console.WriteLine("Name: " + empDTO.Fullname + ", Salary: " + empDTO.Salary + ", Department: " + empDTO.Department);
            Console.ReadLine();
        }

        static Mapper InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDTO>()
                .ForMember(dest => dest.Fullname, act => act.MapFrom(src => src.Name));
            });

            var mapper = new Mapper(config);
            return mapper;
        }
    }

    public class Employee
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
    }

    public class EmployeeDTO
    {
        public string Fullname { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
    }
}

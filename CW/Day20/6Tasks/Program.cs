using System;
using System.Collections.Generic;
using System.Linq;
using TaskLinqLib;

namespace TaskLinqApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository repository = new Repository();
            var employees = repository.GetEmployees();
            var departments = repository.GetDepartments();


            // 1. Вывести зарплату только менеджеров
            // Вывод - Name,Position, Salary

            //var manager = from repo in employees where repo.Position.Equals("Manager") select new { repo.Position, repo.Name, repo.Salary };
            //foreach (var repo in manager)
            //{
            //    Console.WriteLine("{0}", repo);
            //}


            // 2. Вывести среднюю зарплату по должностям. Сортировка по зарплате
            // Вывод - Position, Salary
            //var salary = from repo in employees orderby repo.Salary group repo by new { repo.Position } into gr select new { D = gr.Key.Position, Salary = gr.Average(n => n.Salary) };
            //foreach (var repo in salary)
            //{
            //    Console.WriteLine("{0}", repo);
            //}

            // 3. Вывести информацию о сотруднике с выводом Name его начальника
            // Вывод - Name, Position, ChieName
            //var parent = from repo in employees join depart in departments on repo.ParentId equals depart.Id select new { Name = repo.Name, Pos = repo.Position, ChieName = depart.Name };
            //foreach (var repo in parent)
            //{
            //    Console.WriteLine("{0}      {1}       {2}", repo.Name, repo.Pos, repo.ChieName);
            //}

            // 4. Вывести информацию об отделах  с выводом информации  - кол-во сотрудников в данном отделе, суммарной ЗП отдела
            // Вывод - DepartmentName, CountEmployees, TotalSalary
            //var depInfo = from repo in employees
            //              join depart in departments on repo.DepartmentId equals depart.Id
            //              where (!String.IsNullOrEmpty(depart.Name))
            //              group repo by new { depart.Name } into gr
            //              select new
            //              {
            //                  Name = gr.Key.Name,
            //                  CountEmp = gr.Count(),
            //                  Salary = gr.Sum(n => n.Salary)
            //              };

            //foreach (var repo in depInfo)
            //{
            //    Console.WriteLine("{0} {1} {2}", repo.Name, repo.Salary, repo.CountEmp);
            //}

            // 5. Вывести информацию о сотрудниках отдела, который был создан самым первым
            // Вывод - DepartmentName, DateCreated, Список сотрудников (Name,Position)
            var empInfo = from repo in employees
                          join depart in departments on repo.DepartmentId equals depart.Id
                          where depart.DateCreated.Month < 2 && (!String.IsNullOrEmpty(depart.Name))
                          select new
                          {
                              DateCr = depart.DateCreated,
                              DepName = depart.Name,
                              
                              Emp = repo.Name,
                              EmpPos = repo.Position
                          };

            foreach (var repo in empInfo)
            {
                Console.WriteLine("{0}    {1}    {2}", repo.DepName, repo.DateCr, repo.Emp);
            }

            // 6. Вевести информацию о должностях отделов, которые были созданы в марте и феврале 2010 года
            // Сортировка по наименованию отдела, дате создания, должности
            // Вывод - DepartmentName,DateCreated, Список должностей
            //var posInfo = from repo in employees
            //              join depart in departments on repo.DepartmentId equals depart.Id
            //              where depart.DateCreated.Month == 2 || depart.DateCreated.Month == 3
            //              orderby depart.DateCreated, depart.Name, repo.Position
            //              select new
            //              {
            //                  DepName = depart.Name,
            //                  DC = depart.DateCreated,
            //                  EmpInfo = repo.Position
            //              };
            //foreach (var repo in posInfo)
            //{
            //    Console.WriteLine("{0}   {1}   {2}", repo.DepName, repo.DC, repo.EmpInfo);
            //}

            Console.ReadKey();
        }
    }
}

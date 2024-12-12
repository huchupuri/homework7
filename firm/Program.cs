using firm;
using System;

namespace managers
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee timur = new Employee("Тимур", null, null);
            Employee rashid = new Employee("Рашид", timur, null);
            Employee ilham = new Employee("О Ильхам", timur, null);
            Employee lukas = new Employee("Лукас", rashid, null);
            Employee orkadiy = new Employee("Оркадий", ilham, CaseType.management);
            Employee volodya = new Employee("Володя", orkadiy, CaseType.management);
            Employee ilshat = new Employee("Ильшат", volodya, CaseType.sys);
            Employee ivanych = new Employee("Иваныч", ilshat, CaseType.sys);
            Employee ilya = new Employee("Илья", ivanych, CaseType.sys);
            Employee vitya = new Employee("Витя", ivanych, CaseType.sys);
            Employee zhenya = new Employee("Женя", ivanych, CaseType.sys);
            Employee sergey = new Employee("Сергей", volodya, CaseType.devOps);
            Employee lyaysan = new Employee("Ляйсан", sergey, CaseType.devOps);
            Employee marat = new Employee("Марат", lyaysan, CaseType.devOps);
            Employee dina = new Employee("Дина", lyaysan, CaseType.devOps);
            Employee ildar = new Employee("Ильдар", lyaysan, CaseType.devOps);
            Employee anton = new Employee("Антон", lyaysan, CaseType.devOps);

            Case task1 = new Case("реализовать сеть", CaseType.devOps, timur);
            Case task2 = new Case("разработать что-то", CaseType.sys, zhenya);
            Case task3 = new Case("пораспределять что-то", CaseType.management, anton);

            Check(sergey, task1);
            Check(vitya, task2);
            Check(timur, task3);
        }

        /// <summary>
        /// проверка на возможность передачи задания
        /// </summary>
        static void Check(Employee employee, Case task)
        {
            Console.WriteLine(employee.IsCaseAvailable(task) ?
            $"{employee.name} берет задачу: {task.title}." : $"{employee.name} не берет задачу: {task.title}.");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace firm
{
    public class Employee
    {
        public string name;
        public Employee head;
        public CaseType? possibleCase;

        public Employee(string name, Employee head, CaseType? possibleCase)
        {
            this.name = name;
            this.head = head;
            this.possibleCase = possibleCase;
        }

        public bool IsCaseAvailable(Case task)
        {
            Employee appointer = task.appointer;
            CaseType caseType = task.caseType;
            Employee recipient = this;

            if (!(recipient.possibleCase == caseType)) return false;

            while (recipient != null)
            {
                if (recipient == appointer)
                {
                    return true;
                }
                recipient = recipient.head;
            }
            return false;
        }

    }
}

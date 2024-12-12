using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firm
{
    public enum CaseType { sys, devOps, management }
    public class Case
    {
        public string title;
        public CaseType caseType;
        public Employee appointer;
        public Case(string title, CaseType caseType, Employee appointer)
        {
            this.title = title;
            this.caseType = caseType;
            this.appointer = appointer;
        }
    }
}

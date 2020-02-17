using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign_3
{
    enum BusinessType { Grocery, Bank, Repair, FastFood, DepartmentStore };
    class Business : Property
    {
        string name;
        readonly BusinessType type;
        readonly string yearEstablished;
        uint activeRecruitment;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign_3
{
    enum SchoolType { Elementary, HighSchool, CommunityCollege, University }
    class School
    {
        string name;
        readonly SchoolType type;
        string yearEstablished;
        uint enrolled;
    }
}

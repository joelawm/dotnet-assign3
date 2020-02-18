using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign_3
{
    enum SchoolType { Elementary, HighSchool, CommunityCollege, University }
    class School : Property
    {
        string name;
        readonly SchoolType type;
        string yearEstablished;
        uint enrolled;
        School(uint id, uint x, uint y, uint o, string sa, string c, string st, string z, bool fs,
            string cName, SchoolType ctype, string cYear, uint cEnrolled)
            : base(id, x, y, o, sa, c, st, z, fs)
        {

        }
    }
}

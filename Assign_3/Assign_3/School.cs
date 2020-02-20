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
        public School(uint id, uint x, uint y, uint o, string sa, string c, string st, string z, string fs,
            string cName, SchoolType stype, string sYear, uint sEnrolled)
            : base(id, x, y, o, sa, c, st, z, fs)
        {
            Name = cName;
            type = stype;
            YearEstablished = sYear;
            Enrolled = sEnrolled;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }
        
        public SchoolType Type => type;
        
        public string YearEstablished
        {
            get => yearEstablished;
            set => yearEstablished = value;
        }

        public uint Enrolled
        {
            get => enrolled;
            set => enrolled = value;
        }
    }
}

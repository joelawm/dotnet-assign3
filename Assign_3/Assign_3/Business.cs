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

        public Business(uint id, uint x, uint y, uint o, string sa, string c, string st, string z, string fs, 
            string bName, BusinessType btype, string bYear, uint bActive)
            : base(id, x, y, o, sa, c, st, z, fs)
        {
            Name = bName;
            type = btype;
            yearEstablished = bYear;
            ActiveRecruitment = bActive;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public BusinessType Type => type;

        public string YearEstablished => yearEstablished;

        public uint ActiveRecruitment
        {
            get => activeRecruitment;
            set => activeRecruitment = value;
        }
    }
}

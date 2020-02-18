using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign_3
{
    public class Business : Property
    {
        //variables for class
        private string name;
        private readonly BusinessType _type;
        private readonly string _yearEst;
        private uint activeRecruitment;

        public enum BusinessType { Grocery, Bank, Repair, FastFood, DepartmentStore };

        //creating the residential object
        protected Business(uint id, uint x, uint y, uint o, string sa, string c, string st, string z, bool fs, string name, BusinessType type, string yearEst, uint activeRecuritment) : base(id, x, y, o, sa, c, st, z, fs)
        {
            //readonly
            _type = type;
            _yearEst = yearEst;

            //get/set
            Name = name;
            ActiveRecruitment = activeRecruitment;
        }

        //all the GET/SET methods for The class.
        public string Name
        {
            get => name;
            set => name = value;
        }

        public uint ActiveRecruitment
        {
            get => activeRecruitment;
            set => activeRecruitment = value;
        }
    }
}

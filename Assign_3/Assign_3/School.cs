using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign_3
{
    class School : Property
    {
        private string name;
        private readonly SchoolType _type;
        private string _yearEst;
        private uint enrolled;

        public enum SchoolType { Elementary, HighSchool, CommunityCollege, University };

        //creating the residential object
        protected School(uint id, uint x, uint y, uint o, string sa, string c, string st, string z, bool fs, string name, SchoolType type, string yearEst, uint enrolled) : base(id, x, y, o, sa, c, st, z, fs)
        {
            //readonly
            _type = type;
            _yearEst = yearEst;

            //get/set
            Name = name;            
            Enrolled = enrolled;
        }

        //all the GET/SET methods for The class.
        public string Name
        {
            get => name;
            set => name = value;
        }

        public uint Enrolled
        {
            get => enrolled;
            set => enrolled = value;
        }
    }
}

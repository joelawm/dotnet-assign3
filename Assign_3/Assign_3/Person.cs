using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign_2
{
    //person class
    public class Person : IComparable
    {
        //variables
        private readonly uint _id;
        private readonly DateTime _birthday;

        private string lastName;
        private string firstName;
        private string occupation;
        private List<uint> residencelds = new List<uint>();
        private string fullName;

        //person object for base
        public Person()
        {
            _id = 0;
            LastName = "";
            FirstName = "";
            fullName = "";
            Occupation = "";
            _birthday = DateTime.Now;
            residencelds.Add(0);
        }

        //for creating a person object
        public Person(uint id, DateTime bd, string l, string f, string o, string resId)
        {
            _id = id;
            _birthday = bd;
            LastName = l;
            FirstName = f;
            Occupation = o;
            fullName = FirstName + ", " + LastName;

            // if fail to convert the residence id
            if (Int32.TryParse(resId, out var result))
            {
                residencelds.Add((uint)result);
            }
            else
            {
                throw new ArgumentException("error: fail to convert residence id, please check again!");
            }
        }

        //all the following are get/set methods
        public string LastName
        {
            get => lastName;
            set => lastName = value;
        }

        public string FirstName
        {
            get => firstName;
            set => firstName = value;
        }

        public string Occupation
        {
            get => occupation;
            set => occupation = value;
        }

        public uint[] Residencelds => residencelds.ToArray();

        //add residence id to array
        public void Add(uint id)
        {
            residencelds.Add(id);
        }

        //remove residence id to array
        public void Remove(uint id)
        {
            residencelds.Remove(id);
        }

        public uint Id => _id;

        public DateTime Birthday => _birthday;

        public string FullName => fullName;


        //compare method for person class
        public int CompareTo(object alpha)
        {
            if (alpha == null)
            {
                return 1;
            }

            Person otherO = alpha as Person;
            if (this.Id == otherO.Id)
                return 0;

            return this.fullName.CompareTo(otherO.fullName);
        }

        //toString method to output the different variables
        public override string ToString()
        {
            return $"ID: {_id} Name: {FullName} Date of birth: {_birthday} Occupation: {Occupation}";
        }
    }
}

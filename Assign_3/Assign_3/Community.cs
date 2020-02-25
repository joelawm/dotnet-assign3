using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign_3
{
    //community class
    public class Community : IComparable, IEnumerable
    {
        private readonly uint _id;
        private readonly string _name;

        private SortedSet<Property> props;
        private SortedSet<Person> residents;
        private uint mayorID;
        private uint population;

        //Communaity Object
        public Community()
        {
            _id = 0;
            _name = "";
            Props = null;
            Residents = null;
            MayorID = 0;
        }

        //creating the Community Object
        public Community(uint id, string name, uint mId)
        {
            _id = id;
            _name = name;
            props = new SortedSet<Property>();
            residents = new SortedSet<Person>();
            MayorID = mId;
        }


        //GET/SET methods for community object
        public SortedSet<Property> Props
        {
            get => props;
            set => props = value;
        }

        public SortedSet<Person> Residents
        {
            get => residents;
            set => residents = value;
        }

        //compare residence
        public bool CompareResidenceToJob(string comp1)
        {


            return true;
        }


        //Compareto method
        public int CompareTo(object alpha)
        {
            if (alpha == null)
            {
                return 1;
            }

            Community otherC = alpha as Community;
            return this._name.CompareTo(otherC._name);
        }

        public uint Id => _id;

        public string Name => _name;

        //GET/SEt for mayor
        public uint MayorID
        {
            get => mayorID;
            set => mayorID = value;
        }

        public uint Population => (uint)residents.Count;

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new CommEnum(this);
        }
    }


    public class CommEnum : IEnumerator
    {
        private Community cList;
        private int pos = -1;

        internal CommEnum(Community cList)
        {
            this.cList = cList;
        }

        //Move to the next object
        public bool MoveNext()
        {
            if (pos != cList.Residents.Count)
            {
                pos++;
            }
            return pos < cList.Residents.Count;
        }

        //get the current spot in count
        public object Current
        {
            get
            {
                if (pos == -1 || pos == cList.Residents.Count)
                {
                    throw new InvalidOperationException();
                }

                return pos;
            }
        }

        //reset method to reset the pos
        public void Reset()
        {
            pos = -1;
        }
    }
}

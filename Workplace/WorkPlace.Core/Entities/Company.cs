using System.ComponentModel.Design;
using WorkPlace.Core.Interfaces;

namespace WorkPlace.Core.Entities
{
    public class Company:IEntity
	{
        private static int _count = 1;
        public int CompanyId { get; }
        public string CompanyName { get; set; }
        public Company()
        {
            CompanyId = _count;
            _count++;
        }
        public Company(string name):this()
        {
            CompanyName = name;
        }
       
    }
}


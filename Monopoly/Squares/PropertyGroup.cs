using System.Collections.Generic;

namespace Monopoly.Squares
{
    public class PropertyGroup
    {
        private readonly IList<PropertySquare> _members = new List<PropertySquare>();

        public void AddProperty(PropertySquare s)
        {
            _members.Add(s);
        }

        public IList<PropertySquare> GetMembers()
        {
            return _members;
        }
    }
}

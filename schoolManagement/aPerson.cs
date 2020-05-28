using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace schoolManagement
{
    public abstract class aPerson
    {
        public abstract void ShowDetails(int Id);
        public abstract void Profile(int Id);

        public abstract void Delete(int Id);
    }
}

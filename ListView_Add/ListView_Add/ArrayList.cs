using System.Collections.Generic;

namespace ListView_Add
{
    internal class ArrayList<T> : List<string>
    {
        private object p;

        public ArrayList(object p)
        {
            this.p = p;
        }
    }
}
using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace PrestigeWorldwide
{
    public class StampPositionSorter
    {
        public class SortHeightValues: IComparer
        {
            int IComparer.Compare(Object obj1, Object obj2)
            {
                Stamp stamp1 = (Stamp)obj1;
                Stamp stamp2 = (Stamp)obj2;

                return ((new CaseInsensitiveComparer()).Compare(stamp1.Y, stamp2.Y));
            }
        }
        public class SortWidthValues : IComparer
        {
            int IComparer.Compare(Object obj1, Object obj2)
            {
                Stamp stamp1 = (Stamp)obj1;
                Stamp stamp2 = (Stamp)obj2;

                return ((new CaseInsensitiveComparer()).Compare(stamp1.X, stamp2.X));
            }
        }
    }
}

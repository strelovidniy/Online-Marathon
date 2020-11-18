using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Sprint_06.Task_01
{
    public class CircleOfChildren
    {
        private readonly List<string> children;

        public CircleOfChildren(IEnumerable<string> children)
            => this.children = children.ToList();

        public IEnumerable GetChildrenInOrder(int syllables, int childrenCount = 0)
        {
            if (syllables <= 0)
            {
                yield break;
            }
            
            var deletingCount = children.Count;

            if (childrenCount != 0)
            {
                deletingCount = childrenCount < children.Count ? childrenCount : children.Count;
            }

            var index = 0;

            while (deletingCount > 0)
            {
                index = (--index + syllables) % children.Count;

                yield return children[index];

                children.RemoveAt(index);
                deletingCount--;
            }
        }
    }
}

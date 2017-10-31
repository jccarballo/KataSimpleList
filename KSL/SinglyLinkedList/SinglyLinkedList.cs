using System;
using System.Collections;
using System.Linq;

namespace KataSimpleList.SinglyLinkedList
{
    public class SinglyLinkedList: IEnumerable
    {
        private SLLNode[] _list;

        public SinglyLinkedList()
        {
            _list = new SLLNode[] { };
        }

        public SLLNode Find(string nodeValue)
        {
            return _list.FirstOrDefault(x => x.Value == nodeValue);
        }

        public void Add(string nodeValue)
        {
            int count = _list.Length;

            Array.Resize(ref _list, count + 1);
            _list[count] = new SLLNode { Value = nodeValue };

            if (count > 0)
                _list[count - 1].Next = _list[count];
        }

        public void Delete(SLLNode node)
        {
            if (node == null)
                throw new NullReferenceException();

            if (this.Find(node.Value) == null)
                throw new ArgumentOutOfRangeException();

            _list = _list.Where(x => x != node).ToArray();

            for (int i = 0; i < _list.Length; i++)
            {
                _list[i].Next = (i < _list.Length - 1) ? _list[i + 1] : null;
            }
        }

        public string[] Values()
        {
            return _list.Select(x => x.Value).ToArray();
        }

        public IEnumerator GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}


using System;
using System.Collections;
using System.Linq;

namespace KataSimpleList.BasicList
{
	public class BasicList: IEnumerable
	{
		private BLNode[] _list;
		
		public BasicList()
		{
			_list = new BLNode[] {};
		}
		
		public BLNode Find(string nodeValue)
		{
            return _list.FirstOrDefault(x => x.Value == nodeValue);
		}
		
		public void Add(string nodeValue)
		{
            Array.Resize(ref _list, _list.Length + 1);
            _list[_list.Length - 1] = new BLNode { Value = nodeValue };
        }

		public void Delete (BLNode node)
		{
			if (node == null)
				throw new NullReferenceException();
			
			if (this.Find(node.Value) == null) 
				throw new ArgumentOutOfRangeException();

            _list = _list.Where(x => x != node).ToArray();
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


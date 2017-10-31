using System;
using NUnit.Framework;
using KataSimpleList.BasicList;

namespace KataSimpleListTests
{
	[TestFixture]
    [Category("BasicListTest")]
    public class BasicListTest
	{
		[Test]
		public void Find_ShouldReturnNull_WhenListIsEmpty()
		{
			var list = new BasicList();
			
			Assert.IsNull(list.Find("fred"));
		}
		
		[Test]
		public void Find_ShouldReturnNodeValue_WhenNodeExists()
		{
            var list = new BasicList { "fred" };

			Assert.AreEqual("fred", list.Find("fred").Value);
		}

        [Test]
        public void Add_ShouldAddNodeToList()
        {
            var list = new BasicList();
            list.Add("fred");
            Assert.AreEqual("fred", list.Find("fred").Value);
        }
		
		[Test]
		public void Values_ShouldReturnAllNodeValues()
		{
            var list = new BasicList { "fred", "wilma" };
			
			Assert.AreEqual(new[] {"fred", "wilma"}, list.Values());
		}
			
		[Test]
		public void Delete_ThrowNullReferenceException_WhenNodeParameterIsNull()
		{
            var list = new BasicList { "fred", "wilma", "betty", "barney" };

            Assert.Throws<NullReferenceException>(() => list.Delete(null));
		}

        [Test]
        public void Delete_ThrowArgumentOutOfRangeException_WhenNodeParameterNotExistsInList()
        {
            var list = new BasicList { "fred", "wilma", "betty", "barney" };

            Assert.Throws<ArgumentOutOfRangeException>(() => list.Delete(new BLNode { Value = "peter" }));
        }

        [Test]
		public void Delete_ShowDeleteNode_WhenListContainsNodeValue()
		{
            var list = new BasicList { "fred", "wilma", "betty", "barney" };

            list.Delete(list.Find("barney"));

			Assert.AreEqual(new[] { "fred", "wilma", "betty" }, list.Values());
		}
		
			
		[Test]
		public void Delete_ShowDeleteAllNodes_WhenAllNodesAreDeleted()
		{
            var list = new BasicList { "fred", "wilma", "betty", "barney" };

            list.Delete(list.Find("wilma"));
            list.Delete(list.Find("barney"));
            list.Delete(list.Find("fred"));
            list.Delete(list.Find("betty"));

            Assert.AreEqual(new string[] { }, list.Values());
		}
	}
}


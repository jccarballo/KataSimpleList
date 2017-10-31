using System;
using NUnit.Framework;
using KataSimpleList.SinglyLinkedList;

namespace KataSimpleListTests
{
	[TestFixture]
    [Category("SinglyLinkedListTest")]
    public class SinglyLinkedListTest
	{
        [Test]
        public void Find_ShouldReturnNull_WhenListIsEmpty()
        {
            var list = new SinglyLinkedList();

            Assert.IsNull(list.Find("fred"));
        }

        [Test]
        public void Find_ShouldReturnNodeValue_WhenNodeExists()
        {
            var list = new SinglyLinkedList { "fred" };

            Assert.AreEqual("fred", list.Find("fred").Value);
        }

        [Test]
        public void Add_ShouldAddNodeToList()
        {
            var list = new SinglyLinkedList();
            list.Add("fred");
            Assert.AreEqual("fred", list.Find("fred").Value);
        }

        [Test]
        public void Values_ShouldReturnAllNodeValues()
        {
            var list = new SinglyLinkedList { "fred", "wilma" };

            Assert.AreEqual(new[] { "fred", "wilma" }, list.Values());
        }

        [Test]
        public void Delete_ThrowNullReferenceException_WhenNodeParameterIsNull()
        {
            var list = new SinglyLinkedList { "fred", "wilma", "betty", "barney" };

            Assert.Throws<NullReferenceException>(() => list.Delete(null));
        }

        [Test]
        public void Delete_ThrowArgumentOutOfRangeException_WhenNodeParameterNotExistsInList()
        {
            var list = new SinglyLinkedList { "fred", "wilma", "betty", "barney" };

            Assert.Throws<ArgumentOutOfRangeException>(() => list.Delete(new SLLNode { Value = "peter" }));
        }

        [Test]
        public void Delete_ShowDeleteNode_WhenListContainsNodeValue()
        {
            var list = new SinglyLinkedList { "fred", "wilma", "betty", "barney" };

            list.Delete(list.Find("barney"));

            Assert.AreEqual(new[] { "fred", "wilma", "betty" }, list.Values());
        }


        [Test]
        public void Delete_ShowDeleteAllNodes_WhenAllNodesAreDeleted()
        {
            var list = new SinglyLinkedList { "fred", "wilma", "betty", "barney" };

            list.Delete(list.Find("wilma"));
            list.Delete(list.Find("barney"));
            list.Delete(list.Find("fred"));
            list.Delete(list.Find("betty"));

            Assert.AreEqual(new string[] { }, list.Values());
        }

        // ----------

        [Test]
        public void NodeIsNotLinked_WhenListOnlyContainsOneNode()
        {
            var list = new SinglyLinkedList { "fred" };

            Assert.IsNull(list.Find("fred").Next);
        }

        [Test]
        public void NodeIsNotLinked_WhenNodePositionIsLast()
        {
            var list = new SinglyLinkedList { "fred", "wilma" };

            Assert.IsNull(list.Find("wilma").Next);
        }

        [Test]
        public void FirstNodeIsLinkedToSecondNode()
        {
            var list = new SinglyLinkedList { "fred", "wilma" };

            Assert.AreEqual("wilma", list.Find("fred").Next.Value);
        }

        [Test]
        public void NodeFredLinkedWithNodeBetty_AfterDeleteNodeWilma()
        {
            var list = new SinglyLinkedList { "fred", "wilma", "betty" };

            list.Delete(list.Find("wilma"));

            Assert.AreEqual("betty", list.Find("fred").Next.Value);
        }

        [Test]
        public void LinkedNotAltered_AfterDeleteNodeFred()
        {
            var list = new SinglyLinkedList { "fred", "wilma", "betty" };

            list.Delete(list.Find("fred"));

            Assert.AreEqual("betty", list.Find("wilma").Next.Value);
        }

        [Test]
        public void NodeWilmaLinkedToNull_AfterDeleteNodeBetty()
        {
            var list = new SinglyLinkedList { "fred", "wilma", "betty" };

            list.Delete(list.Find("betty"));

            Assert.AreEqual("wilma", list.Find("fred").Next.Value);
            Assert.IsNull(list.Find("wilma").Next);
        }
    }
}


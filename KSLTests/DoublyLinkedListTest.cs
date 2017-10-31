using System;
using NUnit.Framework;
using KataSimpleList.DoublyLinkedList;
using KataSimpleList;

namespace KataSimpleListTests
{
	[TestFixture]
    [Category("DoublyLinkedListTest")]
    public class DoublyLinkedListTest
    {
        [Test]
        public void Find_ShouldReturnNull_WhenListIsEmpty()
        {
            var list = new DoublyLinkedList();

            Assert.IsNull(list.Find("fred"));
        }

        [Test]
        public void Find_ShouldReturnNodeValue_WhenNodeExists()
        {
            var list = new DoublyLinkedList { "fred" };

            Assert.AreEqual("fred", list.Find("fred").Value);
        }

        [Test]
        public void Add_ShouldAddNodeToList()
        {
            var list = new DoublyLinkedList();
            list.Add("fred");
            Assert.AreEqual("fred", list.Find("fred").Value);
        }

        [Test]
        public void Values_ShouldReturnAllNodeValues()
        {
            var list = new DoublyLinkedList { "fred", "wilma" };

            Assert.AreEqual(new[] { "fred", "wilma" }, list.Values());
        }

        [Test]
        public void Delete_ThrowNullReferenceException_WhenNodeParameterIsNull()
        {
            var list = new DoublyLinkedList { "fred", "wilma", "betty", "barney" };

            Assert.Throws<NullReferenceException>(() => list.Delete(null));
        }

        [Test]
        public void Delete_ThrowArgumentOutOfRangeException_WhenNodeParameterNotExistsInList()
        {
            var list = new DoublyLinkedList { "fred", "wilma", "betty", "barney" };

            Assert.Throws<ArgumentOutOfRangeException>(() => list.Delete(new DLLNode { Value = "peter" }));
        }

        [Test]
        public void Delete_ShowDeleteNode_WhenListContainsNodeValue()
        {
            var list = new DoublyLinkedList { "fred", "wilma", "betty", "barney" };

            list.Delete(list.Find("barney"));

            Assert.AreEqual(new[] { "fred", "wilma", "betty" }, list.Values());
        }

        [Test]
        public void Delete_ShowDeleteAllNodes_WhenAllNodesAreDeleted()
        {
            var list = new DoublyLinkedList { "fred", "wilma", "betty", "barney" };

            list.Delete(list.Find("wilma"));
            list.Delete(list.Find("barney"));
            list.Delete(list.Find("fred"));
            list.Delete(list.Find("betty"));

            Assert.AreEqual(new string[] { }, list.Values());
        }

        // -----

        [Test]
        public void NodeIsNotLinked_WhenListOnlyContainsOneNode()
        {
            var list = new DoublyLinkedList { "fred" };

            Assert.IsNull(list.Find("fred").Next);
            Assert.IsNull(list.Find("fred").Previous);
        }

        [Test]
        public void NodeFredNextLinkedWithNodeWilmaAndPreviousWithoutLinked_AfterAddFredAndWilmaNode()
        {
            var list = new DoublyLinkedList { "fred", "wilma" };

            Assert.IsNotNull(list.Find("fred").Next);
            Assert.AreEqual("wilma", list.Find("fred").Next.Value);
            Assert.IsNull(list.Find("fred").Previous);
        }

        [Test]
        public void NodeWilmaNextWithoutLinkedAndPreviousLinkedWithNodeFred_AfterAddFredAndWilmaNode()
        {
            var list = new DoublyLinkedList { "fred", "wilma" };

            Assert.AreEqual("wilma", list.Find("wilma").Value);
            Assert.IsNull(list.Find("wilma").Next);
            Assert.IsNotNull(list.Find("wilma").Previous);
            Assert.AreEqual("fred", list.Find("wilma").Previous.Value);
        }

        [Test]
        public void NodeFredNextLinkedWithWilmaAndPreviousLinkedIsNull_AfterAddFredWilmaAndBettyNode()
        {
            var list = new DoublyLinkedList { "fred", "wilma", "betty" };

            Assert.AreEqual("wilma", list.Find("fred").Next.Value);
            Assert.IsNull(list.Find("fred").Previous);
        }

        [Test]
        public void NodeWilmaNextLinkedWithBettyAndPreviousLinkedWithFred_AfterAddFredWilmaAndBettyNode()
        {
            var list = new DoublyLinkedList { "fred", "wilma", "betty" };

            Assert.AreEqual("betty", list.Find("wilma").Next.Value);
            Assert.AreEqual("fred", list.Find("wilma").Previous.Value);
        }

        [Test]
        public void NodeBettyNextLinkedIsNullAndPreviousLinkedWithWilma_AfterAddFredWilmaAndBettyNode()
        {
            var list = new DoublyLinkedList { "fred", "wilma", "betty" };

            Assert.IsNull(list.Find("betty").Next);
            Assert.AreEqual("wilma", list.Find("betty").Previous.Value);
        }

        [Test]
        public void NodeFredNextLinkedWithNodeBettyAndPreviousLinkedIsNull_AfterDeleteNodeWilma()
        {
            var list = new DoublyLinkedList { "fred", "wilma", "betty" };

            list.Delete(list.Find("wilma"));

            Assert.AreEqual("betty", list.Find("fred").Next.Value);
            Assert.IsNull(list.Find("fred").Previous);
        }

        [Test]
        public void NodeBettyNextLinkedIsNullAndPreviousLinkedWithNodeFred_AfterDeleteNodeWilma()
        {
            var list = new DoublyLinkedList { "fred", "wilma", "betty" };

            list.Delete(list.Find("wilma"));

            Assert.IsNull(list.Find("betty").Next);
            Assert.AreEqual("fred", list.Find("betty").Previous.Value);
        }

        [Test]
        public void NodeWilmaLinkPreviousIsNullAndBettyDontAlteredLinked_AfterDeleteNodeFred()
        {
            var list = new DoublyLinkedList { "fred", "wilma", "betty" };

            list.Delete(list.Find("fred"));

            Assert.AreEqual("betty", list.Find("wilma").Next.Value);
            Assert.IsNull(list.Find("wilma").Previous);
            Assert.AreEqual("wilma", list.Find("betty").Previous.Value);
            Assert.IsNull(list.Find("betty").Next);
        }

        [Test]
        public void NodeWilmaLinkNextIsNullAndFredDontAlteredLinked_AfterDeleteNodeBetty()
        {
            var list = new DoublyLinkedList { "fred", "wilma", "betty" };

            list.Delete(list.Find("betty"));

            Assert.AreEqual("wilma", list.Find("fred").Next.Value);
            Assert.IsNull(list.Find("fred").Previous);
            Assert.AreEqual("fred", list.Find("wilma").Previous.Value);
            Assert.IsNull(list.Find("wilma").Next);
        }
    }
}


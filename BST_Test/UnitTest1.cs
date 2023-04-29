using BST;

namespace BST_Test
{
    [TestClass]
    public class UnitTest1
    {
        private BinarySearchTree bst;

        [TestInitialize]
        public void SetUp()
        {
            // Executed before each test method.
            // Before each test method, create a BST with some fixed key-values. 
            bst = new BinarySearchTree();
            bst.Add(10, "Value for 10");
            bst.Add(52, "Value for 52");
            bst.Add(5, "Value for 5");
            bst.Add(8, "Value for 8");
            bst.Add(1, "Value for 1");
            bst.Add(40, "Value for 40");
            bst.Add(30, "Value for 30");
            bst.Add(45, "Value for 45");
        }

        [TestMethod]
        public void TestAdd()
        {
            // Create an instance of BinarySearchTree
            BinarySearchTree bsTree = new BinarySearchTree();

            // bsTree must be empty
            Assert.AreEqual(0, bsTree.Size());

            // Add a key-value pair
            bsTree.Add(15, "Value for 15");
            // Size of bsTree must be 1
            Assert.AreEqual(1, bsTree.Size());

            // Add another key-value pair
            bsTree.Add(10, "Value for 10");
            // Size of bsTree must be 2
            Assert.AreEqual(2, bsTree.Size());

            // The added keys must exist.
            Assert.AreEqual("Value for 10", bsTree.Search(10));
            Assert.AreEqual("Value for 15", bsTree.Search(15));
        }

        [TestMethod]
        public void TestInorder()
        {
            List<int> expectedOutput = new List<int> { 1, 5, 8, 10, 30, 40, 45, 52 };
            List<int> actualOutput = bst.InorderWalk();
            CollectionAssert.AreEqual(expectedOutput, actualOutput);

            bst.Add(25, "Value for 25");
            List<int> expectedOutput2 = new List<int> { 1, 5, 8, 10, 25, 30, 40, 45, 52 };
            List<int> actualOutput2 = bst.InorderWalk();
            CollectionAssert.AreEqual(expectedOutput2, actualOutput2);
        }

        [TestMethod]
        public void TestPostorder()
        {
            List<int> expectedOutput = new List<int> { 1, 8, 5, 30, 45, 40, 52, 10 };
            List<int> actualOutput = bst.PostorderWalk();
            CollectionAssert.AreEqual(expectedOutput, actualOutput);

            bst.Add(25, "Value for 25");
            List<int> expectedOutput2 = new List<int> { 1, 8, 5, 25, 30, 45, 40, 52, 10 };
            List<int> actualOutput2 = bst.PostorderWalk();
            CollectionAssert.AreEqual(expectedOutput2, actualOutput2);
        }

        [TestMethod]
        public void TestPreorder()
        {
            List<int> expectedOutput = new List<int> { 10, 5, 1, 8, 52, 40, 30, 45 };
            List<int> actualOutput = bst.PreorderWalk();
            CollectionAssert.AreEqual(expectedOutput, actualOutput);

            bst.Add(25, "Value for 25");
            List<int> expectedOutput2 = new List<int> { 10, 5, 1, 8, 52, 40, 30, 25, 45 };
            List<int> actualOutput2 = bst.PreorderWalk();
            CollectionAssert.AreEqual(expectedOutput2, actualOutput2);
        }

        [TestMethod]
        public void TestSearch()
        {
            /*
            tests for search
            */
            Assert.AreEqual("Value for 40", bst.Search(40));
            Assert.IsFalse((bool)bst.Search(90));
            bst.Add(90, "Value for 90");
            Assert.AreEqual("Value for 90", bst.Search(90));
        }

        [TestMethod]
        public void TestRemove()
        {
            /*
            tests for remove
            */
            bst.Remove(40);
            Assert.AreEqual(7, bst.Size());
            CollectionAssert.AreEqual(new List<int> { 1, 5, 8, 10, 30, 45, 52 }, bst.InorderWalk());
            CollectionAssert.AreEqual(new List<int> { 10, 5, 1, 8, 52, 30, 45 }, bst.PreorderWalk());
        }

        [TestMethod]
        public void TestSmallest()
        {
            /*
            tests for smallest
            */
            Assert.AreEqual(Tuple.Create(1, (object)"Value for 1"), bst.Smallest());
            bst.Add(6, "Value for 6");
            bst.Add(4, "Value for 4");
            bst.Add(0, "Value for 0");
            bst.Add(32, "Value for 32");
            Assert.AreEqual(Tuple.Create(0, (object)"Value for 0"), bst.Smallest());
        }

        [TestMethod]
        public void TestLargest()
        {
            /*
            tests for largest
            */
            Assert.AreEqual(Tuple.Create(52, (object)"Value for 52"), bst.Largest());
            bst.Add(6, "Value for 6");
            bst.Add(54, "Value for 54");
            bst.Add(0, "Value for 0");
            bst.Add(32, "Value for 32");
            Assert.AreEqual(Tuple.Create(54, (object)"Value for 54"), bst.Largest());
        }
    }
}
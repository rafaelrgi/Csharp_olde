using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortArrayManually;

namespace Tests;

[TestClass]
public class SortArrayManuallyTest
{
  [TestMethod]
  public void Test1()
  {
    var numbers = new[] { 0 };
    int[] x = Test.Run(numbers);
    Array.Sort(numbers);
    CollectionAssert.AreEqual(x, numbers);
  }

  [TestMethod]
  public void Test2()
  {
    var numbers = new[] { 1, 2, 3, 4, 5, 0 };
    int[] x = Test.Run(numbers);
    Array.Sort(numbers);
    CollectionAssert.AreEqual(x, numbers);
  }

  [TestMethod]
  public void Test3()
  {
    var numbers = new[] { 11, 22, 33, 44, 55, 66 };
    int[] x = Test.Run(numbers);
    Array.Sort(numbers);
    CollectionAssert.AreEqual(x, numbers);
  }

  [TestMethod]
  public void Test4()
  {
    var numbers = new[] { -1, 1, 1, 1, 1, -9, 9, -90, 9, 1, };
    int[] x = Test.Run(numbers);
    Array.Sort(numbers);
    CollectionAssert.AreEqual(x, numbers);
  }

  [TestMethod]
  public void Test5()
  {
    var numbers = new[] { 1024, 8080, -512, 666, 4, -666, 256, 1 };
    int[] x = Test.Run(numbers);
    Array.Sort(numbers);
    CollectionAssert.AreEqual(x, numbers);
  }

  [TestMethod]
  public void Test6()
  {
    var numbers = new[] { 3, 44, 33, 128, 0, 2, 5, -1, 4, 1, 22, 11, 42, 37 };
    int[] x = Test.Run(numbers);
    Array.Sort(numbers);
    CollectionAssert.AreEqual(x, numbers);
  }
}
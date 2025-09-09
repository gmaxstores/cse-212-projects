using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Create a queue with the following items and priorities: A (1), B (1), C(1), D(1), E(1), F(1)
    //Then compare the result of Peek() method to the expected result to test the enueue and peek methods.
    // Expected Result: A, B, C, D, E, F
    // Defect(s) Found: None
    //summary of tests result:
    //1. created a new person object for A, B, C, D, E and F with their respective turns.
    //2. created an expected result array with the order in which the persons are expected to be returned from the queue.
    //3. called an instance of PriorityQueue and added the persons to the queue using Enqueue method.
    //4. used a for loop to run through the expected result array and in each iteration called Peek method to get all the items from the queue.
    //5. compared the name of the item returned from the queue with the expected result array
    //6. verified that the order of items returned from the queue is same as the order in which they were added to the queue (at the back of the queue).
    public void TestPriorityQueue_1()
    {
        var itemA = new PriorityItem("A", 1);
        var itemB = new PriorityItem("B", 1);
        var itemC = new PriorityItem("C", 1);
        var itemD = new PriorityItem("D", 1);
        var itemE = new PriorityItem("E", 1);
        var itemF = new PriorityItem("F", 1);
        PriorityItem[] expectedResult = [itemA, itemB, itemC, itemD, itemE, itemF];

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(itemA.Value, itemA.Priority);
        priorityQueue.Enqueue(itemB.Value, itemB.Priority);
        priorityQueue.Enqueue(itemC.Value, itemC.Priority);
        priorityQueue.Enqueue(itemD.Value, itemD.Priority);
        priorityQueue.Enqueue(itemE.Value, itemE.Priority);
        priorityQueue.Enqueue(itemF.Value, itemF.Priority);

        for (int i = 0; i < expectedResult.Length; i++)
        {
            var item = priorityQueue.Peek();
            Assert.AreEqual(expectedResult[i].Value, item[i]);
        }
    }

    [TestMethod]
    // Scenario: Create a queue with the following items with different priorities: A (2), B (1), C(3), D(5), E(1), F(1)
    //Then compare the result of Peek() method to the expected result to test the enueue and peek methods.
    //enqueue function adds items to the back of the queue regardless of priority.
    // Expected Result: A, B, C, D, E, F
    // Defect(s) Found: None
    //1. created a new person object for A, B, C, D, E and F with their respective turns.
    //2. created an expected result array with the order in which the persons are expected to be returned from the queue.
    //3. called an instance of PriorityQueue and added the persons to the queue using Enqueue method.
    //4. used a for loop to run through the expected result array and in each iteration called Peek method to get all the items from the queue.
    //5. compared the name of the item returned from the queue with the expected result array
    //6. verified that the order of items returned from the queue is same as the order in which they were added to the queue (at the back of the queue) regardless of priority.
    public void TestPriorityQueue_2()
    {
        var itemA = new PriorityItem("A", 2);
        var itemB = new PriorityItem("B", 1);
        var itemC = new PriorityItem("C", 3);
        var itemD = new PriorityItem("D", 5);
        var itemE = new PriorityItem("E", 1);
        var itemF = new PriorityItem("F", 1);
        PriorityItem[] expectedResult = [itemA, itemB, itemC, itemD, itemE, itemF];

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(itemA.Value, itemA.Priority);
        priorityQueue.Enqueue(itemB.Value, itemB.Priority);
        priorityQueue.Enqueue(itemC.Value, itemC.Priority);
        priorityQueue.Enqueue(itemD.Value, itemD.Priority);
        priorityQueue.Enqueue(itemE.Value, itemE.Priority);
        priorityQueue.Enqueue(itemF.Value, itemF.Priority);

        for (int i = 0; i < expectedResult.Length; i++)
        {
            var item = priorityQueue.Peek();
            Assert.AreEqual(expectedResult[i].Value, item[i]);
        }
    }

    [TestMethod]
    // Scenario: Create a queue with the following items and priorities: A (1), B (2), C(3), D(4), E(5), F(6)
    //Then remove items having different priorities
    // Expected Result: D, F, C, A, B, E
    // Defect(s) Found: It is not considering the index of the items with the same priority while dequeuing.
    // 2. It is not removing the item from the queue after dequeuing it.
    //summary of tests result:
    //1. created a new person object for A, B, C, D, E and F with their respective turns.
    //2. created an expected result array with the order in which the persons are expected to be returned from the queue.
    //3. called an instance of PriorityQueue and added the persons to the queue using Enqueue method.
    //4. used a for loop to run through the expected result array and in each iteration called Dequeue method to get the next item from the queue based on priority and remove it from the queue.
    //5. compared the name of the item returned from the queue with the expected result array
    //6. verified that the order of items returned from the queue is based on priority (highest priority first) and for items with same priority the one added first is returned first (FIFO order).

    public void TestPriorityQueue_3()
    {
        var itemA = new PriorityItem("A", 2);
        var itemB = new PriorityItem("B", 1);
        var itemC = new PriorityItem("C", 3);
        var itemD = new PriorityItem("D", 5);
        var itemE = new PriorityItem("E", 1);
        var itemF = new PriorityItem("F", 5);
        PriorityItem[] expectedResult = [itemD, itemF, itemC, itemA, itemB, itemE];
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(itemA.Value, itemA.Priority);
        priorityQueue.Enqueue(itemB.Value, itemB.Priority);
        priorityQueue.Enqueue(itemC.Value, itemC.Priority);
        priorityQueue.Enqueue(itemD.Value, itemD.Priority);
        priorityQueue.Enqueue(itemE.Value, itemE.Priority);
        priorityQueue.Enqueue(itemF.Value, itemF.Priority);
        for (int i = 0; i < expectedResult.Length; i++)
        {
            var item = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, item);
        }
    }

    // Add more test cases as needed below.

    [TestMethod]
    // scenario: Create a queue with the following items having similar prioroties: A (1), B (1), C(-1), D(1), E(1), F(1)
    //Then test the dequeue method to remove items having same priorities using FIFO order.
    //Expected result: A, B, D, E, F, C
    //Defects found: none
    //summary of tests result:
    //1. created a new person object for A, B, C, D, E and F with their respective turns.
    //2. created an expected result array with the order in which the persons are expected to be returned from the queue.
    //3. called an instance of PriorityQueue and added the persons to the queue using Enqueue method.
    //4. used a for loop to run through the expected result array and in each iteration called Dequeue method to get the next item from the queue based on priority and remove it from the queue.
    //5. compared the name of the item returned from the queue with the expected result array
    //6. verified that the order of items returned from the queue is based on priority (highest priority first) and for items with same priority the one added first is returned first (FIFO order).
    //7. verified that the item with negative priority is returned last as it has the lowest priority.

    public void TestPriorityQueue_4()
    {
        var itemA = new PriorityItem("A", 1);
        var itemB = new PriorityItem("B", 1);
        var itemC = new PriorityItem("C", -1);
        var itemD = new PriorityItem("D", 1);
        var itemE = new PriorityItem("E", 1);
        var itemF = new PriorityItem("F", 1);
        PriorityItem[] expectedResult = [itemA, itemB, itemD, itemE, itemF, itemC];

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(itemA.Value, itemA.Priority);
        priorityQueue.Enqueue(itemB.Value, itemB.Priority);
        priorityQueue.Enqueue(itemC.Value, itemC.Priority);
        priorityQueue.Enqueue(itemD.Value, itemD.Priority);
        priorityQueue.Enqueue(itemE.Value, itemE.Priority);
        priorityQueue.Enqueue(itemF.Value, itemF.Priority);

        for (int i = 0; i < expectedResult.Length; i++)
        {
            var item = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, item);
        }
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue
    // Expected Result: InvalidOperationException is thrown with message "The queue is empty."
    // Defects(s) found: None
    //1. created an instance of TakingTurnsQueue
    //2. called GetNextPerson method to get the next person from the queue which is empty and verified that the appropriate exception is thrown.
    public void TestPriorityQueue_5()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            var item = priorityQueue.Dequeue();
            Assert.Fail("Expected InvalidOperationException was not thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
    }
}
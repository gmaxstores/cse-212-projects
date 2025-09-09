using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 1 - Run test cases and record any defects the test code finds in the comment above the test method.
// DO NOT MODIFY THE CODE IN THE TESTS in this file, just the comments above the tests. 
// Fix the code being tested to match requirements and make all tests pass. 

[TestClass]
public class TakingTurnsQueueTests
{
    [TestMethod]
    // Scenario: Create a queue with the following people and turns: Bob (2), Tim (5), Sue (3) and
    // run until the queue is empty
    // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, Sue, Tim, Tim
    // Defect(s) Found: the first person in the queue was not being returned first. Rather the last person added was being returned first.
    // This was due to using a stack instead of a queue.
    //Summary of tests results:
    //1. created a new person object for Bob, Tim and sue with their respective turns.
    //2. created an expected result array with the order in which the persons are expected to be returned from the queue.
    //3. called an instance of TakingTurnsQueue and added the persons to the queue using AddPerson method.
    //4. used a while loop to run until the queue is empty and in each iteration called GetNextPerson method to get the next person from the queue.
    //5. compared the name of the person returned from the queue with the expected result array
    public void TestTakingTurnsQueue_FiniteRepetition()
    {
        var bob = new Person("Bob", 2);
        var tim = new Person("Tim", 5);
        var sue = new Person("Sue", 3);

        Person[] expectedResult = [bob, tim, sue, bob, tim, sue, tim, sue, tim, tim];

        var players = new TakingTurnsQueue();
        players.AddPerson(bob.Name, bob.Turns);
        players.AddPerson(tim.Name, tim.Turns);
        players.AddPerson(sue.Name, sue.Turns);

        int i = 0;
        while (players.Length > 0)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("Queue should have ran out of items by now.");
            }

            var person = players.GetNextPerson();
            Assert.AreEqual(expectedResult[i].Name, person.Name);
            i++;
        }
    }

    [TestMethod]
    // Scenario: Create a queue with the following people and turns: Bob (2), Tim (5), Sue (3)
    // After running 5 times, add George with 3 turns.  Run until the queue is empty.
    // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, George, Sue, Tim, George, Tim, George
    // Defect(s) Found: the first person in the queue was not being returned first. Rather the last person added was being returned first.
    // this was due to using a stack instead of a queue.
    //summary of tests result:
    //1. created a new Person object for Bob, Tim, Sue and George with their respective turns.
    //2. created an expected result array with the order in which the persons are expected to be returned from the queue.
    //3. called an instance of TakingTurnsQueue and added Bob, Tim and Sue first to the queue using AddPerson method.
    //4. used a for loop to run 5 times and in each iteration called GetNextPerson method to get the next person from the queue.
    //5. after 5 iterations added George to the queue using AddPerson method.
    //6. used a while loop to run until the queue is empty and in each iteration called GetNextPerson method to get the next person from the queue.
    //7. compared the name of the person returned from the queue with the expected result array
    public void TestTakingTurnsQueue_AddPlayerMidway()
    {
        var bob = new Person("Bob", 2);
        var tim = new Person("Tim", 5);
        var sue = new Person("Sue", 3);
        var george = new Person("George", 3);

        Person[] expectedResult = [bob, tim, sue, bob, tim, sue, tim, george, sue, tim, george, tim, george];

        var players = new TakingTurnsQueue();
        players.AddPerson(bob.Name, bob.Turns);
        players.AddPerson(tim.Name, tim.Turns);
        players.AddPerson(sue.Name, sue.Turns);

        int i = 0;
        for (; i < 5; i++)
        {
            var person = players.GetNextPerson();
            Assert.AreEqual(expectedResult[i].Name, person.Name);
        }

        players.AddPerson("George", 3);

        while (players.Length > 0)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("Queue should have ran out of items by now.");
            }

            var person = players.GetNextPerson();
            Assert.AreEqual(expectedResult[i].Name, person.Name);

            i++;
        }
    }

    [TestMethod]
    // Scenario: Create a queue with the following people and turns: Bob (2), Tim (Forever), Sue (3)
    // Run 10 times.
    // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, Sue, Tim, Tim
    // Defect(s) Found: 1. the first person in the queue was not being returned first. Rather the last person added was being returned first.
    // This is beacuse the code was using a stack instead of a queue.
    // 2. No condition was being checked for infinite turns(0).
    //summary of tests result:
    //1. created a new Person object for Bob, Tim and Sue with their respective turns.
    //2. created an expected result array with the order in which the persons are expected to be returned from the queue.
    //3. called an instance of TakingTurnsQueue and added the persons to the queue using AddPerson method.
    //4. used a for loop to run 10 times and in each iteration called GetNextPerson method to get the next person from the queue.
    //5. compared the name of the person returned from the queue with the expected result array
    //6. verified that the person with infinite turns really do have infinite turns by checking that their turns parameter is still 0.
    public void TestTakingTurnsQueue_ForeverZero()
    {
        var timTurns = 0;

        var bob = new Person("Bob", 2);
        var tim = new Person("Tim", timTurns);
        var sue = new Person("Sue", 3);

        Person[] expectedResult = [bob, tim, sue, bob, tim, sue, tim, sue, tim, tim];

        var players = new TakingTurnsQueue();
        players.AddPerson(bob.Name, bob.Turns);
        players.AddPerson(tim.Name, tim.Turns);
        players.AddPerson(sue.Name, sue.Turns);

        for (int i = 0; i < 10; i++)
        {
            var person = players.GetNextPerson();
            Assert.AreEqual(expectedResult[i].Name, person.Name);
        }

        // Verify that the people with infinite turns really do have infinite turns.
        var infinitePerson = players.GetNextPerson();
        Assert.AreEqual(timTurns, infinitePerson.Turns, "People with infinite turns should not have their turns parameter modified to a very big number. A very big number is not infinite.");
    }

    [TestMethod]
    // Scenario: Create a queue with the following people and turns: Tim (Forever), Sue (3)
    // Run 10 times.
    // Expected Result: Tim, Sue, Tim, Sue, Tim, Sue, Tim, Tim, Tim, Tim
    // Defect(s) Found: 1. the first person in the queue was not being returned first. Rather the last person added was being returned first
    // 2. No condition was being checked for infinite turns (negative numbers)
    //1. created a new Person object for Bob, Tim and Sue with their respective turns.
    //2. created an expected result array with the order in which the persons are expected to be returned from the queue.
    //3. called an instance of TakingTurnsQueue and added the persons to the queue using AddPerson method.
    //4. used a for loop to run 10 times and in each iteration called GetNextPerson method to get the next person from the queue.
    //5. compared the name of the person returned from the queue with the expected result array
    //6. verified that the person with infinite turns really do have infinite turns by checking that their turns parameter is still negative.
    public void TestTakingTurnsQueue_ForeverNegative()
    {
        var timTurns = -3;
        var tim = new Person("Tim", timTurns);
        var sue = new Person("Sue", 3);

        Person[] expectedResult = [tim, sue, tim, sue, tim, sue, tim, tim, tim, tim];

        var players = new TakingTurnsQueue();
        players.AddPerson(tim.Name, tim.Turns);
        players.AddPerson(sue.Name, sue.Turns);

        for (int i = 0; i < 10; i++)
        {
            var person = players.GetNextPerson();
            Assert.AreEqual(expectedResult[i].Name, person.Name);
        }

        // Verify that the people with infinite turns really do have infinite turns.
        var infinitePerson = players.GetNextPerson();
        Assert.AreEqual(timTurns, infinitePerson.Turns, "People with infinite turns should not have their turns parameter modified to a very big number. A very big number is not infinite.");
    }

    [TestMethod]
    // Scenario: Try to get the next person from an empty queue
    // Expected Result: Exception should be thrown with appropriate error message.
    // Defect(s) Found: None
    //summary of tests result:
    //1. created an instance of TakingTurnsQueue
    //2. called GetNextPerson method to get the next person from the queue which is empty and verified that the appropriate exception is thrown.
    public void TestTakingTurnsQueue_Empty()
    {
        var players = new TakingTurnsQueue();

        try
        {
            players.GetNextPerson();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("No one in the queue.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }
}
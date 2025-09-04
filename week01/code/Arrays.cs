public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        //create an array of doubles with the size of the length supplied
        var multiples = new double[length];

        //use a for loop to iterate through the length of the array and add the multiples of the given number to the array created above
        for (int i = 0; i < length; i++)
        {
            //using the index of the loop, calculate the multiple and assign it to the current index of the array
            multiples[i] = number * (i + 1);
        }

        //return the array of multiples
        return multiples; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        //get a range of the last amount of numbers from the list
        var end = data.GetRange(data.Count - amount, amount);

        //remove the last amount of numbers from the list
        data.RemoveRange(data.Count - amount, amount);

        //insert the range of numbers at the start of the list
        data.InsertRange(0, end);

    }
}

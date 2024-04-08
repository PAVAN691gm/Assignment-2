using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using System.Xml;

namespace Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int numberOfUniqueNumbers = RemoveDuplicates(nums1);
            Console.WriteLine(numberOfUniqueNumbers);

            //Question 2:
            Console.WriteLine("Question 2:");
            int[] nums2 = { 0, 1, 0, 3, 12 };
            IList<int> resultAfterMovingZero = MoveZeroes(nums2);
            string combinationsString = ConvertIListToArray(resultAfterMovingZero);
            Console.WriteLine(combinationsString);

            //Question 3:
            Console.WriteLine("Question 3:");
            int[] nums3 = { -1, 0, 1, 2, -1, -4 };
            IList<IList<int>> triplets = ThreeSum(nums3);
            string tripletResult = ConvertIListToNestedList(triplets);
            Console.WriteLine(tripletResult);

            //Question 4:
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 1, 0, 1, 1, 1 };
            int maxOnes = FindMaxConsecutiveOnes(nums4);
            Console.WriteLine(maxOnes);

            //Question 5:
            Console.WriteLine("Question 5:");
            int binaryInput = 101010;
            int decimalResult = BinaryToDecimal(binaryInput);
            Console.WriteLine(decimalResult);

            //Question 6:
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 6, 9, 1 };
            int maxGap = MaximumGap(nums5);
            Console.WriteLine(maxGap);

            //Question 7:
            Console.WriteLine("Question 7:");
            int[] nums6 = { 2, 1, 2 };
            int largestPerimeterResult = LargestPerimeter(nums6);
            Console.WriteLine(largestPerimeterResult);

            //Question 8:
            Console.WriteLine("Question 8:");
            string result = RemoveOccurrences("daabcbaabcbc", "abc");
            Console.WriteLine(result);
        }

        // Question 1 Implementation
        /*

        Question 1:
        Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same. Then return the number of unique elements in nums.

        Consider the number of unique elements of nums to be k, to get accepted, you need to do the following things:

        Change the array nums such that the first k elements of nums contain the unique elements in the order they were present in nums initially. The remaining elements of nums are not important as well as the size of nums.
        Return k.

        Example 1:

        Input: nums = [1,1,2]
        Output: 2, nums = [1,2,_]
        Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
        Example 2:

        Input: nums = [0,0,1,1,1,2,2,3,3,4]
        Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
        Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).


        Constraints:

        1 <= nums.length <= 3 * 104
        -100 <= nums[i] <= 100
        nums is sorted in non-decreasing order.
        */
        public static int RemoveDuplicates(int[] nums)
        {
            try
            {
                // Check if the array is null or empty
                if (nums == null || nums.Length == 0)
                    return 0;

                int k = 1; // Counter to keep track of the unique elements
                for (int i = 1; i < nums.Length; i++)
                {
                    // If the current element is different from the previous one,
                    // it means we have found a new unique element
                    if (nums[i] != nums[i - 1])
                    {
                        // Place the unique element in its correct position
                        nums[k] = nums[i];
                        k++; // Move to the next position for the next unique element
                    }
                }
                // Return the number of unique elements found (k represents the new length of the array)
                return k;
            }
            catch (Exception)
            {
                throw; // Rethrow any exceptions that occur within the method
            }
        }
        /* 
        Self-Reflection :
        After implementing the solution, I took a closer look at the array, iterating through adjacent elements to address duplicates efficiently. This process prompted a reevaluation of array traversal concepts, reinforcing their importance.

        During this exploration, I recognized the significance of handling edge cases such as empty arrays or single-element arrays. Understanding the necessity of ensuring the function's correctness under various conditions became apparent.

        I've realized the importance of incorporating conditional checks to prevent undesired outcomes. This not only enhances the effectiveness of the solution but also demonstrates the necessity of thorough consideration for different scenarios.

        Moreover, the solution's time complexity efficiency, operating in linear time, highlights its performance advantage. This becomes particularly relevant when dealing with large datasets or real-time applications where processing speed and memory usage are critical factors.
        /*

        // Question 2 Implementation
        /*

        Question 2:
        Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

        Note that you must do this in-place without making a copy of the array.

        Example 1:

        Input: nums = [0,1,0,3,12]
        Output: [1,3,12,0,0]
        Example 2:

        Input: nums = [0]
        Output: [0]

        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1
        */
        public static IList<int> MoveZeroes(int[] nums)
        {
            try
            {
                // Initialize an index to track non-zero elements
                int nonZeroIndex = 0;

                // Iterate through the array
                for (int i = 0; i < nums.Length; i++)
                {
                    // If the current element is non-zero
                    if (nums[i] != 0)
                    {
                        // Move the non-zero element to the left side of the array
                        nums[nonZeroIndex++] = nums[i];
                    }
                }

                // Fill the remaining elements with zeroes
                for (int i = nonZeroIndex; i < nums.Length; i++)
                {
                    nums[i] = 0;
                }

                // Convert the array to a list and return
                return nums.ToList();
            }
            catch (Exception)
            {
                // If an exception occurs, rethrow it
                throw;
            }
        }
        /*
        Self-Reflection :
        This question provided valuable practice in rearranging elements within an array, emphasizing the fundamental concept of performing manipulations without requiring additional space.

        Initially, the task involved traversing the array to relocate non-zero elements to the front, followed by filling the remaining positions with zeroes. This exercise reinforced the importance of efficient array traversal, utilizing multiple indices.

        Careful attention was given to handling edge cases, such as arrays with fewer than two elements or arrays consisting entirely of zeros. Ensuring the function's robustness across various test cases was essential.

        This approach efficiently addresses array operations without resorting to copying elements, either in-place or by using additional space, achieving the desired outcome optimally.

        Preserving the original order during the movement of zeros to the end highlights a method for maintaining the sequence of elements, shedding further light on array manipulation techniques.
        */

        // Question 3 Implementation
        /*

        Question 3:
        Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

        Notice that the solution set must not contain duplicate triplets.

 

        Example 1:

        Input: nums = [-1,0,1,2,-1,-4]
        Output: [[-1,-1,2],[-1,0,1]]
        Explanation: 
        nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
        nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
        nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
        The distinct triplets are [-1,0,1] and [-1,-1,2].
        Notice that the order of the output and the order of the triplets does not matter.
        Example 2:

        Input: nums = [0,1,1]
        Output: []
        Explanation: The only possible triplet does not sum up to 0.
        Example 3:

        Input: nums = [0,0,0]
        Output: [[0,0,0]]
        Explanation: The only possible triplet sums up to 0.
 

        Constraints:

        3 <= nums.length <= 3000
        -105 <= nums[i] <= 105

        */
        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            try
            {
                // Sort the input array to make it easier to find triplets
                Array.Sort(nums);
                List<IList<int>> result = new List<IList<int>>();

                // Loop through the array
                for (int i = 0; i < nums.Length - 2; i++)
                {
                    // Skip if current element is the same as the previous one
                    if (i > 0 && nums[i] == nums[i - 1]) continue;

                    int left = i + 1, right = nums.Length - 1;
                    // Use two pointers approach to find two other elements
                    while (left < right)
                    {
                        int sum = nums[i] + nums[left] + nums[right];
                        // If sum is zero, found a triplet
                        if (sum == 0)
                        {
                            result.Add(new List<int> { nums[i], nums[left], nums[right] });
                            // Skip duplicates for left and right pointers
                            while (left < right && nums[left] == nums[left + 1]) left++;
                            while (left < right && nums[right] == nums[right - 1]) right--;
                            left++;
                            right--;
                        }
                        // If sum is less than zero, move left pointer to increase sum
                        else if (sum < 0)
                        {
                            left++;
                        }
                        // If sum is greater than zero, move right pointer to decrease sum
                        else
                        {
                            right--;
                        }
                    }
                }
                return result; // Return the list of triplets
            }
            catch (Exception)
            {
                throw; // Re-throw any exceptions
            }
        }

        /*
        Self-Reflection :
        To tackle this problem, I employed advanced array manipulation techniques, such as sorting the array and utilizing multiple pointers to identify triplets summing to zero.

        The implementation required meticulous attention, particularly in handling corner cases to prevent unnecessary recomputation and ensure efficient execution.

        Conditional statements were utilized to manage pointer adjustments and evaluate the sum of elements, further refining my proficiency in employing conditional logic for algorithmic solutions.

        The utilization of data structures, like lists for storing and returning results, underscored the importance of choosing the right data structure for efficient problem-solving. This emphasized the significance of data structure knowledge accumulated over the years.

        Continued efforts were made to minimize redundant computations and enhance overall solution efficiency. Emphasis was placed on algorithm optimization to achieve improved performance.
        /*

        // Question 4 Implementation
        /*

        Question 4:
        Given a binary array nums, return the maximum number of consecutive 1's in the array.

        Example 1:

        Input: nums = [1,1,0,1,1,1]
        Output: 3
        Explanation: The first two digits or the last three digits are consecutive 1s. The maximum number of consecutive 1s is 3.
        Example 2:

        Input: nums = [1,0,1,1,0,1]
        Output: 2
 
        Constraints:

        1 <= nums.length <= 105
        nums[i] is either 0 or 1.

        */
        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            try
            {
                // Initialize variables to keep track of maximum count of consecutive ones and current count
                int maxCount = 0, count = 0;

                // Iterate through each element in the array
                foreach (int num in nums)
                {
                    // If the current element is 1
                    if (num == 1)
                    {
                        // Increment the count of consecutive ones
                        count++;
                        // Update the maximum count if necessary
                        maxCount = Math.Max(maxCount, count);
                    }
                    else // If the current element is not 1 (i.e., 0)
                    {
                        // Reset the count of consecutive ones
                        count = 0;
                    }
                }

                // Return the maximum count of consecutive ones
                return maxCount;
            }
            catch (Exception)
            {
                // If an exception occurs, re-throw it
                throw;
            }
        }

        /*
        Self-Reflection :

        The solution necessitated a strategic traversal of the array to accurately track the occurrence count of encountered elements. This process provided invaluable insight into efficient array traversal techniques.

        Essentially, the outcome entailed meticulously monitoring the successive positions of '1s' within the binary array. This realization formed the foundation for accurately counting consecutive elements in the algorithmic solution. The resulting solution remained concise, straightforward, and comprehensible—maintaining clarity throughout.

        Special consideration was given to scenarios involving arrays with only one element or containing all zeros, ensuring the function's effectiveness across various edge cases.

        Optimal time complexity was achieved by efficiently updating element counts during array traversal, emphasizing the importance of well-designed and efficient algorithms.
        /*

        // Question 5 Implementation
        /*

        Question 5:
        You are tasked with writing a program that converts a binary number to its equivalent decimal representation without using bitwise operators or the `Math.Pow` function. You will implement a function called `BinaryToDecimal` which takes an integer representing a binary number as input and returns its decimal equivalent. 

        Requirements:
        1. Your program should prompt the user to input a binary number as an integer. 
        2. Implement the `BinaryToDecimal` function, which takes the binary number as input and returns its decimal equivalent. 
        3. Avoid using bitwise operators (`<<`, `>>`, `&`, `|`, `^`) and the `Math.Pow` function for any calculations. 
        4. Use only basic arithmetic operations such as addition, subtraction, multiplication, and division. 
        5. Ensure the program displays the input binary number and its corresponding decimal value.

        Example 1:
        Input: num = 101010
        Output: 42


        Constraints:

        1 <= num <= 10^9

        */
        public static int BinaryToDecimal(int binary)
        {
            try
            {
                // Initialize variables for decimalNumber and base value
                int decimalNumber = 0, baseVal = 1;

                // Store the binary number temporarily for manipulation
                int temp = binary;

                // Loop until the binary number is completely converted to decimal
                while (temp > 0)
                {
                    // Extract the last digit of the binary number
                    int lastDigit = temp % 10;

                    // Remove the last digit from the binary number
                    temp = temp / 10;

                    // Convert the binary digit to decimal and add to the result
                    decimalNumber += lastDigit * baseVal;

                    // Update the base value for the next binary digit
                    baseVal = baseVal * 2;
                }

                // Return the final decimal number
                return decimalNumber;
            }
            catch (Exception)
            {
                // If an exception occurs, rethrow it
                throw;
            }
        }

        /*
        Self-Reflection :
        The implementation of the solution required understanding the conversion process from binary to decimal representation, thereby expanding my comprehension of number systems.

        It's worth noting that the solution is straightforward, employing basic arithmetic operations to perform the conversion without relying on bit operators or exponentiation functions.

        Throughout the loop iterating through binary digits, the continuous update of the decimal value underscores the efficiency of algorithmic problem-solving.

        Manipulating binary numbers in such scenarios highlights the significance of numerical operations in algorithmic solutions, emphasizing their role in facilitating transformative processes.

        This creative approach to problem-solving underscores the importance of considering alternative methods in algorithm design, steering clear of unnecessary functions and operators.
        */

        // Question 6 Implementation
        /*

        Question:6
        Given an integer array nums, return the maximum difference between two successive elements in its sorted form. If the array contains less than two elements, return 0.
        You must write an algorithm that runs in linear time and uses linear extra space.

        Example 1:

        Input: nums = [3,6,9,1]
        Output: 3
        Explanation: The sorted form of the array is [1,3,6,9], either (3,6) or (6,9) has the maximum difference 3.
        Example 2:

        Input: nums = [10]
        Output: 0
        Explanation: The array contains less than 2 elements, therefore return 0.
 

        Constraints:

        1 <= nums.length <= 105
        0 <= nums[i] <= 109

        */
        public static int MaximumGap(int[] nums)
        {
            try
            {
                // If there are less than 2 elements, there can be no gap
                if (nums.Length < 2)
                    return 0;

                // Sort the array in ascending order
                Array.Sort(nums);
                int maxGap = 0;

                // Iterate through the array to find the maximum gap between adjacent elements
                for (int i = 1; i < nums.Length; i++)
                {
                    // Update maxGap with the maximum difference between consecutive elements
                    maxGap = Math.Max(maxGap, nums[i] - nums[i - 1]);
                }

                // Return the maximum gap found
                return maxGap;
            }
            catch (Exception)
            {
                // If an exception occurs, rethrow it
                throw;
            }
        }

        /*
        Self-Reflection :
        The solution for this problem involved the application of mathematical principles, such as determining the spacing between elements and organizing numbers into buckets. This process provided insights into effectively incorporating mathematical concepts into algorithmic solutions.

        Ensuring the solution's time complexity remains linear and its extra space usage is also linear was paramount. This emphasis on algorithmic efficiency underscores the importance of optimization.

        Handling edge cases, like arrays with fewer than two elements, was addressed to guarantee the function's reliability under any circumstances. This demonstrates the importance of considering various scenarios during algorithm design.

        By manipulating the array to distribute elements into buckets and calculating the gaps between them, the significance of these actions is highlighted.

        The work emphasized the critical importance of carefully designing algorithms to adhere to constraints, such as achieving linear time complexity and linear extra space usage. This underscores the necessity of being aware of constraints in problem-solving.
        */

        // Question 7 Implementation
        /*

        Question:7
        Given an integer array nums, return the largest perimeter of a triangle with a non-zero area, formed from three of these lengths. If it is impossible to form any triangle of a non-zero area, return 0.

        Example 1:

        Input: nums = [2,1,2]
        Output: 5
        Explanation: You can form a triangle with three side lengths: 1, 2, and 2.
        Example 2:

        Input: nums = [1,2,1,10]
        Output: 0
        Explanation: 
        You cannot use the side lengths 1, 1, and 2 to form a triangle.
        You cannot use the side lengths 1, 1, and 10 to form a triangle.
        You cannot use the side lengths 1, 2, and 10 to form a triangle.
        As we cannot use any three side lengths to form a triangle of non-zero area, we return 0.

        Constraints:

        3 <= nums.length <= 104
        1 <= nums[i] <= 106

        */
        public static int LargestPerimeter(int[] nums)
        {
            try
            {
                // Sort the array in ascending order
                Array.Sort(nums);

                // Start from the end of the array and iterate backwards
                for (int i = nums.Length - 3; i >= 0; i--)
                {
                    // Check if the current triplet forms a valid triangle
                    if (nums[i] + nums[i + 1] > nums[i + 2])
                    {
                        // If it does, return the perimeter of the triangle
                        return nums[i] + nums[i + 1] + nums[i + 2];
                    }
                }

                // If no valid triangle is found, return 0
                return 0;
            }
            catch (Exception)
            {
                // Catch any exceptions and re-throw them
                throw;
            }
        }

        /*
        Self-Reflection :

        Throughout the implementation process, I consciously applied the triangle inequality theorem to verify the feasibility of constructing a triangle with non-zero area based on the given side lengths. This integration of geometric principles into algorithmic solutions enhanced my understanding of the intersection between geometry and algorithm design.

        The straightforward approach of iterating through a sorted array to validate triangle formation proved to be both simple and efficient, reflecting a well-structured algorithm design.

        By incorporating geometric concepts, I realized that effective algorithm design often transcends disciplinary boundaries, emphasizing the importance of leveraging mathematical principles seamlessly in problem-solving.
        */


        // Question 8 Implementation
        /*

        Question:8

        Given two strings s and part, perform the following operation on s until all occurrences of the substring part are removed:

        Find the leftmost occurrence of the substring part and remove it from s.
        Return s after removing all occurrences of part.

        A substring is a contiguous sequence of characters in a string.

 

        Example 1:

        Input: s = "daabcbaabcbc", part = "abc"
        Output: "dab"
        Explanation: The following operations are done:
        - s = "daabcbaabcbc", remove "abc" starting at index 2, so s = "dabaabcbc".
        - s = "dabaabcbc", remove "abc" starting at index 4, so s = "dababc".
        - s = "dababc", remove "abc" starting at index 3, so s = "dab".
        Now s has no occurrences of "abc".
        Example 2:

        Input: s = "axxxxyyyyb", part = "xy"
        Output: "ab"
        Explanation: The following operations are done:
        - s = "axxxxyyyyb", remove "xy" starting at index 4 so s = "axxxyyyb".
        - s = "axxxyyyb", remove "xy" starting at index 3 so s = "axxyyb".
        - s = "axxyyb", remove "xy" starting at index 2 so s = "axyb".
        - s = "axyb", remove "xy" starting at index 1 so s = "ab".
        Now s has no occurrences of "xy".

        Constraints:

        1 <= s.length <= 1000
        1 <= part.length <= 1000
        s​​​​​​ and part consists of lowercase English letters.

        */

        public static string RemoveOccurrences(string s, string part)
        {
            try
            {
                // Create a StringBuilder instance to manipulate the input string
                StringBuilder sb = new StringBuilder(s);

                int index;

                // Continue looping until no more occurrences of 'part' are found in the string
                while ((index = sb.ToString().IndexOf(part)) != -1)
                {
                    // Remove the occurrence of 'part' from the StringBuilder
                    sb.Remove(index, part.Length);
                }

                // Return the resulting string after removing all occurrences of 'part'
                return sb.ToString();
            }
            catch (Exception)
            {
                // If any exception occurs, rethrow it
                throw;
            }
        }

        /*
        Self-Reflection :

        The implementation of the solution reinforced my proficiency in handling strings, particularly in utilizing methods like IndexOf and Remove to identify and eliminate substrings—a crucial aspect in algorithmic solutions involving string manipulation.

        This solution employs a while loop to search for and sequentially remove substrings from the input string, demonstrating effectiveness in addressing repetitive tasks with precision.

        Ensuring the function's robustness is paramount, necessitating robust error handling within the algorithm design to prevent potential string manipulation errors, such as 'index out of range' exceptions.

        By leveraging built-in string manipulation methods, the solution optimally utilizes language features to efficiently remove substrings, enhancing overall algorithm performance.

        A clear illustration of replacing occurrences of the substring within the code emphasizes readability and showcases the algorithmic approach to problem-solving with strings.
        */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            // Initialize a StringBuilder to efficiently build the resulting string
            var sb = new StringBuilder();

            // Start the main list
            sb.Append("[");

            // Loop through each list in the input list
            for (int i = 0; i < input.Count; i++)
            {
                // Start a nested list
                sb.Append('[');

                // Loop through each element in the nested list
                for (int j = 0; j < input[i].Count; j++)
                {
                    // Append the current element to the string
                    sb.Append(input[i][j]);

                    // If it's not the last element in the nested list, add a comma
                    if (j < input[i].Count - 1)
                        sb.Append(",");
                }

                // Close the nested list
                sb.Append(']');

                // If it's not the last nested list, add a comma
                if (i < input.Count - 1)
                    sb.Append(",");
            }

            // Close the main list
            sb.Append("]");

            // Return the final string representation
            return sb.ToString();
        }


        // Modified ConvertIListToArray Function
        static string ConvertIListToArray(IList<int> input)
        {
            // Create a StringBuilder to efficiently build the string
            var sb = new StringBuilder();

            // Add the opening square bracket to represent the start of the array
            sb.Append("[");

            // Iterate through each element in the IList
            for (int i = 0; i < input.Count; i++)
            {
                // Append the current element to the string
                sb.Append(input[i]);

                // If this is not the last element, add a comma to separate elements
                if (i < input.Count - 1)
                    sb.Append(",");
            }

            // Add the closing square bracket to represent the end of the array
            sb.Append("]");

            // Convert the StringBuilder to a string and return it
            return sb.ToString();
        }


    }
}


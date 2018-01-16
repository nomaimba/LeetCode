using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class ArrayProblems
    {
        #region 1. Two Sum
        //Given an array of integers, return indices of the two numbers such that they add up to a specific target.

        //You may assume that each input would have exactly one solution, and you may not use the same element twice.

        //Example:
        //Given nums = [2, 7, 11, 15], target = 9,

        //Because nums[0] + nums[1] = 2 + 7 = 9,
        //return [0, 1].
        public static int[] TwoSum(int[] nums, int target)
        {
            var result = new int[2];
            var map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (map.ContainsKey(target - nums[i]))
                {
                    result[1] = i;
                    result[0] = map[target - nums[i]];
                    break;
                }
                map[nums[i]] = i;
            }
            return result;
        }
        #endregion

        #region 2. Add Two Numbers
        //You are given two non-empty linked lists representing two non-negative integers.The digits are stored in reverse order and each of their nodes contain a single digit.Add the two numbers and return it as a linked list.

        //You may assume the two numbers do not contain any leading zero, except the number 0 itself.

        //Example

        //Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
        //Output: 7 -> 0 -> 8
        //Explanation: 342 + 465 = 807.
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode result = null;
            ListNode currentNode = null;
            int last = 0;

            while (l1 != null || l2 != null)
            {
                int v1 = l1 == null ? 0 : l1.val;
                int v2 = l2 == null ? 0 : l2.val;
                var thisNode = new ListNode(v1 + v2);
                thisNode.val += last;
                last = thisNode.val / 10;
                thisNode.val %= 10;
                if (result == null)
                {
                    result = thisNode;
                    currentNode = thisNode;
                }
                else
                {
                    currentNode.next = thisNode;
                    currentNode = currentNode.next;
                }
                if (l1 != null)
                    l1 = l1.next;
                if (l2 != null)
                    l2 = l2.next;
            }
            if (last > 0)
            {
                var thisNode = new ListNode(last);
                currentNode.next = thisNode;

            }
            return result;
        }
        #endregion 

        #region 26. Remove Duplicates from Sorted Array
        //Given a sorted array, remove the duplicates in-place such that each element appear only once and return the new length.

        //Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.

        //Example:

        //Given nums = [1, 1, 2],

        //Your function should return length = 2, with the first two elements of nums being 1 and 2 respectively.
        //It doesn't matter what you leave beyond the new length.
        public static int RemoveDuplicates(int[] nums)
        {
            var result = nums.Length > 0 ? 1 : 0;
            foreach (var num in nums)
            {
                if (num > nums[result - 1])
                    nums[result++] = num;

            }
            return result;
        }
        #endregion

        #region 27. Remove Element
        //Given an array and a value, remove all instances of that value in-place and return the new length.

        //Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.

        //The order of elements can be changed. It doesn't matter what you leave beyond the new length.

        //Example:

        //Given nums = [3, 2, 2, 3], val = 3,

        //Your function should return length = 2, with the first two elements of nums being 2.
        public static int RemoveElement(int[] nums, int val)
        {
            int result = nums.Length > 0 ? nums.Length : 0;
            for (int i = 0; i < nums.Length;)
            {
                if (nums[i] == val)
                {
                    for (int j = i; j < nums.Length - 1; j++)
                    {
                        nums[j] = nums[j + 1];
                    }
                    result--;
                    if (i + (nums.Length - result) == nums.Length)
                        break;
                }
                else
                {
                    i++;
                }
            }
            return result;

        }
        #endregion

        #region 35. Search Insert Position
        //Given a sorted array and a target value, return the index if the target is found.If not, return the index where it would be if it were inserted in order.

        //You may assume no duplicates in the array.

        //Example 1:

        //Input: [1,3,5,6], 5
        //Output: 2
        //Example 2:


        //Input: [1,3,5,6], 2
        //Output: 1
        //Example 3:


        //Input: [1,3,5,6], 7
        //Output: 4
        //Example 1:


        //Input: [1,3,5,6], 0
        //Output: 0
        public static int SearchInsert(int[] nums, int target)
        {
            var result = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == target)
                {
                    result = i;
                    break;
                }
                else if (nums[i] > target)
                {
                    result = i;
                    break;
                }
                else
                {
                    result = i;
                    if (result == nums.Length - 1)
                        result += 1;
                }
            }
            return result;
        }
        #endregion

        #region 43. Multiply Strings
        //Given two non-negative integers num1 and num2 represented as strings, return the product of num1 and num2.

        //Note:

        //The length of both num1 and num2 is < 110.
        //Both num1 and num2 contains only digits 0-9.
        //Both num1 and num2 does not contain any leading zero.
        //You must not use any built-in BigInteger library or convert the inputs to integer directly.
        public static string Multiply(string num1, string num2)
        {
            int[] num1Arr = new int[num1.Length];
            for (int i = 0; i < num1.Length; i++)
            {
                num1Arr[i] = int.Parse(num1[i].ToString());
            }
            int[] num2Arr = new int[num2.Length];
            for (int i = 0; i < num2.Length; i++)
            {
                num2Arr[i] = int.Parse(num2[i].ToString());
            }
            int[] resultArr = new int[num1.Length + num2.Length];
            for (int i = num1Arr.Length - 1; i >= 0; i--)
            {
                for (int j = num2Arr.Length - 1; j >= 0; j--)
                {
                    resultArr[i + j + 1] += num1Arr[i] * num2Arr[j];
                }
            }

            for (int i = resultArr.Length - 1; i > 0; i--)
            {
                if (resultArr[i] >= 10)
                {
                    resultArr[i - 1] += resultArr[i] / 10;
                    resultArr[i] %= 10;
                }
            }

            int k = 0;
            while (k < resultArr.Length && resultArr[k] == 0)
                k++;
            StringBuilder sb = new StringBuilder();
            for (int j = k; j < resultArr.Length; j++)
            {
                sb.Append(resultArr[j].ToString());
            };
            if (string.IsNullOrEmpty(sb.ToString()))
                sb.Append("0");

            return sb.ToString();
        }
        #endregion 

        #region 53. Maximum Subarray
        //Find the contiguous subarray within an array(containing at least one number) which has the largest sum.

        //For example, given the array[-2, 1, -3, 4, -1, 2, 1, -5, 4],
        //the contiguous subarray[4, -1, 2, 1] has the largest sum = 6.
        public static int MaxSubArray(int[] nums)
        {
            int max = nums[0];
            int maxToHere = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                maxToHere = maxToHere + nums[i] > nums[i] ? maxToHere + nums[i] : nums[i];
                max = max > maxToHere ? max : maxToHere;
            }
            return max;
        }
        #endregion

        #region 66. Plus One
        //Given a non-negative integer represented as a non-empty array of digits, plus one to the integer.

        //You may assume the integer do not contain any leading zero, except the number 0 itself.

        //The digits are stored such that the most significant digit is at the head of the list.
        public static int[] PlusOne(int[] digits)
        {
            digits[digits.Length - 1] += 1;
            for (int i = digits.Length - 1; i > 0; i--)
            {
                if (digits[i] >= 10)
                {
                    digits[i] %= 10;
                    digits[i - 1] += 1;
                }
            }
            if (digits[0] >= 10)
            {
                Array.Resize(ref digits, digits.Length + 1);
                for (int i = digits.Length - 2; i > 0; i--)
                {
                    digits[i + 1] = digits[i];
                }
                digits[1] %= 10;
                digits[0] = 1;
            }

            return digits;
        }
        #endregion

        #region 152. Maximum Product Subarray
        //Find the contiguous subarray within an array(containing at least one number) which has the largest product.

        //For example, given the array[2, 3, -2, 4],
        //the contiguous subarray[2, 3] has the largest product = 6.
        public static int MaxProduct(int[] a)
        {
            if (a == null || a.Length == 0)
                return 0;

            int ans = a[0], min = ans, max = ans;

            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] >= 0)
                {
                    max = a[i] > max * a[i] ? a[i] : max * a[i];
                    min = a[i] < min * a[i] ? a[i] : min * a[i];
                }
                else
                {
                    int tmp = max;
                    max = a[i] > min * a[i] ? a[i] : min * a[i];
                    min = a[i] < tmp * a[i] ? a[i] : tmp * a[i];
                }

                ans = ans > max ? ans : max;
            }

            return ans;
        }
        #endregion

        #region 561. Array Partition I
        //Given an array of 2n integers, your task is to group these integers into n pairs of integer, say(a1, b1), (a2, b2), ..., (an, bn) which makes sum of min(ai, bi) for all i from 1 to n as large as possible.

        //Example 1:
        //Input: [1,4,3,2]

        //        Output: 4
        //Explanation: n is 2, and the maximum sum of pairs is 4 = min(1, 2) + min(3, 4).
        //Note:
        //n is a positive integer, which is in the range of[1, 10000].
        //All the integers in the array will be in the range of[-10000, 10000].
        public static int ArrayPairSum(int[] nums)
        {
            var result = 0;

            Array.Sort(nums);
            for (int i = 0; i < nums.Length; i += 2)
            {
                result += nums[i];
            }

            return result;
        }
        #endregion

        #region 566. Reshape the Matrix
        //In MATLAB, there is a very useful function called 'reshape', which can reshape a matrix into a new one with different size but keep its original data.

        //You're given a matrix represented by a two-dimensional array, and two positive integers r and c representing the row number and column number of the wanted reshaped matrix, respectively.

        //The reshaped matrix need to be filled with all the elements of the original matrix in the same row-traversing order as they were.

        //If the 'reshape' operation with given parameters is possible and legal, output the new reshaped matrix; Otherwise, output the original matrix.

        //Example 1:
        //Input: 
        //nums =
        //[[1, 2],
        // [3,4]]
        //r = 1, c = 4
        //Output: 
        //[[1,2,3,4]]
        //Explanation:
        //The row-traversing of nums is [1,2,3,4]. The new reshaped matrix is a 1 * 4 matrix, fill it row by row by using the previous list.
        //Example 2:
        //Input: 
        //nums =
        //[[1, 2],
        //[3,4]]
        //r = 2, c = 4
        //Output: 
        //[[1,2],
        // [3,4]]
        //Explanation:
        //There is no way to reshape a 2 * 2 matrix to a 2 * 4 matrix.So output the original matrix.
        //Note:
        //The height and width of the given matrix is in range[1, 100].
        //The given r and c are all positive.
        public static int[,] MatrixReshape(int[,] nums, int r, int c)
        {
            int row = nums.GetLength(0);
            int column = nums.GetLength(1);
            if (row * column != r * c)
                return nums;
            var result = new int[r, c];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    var index = i * column + j + 1;
                    int newRow = (index - 1) / c;
                    int newColumn = index % c == 0 ? c - 1 : index % c - 1;
                    result[newRow, newColumn] = nums[i, j];
                }
            }
            return result;
        }
        #endregion

        #region 581. Shortest Unsorted Continuous Subarray
        //Given an integer array, you need to find one continuous subarray that if you only sort this subarray in ascending order, then the whole array will be sorted in ascending order, too.

        //You need to find the shortest such subarray and output its length.

        //Example 1:
        //Input: [2, 6, 4, 8, 10, 9, 15]
        //Output: 5
        //Explanation: You need to sort [6, 4, 8, 10, 9] in ascending order to make the whole array sorted in ascending order.
        //Note:
        //Then length of the input array is in range[1, 10, 000].
        //The input array may contain duplicates, so ascending order here means <=.
        public static int FindUnsortedSubarray(int[] nums)
        {
            int n = nums.Length, beg = -1, end = -2, min = nums[n - 1], max = nums[0];
            for (int i = 1; i < n; i++)
            {
                max = max > nums[i] ? max : nums[i];
                min = min < nums[n - 1 - i] ? min : nums[n - 1 - i];
                if (nums[i] < max) end = i;
                if (nums[n - 1 - i] > min) beg = n - 1 - i;
            }
            return end - beg + 1;
        }
        #endregion


    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
}

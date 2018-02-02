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

        #region 11. Container With Most Water
        //Given n non-negative integers a1, a2, ..., an, where each represents a point at coordinate(i, ai). n vertical lines are drawn such that the two endpoints of line i is at(i, ai) and(i, 0). Find two lines, which together with x-axis forms a container, such that the container contains the most water.

        //Note: You may not slant the container and n is at least 2.
        public static int MaxArea(int[] height)
        {
            int max = 0;
            for (int i = 0, j = height.Length - 1; i != j;)
            {
                int area = (j - i) * (height[i] < height[j] ? height[i] : height[j]);
                if (area > max)
                    max = area;
                if (height[i] > height[j])
                {
                    j--;
                }
                else
                {
                    i++;
                }
            }
            return max;
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

        #region 88. Merge Sorted Array
        //Given two sorted integer arrays nums1 and nums2, merge nums2 into nums1 as one sorted array.

        //Note:
        //You may assume that nums1 has enough space(size that is greater or equal to m + n) to hold additional elements from nums2.The number of elements initialized in nums1 and nums2 are m and n respectively.
        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int i = m - 1, j = n - 1, k = m + n - 1;
            while (i > -1 && j > -1) nums1[k--] = (nums1[i] > nums2[j]) ? nums1[i--] : nums2[j--];
            while (j > -1) nums1[k--] = nums2[j--];
        }

        #endregion

        #region 118. Pascal's Triangle
        //Given numRows, generate the first numRows of Pascal's triangle.

        //For example, given numRows = 5,
        //Return

        //[
        //     [1],
        //    [1,1],
        //   [1,2,1],
        //  [1,3,3,1],
        // [1,4,6,4,1]
        //]
        public static IList<IList<int>> Generate(int numRows)
        {
            var result = new List<IList<int>>();
            for (int i = 0; i < numRows; i++)
            {
                List<int> arr = new List<int>();
                for (int j = 0; j < i + 1; j++)
                {
                    if (i == 0)
                    {
                        arr.Add(j + 1);
                    }
                    else
                    {
                        int value = 0;
                        if (j - 1 >= 0 && result[i - 1].Count > j - 1)
                        {
                            value += result[i - 1][j - 1];
                        }
                        if (result[i - 1].Count > j)
                        {
                            value += result[i - 1][j];
                        }
                        arr.Add(value);
                    }
                }
                result.Add(arr);
            }
            return result;
        }
        #endregion

        #region 119. Pascal's Triangle II
        //Given an index k, return the kth row of the Pascal's triangle.

        //For example, given k = 3,
        //Return[1, 3, 3, 1].

        //Note:
        //Could you optimize your algorithm to use only O(k) extra space?
        public static IList<int> GetRow(int rowIndex)
        {
            var last = new List<int>();
            var result = new List<int>();
            for (int i = 0; i < rowIndex + 1; i++)
            {
                last.Clear();
                last.InsertRange(0, result);
                result.Clear();
                for (int j = 0; j < i + 1; j++)
                {
                    int value = 0;
                    if (j - 1 >= 0 && last.Count >= j)
                    {
                        value += last[j - 1];
                    }
                    if (last.Count >= j + 1)
                    {
                        value += last[j];
                    }
                    if (value == 0)
                        value = 1;
                    result.Add(value);
                }

            }
            return result;
        }
        #endregion

        #region 121. Best Time to Buy and Sell Stock
        //Say you have an array for which the ith element is the price of a given stock on day i.

        //If you were only permitted to complete at most one transaction(ie, buy one and sell one share of the stock), design an algorithm to find the maximum profit.
        public static int MaxProfit1(int[] prices)
        {
            int maxCur = 0, maxSoFar = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                maxCur += prices[i] - prices[i - 1];
                maxCur = 0 > maxCur ? 0 : maxCur;
                maxSoFar = maxCur > maxSoFar ? maxCur : maxSoFar;
            }
            return maxSoFar;
        }
        #endregion

        #region 122. Best Time to Buy and Sell Stock II
        //Say you have an array for which the ith element is the price of a given stock on day i.

        //Design an algorithm to find the maximum profit.You may complete as many transactions as you like (ie, buy one and sell one share of the stock multiple times). However, you may not engage in multiple transactions at the same time(ie, you must sell the stock before you buy again).
        public static int MaxProfit2(int[] prices)
        {
            int result = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] - prices[i - 1] > 0)
                    result += prices[i] - prices[i - 1];
            }


            return result;
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

        #region 167. Two Sum II - Input array is sorted
        //Given an array of integers that is already sorted in ascending order, find two numbers such that they add up to a specific target number.

        //The function twoSum should return indices of the two numbers such that they add up to the target, where index1 must be less than index2.Please note that your returned answers (both index1 and index2) are not zero-based.

        //You may assume that each input would have exactly one solution and you may not use the same element twice.

        //Input: numbers={ 2, 7, 11, 15}, target=9
        //Output: index1=1, index2=2
        public static int[] TwoSum2(int[] numbers, int target)
        {
            var dics = new Dictionary<int, int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (dics.ContainsKey(numbers[i]))
                {
                    return new int[] { dics[numbers[i]] + 1, i + 1 };
                }
                else
                {
                    dics[target - numbers[i]] = i;
                }
            }
            return null;
        }
        #endregion

        #region 169. Majority Element
        //Given an array of size n, find the majority element.The majority element is the element that appears more than ⌊ n/2 ⌋ times.

        //You may assume that the array is non-empty and the majority element always exist in the array.
        public static int MajorityElement(int[] nums)
        {
            int count = 0;
            int candidate = 0;
            foreach (int num in nums)
            {
                if (count == 0)
                    candidate = num;
                count += candidate == num ? 1 : -1;
            }
            return candidate;
        }
        #endregion

        #region 189. Rotate Array
        //Rotate an array of n elements to the right by k steps.

        //For example, with n = 7 and k = 3, the array [1,2,3,4,5,6,7] is rotated to [5,6,7,1,2,3,4].

        //Note:
        //Try to come up as many solutions as you can, there are at least 3 different ways to solve this problem.

        //[show hint]

        //Related problem: Reverse Words in a String II

        //Credits:
        //Special thanks to @Freezen for adding this problem and creating all test cases.
        public static void Rotate(int[] nums, int k)
        {
            k = k % nums.Length;
            if (k == 0)
                return;
            var move = new int[k];
            int count = k;
            for (int i = nums.Length - 1; count > 0; i--)
            {
                move[--count] = nums[i];
            }
            for (int i = nums.Length - k - 1; i >= 0; i--)
            {
                nums[i + k] = nums[i];
            }
            for (int i = 0; i < move.Length; i++)
            {
                nums[i] = move[i];
            }
        }
        #endregion

        #region 198. House Robber
        //You are a professional robber planning to rob houses along a street.Each house has a certain amount of money stashed, the only constraint stopping you from robbing each of them is that adjacent houses have security system connected and it will automatically contact the police if two adjacent houses were broken into on the same night.

        //Given a list of non-negative integers representing the amount of money of each house, determine the maximum amount of money you can rob tonight without alerting the police.
        public static int Rob(int[] nums)
        {
            int n = nums.Length;
            int oddSum = 0;
            int evenSum = 0;
            for (int i = 0; i < n; i++)
            {
                if (i % 2 == 0)
                {
                    evenSum = evenSum + nums[i] > oddSum ? evenSum + nums[i] : oddSum;
                }
                else
                {
                    oddSum = oddSum + nums[i] > evenSum ? oddSum + nums[i] : evenSum;
                }
            }
            return oddSum > evenSum ? oddSum : evenSum;
        }
        #endregion

        #region 216. Combination Sum III
        //Find all possible combinations of k numbers that add up to a number n, given that only numbers from 1 to 9 can be used and each combination should be a unique set of numbers.


        //Example 1:

        //Input: k = 3, n = 7
        public static IList<IList<int>> CombinationSum3(int k, int n)
        {
            var result = new List<IList<int>>();
            combination(result, new List<int>(), k, 1, n);
            return result;
        }

        private static void combination(List<IList<int>> ans, List<int> comb, int k, int start, int n)
        {
            if (comb.Count > k)
                return;
            if (comb.Count == k && n == 0)
            {
                var l = new List<int>();
                foreach (var c in comb)
                {
                    l.Add(c);
                }
                ans.Add(l);
                return;
            }
            for (int i = start; i <= 9; i++)
            {
                comb.Add(i);
                combination(ans, comb, k, i + 1, n - i);
                comb.RemoveAt(comb.Count - 1);
            }
        }
        #endregion 

        #region 217. Contains Duplicate
        //Given an array of integers, find if the array contains any duplicates.Your function should return true if any value appears at least twice in the array, and it should return false if every element is distinct.
        public static bool ContainsDuplicate(int[] nums)
        {
            var ex = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (ex.ContainsKey(num))
                    return true;
                ex[num] = 1;
            }
            return false;
        }
        #endregion

        #region 219. Contains Duplicate II
        //Given an array of integers and an integer k, find out whether there are two distinct indices i and j in the array such that nums[i] = nums[j] and the absolute difference between i and j is at most k.
        public static bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            var dic = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dic.ContainsKey(nums[i]) && (dic[nums[i]] - i >= 0 - k && dic[nums[i]] - i <= k))
                    return true;
                dic[nums[i]] = i;
            }
            return false;
        }
        #endregion

        #region 238. Product of Array Except Self
        //Given an array of n integers where n > 1, nums, return an array output such that output[i] is equal to the product of all the elements of nums except nums[i].

        //Solve it without division and in O(n).

        //For example, given[1, 2, 3, 4], return [24,12,8,6].

        //Follow up:
        //Could you solve it with constant space complexity? (Note: The output array does not count as extra space for the purpose of space complexity analysis.)
        public static int[] ProductExceptSelf(int[] nums)
        {
            int product = 1;
            int zeroCount = 0;
            foreach (var num in nums)
            {
                if (num != 0)
                    product *= num;
                else
                    zeroCount++;
            }
            var result = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                if (zeroCount == 0)
                    result[i] = product / nums[i];
                else if (zeroCount == 1)
                {
                    if (nums[i] != 0)
                        result[i] = 0;
                    else
                        result[i] = product;
                }
                else
                {
                    result[i] = 0;
                }
            }
            return result;
        }
        #endregion

        #region 268. Missing Number
        //Given an array containing n distinct numbers taken from 0, 1, 2, ..., n, find the one that is missing from the array.

        //Example 1

        //Input: [3,0,1]
        //Output: 2
        //Example 2

        //Input: [9,6,4,2,3,5,7,0,1]
        //Output: 8
        public static int MissingNumber(int[] nums)
        {
            int sum = (1 + nums.Length) * nums.Length / 2;
            int realSum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                realSum += nums[i];
            }
            return sum - realSum;
        }
        #endregion 

        #region 283. Move Zeroes
        //Given an array nums, write a function to move all 0's to the end of it while maintaining the relative order of the non-zero elements.

        //For example, given nums = [0, 1, 0, 3, 12], after calling your function, nums should be[1, 3, 12, 0, 0].

        //Note:
        //You must do this in-place without making a copy of the array.
        //Minimize the total number of operations.
        //Credits:
        //Special thanks to @jianchao.li.fighter for adding this problem and creating all test cases.
        public static void MoveZeroes(int[] nums)
        {
            int count = 0;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (nums[i] == 0)
                {
                    for (int j = i + 1; j < nums.Length - count; j++)
                    {
                        nums[j - 1] = nums[j];
                    }
                    nums[nums.Length - 1 - count] = 0;
                    count++;
                }
            }
        }
        #endregion

        #region 414. Third Maximum Number
        //Given a non-empty array of integers, return the third maximum number in this array.If it does not exist, return the maximum number.The time complexity must be in O(n).
        public static int ThirdMax(int[] nums)
        {
            int max1 = int.MinValue;
            int max2 = int.MinValue;
            int max3 = int.MinValue;
            int findCount = 0;
            bool minEnter = false;
            for (int i = 0; i < nums.Length; i++)
            {
                if (((max1 == nums[i] || max2 == nums[i] || max3 == nums[i]) && nums[i] != int.MinValue) || (nums[i] == int.MinValue && minEnter))
                    continue;
                if (nums[i] == int.MinValue)
                    minEnter = true;
                if (nums[i] > max1)
                {
                    max3 = max2;
                    max2 = max1;
                    max1 = nums[i];
                }
                else if (nums[i] > max2)
                {
                    max3 = max2;
                    max2 = nums[i];

                }
                else if (nums[i] > max3)
                {
                    max3 = nums[i];
                }
                findCount++;
            }
            if (findCount >= 3)
                return max3;
            else
                return max1;
        }
        #endregion

        #region 442. Find All Duplicates in an Array
        //Given an array of integers, 1 ≤ a[i] ≤ n(n = size of array), some elements appear twice and others appear once.

        //Find all the elements that appear twice in this array.

        //Could you do it without extra space and in O(n) runtime?
        public static IList<int> FindDuplicates(int[] nums)
        {
            var result = new List<int>();
            Array.Sort(nums);
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == nums[i - 1])
                {
                    result.Add(nums[i]);
                    i++;
                }
            }
            return result;
        }
        #endregion

        #region 448. Find All Numbers Disappeared in an Array
        //Given an array of integers where 1 ≤ a[i] ≤ n(n = size of array), some elements appear twice and others appear once.

        //Find all the elements of [1, n] inclusive that do not appear in this array.

        //Could you do it without extra space and in O(n) runtime? You may assume the returned list does not count as extra space.
        public static IList<int> FindDisappearedNumbers(int[] nums)
        {
            var result = new List<int>();
            int n = nums.Length;
            for (int i = 0; i < nums.Length; i++)
            {
                nums[(nums[i] - 1) % n] += n;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] <= n)
                    result.Add(i + 1);
            }
            return result;
        }
        #endregion

        #region 485. Max Consecutive Ones
        //Given a binary array, find the maximum number of consecutive 1s in this array.

        //Example 1:
        //Input: [1,1,0,1,1,1]
        //        Output: 3
        //Explanation: The first two digits or the last three digits are consecutive 1s.
        //    The maximum number of consecutive 1s is 3.
        //Note:

        //The input array will only contain 0 and 1.
        //The length of input array is a positive integer and will not exceed 10,000
        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            var max = 0;
            var currentSum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                    currentSum++;
                else
                {
                    if (currentSum > max)
                        max = currentSum;
                    currentSum = 0;
                }
            }
            if (currentSum > max)
                max = currentSum;
            return max;
        }
        #endregion

        #region 495. Teemo Attacking
        //In LOL world, there is a hero called Teemo and his attacking can make his enemy Ashe be in poisoned condition.Now, given the Teemo's attacking ascending time series towards Ashe and the poisoning time duration per Teemo's attacking, you need to output the total time that Ashe is in poisoned condition.

        //You may assume that Teemo attacks at the very beginning of a specific time point, and makes Ashe be in poisoned condition immediately.

        //Example 1:
        //Input: [1,4], 2
        //Output: 4
        //Explanation: At time point 1, Teemo starts attacking Ashe and makes Ashe be poisoned immediately. 
        //This poisoned status will last 2 seconds until the end of time point 2. 
        //And at time point 4, Teemo attacks Ashe again, and causes Ashe to be in poisoned status for another 2 seconds.
        //So you finally need to output 4.
        //Example 2:
        //Input: [1,2], 2
        //Output: 3
        //Explanation: At time point 1, Teemo starts attacking Ashe and makes Ashe be poisoned.
        //This poisoned status will last 2 seconds until the end of time point 2. 
        //However, at the beginning of time point 2, Teemo attacks Ashe again who is already in poisoned status. 
        //Since the poisoned status won't add up together, though the second poisoning attack will still work at time point 2, it will stop at the end of time point 3. 
        //So you finally need to output 3.
        //Note:
        //You may assume the length of given time series array won't exceed 10000.
        //You may assume the numbers in the Teemo's attacking time series and his poisoning time duration per attacking are non-negative integers, which won't exceed 10,000,000.
        public static int FindPoisonedDuration(int[] timeSeries, int duration)
        {
            int result = 0;
            for (int i = 1; i < timeSeries.Length; i++)
            {
                if (timeSeries[i] - timeSeries[i - 1] > duration)
                    result += duration;
                else
                    result += timeSeries[i] - timeSeries[i - 1];
            }
            if (timeSeries.Length > 0)
                result += duration;
            return result;
        }

        #endregion 

        #region 532. K-diff Pairs in an Array
        //Given an array of integers and an integer k, you need to find the number of unique k-diff pairs in the array.Here a k-diff pair is defined as an integer pair (i, j), where i and j are both numbers in the array and their absolute difference is k.

        //Example 1:
        //Input: [3, 1, 4, 1, 5], k = 2
        //Output: 2
        //Explanation: There are two 2-diff pairs in the array, (1, 3) and(3, 5).
        //Although we have two 1s in the input, we should only return the number of unique pairs.
        //Example 2:
        //Input:[1, 2, 3, 4, 5], k = 1
        //Output: 4
        //Explanation: There are four 1-diff pairs in the array, (1, 2), (2, 3), (3, 4) and(4, 5).
        //Example 3:
        //Input: [1, 3, 1, 5, 4], k = 0
        //Output: 1
        //Explanation: There is one 0-diff pair in the array, (1, 1).
        //Note:
        //The pairs(i, j) and(j, i) count as the same pair.
        //The length of the array won't exceed 10,000.
        //All the integers in the given input belong to the range: [-1e7, 1e7].
        public static int FindPairs(int[] nums, int k)
        {
            if (k < 0)
                return 0;
            var lowDic = new Dictionary<int, int>();
            var upDic = new Dictionary<int, int>();
            var result = new List<int>();
            foreach (var num in nums)
            {
                if (lowDic.ContainsKey(num))
                {
                    if (!result.Contains(num))
                        result.Add(num);
                }
                if (upDic.ContainsKey(num))
                {
                    if (!result.Contains(upDic[num]))
                        result.Add(upDic[num]);
                }
                lowDic[num - k] = num;
                upDic[num + k] = num;

            }
            return result.Count;
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

        #region 565. Array Nesting
        //A zero-indexed array A of length N contains all integers from 0 to N-1. Find and return the longest length of set S, where S[i] = {A[i], A[A[i]], A[A[A[i]]], ... }
        //subjected to the rule below.

        //    Suppose the first element in S starts with the selection of element A[i] of index = i, the next element in S should be A[A[i]], and then A[A[A[i]]]… By that analogy, we stop adding right before a duplicate element occurs in S.

        //    Example 1:
        //    Input: A = [5,4,0,3,1,6,2]
        //        Output: 6
        //    Explanation: 
        //    A[0] = 5, A[1] = 4, A[2] = 0, A[3] = 3, A[4] = 1, A[5] = 6, A[6] = 2.

        //    One of the longest S[K]:
        //    S[0] = {A[0], A[5], A[6], A[2]
        //    } = {5, 6, 2, 0}
        //    Note:
        //    N is an integer within the range[1, 20, 000].
        //The elements of A are all distinct.
        //Each element of A is an integer within the range[0, N - 1].
        public static int ArrayNesting(int[] nums)
        {
            int result = 0;
            var dic = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dic.ContainsKey(i))
                    continue;
                int index = i;
                int value = nums[i];
                int count = 1;
                while (value != index)
                {
                    dic[value] = 0;
                    value = nums[value];
                    count++;
                }
                if (count > result)
                    result = count;
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

        #region 605. Can Place Flowers
        //Suppose you have a long flowerbed in which some of the plots are planted and some are not.However, flowers cannot be planted in adjacent plots - they would compete for water and both would die.

        //Given a flowerbed(represented as an array containing 0 and 1, where 0 means empty and 1 means not empty), and a number n, return if n new flowers can be planted in it without violating the no-adjacent-flowers rule.

        //Example 1:
        //Input: flowerbed = [1, 0, 0, 0, 1], n = 1
        //Output: True
        //Example 2:
        //Input: flowerbed = [1, 0, 0, 0, 1], n = 2
        //Output: False
        //Note:
        //The input array won't violate no-adjacent-flowers rule.
        //The input array size is in the range of[1, 20000].
        //n is a non-negative integer which won't exceed the input array size.
        public static bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            if (n == 0)
                return true;
            for (int i = 0; i < flowerbed.Length; i++)
            {
                if (flowerbed[i] == 0 && (i - 1 < 0 || flowerbed[i - 1] != 1) && (i + 1 >= flowerbed.Length || flowerbed[i + 1] != 1))
                {
                    flowerbed[i] = 1;
                    i++;
                    n--;
                }

                if (n == 0)
                    break;
            }
            return n == 0;
        }
        #endregion

        #region 628. Maximum Product of Three Numbers
        //Given an integer array, find three numbers whose product is maximum and output the maximum product.

        //Example 1:
        //Input: [1,2,3]
        //Output: 6
        //Example 2:
        //Input: [1,2,3,4]
        //Output: 24
        public static int MaximumProduct(int[] nums)
        {
            int max1, max2, max3;
            max1 = max2 = max3 = int.MinValue;
            int min1, min2;
            min1 = min2 = int.MaxValue;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > max1)
                {
                    max3 = max2;
                    max2 = max1;
                    max1 = nums[i];
                }
                else if (nums[i] > max2)
                {
                    max3 = max2;
                    max2 = nums[i];
                }
                else if (nums[i] > max3)
                    max3 = nums[i];

                if (nums[i] < min1)
                {
                    min2 = min1;
                    min1 = nums[i];
                }
                else if (nums[i] < min2)
                    min2 = nums[i];

            }

            return max1 * max2 * max3 > min1 * min2 * max1 ? max1 * max2 * max3 : min1 * min2 * max1;
        }
        #endregion

        #region 643. Maximum Average Subarray I
        //Given an array consisting of n integers, find the contiguous subarray of given length k that has the maximum average value.And you need to output the maximum average value.

        //Example 1:
        //Input: [1,12,-5,-6,50,3], k = 4
        //Output: 12.75
        //Explanation: Maximum average is (12-5-6+50)/4 = 51/4 = 12.75
        //Note:
        //1 <= k <= n <= 30,000.
        //Elements of the given array will be in the range[-10, 000, 10, 000].
        public static double FindMaxAverage(int[] nums, int k)
        {
            double currentMax = int.MinValue;
            int beforesums = int.MinValue;
            for (int i = k - 1; i < nums.Length; i++)
            {

                int sum = 0;
                if (beforesums == int.MinValue)
                {
                    for (int j = 0; j < k; j++)
                    {
                        sum += nums[i - j];
                    }
                    beforesums = sum;
                }
                else
                {
                    sum = beforesums - nums[i - k];
                    sum += nums[i];
                    beforesums = sum;
                }

                if (sum > currentMax)
                    currentMax = sum;
            }
            return currentMax / (double)k;
        }
        #endregion

        #region 661. Image Smoother
        //Given a 2D integer matrix M representing the gray scale of an image, you need to design a smoother to make the gray scale of each cell becomes the average gray scale(rounding down) of all the 8 surrounding cells and itself.If a cell has less than 8 surrounding cells, then use as many as you can.


        //Example 1:
        //Input:
        //[[1,1,1],
        //[1,0,1],
        //[1,1,1]]
        //Output:
        //[[0, 0, 0],
        // [0, 0, 0],
        // [0, 0, 0]]
        //Explanation:
        //For the point(0,0), (0,2), (2,0), (2,2): floor(3/4) = floor(0.75) = 0
        //For the point(0,1), (1,0), (1,2), (2,1): floor(5/6) = floor(0.83333333) = 0
        //For the point(1,1): floor(8/9) = floor(0.88888889) = 0
        //Note:
        //The value in the given matrix is in the range of[0, 255].
        //The length and width of the given matrix are in the range of[1, 150].
        public static int[,] ImageSmoother(int[,] M)
        {
            int[,] result = new int[M.GetLength(0), M.GetLength(1)];
            for (int i = 0; i < M.GetLength(0); i++)
            {
                for (int j = 0; j < M.GetLength(1); j++)
                {
                    int value = 0;
                    int count = 0;
                    value += M[i, j];
                    count++;
                    if (i - 1 >= 0)
                    {
                        value += M[i - 1, j];
                        count++;
                    }
                    if (j - 1 >= 0)
                    {
                        value += M[i, j - 1];
                        count++;
                    }
                    if (i + 1 < M.GetLength(0))
                    {
                        value += M[i + 1, j];
                        count++;
                    }
                    if (j + 1 < M.GetLength(1))
                    {
                        value += M[i, j + 1];
                        count++;
                    }
                    if (i - 1 >= 0 && j - 1 >= 0)
                    {
                        value += M[i - 1, j - 1];
                        count++;
                    }
                    if (i - 1 >= 0 && j + 1 < M.GetLength(1))
                    {
                        value += M[i - 1, j + 1];
                        count++;
                    }
                    if (i + 1 < M.GetLength(0) && j - 1 >= 0)
                    {
                        value += M[i + 1, j - 1];
                        count++;
                    }
                    if (i + 1 < M.GetLength(0) && j + 1 < M.GetLength(1))
                    {
                        value += M[i + 1, j + 1];
                        count++;
                    }
                    value = value / count;
                    result[i, j] = value;
                }
            }
            return result;
        }
        #endregion

        #region 665. Non-decreasing Array
        //Given an array with n integers, your task is to check if it could become non-decreasing by modifying at most 1 element.

        //We define an array is non-decreasing if array[i] <= array[i + 1] holds for every i(1 <= i<n).

        //Example 1:
        //Input: [4,2,3]
        //        Output: True
        //        Explanation: You could modify the first 4 to 1 to get a non-decreasing array.
        //        Example 2:
        //Input: [4,2,1]
        //Output: False
        //        Explanation: You can't get a non-decreasing array by modify at most one element.
        //Note: The n belongs to [1, 10,000].
        public static bool CheckPossibility(int[] nums)
        {
            int count = 0;
            for (int i = 1; i < nums.Length - 1; i++)
            {
                if (nums[i] < nums[i - 1])
                {
                    if (i - 2 >= 0 && nums[i] > nums[i - 2])
                        nums[i - 1] = nums[i - 2];
                    else if (i - 2 < 0)
                        nums[i - 1] = 1;
                    else
                        nums[i] = nums[i - 1];
                    count++;
                }
                if (count > 1)
                    return false;
            }
            if (count == 1 && nums[nums.Length - 1] < nums[nums.Length - 2])
                return false;
            return true;
        }
        #endregion

        #region 667. Beautiful Arrangement II
        //Given two integers n and k, you need to construct a list which contains n different positive integers ranging from 1 to n and obeys the following requirement: 
        //Suppose this list is [a1, a2, a3, ... , an], then the list[| a1 - a2 |, | a2 - a3 |, | a3 - a4 |, ... , | an - 1 - an |] has exactly k distinct integers.

        //If there are multiple answers, print any of them.

        //Example 1:
        //Input: n = 3, k = 1
        //Output: [1, 2, 3]
        //Explanation: The[1, 2, 3] has three different positive integers ranging from 1 to 3, and the [1, 1] has exactly 1 distinct integer: 1.
        //Example 2:
        //Input: n = 3, k = 2
        //Output: [1, 3, 2]
        //Explanation: The[1, 3, 2] has three different positive integers ranging from 1 to 3, and the [2, 1] has exactly 2 distinct integers: 1 and 2.
        //Note:
        //The n and k are in the range 1 <= k<n <= 104.
        public static int[] ConstructArray(int n, int k)
        {
            int[] res = new int[n];
            for (int i = 0, l = 1, r = n; l <= r; i++)
                res[i] = k > 1 ? (k-- % 2 != 0 ? l++ : r--) : l++;
            return res;
        }
        #endregion

        #region 674. Longest Continuous Increasing Subsequence
        //Given an unsorted array of integers, find the length of longest continuous increasing subsequence(subarray).

        //Example 1:
        //Input: [1,3,5,4,7]
        //        Output: 3
        //Explanation: The longest continuous increasing subsequence is [1,3,5], its length is 3. 
        //Even though[1, 3, 5, 7] is also an increasing subsequence, it's not a continuous one where 5 and 7 are separated by 4. 
        //Example 2:
        //Input: [2,2,2,2,2]
        //        Output: 1
        //Explanation: The longest continuous increasing subsequence is [2], its length is 1. 
        //Note: Length of the array will not exceed 10,000.
        public static int FindLengthOfLCIS(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            int result = 0;
            int currentMax = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > nums[i - 1])
                    currentMax++;
                else
                {
                    if (currentMax > result)
                        result = currentMax;
                    currentMax = 1;
                }

            }
            if (currentMax > result)
                result = currentMax;
            return result;
        }
        #endregion  

        #region 695. Max Area of Island
        //Given a non-empty 2D array grid of 0's and 1's, an island is a group of 1's (representing land) connected 4-directionally (horizontal or vertical.) You may assume all four edges of the grid are surrounded by water.

        //Find the maximum area of an island in the given 2D array. (If there is no island, the maximum area is 0.)

        //Example 1:
        //[[0,0,1,0,0,0,0,1,0,0,0,0,0],
        // [0,0,0,0,0,0,0,1,1,1,0,0,0],
        // [0,1,1,0,1,0,0,0,0,0,0,0,0],
        // [0,1,0,0,1,1,0,0,1,0,1,0,0],
        // [0,1,0,0,1,1,0,0,1,1,1,0,0],
        // [0,0,0,0,0,0,0,0,0,0,1,0,0],
        // [0,0,0,0,0,0,0,1,1,1,0,0,0],
        // [0,0,0,0,0,0,0,1,1,0,0,0,0]]
        //Given the above grid, return 6. Note the answer is not 11, because the island must be connected 4-directionally.
        //Example 2:
        //[[0,0,0,0,0,0,0,0]]
        //Given the above grid, return 0.
        //Note: The length of each dimension in the given grid does not exceed 50.
        public static int MaxAreaOfIsland(int[,] grid)
        {
            var max = 0;
            for (int row = 0; row < grid.GetLength(0); row++)
            {
                for (int column = 0; column < grid.GetLength(1); column++)
                {
                    if (grid[row, column] == 1)
                    {
                        var area = MaxAreaOfIsland(grid, row, column);
                        max = max > area ? max : area;
                    }


                }
            }
            return max;
        }

        public static int MaxAreaOfIsland(int[,] grid, int row, int column)
        {
            if (row < 0 || row >= grid.GetLength(0) || column < 0 || column >= grid.GetLength(1) || grid[row, column] == 0)
            {
                return 0;
            }
            grid[row, column] = 0;
            return 1 + MaxAreaOfIsland(grid, row - 1, column) + MaxAreaOfIsland(grid, row + 1, column) + MaxAreaOfIsland(grid, row, column - 1)
                + MaxAreaOfIsland(grid, row, column + 1);
        }
        #endregion

        #region 697. Degree of an Array
        //Given a non-empty array of non-negative integers nums, the degree of this array is defined as the maximum frequency of any one of its elements.

        //Your task is to find the smallest possible length of a (contiguous) subarray of nums, that has the same degree as nums.

        //Example 1:
        //Input: [1, 2, 2, 3, 1]
        //Output: 2
        //Explanation: 
        //The input array has a degree of 2 because both elements 1 and 2 appear twice.
        //Of the subarrays that have the same degree:
        //[1, 2, 2, 3, 1], [1, 2, 2, 3], [2, 2, 3, 1], [1, 2, 2], [2, 2, 3], [2, 2]
        //The shortest length is 2. So return 2.
        //Example 2:
        //Input: [1,2,2,3,1,4,2]
        //Output: 6
        //Note:

        //nums.length will be between 1 and 50,000.
        //nums[i] will be an integer between 0 and 49,999.
        public static int FindShortestSubArray(int[] nums)
        {
            var frenquency = new Dictionary<int, int>();
            var startIndex = new Dictionary<int, int>();
            var endIndex = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (frenquency.ContainsKey(nums[i]))
                {
                    frenquency[nums[i]]++;
                    endIndex[nums[i]] = i;
                }
                else
                {
                    frenquency[nums[i]] = 1;
                    startIndex[nums[i]] = i;
                    endIndex[nums[i]] = i;
                }
            }


            int maxCount = 0;
            foreach (var value in frenquency.Values)
            {
                if (value > maxCount)
                    maxCount = value;
            }
            var maxList = frenquency.Where(x => x.Value == maxCount).Select(x => x.Key).ToList();
            int result = int.MaxValue;
            foreach (var max in maxList)
            {
                if (endIndex[max] - startIndex[max] + 1 < result)
                {
                    result = endIndex[max] - startIndex[max] + 1;
                }
            }
            return result;
        }
        #endregion

        #region 714. Best Time to Buy and Sell Stock with Transaction Fee
        //Your are given an array of integers prices, for which the i-th element is the price of a given stock on day i; and a non-negative integer fee representing a transaction fee.

        //You may complete as many transactions as you like, but you need to pay the transaction fee for each transaction.You may not buy more than 1 share of a stock at a time (ie.you must sell the stock share before you buy again.)

        //Return the maximum profit you can make.

        //Example 1:
        //Input: prices = [1, 3, 2, 8, 4, 9], fee = 2
        //Output: 8
        //Explanation: The maximum profit can be achieved by:
        //Buying at prices[0] = 1
        //Selling at prices[3] = 8
        //Buying at prices[4] = 4
        //Selling at prices[5] = 9
        //The total profit is ((8 - 1) - 2) + ((9 - 4) - 2) = 8.
        //Note:

        //0 < prices.length <= 50000.
        //0 < prices[i] < 50000.
        //0 <= fee< 50000.
        public static int MaxProfit(int[] prices, int fee)
        {
            int cash = 0, hold = -prices[0];
            for (int i = 1; i < prices.Length; i++)
            {
                cash = cash > hold + prices[i] - fee ? cash : hold + prices[i] - fee;
                hold = hold > cash - prices[i] ? hold : cash - prices[i];
            }
            return cash;
        }
        #endregion

        #region 717. 1-bit and 2-bit Characters
        //We have two special characters.The first character can be represented by one bit 0. The second character can be represented by two bits(10 or 11).

        //Now given a string represented by several bits.Return whether the last character must be a one-bit character or not.The given string will always end with a zero.

        //Example 1:
        //Input: 
        //bits = [1, 0, 0]
        //Output: True
        //Explanation: 
        //The only way to decode it is two-bit character and one-bit character. So the last character is one-bit character.
        //Example 2:
        //Input: 
        //bits = [1, 1, 1, 0]
        //Output: False
        //Explanation: 
        //The only way to decode it is two-bit character and two-bit character. So the last character is NOT one-bit character.
        //Note:

        //1 <= len(bits) <= 1000.
        //bits[i] is always 0 or 1.
        public static bool IsOneBitCharacter(int[] bits)
        {
            int n = bits.Length;
            int position = 0;
            while (position < n - 1)
            {
                if (bits[position] == 0)
                    position++;
                else
                    position += 2;
            }
            return position == n - 1;

        }
        #endregion

        #region 724. Find Pivot Index
        //Given an array of integers nums, write a method that returns the "pivot" index of this array.

        //We define the pivot index as the index where the sum of the numbers to the left of the index is equal to the sum of the numbers to the right of the index.

        //If no such index exists, we should return -1. If there are multiple pivot indexes, you should return the left-most pivot index.

        //Example 1:
        //Input: 
        //nums = [1, 7, 3, 6, 5, 6]
        //        Output: 3
        //Explanation: 
        //The sum of the numbers to the left of index 3 (nums[3] = 6) is equal to the sum of numbers to the right of index 3.
        //Also, 3 is the first index where this occurs.
        //Example 2:
        //Input: 
        //nums = [1, 2, 3]
        //        Output: -1
        //Explanation: 
        //There is no index that satisfies the conditions in the problem statement.
        //Note:

        //The length of nums will be in the range[0, 10000].
        //Each element nums[i] will be an integer in the range[-1000, 1000].
        public static int PivotIndex(int[] nums)
        {
            int sum = 0;
            foreach (int num in nums)
            {
                sum += num;
            }
            int leftSum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (sum - leftSum - nums[i] == leftSum)
                    return i;
                leftSum += nums[i];
            }
            return -1;
        }
        #endregion

        #region 740. Delete and Earn
        //Given an array nums of integers, you can perform operations on the array.

        //In each operation, you pick any nums[i] and delete it to earn nums[i] points.After, you must delete every element equal to nums[i] - 1 or nums[i] + 1.

        //You start with 0 points.Return the maximum number of points you can earn by applying such operations.

        //Example 1:
        //Input: nums = [3, 4, 2]
        //Output: 6
        //Explanation: 
        //Delete 4 to earn 4 points, consequently 3 is also deleted.
        //Then, delete 2 to earn 2 points. 6 total points are earned.
        //Example 2:
        //Input: nums = [2, 2, 3, 3, 3, 4]
        //Output: 9
        //Explanation: 
        //Delete 3 to earn 3 points, deleting both 2's and the 4.
        //Then, delete 3 again to earn 3 points, and 3 again to earn 3 points.
        //9 total points are earned.
        //Note:

        //The length of nums is at most 20000.
        //Each element nums[i] is an integer in the range [1, 10000].
        public static int DeleteAndEarn(int[] nums)
        {
            var result = 0;

            var sums = new int[10001];

            for (int i = 0; i < nums.Length; i++)
            {
                sums[nums[i]] += nums[i];
            }

            int oddSum = 0;
            int evenSum = 0;
            for (int key = 0; key < sums.Length; key++)
            {
                if (key % 2 == 0)
                {
                    evenSum = evenSum + sums[key] > oddSum ? evenSum + sums[key] : oddSum;
                }
                else
                {
                    oddSum = oddSum + sums[key] > evenSum ? oddSum + sums[key] : evenSum;
                }
            }

            result = oddSum > evenSum ? oddSum : evenSum;

            return result;
        }

        #endregion

        #region 744. Find Smallest Letter Greater Than Target
        //Given a list of sorted characters letters containing only lowercase letters, and given a target letter target, find the smallest element in the list that is larger than the given target.

        //Letters also wrap around.For example, if the target is target = 'z' and letters = ['a', 'b'], the answer is 'a'.

        //Examples:
        //Input:
        //letters = ["c", "f", "j"]
        //target = "a"
        //Output: "c"

        //Input:
        //letters = ["c", "f", "j"]
        //target = "c"
        //Output: "f"

        //Input:
        //letters = ["c", "f", "j"]
        //target = "d"
        //Output: "f"

        //Input:
        //letters = ["c", "f", "j"]
        //target = "g"
        //Output: "j"

        //Input:
        //letters = ["c", "f", "j"]
        //target = "j"
        //Output: "c"

        //Input:
        //letters = ["c", "f", "j"]
        //target = "k"
        //Output: "c"
        //Note:
        //letters has a length in range[2, 10000].
        //letters consists of lowercase letters, and contains at least 2 unique letters.
        //target is a lowercase letter.
        public static char NextGreatestLetter(char[] letters, char target)
        {

            foreach (var letter in letters)
            {
                if (letter > target)
                    return letter;
            }
            return letters[0];
        }
        #endregion

        #region 746. Min Cost Climbing Stairs
        //On a staircase, the i-th step has some non-negative cost cost[i] assigned(0 indexed).

        //Once you pay the cost, you can either climb one or two steps.You need to find minimum cost to reach the top of the floor, and you can either start from the step with index 0, or the step with index 1.

        //Example 1:
        //Input: cost = [10, 15, 20]
        //Output: 15
        //Explanation: Cheapest is start on cost[1], pay that cost and go to the top.
        //Example 2:
        //Input: cost = [1, 100, 1, 1, 1, 100, 1, 1, 100, 1]
        //Output: 6
        //Explanation: Cheapest is start on cost[0], and only step on 1s, skipping cost[3].
        //Note:
        //cost will have a length in the range [2, 1000].
        //Every cost[i] will be an integer in the range [0, 999].
        public static int MinCostClimbingStairs(int[] cost)
        {
            int f1 = 0, f2 = 0;
            for (int i = cost.Length - 1; i >= 0; i--)
            {
                int f0 = cost[i] + (f1 < f2 ? f1 : f2);
                f2 = f1;
                f1 = f0;
            }
            return f1 < f2 ? f1 : f2;
        }
        #endregion

        #region 747. Largest Number At Least Twice of Others
        //In a given integer array nums, there is always exactly one largest element.

        //Find whether the largest element in the array is at least twice as much as every other number in the array.

        //If it is, return the index of the largest element, otherwise return -1.

        //Example 1:
        //Input: nums = [3, 6, 1, 0]
        //Output: 1
        //Explanation: 6 is the largest integer, and for every other number in the array x,
        //6 is more than twice as big as x.The index of value 6 is 1, so we return 1.
        //Example 2:
        //Input: nums = [1, 2, 3, 4]
        //Output: -1
        //Explanation: 4 isn't at least as big as twice the value of 3, so we return -1.
        //Note:
        //nums will have a length in the range [1, 50].
        //Every nums[i] will be an integer in the range [0, 99].
        public static int DominantIndex(int[] nums)
        {
            int max = -1; int maxIndex = -1;
            int secMax = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > max)
                {
                    secMax = max;
                    max = nums[i];
                    maxIndex = i;
                }
                if (nums[i] > secMax && nums[i] < max)
                    secMax = nums[i];
            }
            if (max >= secMax * 2)
                return maxIndex;
            else
                return -1;
        }
        #endregion

        #region 760. Find Anagram Mappings
        //Given two lists Aand B, and B is an anagram of A.B is an anagram of A means B is made by randomizing the order of the elements in A.

        //We want to find an index mapping P, from A to B. A mapping P[i] = j means the ith element in A appears in B at index j.

        //These lists A and B may contain duplicates. If there are multiple answers, output any of them.

        //For example, given

        //A = [12, 28, 46, 32, 50]
        //B = [50, 12, 32, 46, 28]
        //We should return
        //[1, 4, 3, 2, 0]
        //as P[0] = 1 because the 0th element of A appears at B[1], and P[1] = 4 because the 1st element of A appears at B[4], and so on.
        //Note:

        //A, B have equal lengths in range[1, 100].
        //A[i], B[i] are integers in range[0, 10 ^ 5].
        public static int[] AnagramMappings(int[] A, int[] B)
        {
            int[] result = new int[A.Length];
            for (int i = 0; i < A.Length; i++)
            {
                for (int j = 0; j < B.Length; j++)
                {
                    if (A[i] == B[j] && !result.Contains(j))
                    {
                        result[i] = j;
                    }
                }
            }
            return result;
        }
        #endregion

        #region 766. Toeplitz Matrix
        //A matrix is Toeplitz if every diagonal from top-left to bottom-right has the same element.

        //Now given an M x N matrix, return True if and only if the matrix is Toeplitz.


        //Example 1:

        //Input: matrix = [[1,2,3,4],[5,1,2,3],[9,5,1,2]]
        //Output: True
        //Explanation:
        //1234
        //5123
        //9512

        //In the above grid, the diagonals are "[9]", "[5, 5]", "[1, 1, 1]", "[2, 2, 2]", "[3, 3]", "[4]", and in each diagonal all elements are the same, so the answer is True.
        //Example 2:

        //Input: matrix = [[1,2],[2,2]]
        //Output: False
        //Explanation:
        //The diagonal "[1, 2]" has different elements.
        //Note:

        //matrix will be a 2D array of integers.
        //matrix will have a number of rows and columns in range[1, 20].
        //matrix[i][j] will be integers in range[0, 99].
        public static bool IsToeplitzMatrix(int[,] matrix)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int value = matrix[i, j];
                    int row = i + 1;
                    int column = j + 1;
                    while (row < m && column < n)
                    {
                        if (matrix[row, column] != value)
                            return false;
                        row++;
                        column++;
                    }
                }
            }
            return true; ;
        }
        #endregion

        #region 769. Max Chunks To Make Sorted
        //Given an array arr that is a permutation of[0, 1, ..., arr.length - 1], we split the array into some number of "chunks" (partitions), and individually sort each chunk.After concatenating them, the result equals the sorted array.

        //What is the most number of chunks we could have made?

        //Example 1:


        //Input: arr = [4, 3, 2, 1, 0]
        //Output: 1
        //Explanation:
        //Splitting into two or more chunks will not return the required result.
        //For example, splitting into [4, 3], [2, 1, 0] will result in [3, 4, 0, 1, 2], which isn't sorted.
        //Example 2:


        //Input: arr = [1, 0, 2, 3, 4]
        //Output: 4
        //Explanation:
        //We can split into two chunks, such as [1, 0], [2, 3, 4].
        //However, splitting into [1, 0], [2], [3], [4] is the highest number of chunks possible.
        //Note:


        //arr will have length in range[1, 10].
        //arr[i] will be a permutation of [0, 1, ..., arr.length - 1].
        public static int MaxChunksToSorted(int[] arr)
        {
            int ans = 0, max = 0;
            for (int i = 0; i < arr.Length; ++i)
            {
                max = max > arr[i] ? max : arr[i];
                if (max == i) ans++;
            }
            return ans;
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

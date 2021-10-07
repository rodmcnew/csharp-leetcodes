// https://leetcode.com/problems/two-sum/

// Compared to the  solution further below, this one uses about 500KB less memory but may be harder to understand. It is the same speed.
public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        // Create an array of the num indicies sorted by num value.
        // This gives us a sorted view of the nums while retaining their original indicies.
        var sortedIndicies = Enumerable.Range(0, nums.Length).OrderBy(i => nums[i]).ToArray();
        
        // Start with a pointer on each side of the sorted nums       
        // Then move the left and right pointers inward until we find the match
        int left = 0;
        int right = sortedIndicies.Length - 1;
        while(left < right) {
            int leftI = sortedIndicies[left];
            int rightI = sortedIndicies[right];
            int sum = nums[leftI] + nums[rightI];
            if(sum > target) {
                right--;
            } else if (sum < target) {
                left++;
            } else {
                return new int[] {leftI, rightI};
            }
        }
        
        // The requirements say there is always a solution so throw if its not true.
        throw new ArgumentException("No solution found");
    }
}




//////// Another older solution below ////////




public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        // Get the nums into a data structure that we can sort while remembering their indicies
        var sortedNums = nums.Select((Value, Index) => new { Value, Index }).OrderBy(num => num.Value).ToArray();
        
        // Start with a pointer on each side of the sorted nums       
        // Then move the left and right pointers inward until we find the match
        int left = 0;
        int right = sortedNums.Length - 1;
        while(left < right) {
            int sum = sortedNums[left].Value + sortedNums[right].Value;
            if(sum > target) {
                right--;
            } else if (sum < target) {
                left++;
            } else {
                return new int[] {sortedNums[left].Index, sortedNums[right].Index};
            }
        }
        
        // The requirements say there is always a solution so throw if its not true.
        throw new ArgumentException("No solution found");
    }
}

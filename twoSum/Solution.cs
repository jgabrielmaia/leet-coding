namespace Leet {
    public class Solution {
        public int[] SumToTarget(int[] nums, int target) 
        {
            return calculate(nums, target);
        }

        private int[] calculate(int[] nums, int target)
        {
            var firstHalf = new int[nums.Length / 2];
            var secondHalf = new int[nums.Length / 2];

            for (int i = 0; i < nums.Length / 2; i++) 
            {
                firstHalf[i] = nums[i];    
            }
            int j=0;
            for (int i = nums.Length / 2; i < nums.Length; i++) 
            {
                secondHalf[j++] = nums[i];
            }

            var indexes = compareTwoArrays(firstHalf, secondHalf, target);
            
            if (indexes[0] == -1 || indexes[1] == -1) 
            {
                calculate(firstHalf, target);
                calculate(secondHalf, target);
            }

            return indexes;                
        }

        private int[] compareTwoArrays(int[] first, int[] second, int target) 
        {
            var count = 0;
            for(int i = 0; i < first.Length; i++)
            {
                if((first[i] + second[count++]) == target)
                {
                    return new int[]{i, count};
                }
            }
            return new int[]{-1, -1};
        }
    }
}
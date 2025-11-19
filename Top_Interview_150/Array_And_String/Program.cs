// leetcode solutions for top 150 interview array & strings

// solution for merging 2 sorted arrays
void MergeSortedArray(int[] nums1, int m, int[] nums2, int n) 
{
    int p1 = m - 1; // end of nums1
    int p2 = n - 1; // end of nums2
    int i = nums1.Length - 1; // end of entire array
    // while nums2 has not been fully added to nums1
    while(p2 >= 0)
    {
        // if pointers pointing to a value 
        // if pointer 1 val greater than pointer 2 val
        if(p1 >= 0 && nums1[p1] > nums2[p2])
        {
            nums1[i--] = nums1[p1--];
        }
        else
        {
            nums1[i--] = nums2[p2--];
        }
    }
}

// solution for removing element val from array
int RemoveElement(int[] nums, int val) 
{
    // count & pointer
    int count = 0;
    int p1 = 0;
    for(int i = 0; i < nums.Length; i++)
    {
        // if val keep pointer there until not val then copy to pointer
        if(nums[i] != val)
        {
            // pointer increments after new assignment
            nums[p1++] = nums[i];
            count++;
        }
    }
    return count;
}

// solution for removing duplicates from sorted array
int RemoveDuplicatesSortedArray(int[] nums) 
{
    int i = 0;
    for(int j = 1; j < nums.Length; j++)
    {
        if(nums[i] != nums[j])
        {
            nums[++i] = nums[j];
        }
    }
    return i + 1;
}

// solution for majority element
// if val in array occours more than target return val
int MajorityElement(int[] nums) 
{
    int target = nums.Length / 2;
    int count = 0;
    // go through every element
    for(int i = 0; i < nums.Length; i++)
    {
        // count each element starting from back to front
        for(int j = nums.Length - 1; j >= 0; j--)
        {
            if(nums[i] == nums[j]) count++;
        }
        if(count > target) return nums[i];
        count = 0;
    }
    return 0;
}
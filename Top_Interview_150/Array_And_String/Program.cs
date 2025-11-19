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
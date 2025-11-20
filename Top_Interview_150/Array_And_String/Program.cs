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
        if(p1 >= 0 && nums1[p1] > nums2[p2]) nums1[i--] = nums1[p1--];
        else nums1[i--] = nums2[p2--];
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
        if(nums[i] != nums[j]) nums[++i] = nums[j];
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
        for(int j = nums.Length - 1; j >= 0; j--) if(nums[i] == nums[j]) count++;
        if(count > target) return nums[i];
        count = 0;
    }
    return 0;
}

// solution for best time to buy and sell stock
int MaxProfit(int[] prices) 
{
    int buy = prices[0];
    int profit = 0;
    for(int i = 1; i < prices.Length; i++)
    {
        // new lowest buy
        if(prices[i] < buy)
        {
            buy = prices[i]; 
            continue; // cant sell on same day
        }
        // if selling on this day gives bigger profit
        if(prices[i] - buy > profit) profit = prices[i] - buy;
    }
    if(profit < 1) return 0;
    return profit;
}

// solution for length of last word
// could use for loop from end of array 
int LengthOfLastWord(string s) 
{
    string[] words = s.Split(" ");
    int answer = 0;
    foreach(string word in words) if(word.Length != 0) answer = word.Length;
    return answer;
}

// solution for converting roman to intiger
int RomanToInt(string s) 
{
    // mapping all possible chars with the val
    Dictionary<char, int> dict = new Dictionary<char, int>
    {
        {'I', 1},
        {'V', 5},
        {'X', 10},
        {'L', 50},
        {'C', 100},
        {'D', 500},
        {'M', 1000}
    };
    int answer = 0;
    int current = 0;
    int previous = 0;
    for(int i = s.Length - 1; i >= 0; i--)
    {
        current = dict[s[i]];
        if(current < previous) answer -= current;
        else answer += current;
        previous = current;
    }
    return answer;
}

// solution for longest common prefix
// start with first char as current
// if all char at current pos in strings is same add to prefix
// else return prefix
string LongestCommonPrefix(string[] strs) 
{
    string prefix = "";
    foreach(string s in strs) if(s.Length <= 0) return prefix; // end before its begun
    char current = strs[0][0];
    for(int i = 0; i < strs[0].Length; i++)
    {
        current = strs[0][i];
        foreach(string s in strs) if(i >= s.Length || s[i] != current) return prefix;
        prefix += current;
    }
    return prefix;
}

// solution for Find the Index of the First Occurrence in a String
int StrStr(string haystack, string needle) 
{
    int p1 = 0;
    for(int i = 0; i < haystack.Length; i++)
    {
        // if first chars match check the rest
        if(haystack[i] == needle[0])
        {
            p1 = i;
            // if index is going out of range return wrong
            // if current chars dont match break
            // if j == needle length - 1 return answer
            for(int j = 0; j < needle.Length; j++, p1++)
            {
                if(p1 >= haystack.Length) return -1;
                if(haystack[p1] != needle[j]) break;
                if(j == needle.Length - 1) return i;
            }
        }
    }
    return -1;
}

// solution for is palindrome
bool IsPalindrome(string s) 
{
    int left = 0;
    int right = s.Length - 1;
    while(left < right)
    {
        // move left & right until its a char 
        while(left < right && !char.IsLetterOrDigit(s[left])) left++;
        while(left < right && !char.IsLetterOrDigit(s[right])) right--;
        // if not the same false
        if(char.ToLower(s[left]) != char.ToLower(s[right])) return false;
        left++;
        right--;
    }
    return true;
}

// solution for is subsequence 
// is s in t 
// s chars do not have to be next to eacher just in order
bool IsSubsequence(string s, string t) {
    int p1 = 0;
    int p2 = 0;
    // while s has not been found
    while(p1 < s.Length)
    {
        // while t has not been finished and s & t != eachother rn
        while(p2 < t.Length && s[p1] != t[p2]) p2++;
        if(p2 == t.Length) return false;
        if(s[p1] == t[p2])
        {
            p1++;
            p2++;
        }
    }
    return true;
}
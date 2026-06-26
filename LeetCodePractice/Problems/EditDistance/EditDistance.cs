namespace LeetCodePractice.Problems;

/// <summary>
/// Edit Distance
/// 對應 LeetCode：LC 72
/// 來源：NeetCode 150
/// 難度：Medium
///
/// Given two strings `word1` and `word2`, return the minimum number of operations required to convert `word1` to `word2`.
/// 
/// You have the following three operations permitted on a word:
/// 
/// 	  - Insert a character
/// 
/// 	  - Delete a character
/// 
/// 	  - Replace a character
/// 
///  
/// 
/// Example 1:
/// 
/// Input: word1 = "horse", word2 = "ros"
/// Output: 3
/// Explanation: 
/// horse -> rorse (replace 'h' with 'r')
/// rorse -> rose (remove 'r')
/// rose -> ros (remove 'e')
/// 
/// Example 2:
/// 
/// Input: word1 = "intention", word2 = "execution"
/// Output: 5
/// Explanation: 
/// intention -> inention (remove 't')
/// inention -> enention (replace 'i' with 'e')
/// enention -> exention (replace 'n' with 'x')
/// exention -> exection (replace 'n' with 'c')
/// exection -> execution (insert 'u')
/// 
///  
/// 
/// Constraints:
/// 
/// 	  - `0 <= word1.length, word2.length <= 500`
/// 
/// 	  - `word1` and `word2` consist of lowercase English letters.
/// </summary>
public class EditDistance
{
    public int Solve(string word1, string word2)
    {
        throw new NotImplementedException();
    }
}




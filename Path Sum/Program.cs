using System;
using System.Collections.Generic;

namespace Path_Sum
{
  class Program
  {
    static void Main(string[] args)
    {
      TreeNode root = new TreeNode(5);
      root.left = new TreeNode(4);
      root.left.left = new TreeNode(11);
      root.left.left.left = new TreeNode(7);
      root.left.left.right = new TreeNode(2);

      root.right = new TreeNode(8);
      root.right.left = new TreeNode(13);
      root.right.right = new TreeNode(4);
      root.right.right.right = new TreeNode(1);

      Solution s = new Solution();
      var answer = s.HasPathSum_(root, 22);
      Console.WriteLine(answer);
    }
  }

  public class TreeNode
  {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
      this.val = val;
      this.left = left;
      this.right = right;
    }
  }

  public class Solution
  {
    public bool HasPathSum(TreeNode root, int targetSum)
    {
      if (root == null) return false;
      Queue<(TreeNode, int)> q = new Queue<(TreeNode, int)>();
      q.Enqueue((root, targetSum - root.val));
      while (q.Count > 0)
      {
        var (node, sum) = q.Dequeue();
        if (node.left == null && node.right == null && sum == 0)
        {
          return true;
        }

        if (node.left != null)
          q.Enqueue((node.left, sum - node.left.val));
        if (node.right != null)
          q.Enqueue((node.right, sum - node.right.val));
      }
      return false;
    }

    public bool HasPathSum_(TreeNode root, int targetSum)
    {
      if (root == null) return false;
      if (root.left == null && root.right == null && targetSum - root.val == 0) return true;
      return HasPathSum_(root.left, targetSum - root.left.val) || HasPathSum_(root.right, targetSum - root.right.val);
    }
  }
}

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
class Comment
{
    public int Id { get; set; }
    public int ParentId { get; set; }
    public string Text { get; set; }
}

class Program
{

static void Main()
    {
        int inputCount = int.Parse(Console.ReadLine());
        List<List<Comment>> input = new List<List<Comment>>();
        for (int i = 0; i < inputCount; i++)
        {
            List<Comment> comments = new List<Comment>();
            int m = int.Parse(Console.ReadLine());
            for (int j = 0; j < m; j++)
            {
                string[] inputLine = Console.ReadLine().Split(' ');
                int id = int.Parse(inputLine[0]);
                int parentId = int.Parse(inputLine[1]);
                string text = string.Join(" ", inputLine, 2, inputLine.Length - 2);
             comments.Add (new Comment
                {
                    Id = id,
                    ParentId = parentId,
                    Text = text
                });
            }

            input.Add(comments);
        }
foreach (List<Comment> comments in input)
        {
        Dictionary<int, List<Comment>> childrenMap = new Dictionary<int, List<Comment>>();

        foreach (var comment in comments)
        {
            if (!childrenMap.ContainsKey(comment.ParentId))
            {
                childrenMap[comment.ParentId] = new List<Comment>();
            }
            childrenMap[comment.ParentId].Add(comment);
        }

        PrintCommentTree(childrenMap, -1, "");
    }
    }
   static void PrintCommentTree(Dictionary<int, List<Comment>> childrenMap, int Id, string prefix)
    {
        if (childrenMap.ContainsKey(Id))
        {
            List<Comment> children = childrenMap[Id];
            for (int i = 0; i < children.Count; i++)
            {
                Comment comment = children[i];
                string line = (Id == - 1) ? "" : "|--" ;
   
                Console.WriteLine(prefix + line  + comment.Text);
                PrintCommentTree(childrenMap, comment.Id, prefix + (i == children.Count - 1 ? "    " : "|   "));

            }
        }
    }
}
using System;
using System.Collections.Generic;

namespace TreeTest
{
    public class Tree
    {
        public TreeItem Root { get; set; }

        public Tree() // это конструктор
        {
            Root = new TreeItem(); // распределить память для объекта типа TreeItem // конструктор TreeItem() вызывается для свойства Root
        }

        /// <summary>
        /// Добавляет указанное значение по указанному индексу
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Add(int index, int value)
        {
            // рекурсивное добавление
            Add(new List<TreeItem> {Root}, 0, index, value);
        }

        private void Add(List<TreeItem> nodeList, int maxIndex, int index, int value)
        {
            var nextLevel = new List<TreeItem>();

            foreach (var node in nodeList)
            {
                if (node.Index == index)
                {
                    node.Value = value;
                    return;
                }

                maxIndex++;
                var leftNode = node.LeftNode ?? new TreeItem(maxIndex);
                maxIndex++;
                var rightNode = node.RightNode ?? new TreeItem(maxIndex);

                node.LeftNode = leftNode;
                node.RightNode = rightNode;

                nextLevel.Add(leftNode);
                nextLevel.Add(rightNode);
            }

            Add(nextLevel, maxIndex, index, value);
        }

        public Dictionary<string, int> GetView()
        {
            Random r = new Random();

            Dictionary<string, int> view = new Dictionary<string, int>();

            for (int i = 0; i < 7; i++) // т.к. всего 6 узлов
            {
                view.Add(i.ToString(), r.Next(10));
            }
            return view;
        
            // представление массива в нормальном виде
           
        } 
    }

    public class TreeItem
    {
        public int Index { get; set; }

        public int Value { get; set; }

        public TreeItem LeftNode { get; set; }

        public TreeItem RightNode { get; set; }

        public TreeItem(int index = 0)
        {
            Index = index;
        }
    }
}

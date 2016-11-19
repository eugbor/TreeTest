using System;
using System.Collections.Generic;

namespace TreeTest
{
    public class Tree
    {
        /// <summary>
        /// Корень
        /// </summary>
        public TreeItem Root { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public Tree()
        {
            Root = new TreeItem();
        }

        /// <summary>
        /// Добавляет указанное значение по указанному индексу
        /// </summary>
        /// <param name="index">Индекс</param>
        /// <param name="value">Значение</param>
        public void Add(int index, int value)
        {
            // рекурсивное добавление
            Add(new List<TreeItem> {Root}, 0, index, value);
        }

        /// <summary>
        /// Добавляет в список узлов по индексу значение
        /// </summary>
        /// <param name="nodeList">Список узлов</param>
        /// <param name="maxIndex">Максимальный индекс</param>
        /// <param name="index">Индекс</param>
        /// <param name="value">Значение</param>
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

        /// <summary>
        /// Получае представление
        /// </summary>
        /// <returns>Коллекция ключей и значений</returns>
        public Dictionary<string, int> GetView()
        {
            Random r = new Random();

            Dictionary<string, int> view = new Dictionary<string, int>();

            SetView(view, Root, new List<int>());

            return view;
           
        }

        /// <summary>
        /// Устанавливает представление
        /// </summary>
        /// <param name="views">Коллекция ключей и значений</param>
        /// <param name="node">Узел</param>
        /// <param name="path">Путь</param>
        private void SetView(Dictionary<string, int> views, TreeItem node, List<int> path)
        {
            path.Add(node.Index);

            // Сцепляет указанные элементы списка строк, помещая между ними заданный разделитель
            views.Add(string.Join("-", path), node.Value);

            if (node.LeftNode != null)
                SetView(views, node.LeftNode, path);

            if (node.RightNode != null)
                SetView(views, node.RightNode, path);

            // Удаляет элемент списка List<int> с указанным индексом
            path.RemoveAt(path.Count - 1);
        }

        /// <summary>
        /// Формирует сроку пути до искомого значения
        /// </summary>
        /// <param name="value">Значение</param>
        /// <returns>Путь в виде строки</returns>
        public string Find(int value)
        {
            return String.Join("-", Find(value, Root, new List<int>()));
        }

        /// <summary>
        /// Ищит значение
        /// </summary>
        /// <param name="value">Значение</param>
        /// <param name="node">Узел</param>
        /// <param name="path">Путь</param>
        /// <returns>Путь</returns>
        private List<int> Find(int value, TreeItem node, List<int> path)
        {
            path.Add(node.Index);

            if (node.Value == value)
                return path;

            var lengthPath = path.Count;

            if (node.LeftNode != null)
            {
                path = Find(value, node.LeftNode, path);

                if (lengthPath != path.Count)
                    return path;
            }

            if (node.RightNode != null)
            {
                path = Find(value, node.RightNode, path);

                if (lengthPath != path.Count)
                    return path;
            }
            

            path.RemoveAt(path.Count - 1);

            return path;
        } 
    }


    public class TreeItem
    {
        /// <summary>
        /// Индекс
        /// </summary>
        public int Index { get; set; }
        
        /// <summary>
        /// Значение
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Левый узел
        /// </summary>
        public TreeItem LeftNode { get; set; }

        /// <summary>
        /// Правый узел
        /// </summary>
        public TreeItem RightNode { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="index"></param>
        public TreeItem(int index = 0)
        {
            Index = index;
        }
    }
}

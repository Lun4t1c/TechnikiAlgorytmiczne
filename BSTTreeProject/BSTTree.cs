using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSTTreeProject
{
    internal class BSTTree
    {
        #region Node subclass
        private class Node
        {
            public string Word { get; set; }
            public Node ChildLeft { get; set; } = null;
            public Node ChildRight { get; set; } = null;

            public Node(string word)
            {
                this.Word = word;
            }
        }
        #endregion


        #region Properties
        private Node Root { get; set; } = null;
        public int NumberOfOperations { get; set; } = 0;
        #endregion


        #region Constructor
        public BSTTree()
        {

        }
        #endregion


        #region Methods
        public void PrintOut()
        {
            _printNode(Root, 0);
        }

        public int GetHeight()
        {
            return _findHeight(Root);
        }

        public void Add(string word)
        {
            NumberOfOperations++;
            if (Root == null)
            {                
                Root = new Node(word);
                return;
            }

            Node walker = Root;
            Node previousNode = Root;

            while (walker != null)
            {
                NumberOfOperations++;

                previousNode = walker;
                if (_isStringAlphabeticallyFirst(walker.Word, word))
                {
                    previousNode = walker;
                    walker = walker.ChildLeft;
                }
                else
                {
                    previousNode = walker;
                    walker = walker.ChildRight;
                }
            }

            NumberOfOperations++;
            if (_isStringAlphabeticallyFirst(previousNode.Word, word))
                previousNode.ChildLeft = new Node(word);
            else
                previousNode.ChildRight = new Node(word);
        }

        public bool Find(string word)
        {
            bool result = false;

            Node walker = Root;
            while (walker != null)
            {
                NumberOfOperations++;

                if (walker.Word == word) 
                    return true;

                if (_isStringAlphabeticallyFirst(walker.Word, word))
                    walker = walker.ChildLeft;
                else
                    walker = walker.ChildRight;
            }

            return result;
        }

        public void Remove(string word)
        {
            _removeWord(Root, word);
        }

        public int FlushNumberOfOperations()
        {
            int temp = NumberOfOperations;
            NumberOfOperations = 0;
            return temp;
        }

        private Node _removeWord(Node node, string word)
        {
            if (node == null) return node;

            NumberOfOperations++;
            if (_isStringAlphabeticallyFirst(node.Word, word))
            {
                NumberOfOperations++;
                node.ChildRight = _removeWord(node.ChildRight, word);
            }
            else if (_isStringAlphabeticallyFirst(word, node.Word))
            {
                NumberOfOperations++;
                node.ChildLeft = _removeWord(node.ChildLeft, word);
            }
            else
            {
                Node temp = null;

                NumberOfOperations++;
                if (node.ChildLeft == null)
                {
                    temp = node.ChildRight;
                    node = null;
                    return temp;
                }
                else if (node.ChildRight == null)
                {
                    NumberOfOperations++;
                    temp = node.ChildLeft;
                    node = null;
                    return temp;
                }

                temp = _minValueNode(node.ChildRight);

                node.Word = temp.Word;

                node.ChildRight = _removeWord(node.ChildRight, temp.Word);
            }
            return node;
        }

        private Node _minValueNode(Node node)
        {
            Node walker = node;

            while (walker.ChildLeft != null)
                walker = walker.ChildLeft;

            return walker;
        }

        private bool _isStringAlphabeticallyFirst(string s1, string s2)
        {
            if (string.Compare(s1, s2) > 0) 
                return true;
            else 
                return false;
        }

        private void _printNode(Node node, int level)
        {            
            if (node == null) return;
            else
            {
                Console.WriteLine($"{level} - {node.Word}");
                _printNode(node.ChildLeft, level + 1);
                _printNode(node.ChildRight, level + 1);
            }
        }

        private int _findHeight(Node node)
        {
            if (node == null)
                return -1;

            int lefth = _findHeight(node.ChildLeft);
            int righth = _findHeight(node.ChildRight);

            if (lefth > righth)
                return lefth + 1;
            else
                return righth + 1;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSTTreeProject
{
    internal class SplayTree
    {
        #region Node subclass
        private class Node
        {
            public string Word { get; set; }
            public Node ChildLeft { get; set; } = null;
            public Node ChildRight { get; set; } = null;

            public Node(string word)
            {
                Word = word;
            }
        }
        #endregion


        #region Properties
        private Node Root { get; set; } = null;
        public int NumberOfOperations { get; set; } = 0;
        #endregion


        #region Constructor
        public SplayTree()
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
            if (Root == null)
            {
                NumberOfOperations++;

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
            Root = Splay(Root, word);

            if (Root.Word == word)
                return true;
            else
                return false;
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
            NumberOfOperations++;
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

        private Node Splay(Node root, string word)
        {
            if (root == null || root.Word == word)
                return root;

            NumberOfOperations++;
            if (_isStringAlphabeticallyFirst(root.Word, word))
            {
                if (root.ChildLeft == null) return root;

                NumberOfOperations++;
                if (_isStringAlphabeticallyFirst(root.ChildLeft.Word, word))
                {
                    root.ChildLeft.ChildLeft = Splay(root.ChildLeft.ChildLeft, word);
                    root = _rotateRight(root);
                }
                else if (_isStringAlphabeticallyFirst(word, root.ChildLeft.Word))
                {
                    NumberOfOperations++;
                    root.ChildLeft.ChildRight = Splay(root.ChildLeft.ChildRight, word);
                    if (root.ChildLeft.ChildRight != null)
                        root.ChildLeft = _rotateLeft(root.ChildLeft);
                }

                return (root.ChildLeft == null) ? root : _rotateRight(root);
            }
            else
            {
                NumberOfOperations++;
                if (root.ChildRight == null) return root;

                NumberOfOperations++;
                if (_isStringAlphabeticallyFirst(root.ChildRight.Word, word))
                {
                    root.ChildRight.ChildLeft = Splay(root.ChildRight.ChildLeft, word);

                    if (root.ChildRight.ChildLeft != null)
                        root.ChildRight = _rotateRight(root.ChildRight);
                }
                else if (_isStringAlphabeticallyFirst(word, root.ChildRight.Word))
                {
                    NumberOfOperations++;
                    root.ChildRight.ChildRight = Splay(root.ChildRight.ChildRight, word);
                    root = _rotateLeft(root);
                }

                return (root.ChildRight == null) ? root : _rotateLeft(root);
            }
        }

        private Node _rotateRight(Node node)
        {
            Node tempNode = node.ChildLeft;
            node.ChildLeft = tempNode.ChildRight;
            tempNode.ChildRight = node;
            return tempNode;
        }

        private Node _rotateLeft(Node node)
        {
            Node tempNode = node.ChildRight;
            node.ChildRight = tempNode.ChildLeft;
            tempNode.ChildLeft = node;
            return tempNode;
        }
        #endregion
    }
}

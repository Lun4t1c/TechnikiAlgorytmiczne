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
        public void Add(string word)
        {            
            if (Root == null)
            {
                Root = new Node(word);
                return;
            }
            Node previousNode = Root;

            while (Root != null)
            {
                previousNode = Root;
                if (Root.Word > word)
                {

                }
            }
        }

        public void Find(string word)
        {

        }

        public void Remove(string word)
        {

        }

        public int FlushNumberOfOperations()
        {
            int temp = NumberOfOperations;
            NumberOfOperations = 0;
            return temp;
        }

        private bool CompareStringsAlphabetically(string s1, string s2)
        {
            bool result = false;



            return result;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversList
{
    class ReversList<T>
    {
        private Node<T> Head;
        private Node<T> Tail;
        private Node<T> Head2;

        public Node<T> ReversSimplyConnectedList()
        {
            if (Head != null)
                return ReversSimplyConnectedList(Head);
            return null;
        }
        public Node<T> ReversSimplyConnectedList(Node<T> list)
        {
            if (list.Next == null)
                return list;
            Head = list;
            ReversSimplyConnectedList(Head.Next, Head);
            list.Next = null;
            Head2.Next = list;
            return Head;
        }
        private void ReversSimplyConnectedList(Node<T> list, Node<T> next)
        {
            if (list.Next == null)
            {
                Head = list;
                Head2 = list;
                return;
            }
            else
            {
                ReversSimplyConnectedList(list.Next, next);
                list.Next = null;
                Head2.Next = list;
                Head2 = Head2.Next;
            }
        }

        public Node<T> ReversTwoConnectedList()
        {
            if (Head != null && Tail != null)
                return ReversTwoConnectedList(Head, Tail);
            return null;
        }
        public Node<T> ReversTwoConnectedList(Node<T> head, Node<T> tail)
        {
            Node<T> node = head;

            Node<T> temp = head;
            head = Tail;
            Tail = temp;

            while (node.Next != null)
            {
                temp = node.Next;
                node.Next = node.Previous;
                node.Previous = temp;
                node = node.Previous;
            }
            return node;
        }

        public void AddList(Node<T> head)
        {
            Head = head;
        }
        public void AddList(Node<T> head, Node<T> tail)
        {
            AddList(head);
            Tail = tail;
        }
    }
    public class Node<T>
    {
        private T Value;
        public Node<T> Next;
        public Node<T> Previous;
        public Node(T value)
        {
            this.Value = value;
        }
        public Node(T value, Node<T> next, Node<T> previus)
        {
            this.Value = value;
            this.Next = next;
            this.Previous = previus;
        }
    }
}

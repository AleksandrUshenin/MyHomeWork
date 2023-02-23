using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversList
{
    class Program
    {
        static void Main(string[] args)
        {
            ReversList<int> reverse = new ReversList<int>();
            Node<int> node = new Node<int>(1);
            Node<int> node2 = new Node<int>(2);
            Node<int> node3 = new Node<int>(3);
            Node<int> node4 = new Node<int>(4);
            Node<int> node5 = new Node<int>(5);
            node.Next = node2;
            node2.Next = node3;
            node3.Next = node4;
            node4.Next = node5;

            var res1 = reverse.ReversSimplyConnectedList(node);

            node = new Node<int>(1);
            node2 = new Node<int>(2);
            node3 = new Node<int>(3);
            node4 = new Node<int>(4);
            node5 = new Node<int>(5);
            node.Next = node2;

            node2.Next = node3;
            node2.Previous = node;

            node3.Next = node4;
            node3.Previous = node2;

            node4.Next = node5;
            node4.Previous = node3;

            node5.Previous = node4;

            var res2 = reverse.ReversTwoConnectedList(node, node5);

            Console.ReadKey();
        }
    }
}

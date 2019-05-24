using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_nine
{
    class BiList : IEnumerable
    {
        Node head;
        Node tail;
        int size;

        public BiList()
        {
            head = null;
            tail = null;
            size = 0;
        }

        public BiList(int capacity)
        {
            head = new Node(1);
            Node temp = head;
            for (int i = 1; i < capacity; i++)
            {
                tail = new Node(i + 1);
                tail.prev = temp;
                temp.next = tail;
                temp = temp.next;
            }
            size = capacity;
        }

        public void Add(int item)
        {
            Node node = new Node(item);
            if (head == null) head = node;
            else
            {
                tail.next = node;
                node.prev = tail;
                
            }
            tail = node;
            size += 1;
        }

        public int Remove(int item)
        {
            if (head == null) throw new ArgumentNullException();
            {
                Node current = head;
                while (current != null) // поиск искомого элемента
                {
                    if (current.Value == item) break;
                    current = current.next;
                }
                if (current != null)
                {
                    if (current.next != null) // если не последний
                        current.next.prev = current.prev;
                    else tail = current.prev;

                    if (current.prev != null) // if not the first
                        current.prev.next = current.next;
                    else head = current.next;
                }
                size--;
                if (current != null) return current.Value;
                else return 0;
            }
        }

        public void Clear()
        {
            head = null;
            tail = null;
            size = 0;
        }

        public IEnumerator GetEnumerator()
        {
            Node current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.next;
            }
        }

        public int Count
        {
            get { return size; }
        }

        public bool IsEmpty
        {
            get { return Count == 0; }
        }

    }

    internal class Node // структура узла
    {
        internal int element; //информационное поле
        internal Node next, prev; //адресное поле

        public Node()
        {
            element = 0;
            prev = null;
            next = null;
        }

        public Node(int value)
        {
            element = value;
            prev = null;
            next = null;
        }

        public int Value
        {
            get { return element; }
        }

        public override string ToString()
        {
            return element.ToString();
        }

        public override bool Equals(object obj)
        {
            return (int)obj == this.Value;
        }
    }
}

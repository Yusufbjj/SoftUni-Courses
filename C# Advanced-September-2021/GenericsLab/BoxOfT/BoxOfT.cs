using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class BoxOfT<T>
    {
        private List<T> elements;

        public BoxOfT()
        {
            elements = new List<T>();
        }

        public void Add(T item)
        {
            elements.Insert(0, item);
        }

        public T Remove()
        {
            T removedElement = elements[0];

            elements.RemoveAt(0);

            return removedElement;
        }

        public int Count
        {
            get { return elements.Count; }
        }

    }
}

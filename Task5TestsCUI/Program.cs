using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5;

namespace Task5TestsCUI
{
    public class ComparerString : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x.Length > y.Length)
                return 1;
            else if (x.Length < y.Length)
                return -1;
            else return 0;
        }
    }

    public class Book : IComparable<Book>
    {
        public string Name { get; }
        public int Price { get; }

        public Book(string name, int price)
        {
            Name = name;
            Price = price;
        }
        
        public int CompareTo(Book other)
        {
            if (string.Compare(Name, other.Name) > 0)
                return 1;
            else if (string.Compare(Name, other.Name) < 0)
                return -1;
            else return 0;
        }
    }

    public class ComparerByPrice : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            if (x.Price > y.Price)
                return 1;
            else if (x.Price < y.Price)
                return -1;
            else return 0;
        }
    }

    struct Point
    {
        public int X
        {
            get;
        }
        public int Y
        {
            get;
        }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    class ComparerPoint : IComparer<Point>
    {
        public int Compare(Point x, Point y)
        {
            if (x.X + x.Y > y.X + y.Y)
                return 1;
            else if (x.X + x.Y < y.X + y.Y)
                return -1;
            else return 0;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***************INT***************");
            BinarySearchTree<int> tree = new BinarySearchTree<int>(14);
            tree.Add(20);
            tree.Add(12);
            tree.Add(36);
            tree.Add(32);
            tree.Add(28);
            tree.Add(6);
            tree.Add(3);
            tree.Add(7);
            tree.Add(8);
            tree.Add(13);
            tree.Add(33);
            tree.Add(5);
            tree.Add(15);
            tree.Add(19);
            Console.WriteLine("PreOrder");
            foreach (var item in tree.PreOrder())
                Console.WriteLine(item);

            Console.WriteLine("InOrder");
            foreach (var item in tree.InOrder())
                Console.WriteLine(item);

            Console.WriteLine("PostOrder");
            foreach (var item in tree.PostOrder())
                Console.WriteLine(item);

            Console.WriteLine(tree.Remove(14) + "remove 14(root)");
            Console.WriteLine(tree.Remove(20) + "remove 20(with childs)");
            Console.WriteLine(tree.Remove(3) + "remove 3(whith right child)");

            Console.WriteLine("PreOrder");
            foreach (var item in tree.PreOrder())
                Console.WriteLine(item);

            Console.WriteLine("InOrder");
            foreach (var item in tree.InOrder())
                Console.WriteLine(item);

            Console.WriteLine("***************STRING***************");
            BinarySearchTree<string> treeS = new BinarySearchTree<string>();
            treeS.Add("Sergei");
            treeS.Add("Ann");
            treeS.Add("John");
            treeS.Add("Polina");
            treeS.Add("Alexander");
            treeS.Add("Veronica");
            treeS.Add("Vladimir");
            treeS.Add("Alephtina");

            Console.WriteLine("With default comparer");
            Console.WriteLine("PreOrder");
            foreach (var item in treeS.PreOrder())
                Console.WriteLine(item);

            Console.WriteLine("InOrder");
            foreach (var item in treeS.InOrder())
                Console.WriteLine(item);

            Console.WriteLine("PostOrder");
            foreach (var item in treeS.PostOrder())
                Console.WriteLine(item);

            treeS = new BinarySearchTree<string>(new ComparerString());
            treeS.Add("Sergei");
            treeS.Add("Ann");
            treeS.Add("John");
            treeS.Add("Polina");
            treeS.Add("Alexander");
            treeS.Add("Veronica");
            treeS.Add("Vladimir");
            treeS.Add("Alephtina");

            Console.WriteLine("With comparer by length string");
            Console.WriteLine("PreOrder");
            foreach (var item in treeS.PreOrder())
                Console.WriteLine(item);

            Console.WriteLine("InOrder");
            foreach (var item in treeS.InOrder())
                Console.WriteLine(item);

            Console.WriteLine("PostOrder");
            foreach (var item in treeS.PostOrder())
                Console.WriteLine(item);


            Console.WriteLine("***************BOOK***************");
            BinarySearchTree<Book> treeB = new BinarySearchTree<Book>();
            treeB.Add(new Book("Palanik", 230));
            treeB.Add(new Book("Pushkin", 200));
            treeB.Add(new Book("King", 500));
            treeB.Add(new Book("Lermantov", 400));
            treeB.Add(new Book("Lermantov", 150));

            Console.WriteLine("With default comparer");
            Console.WriteLine("PreOrder");
            foreach (var item in treeB.PreOrder())
                Console.WriteLine(item.Name + " - " + item.Price);
            Console.WriteLine("InOrder");
            foreach (var item in treeB.InOrder())
                Console.WriteLine(item.Name + " - " + item.Price);
            Console.WriteLine("PostOrder");
            foreach (var item in treeB.PostOrder())
                Console.WriteLine(item.Name + " - " + item.Price);

            treeB = new BinarySearchTree<Book>(new ComparerByPrice());
            treeB.Add(new Book("Palanik", 230));
            treeB.Add(new Book("Pushkin", 200));
            treeB.Add(new Book("King", 500));
            treeB.Add(new Book("Lermantov", 400));
            treeB.Add(new Book("Lermantov", 150));

            Console.WriteLine("With comparer by price");
            Console.WriteLine("PreOrder");
            foreach (var item in treeB.PreOrder())
                Console.WriteLine(item.Name + " - " + item.Price);
            Console.WriteLine("InOrder");
            foreach (var item in treeB.InOrder())
                Console.WriteLine(item.Name + " - " + item.Price);
            Console.WriteLine("PostOrder");
            foreach (var item in treeB.PostOrder())
                Console.WriteLine(item.Name + " - " + item.Price);

            Console.WriteLine("***************POINT***************");
            BinarySearchTree<Point> treeP = new BinarySearchTree<Point>(new ComparerPoint());
            Console.WriteLine("With compare by sum x y");
            treeP.Add(new Point(4, 10));
            treeP.Add(new Point(4, 4));
            treeP.Add(new Point(4, 2));
            treeP.Add(new Point(34, 14));
            treeP.Add(new Point(3, 8));
            treeP.Add(new Point(1, 14));
            treeP.Add(new Point(14, 3));
            treeP.Add(new Point(0, 3));
            treeP.Add(new Point(2, 3));

            Console.WriteLine("PreOrder");
            foreach (var item in treeP.PreOrder())
                Console.WriteLine(item.X + " + " + item.Y);
            Console.WriteLine("InOrder");
            foreach (var item in treeP.InOrder())
                Console.WriteLine(item.X + " + " + item.Y);
            Console.WriteLine("PostOrder");
            foreach (var item in treeP.PostOrder())
                Console.WriteLine(item.X + " + " + item.Y);
        }
    }
}
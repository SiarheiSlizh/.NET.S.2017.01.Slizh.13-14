using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2;
using Task1Tests;//from day12

namespace Task2Tests
{
    [TestFixture]
    public class SetTests
    {
        private Set<string> s;
        private string[] seq = { "Olia", "Kate", "Ilya", "Den", "Sasha" };
        Set<Book> books;

        private void InitialSet()
        {
            s = new Set<string>();
            s.Add("Misha");
            s.Add("Alisa");
            s.Add("Ann");
            s.Add("Sasha");
            s.Add("Juri");
            s.Add("Kate");
        }

        private void InitialSetBookWithComparer()
        {
            books = new Set<Book>(new ComparerByPrice());
            InitialBooks();
        }

        private void InitialSetBookWithDefaultComparer()
        {
            books = new Set<Book>();
            InitialBooks();
        }

        private void InitialBooks()
        {
            books.Add(new Book("Palanik", 200));
            books.Add(new Book("King", 250));
            books.Add(new Book("London", 170));
        }

        [Test]
        public void IntersectWith_Positive()
        {
            InitialSet();
            string[] expected = { "Sasha", "Kate" };
            s.IntersectWith(seq);
            Assert.AreEqual(expected, s);
        }

        [Test]
        public void ExceptWith_Positive()
        {
            InitialSet();
            string[] expected = { "Misha", "Alisa", "Ann", "Juri" };
            s.ExceptWith(seq);
            Assert.AreEqual(expected, s);
        }

        [Test]
        public void UnionWith_Positive()
        {
            InitialSet();
            string[] expected = { "Misha", "Alisa", "Ann", "Sasha", "Juri", "Kate", "Olia", "Ilya", "Den" };
            s.UnionWith(seq);
            Assert.AreEqual(expected, s);
        }

        [Test]
        public void SymmetricExceptWith_Positive()
        {
            InitialSet();
            string[] expected = { "Misha", "Alisa", "Ann", "Juri", "Olia", "Ilya", "Den" };
            s.SymmetricExceptWith(seq);
            Assert.AreEqual(expected, s);
        }

        [Test]
        public void SetEquals_EqualityComparer_Positive()
        {
            InitialSetBookWithComparer();
            InitialBooks();
            
            Assert.AreEqual(!default(bool), books.SetEquals(new Book[] { new Book("Pushkin", 200), new Book("Dostoevski", 250), new Book("Esenin", 170) }));
        }

        [Test]
        public void SetEquals_DefaultEqualityComparer_Positive()
        {
            InitialSetBookWithDefaultComparer();
            InitialBooks();

            Assert.AreEqual(!default(bool), books.SetEquals(new[] { new Book("Palanik", 250), new Book("King", 200), new Book("London", 250) }));
        }

        [Test]
        public void Contains_Positive()
        {
            InitialSetBookWithComparer();
            InitialBooks();

            Assert.AreEqual(!default(bool), books.Contains(new Book("Tolstoy", 250)));
        }

        [Test]
        public void CopyTo_Positive()
        {
            InitialSetBookWithComparer();
            InitialBooks();

            Book[] actual = new Book[4];
            actual[0] = new Book("Tolstoy", 250);
            books.CopyTo(actual, 1);

            Book[] expected = { new Book("Tolstoy", 250), new Book("Palanik", 200), new Book("King", 250), new Book("London", 170) };
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IsProperSubSet_Positive()
        {
            InitialSetBookWithDefaultComparer();
            InitialBooks();

            Book[] b = new Book[5];
            b[0] = new Book("Shedrin", 130);
            books.CopyTo(b, 1);
            b[4] = new Book("Richter", 150);
            Assert.AreEqual(!default(bool), books.IsProperSubsetOf(b));
        }

        [Test]
        public void IsProperSupersetOf_Positive()
        {
            InitialSetBookWithDefaultComparer();
            InitialBooks();

            Book[] b = new Book[1];
            b[0] = new Book("London", 175);

            Assert.AreEqual(!default(bool), books.IsProperSupersetOf(b));
        }
    }
}

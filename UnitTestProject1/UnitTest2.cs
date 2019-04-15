using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DependencyInjection.Models;
using System.Linq;
using Moq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest2
    {
        Book[] books =
        {
            new Book {Author = "Shakespiear", Title = "Hamlet", Category = BookCategory.Gexarvetakan, Price = 33.54m},
            new Book {Author = "Duma", Title = "Three Musk", Category = BookCategory.Gexarvetakan, Price = 13.54m},
            new Book {Author = "Sevak", Title = "Zangagatun", Category = BookCategory.Gexarvetakan, Price = 33.54m},
            new Book {Author = "Lipman", Title = "C++", Category = BookCategory.Programming, Price = 25.77m},
            new Book {Author = "Straustrup", Title = "OOP", Category = BookCategory.Programming, Price = 43.44m},

        };
        [TestMethod]
        public void TestMethod1()
        {
            IDiscount disc = new MinDiscount();
            TotalValueCalculator ttCalc = new TotalValueCalculator(disc);

            decimal trueResult = books.Sum(x => x.Price);

            decimal realResult = ttCalc.SumOfPrice(books);

            Assert.AreEqual(trueResult, realResult, " ERROR ");
        }

        [TestMethod]
        public void TestByMoq()
        {
            Mock<IDiscount> mock = new Mock<IDiscount>();

            mock.Setup(m => m.ApplyDiscount(It.IsAny<decimal>())).Returns<decimal>(total => total);


            TotalValueCalculator ttCalc = new TotalValueCalculator(mock.Object);

            decimal trueResult = books.Sum(x => x.Price);

            decimal realResult = ttCalc.SumOfPrice(books);

            Assert.AreEqual(trueResult, realResult, " ERROR ");
        }

        private Book[] CreateBooks(int val)
        {
            return new[] { new Book { Price = val }, new Book { Price = 0 } };
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SecondTestByMoq()
        {
            Mock<IDiscount> mock = new Mock<IDiscount>();

            mock.Setup(m => m.ApplyDiscount(It.IsAny<decimal>()))
                .Throws(new ArgumentOutOfRangeException());
            //.Returns<decimal>(x => x);
            mock.Setup(m => m.ApplyDiscount(It.Is<decimal>(x => x > 100)))
                .Returns<decimal>(y => y / 2m);
            mock.Setup(m => m.ApplyDiscount(It.IsInRange<decimal>(10, 100, Range.Inclusive)))
                .Returns<decimal>(total => total - 5);
            mock.Setup(m => m.ApplyDiscount(It.IsInRange<decimal>(0, 10, Range.Exclusive)))
                .Returns<decimal>(total => total);

            TotalValueCalculator calc = new TotalValueCalculator(mock.Object);

            decimal LessThanZero = calc.SumOfPrice(CreateBooks(-1));
            decimal five = calc.SumOfPrice(CreateBooks(5));
            decimal ten = calc.SumOfPrice(CreateBooks(10));
            decimal fifty = calc.SumOfPrice(CreateBooks(50));
            decimal hundred = calc.SumOfPrice(CreateBooks(100));
            decimal fivehundred = calc.SumOfPrice(CreateBooks(500));

            Assert.AreEqual(5, five, " ERROR 5 ");
            Assert.AreEqual(5, ten, " ERROR 10 ");
            Assert.AreEqual(45, fifty, " ERROR 50 ");
            Assert.AreEqual(95, hundred, " ERROR 100 ");
            Assert.AreEqual(250, fivehundred, " ERROR 500 ");
        }

    }
}

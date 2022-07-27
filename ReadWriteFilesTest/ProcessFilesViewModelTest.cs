using System;
using NUnit.Framework;
using ReadWriteFiles.Models;
using ReadWriteFiles.ViewModels;
using Moq;

namespace ReadWriteFilesTest
{
    [TestFixture]
    public class ProcessFilesViewModelTest
    {
        private Mock<Portfolios> _portfolios;
        private Mock<Securities> _securities;
        private Mock<Transactions> _transactions;
        private ProcessFilesViewModel _viewModel;
        private object _obj;
        private Mock<TypeAAA>_typeAAA;
        private Mock<TypeBBB>_typeBBB;
        private Mock<TypeCCC>_typeCCC;

        [SetUp]
        public void Setup()
        {
            _portfolios = new Mock<Portfolios>();
            _securities = new Mock<Securities>();
            _transactions = new Mock<Transactions>();
            _viewModel = new ProcessFilesViewModel();
            _obj = new object();

            _portfolios.SetupGet(e => e.PortfolioId).Returns(1);
            _portfolios.SetupGet(e => e.PortfolioCode).Returns("p1");

            _securities.SetupGet(e => e.SecurityId).Returns(1);
            _securities.SetupGet(e => e.ISIN).Returns("ISIN11111111");
            _securities.SetupGet(e => e.Ticker).Returns("s1");
            _securities.SetupGet(e => e.Ticker).Returns("CUSIP0001");

            _transactions.SetupGet(e => e.SecurityId).Returns(1);
            _transactions.SetupGet(e => e.PortfolioId).Returns(1);
            _transactions.SetupGet(e => e.Nominal).Returns(10);
            _transactions.SetupGet(e => e.OMS).Returns("AAA");
            _transactions.SetupGet(e => e.TransactionType).Returns("BUY");

        }

        [Test]
        public void ProcessInputData_called()
        {            
           _viewModel.OnProcessInputFiles(_obj);           
        }

        [Test]
        public void ProcessOutTypeAAA_called()
        {           
           _viewModel.OnProcessOutputTypeAAA(_obj);           
        }

        [Test]
        public void ProcessOutTypeBBB_called()
        {           
            _viewModel.OnProcessOutputTypeBBB(_obj);            
        }
        [Test]
        public void ProcessOutTypeCCC_called()
        {            
            _viewModel.OnProcessOutputTypeCCC(_obj);
           
        }
    }
}

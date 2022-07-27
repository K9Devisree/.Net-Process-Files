using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using ReadWriteFiles.Command;
using LINQtoCSV;
using ReadWriteFiles.Common;
using ReadWriteFiles.Models;
using NLog;
using System.Windows;

namespace ReadWriteFiles.ViewModels
{
    public class ProcessFilesViewModel
    {
        private List<Portfolios> portfolios = new List<Portfolios>();
        private List<Securities> securities = new List<Securities>();
        private List<Transactions> transactions = new List<Transactions>();
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        public ProcessFilesViewModel()
        {            
            ProcessInputFilesCommand = new Command.Command(OnProcessInputFiles);
            ProcessOutputTypeAAACommand = new Command.Command(OnProcessOutputTypeAAA);
            ProcessOutputTypeBBBCommand = new Command.Command(OnProcessOutputTypeBBB);
            ProcessOutputTypeCCCCommand = new Command.Command(OnProcessOutputTypeCCC);
        }
        public ICommand ProcessInputFilesCommand { get; set; }

        public ICommand ProcessOutputTypeAAACommand { get; set; }
        public ICommand ProcessOutputTypeBBBCommand { get; set; }
        public ICommand ProcessOutputTypeCCCCommand { get; set; }      

        public void OnProcessInputFiles(object args)
        {
            try
            {
                logger.Info("Started Processing the Input files");
                
                var csvFileDescription = new CsvFileDescription
                {
                    FirstLineHasColumnNames = true,
                    SeparatorChar = ',',
                    UseFieldIndexForReadingData = false,
                };

                var csvContext = new CsvContext();
                portfolios = csvContext.Read<Portfolios>(Constants.InputPortfolios, csvFileDescription).ToList();
                securities = csvContext.Read<Securities>(Constants.InputSecurities, csvFileDescription).ToList();
                transactions = csvContext.Read<Transactions>(Constants.InputTranscations, csvFileDescription).ToList();                
                MessageBox.Show("Processing Input file sucesfull");
            }
            catch (Exception exception)
            {
                logger.Info("Error while processing the input files", exception);
            }

        }
        public void OnProcessOutputTypeAAA(object args)
        {
            try
            {
                logger.Info($"Started writing file [{Constants.OutputTypeAAA}]");
                IEnumerable<TypeAAA> resultAaa = transactions.Join(securities, t => t.SecurityId, s => s.SecurityId, (t, s) => new
                {
                    transactions = t,
                    securities = s
                }).Join(portfolios, m => m.transactions.PortfolioId, p => p.PortfolioId, (m, p) => new TypeAAA
                {
                    ISIN = m.securities.ISIN,
                    PortfolioCode = p.PortfolioCode,
                    Nominal = m.transactions.PortfolioId,
                    TransactionType = m.transactions.TransactionType
                });
                #region Write file
                var csvWriteFileDescription = new CsvFileDescription
                {
                    FirstLineHasColumnNames = true,
                    SeparatorChar = ',',
                    QuoteAllFields = true,
                };
                var csvWriteContext = new CsvContext();
                csvWriteContext.Write(resultAaa, Constants.OutputTypeAAA, csvWriteFileDescription);
                MessageBox.Show("Writing to output file sucesfull");
                #endregion
            }
            catch (Exception exception)
            {
                logger.Error(exception, $"Error while writing to Output file [{Constants.OutputTypeAAA}]");
            }

        }
        public void OnProcessOutputTypeBBB(object args)
        {
            try
            {
                logger.Info($"Started writing file [{Constants.OutputTypeBBB}]");
                IEnumerable<TypeBBB> resultBbb = transactions.Join(securities, t => t.SecurityId, s => s.SecurityId, (t, s) => new
                {
                    transactions = t,
                    securities = s
                }).Join(portfolios, m => m.transactions.PortfolioId, p => p.PortfolioId, (m, p) => new TypeBBB
                {
                    CUSIP = m.securities.CUSIP,
                    PortfolioCode = p.PortfolioCode,
                    Nominal = m.transactions.PortfolioId,
                    TransactionType = m.transactions.TransactionType
                });

                #region Write file
                var csvWriteFileDescription = new CsvFileDescription
                {
                    FirstLineHasColumnNames = true,
                    SeparatorChar = '|',
                };
                var csvWriteContext = new CsvContext();
                csvWriteContext.Write(resultBbb, Constants.OutputTypeBBB, csvWriteFileDescription);
                MessageBox.Show("Writing to output file sucesfull");
                #endregion
            }
            catch (Exception exception)
            {
                logger.Error(exception, $"Error while writing to Output file [{Constants.OutputTypeBBB}]");
            }

        }
        public void OnProcessOutputTypeCCC(object args)
        {
            try
            {
                logger.Info($"Started writing file [{Constants.OutputTypeCCC}]");
                IEnumerable<TypeCCC> resultCcc = transactions.Join(securities, t => t.SecurityId, s => s.SecurityId, (t, s) => new
                {
                    transactions = t,
                    securities = s
                }).Join(portfolios, m => m.transactions.PortfolioId, p => p.PortfolioId, (m, p) => new TypeCCC
                {
                    PortfolioCode = p.PortfolioCode,
                    Ticker = m.securities.Ticker,
                    Nominal = m.transactions.PortfolioId,
                    TransactionType = m.transactions.TransactionType
                });

                #region Write file
                var csvWriteFile = new CsvFileDescription
                {
                    SeparatorChar = ',',                    
                    FirstLineHasColumnNames = true,
                };
                var csvWriteContext = new CsvContext();
                csvWriteContext.Write(resultCcc, Constants.OutputTypeCCC, csvWriteFile);
                MessageBox.Show("Writing to output file sucesfull");
                #endregion
            }
            catch (Exception exception)
            {
                logger.Error(exception, $"Error while writing to Output file [{Constants.OutputTypeCCC}]");
            }

        }
    }
   
}

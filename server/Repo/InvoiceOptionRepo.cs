using Invoices.WebApi.Models;
using System.Data;
using Microsoft.Data.Sqlite;
using Dapper;

namespace Invoices.WebApi.Repo
{
    public class InvoiceOptionRepo: IInvoiceOptionRepo
    {
        private IDbConnection _dbConnection { get; set; }
        public InvoiceOptionRepo()
        {
            _dbConnection = new SqliteConnection("Data Source = " + Environment.CurrentDirectory + "\\data\\invoice_options_db.sqlite3");
        }

        public IEnumerable<InvoiceOption> GetInvoiceOptions()
        {
            return _dbConnection.Query<InvoiceOption>("select * from invoice_options").AsList();
        }

        public IEnumerable<InvoiceOption> GetInvoiceOptions(int invoiceTypeCode, int categoryId)
        {
            return _dbConnection.Query<InvoiceOption>("select * from invoice_options where InvoiceTypeCode = @I and CategoryId = @C", new {I = invoiceTypeCode, C = categoryId}).AsList();
        }
    }
}

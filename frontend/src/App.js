import React, { useEffect, useState } from 'react';
import "./App.css";

export const App = () => {
    const [invoiceOptions, setInvoiceOptions] = useState([]);
    const [loading, setLoading] = useState(true);
    

    useEffect(() => {
        (async () => {
            await fetchInvoiceOptions();
        })();
    }, [])
    
    const renderInvoiceOptions = (invoiceOptions) => {
        return (
            invoiceOptions.length === 0
            ? <p>No Invoices options found.</p>
            : invoiceOptions.map((i) => <div className='card'>
                            <span>Invoice Type: {i.invoiceTypeCode} - {i.invoiceTypeDescription}</span><br></br>
                            <span>Line Item Code: {i.categoryId}.{i.subCategoryId}</span><br></br>
                            <span>Line Item Description: {i.categoryDescription} - {i.subCategoryDescription}</span>
                        </div>)
        );
    }

    const fetchInvoiceOptions = async (invoiceTypeCode, categoryId) => {
        let url = '/api/invoiceoption'
        if (invoiceTypeCode && categoryId) {
            url += `/${invoiceTypeCode}/${categoryId}`
        }

        const response = await fetch(url);
        const data = await response.json();
        setInvoiceOptions(data);
        setLoading(false);
    }

    const submitForm = (e) => {
        e.preventDefault();
        console.log(e);
        fetchInvoiceOptions(e.target.elements.invoiceTypeCode.value, e.target.elements.categoryId.value)
    }
    const resetForm = (e) => {
        e.target.form.reset();
        fetchInvoiceOptions();
    }

    let contents = loading
            ? <p><em>Loading...</em></p>
            : renderInvoiceOptions(invoiceOptions);

    return (
            <>
                <header>
                    <h1 id="tabelLabel" className='App'>Invoice Options</h1>
                    <form onSubmit={submitForm}>
                        <div className="field">
                            <div className="control">
                                <label className="label" htmlFor="invoiceTypeCode">Invoice Type Code:</label>
                                <input id="invoiceTypeCode" className="input is-small" type="number" name="invoiceTypeCode" required></input>
                            </div>
                            <div className="control">
                                <label className="label" htmlFor="categoryId">Category Id:</label>
                                <input id="categoryId" className="input is-small" type="number" name="categoryId" required></input>
                            </div>
                        </div>
                        <div className="field">
                            <div className="control">
                                <input type="submit" value="Fetch Invoic Options"></input>
                            </div>
                            <div className="control">
                                <input type="button" value="Reset" onClick={resetForm}></input>
                            </div>
                        </div>
                    </form>
                </header>
                <main className='container'>
                    {contents}
                </main>
            </>
    );
}

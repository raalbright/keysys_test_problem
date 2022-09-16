import csv
import sqlite3

conn = sqlite3.connect('invoice_options_db.sqlite3')
cursor = conn.cursor()

with open('schema.sql') as f:
    cursor.executescript(f.read())

stmnt = 'insert into invoice_options (InvoiceTypeCode, InvoiceTypeDescription, CategoryId, CategoryDescription, SubCategoryId, SubCategoryDescription) values (?, ?, ?, ?, ?, ?)'

v = []
with open('GetInvoiceOptions_FC_933_6992761995.xlsx - Sheet1.csv', newline='') as f:
    csvreader = csv.DictReader(f)
    for row in csvreader:
        v.append((row["ns3:InvoiceTypeCode"],  row["ns3:InvoiceTypeDescription"], row["ns3:CategoryID"],  row["ns3:CategoryDescription"],  row["ns3:SubCategoryID"],  row["ns3:SubCategoryDescription"]))
        
cursor.executemany(stmnt, v)
conn.commit()
conn.close()
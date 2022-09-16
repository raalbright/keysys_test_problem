create table if not exists invoice_options (
    InvoiceTypeCode int not null,
    InvoiceTypeDescription text not null,
    CategoryId int not null,
    CategoryDescription text not null,
    SubCategoryId int not null,
    SubCategoryDescription text not null
);
### Planering Labb 2 - Webbutveckling

## Endpoints

# Products

| Path                    | Method | Request     | Response   | Status Code |
| ----------------------- | ------ | ----------- | ---------- | ----------- |
| "/products"             | GET    | NONE        | Products[] | 200         |
| "/products/id={id}"     | GET    | int Id      | Product    | 200, 404    |
| "/products/name={name}" | GET    | string Name | Product    | 200, 404    |
| "/products"             | POST   | Product     | NONE       | 200, 400    |
| "/products/id={id}"     | PUT    | int Id      | NONE       | 200, 404    |
| "/products/id={id}"     | DELETE | int Id      | NONE       | 200, 404    |

# Category

| Path                  | Method | Request | Response   | Status Code |
| --------------------- | ------ | ------- | ---------- | ----------- |
| "/categories"         | GET    | NONE    | Products[] | 200         |
| "/categories/id={id}" | GET    | int Id  | Product    | 200, 404    |
| "/categories"         | POST   | Product | NONE       | 200, 400    |
| "/categories/id={id}" | PUT    | int Id  | NONE       | 200, 404    |
| "/categories/id={id}" | DELETE | int Id  | NONE       | 200, 404    |

# Customers

| Path                 | Method | Request      | Response    | Status Code |
| -------------------- | ------ | ------------ | ----------- | ----------- |
| "/customers"         | GET    | NONE         | Customers[] | 200         |
| "/customers/{id}"    | GET    | int Id       | Customer    | 200, 404    |
| "/customers/{email}" | GET    | string Email | Customer    | 200, 404    |
| "/customers"         | POST   | Customer     | NONE        | 200, 400    |
| "/customers/{id}"    | PUT    | int Id       | NONE        | 200, 404    |
| "/customers/{id}"    | DELETE | int Id       | NONE        | 200, 404    |

# Orders

| Path           | Method | Request | Response | Status Code |
| -------------- | ------ | ------- | -------- | ----------- |
| "/orders"      | GET    | NONE    | Orders[] | 200         |
| "/orders/{id}" | GET    | int Id  | Order    | 200, 404    |
| "/orders"      | POST   | Order   | NONE     | 200, 400    |
| "/orders/{id}" | DELETE | int Id  | NONE     | 200, 404    |

## DATA

# Product

| Property Name | Data Type | Description                                | Data Annotation             |
| ------------- | --------- | ------------------------------------------ | --------------------------- |
| ProductId     | int       | Id of the product                          | Key                         |
| Name          | string    | Name of the product                        | Required                    |
| Description   | string    | Information about the product              | NONE                        |
| Price         | decimal   | Price of the product                       | DataType(DataType.Currency) |
| Image         | string    | String path to the image                   | NONE                        |
| CategoryId    | int       | Id of the category for the product         | NONE                        |
| Categroy      | Category  | Category of the product                    | NONE                        |
| IsInStorage   | bool      | Check the status of the product in storage | NONE                        |

# Category

| Property Name | Data Type | Description          | Data Annotation |
| ------------- | --------- | -------------------- | --------------- |
| CategoryId    | int       | Id of the category   | Key             |
| Name          | string    | Name of the category | Required        |

# Customer

| Property Name | Data Type | Description                   | Data Annotation            |
| ------------- | --------- | ----------------------------- | -------------------------- |
| CustomerId    | int       | Id of the customer            | Key                        |
| FirstName     | string    | First name of the customer    | Required                   |
| LastName      | string    | Last name of the customer     | Required                   |
| Email         | string    | Email adress to the customer  | EmailAdress, Required      |
| Phone         | string    | Phone number to the customer  | Phone, Required            |
| Adress        | string    | Streetadress for the customer | NONE                       |
| PostalCode    | string    | Postalcode for the customer   | RegularExpression(@"^\d+$) |
| City          | string    | City for the customer         | NONE                       |
| Country       | string    | Country for the customer      | NONE                       |

# Order

| Property Name | Data Type                 | Description                     | Data Annotation |
| ------------- | ------------------------- | ------------------------------- | --------------- |
| OrderId       | int                       | Id of the order                 | Key             |
| CustomerId    | int                       | Id of the customer on the order | NONE            |
| Customer      | Customer                  | Customer on the order           | NONE            |
| Product       | ICollection<OrderProduct> | Products in the order           | NONE            |

# OrderProduct

| Property Name | Data Type | Description                    | Data Annotation |
| ------------- | --------- | ------------------------------ | --------------- |
| Id            | int       | Id of the product in the order | Key             |
| OrderId       | int       | Id of the order                | NONE            |
| ProductId     | int       | Id of the product              | NONE            |

# Cotancts

This API project provides you to create a contact list and its detail info such as location, phone or e-mail. 

### Installation
First thing after you download source codes is to write connection string of your postgre sql server in **Cotact.DataAccess/dalsaettings.json**. And then migrate database structure to the server by using *update-database*.

`{
  "ConnectionStrings": {
    "Default": "conn"
  }
}`

The second is to type AMQP URL in **Contact.API/appsettings.json** for RabbitMQ Client.

`{
  "RabbitMQConnection": "abc"
  }`

### Usage and Endpoints

This API is a REST Api. So you can consume this api according to REST Api rules.

#### To manage contact
**{domain}/api/people** - GET 	 				(List all contacts)

**{domain}/api/people/{guid}** - GET		(Get a contact by uuid)

**{domain}/api/people** - POST				(Add new contact)
###### Requet body
`{"Name":"a name", "Surname":"A surname"}`

**{domain}/api/people/{guid}** - PUT	(Update contact)
###### Requet body
`{"Name":"a name", "Surname":"A surname"}`

**{domain}/api/people/{guid}** - DELETE (Delete contact)

#### To manage contact detail infos

**{domain}/api/infotypes** - GET (List info types)
`{
        "Phone": 0,
        "Email": 1,
        "Location": 2
}`

**{domain}/api/people/{guid}/contactinfos** - GET (List contact infos by person)

**{domain}/api/people/{guid}/contactinfos/{id}** - GET (Get a contact info data by ID)

**{domain}/api/people/{guid}/contactinfos** - POST (Add new info)
###### Requet body
`{"InfoType":2, "Info":"Istanbul"}`

`{"InfoType":0, "Info":"+905xxxxxxxx"}`

**{domain}/api/people/{guid}/contactinfos** - PUT (Update contact info)
###### Requet body
`{"InfoType":2, "Info":"Ankara"}`

`{"InfoType":0, "Info":"+906xxxxxxxx"}`

**{domain}/api/people/{guid}/contactinfos** - DELETE (Delete contact info)

#### To manage reports

**{domain}/api/reports** - GET (List all reports)

**{domain}/api/reports/{guid}** - GET (Get a report by uuid)

**{domain}/api/reports/createnewreport** - GET (A request that sends a message to background service via RabbitMQ)

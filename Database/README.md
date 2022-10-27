# Database

Nämä pitää ajaa ensin  
`Add-Migration Initial`  
`Update-Database`  
Database.SampleApp kansioon tulee school.db, laita tälle ominaisuudet copy always, jolloin kopioi aina tyhjän kannan bin\debug kansioon

## Database.SampleApp

Configuration root

## Database.Application

Logic for application  
ISampleRepository interface  

## Database.SampleRepository

Repository implementation, with EF Core Models.
Implements the ISampleRepository interface

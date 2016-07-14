# Restaurant Webpage

#### CSharp Database Basics Project for Epicodus, 07/13/2016

#### By Shradha Pulla & Ryan Streur

## Description

Website where users can add their favorite restaurants by the type of cuisine they offer.

## Setup/Installation Requirements

This program can only be accessed on a PC with Windows 10, and with git and atom installed.

* Clone this repository
* Type following command into the Windows PowerShell > dnu restore
* Type following command into PowerShell > dnx kestrel
* Open Chrome and type in the following address: "localhost:5004"

## Known Bugs

No known bugs.

## Specifications

The program should ... | Example Input | Example Output
----- | ----- | -----
User can create a cuisine | User inputs cuisine name | app stores Cuisine object and creates a cuisine page
User can create a restaurant | User inputs restaurant name and cuisine ID | App adds restaurant name to cuisine page
Display restaurant by cuisine | User inputs restaurant name | app outputs cuisine list for that restaurant
No repeat names for cuisines and restaurants | User tries to add a new restaurant or cuisine, but the name of that restaurant or cuisine is already associated with an existing cuisine or restaurant | App returns an error page describing the situation
Delete individual restaurant entry | User clicks button to delete specific restaurant | ---
Delete entire cuisine category | --- | ---

## Future Features

HTML | CSS | C#
----- | ----- | -----
----- | ----- | -----

## Support and Contact Details

Contact Epicodus for support in running this program.

## Technologies Used

* HTML
* CSS
* Bootstrap
* C#

## License

*This software is licensed under the Microsoft ASP.NET license.*

Copyright (c) 2016 Shradha Pulla & Ryan Streur

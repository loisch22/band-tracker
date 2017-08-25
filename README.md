# _Band Tracker_

#### _Users can input and/or view bands and venues._

#### By _**Lois Choi**_

## Description

_Users are able to use this application to see which bands performed at which venues and which venues hosted which bands. Users can also add a venue and/or add a band as well._

## Setup/Installation Requirements

* _Requires MAMP and MySQL as well as C# and .NET_

_Download the necessary files from my <a href="https://github.com/loisch22/band-tracker.git">GitHub Page.</a>_

| Specifications | Input   | Output   |
| -------  | ------- | -------   |
| 1. User can add a venue | >Add Venue Form | >New Venue added, confirmation shown, list of venues shown |
| 2. User can add a band | >Add Band Form | >New Band added, confirmation shown, list of bands shown |
| 3. User can click a venue to see its details and add a band to that venue | >Add band to venue  | >Band name displayed on specific venue details page |
| 4. User can click on band to see its details and add a venue to that band | >Add venue to band  | >Venue name displayed on specific band details page |
| 5. User can update a venue's details | >Update venue detail | >Updated details display in place of old details |
| 6. User can delete a venue and its bands | >Delete venue  | >Updated >Venue and list of bands for that venue deleted |

## <a href="http://ondras.zarovi.cz/sql/demo/">WWW SQL Designer</a>
![](/schema.png)

## Database Setup
| >mysql  |
| -------  |
| Turn on server |
| ~ /Applications/MAMP/Library/bin/mysql --host=localhost -uroot -proot |
| > CREATE DATABASE band_tracker; |
| > USE band_tracker; |
| > CREATE TABLE bands (id serial PRIMARY KEY, name VARCHAR(255)); |
| > CREATE TABLE venues (id serial PRIMARY KEY, name VARCHAR(255)); |
| > CREATE TABLE bands_venues (id serial PRIMARY KEY, band_id INT, venue_id INT);|

## Known Bugs

_There are currently no known bugs in this program._

## Support and contact details

_For questions, please contact Lois Choi at loisch22@gmail.com _

## Technologies Used

_This app is programmed using HTML, CSS, C#, .NET, MVC, and Bootstrap._

### License

*All rights reserved.  Version 1.0.*

Copyright (c) 2017 **_Lois Choi_**

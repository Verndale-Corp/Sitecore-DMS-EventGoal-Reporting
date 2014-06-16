Verndale DMS Goal Reporting Tool for Sitecore

Purpose
Report on the DMS Goal Events that have been triggered by users

Compatibility
The codebase is compatible with Sitecore 6.6.x releases that have Analytics enabled.  
It should work with earlier and later versions though.
This assumes you have enabled Sitecore Analytics and setup the Analytics database

How to build code and deploy the solution
1. Install the Sitecore package 'DMS Goal Reporting.zip'
This will copy some files into the sitecore modules/Web/DMSTools folder
It will also create an application in the Core database referencing the new DMS Goal Report file.

2. Add the analyticsdata project to your solution and reference it from your Website project.  
This contains a simple dbml file that references a couple of the tables in the Analytics database (PageEvent and PageEventDefinition) and a couple classes that uses LINQ to SQL to retrieve analytics data


Testing
1. Open up the tool by opening sitecore in Desktop mode and navigating via the Sitecore start button to the DMS Reporting Tool link in the right menu column



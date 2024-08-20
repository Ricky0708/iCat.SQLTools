# iCat.SQLTools
   
  <p>This is a sql tools collection, it support developer to maintain schema description, and can be export to db schema document.<br/>
  (if table,sp,func name over then 31 char, it will display [TempNameX] in xlsx column, cause excel sheet name only support 31 char)</p>

   <p>
      ※ Code generator for Oracle can't be used yet.
   </p>

#Current features
* **Tables**
   * Maintain DB description for MSSQL
   * Export dbschema to xlsx file for MSSQL, MySQL

* **Code generation**
   * Generate class file with comment (can't generate comment for complex script) from MSSQL, MySQL
   * Generate Dapper CRUD code for MSSQL, MySQL

# History   
* **v2.0.0-Beta**
   * Refactor to .net 8, and remove unnecessary feature
   * Multiple database operations are supported.

* **v1.2.1.0**
   * Generate sp input parameters to model
<p>

* **v1.2.0.0**
   * 『SP Generator』 is available, this feature can generate basic CRUD stored procedures
   * fix export excel file with wrong script description
<p>

* **v1.1.3.1**
   * Adjust UI in 『POCO & Xsd』, and auto open folder after generate files..

* **v1.1.3.0**
   * Update all description
    <br/>
         Now can load from xml file and cover all description to SQL <br/>
         this function usually use in after create a database and copy description from old to new one 
<p>

* **v1.1.2.0**
   * Use TSQL to generate and export xsd schema file for Crystal Report use   
<p>

* **v1.1.1.0**
   * Batch generate model from database to .cs(utf-8) file
<p>

* **v1.1.0.0**
   * 『POCO Generator』 is available ( use script to generate model calss )
          <br/>
          It can also auto generate script when double click row in datagrid 『Tables』..
<p>

* **v1.0.2.2**
   * When every 『Tables』 tabPage load data from SQL, they own self sql connection, make user can maintain different db at the same time
   * Load data from sql, tables sort by TableName
<p>

* **v1.0.2.1**
   * Fix bug『Xml Compare』-doesn't load file path from second xml file when start compare
   * move config setting to 『Tables』→『SQL Server』 block
<br/>

* **v1.0.2.0**
   * Add 『Xml Compare』, can compare databse schema from two xml files 
         </br>(Table、SP、Func only compare name, and column compare all the information)
   * Can open multiple 『Tables』
<p>

* **v1.0.1.0**
   * Filter table name and sp's 、func's name
<p>

* **v1.0.0.0**
   * Load database schema from SQL Server
   * Load xml file from xml file
   * Can maintain table's 、column's description and update to database
   * Output schema to Excel、Xml file

  

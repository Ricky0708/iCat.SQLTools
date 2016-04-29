# RickySQLTools
   
  <p>This is a sql tools collection, it support developer to maintain schema description, and can be export to db schema document or xml file also.<br/>
  (if table,sp,func name over then 31 char, it will display [TempNameX] in xlsx column, cause excel sheet name only support 31 char)</p>
  <p>And it support many features..</p>
  <ul>Current features:
    <li><ul><a>Tables</a>
          <li>Maintain db description</li>
          <li>Export dbschema to xlsx file or xml file</li>
        <ul/>
    <li>
    <li><ul><a>Xml Compare</a>
          <li>Compare two schema xml files</li>
        <ul/>
    <li>
    <li><ul><a>POCO & Xsd</a>
          <li>Generate poco .cs file from db</li>
          <li>Generate poco class use TSQL</li>
          <li>Generate xsd for Crystal Report use TSQL</li>
        <ul/>
    <li>
  <ul/>

# History   
   <ul><a>v1.1.3.0</a>
    <li> Update all description
    <br/>
         Now can load from xml file and cover all description to SQL <br/>
         this function usually use in after create a database and copy description from old to new one
    </li>
  </ul>   
   
  <ul><a>v1.1.2.0</a>
    <li> Use TSQL to generate and export xsd schema file for Crystal Report use</li>
  </ul>   
   
  <ul><a>v1.1.1.0</a>
    <li> Batch generate model from database to .cs(utf-8) file
  </ul>   
   
  <ul><a>v1.1.0.0</a>
    <li> 『POCO Generator』 is available ( use script to generate model calss )
          <br/>
          It can also auto generate script when double click row in datagrid 『Tables』..</li>
  </ul>   
  
  <ul><a>v1.0.2.2</a>
    <li> When every 『Tables』 tabPage load data from SQL, they own self sql connection, make user can maintain different db at the same time</li>
    <li> Load data from sql, tables sort by TableName</li>
  </ul>   
  
  <ul><a>v1.0.2.1</a>
    <li> Fix bug『Xml Compare』-doesn't load file path from second xml file when start compare
    <li> move config setting to 『Tables』→『SQL Server』 block
  </ul>      
  
  <ul><a>v1.0.2.0</a>
    <li> Add 『Xml Compare』, can compare databse schema from two xml files 
         </br>(Table、SP、Func only compare name, and column compare all the information)</li>
    <li> Can open multiple 『Tables』</li>
  </ul>
  
  <ul><a>v1.0.1.0</a>
    <li> Filter table name and sp's 、func's name</li>
  </ul>
  <ul><a>v1.0.0.0</a>
    <li> Load database schema from SQL Server</li>
    <li> Load xml file from xml file</li>
    <li> Can maintain table's 、column's description and update to database</li>
    <li> Output schema to Excel、Xml file</li>
  </ul>
  

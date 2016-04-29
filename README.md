# RickySQLTools
   
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

  <br/>
  
  這一個程式可以讀出 Database的table、column相關資料及註解
  
  並能夠編輯註解並更新回 Database
  
  程式提供匯出文件的功能，將table的schema、描述、sp、func利用npoi匯出至Excel
  
  sp及func的註解必需寫在sql script中，以/** xxx **/包夾起來，才能正確的匯出sp及func的註解
  
  ※如果table、sp、func的名稱長度超過31個字元，匯出至excel後會出現『TempName』加流水號的字樣
   這是因為Excel的sheet name只限制31個字元
  
  ※說明書為CHM檔，如果下載後需要解除封鎖，『右鍵』→『內容』→在右下角會看見『解除封鎖』，勾選即可
  

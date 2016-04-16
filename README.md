# RickySQLTools
  
  <ul><a>v1.2</a>
    <li> Add Xml compare, can compare databse schema from two xml files </li>
    <li> can open multiple 『Tables』</li>
  </ul>
  <ul><a>v1.1</a>
    <li> filter table name and sps name、funcs name</li>
  </ul>
  <ul><a>v1.0</a>
    <li> Load Database Schema from SQL Server</li>
    <li> Load xml file from xml file</li>
    <li> Can edit Tables sescription、columns description and update to database</li>
    <li> output schema to Excel、Xml file</li>
  </ul>
  
  這一個程式可以讀出 Database的table、column相關資料及註解
  
  並能夠編輯註解並更新回 Database
  
  程式提供匯出文件的功能，將table的schema、描述、sp、func利用npoi匯出至Excel
  
  sp及func的註解必需寫在sql script中，以/** xxx **/包夾起來，才能正確的匯出sp及func的註解
  
  ※如果table、sp、func的名稱長度超過31個字元，匯出至excel後會出現『TempName』加流水號的字樣
   這是因為Excel的sheet name只限制31個字元
  
  ※說明書為CHM檔，如果下載後需要解除封鎖，『右鍵』→『內容』→在右下角會看見『解除封鎖』，勾選即可
  

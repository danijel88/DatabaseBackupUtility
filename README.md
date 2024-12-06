# DatabaseBackupUtility
https://roadmap.sh/projects/database-backup-utility

## Overview
The Database Backup Utility is a versatile tool designed to simplify the process of creating and restoring backups for various database management systems (DBMS). This tool is especially useful for developers and administrators who need a reliable way to manage database backups via a command-line interface.

## Features
* Multi-DBMS Support: Supports MSSQL at the moment.
* Automated Backups: Easily set up automated backups with configurable options.
* Command-Line Interface: Manage backups and restores using simple command-line commands.
* Flexible Storage Options: Store backups locally.
* Notifications: Receive notifications via console upon completion of backup or restore operations.
* Modular Architecture: Easily extend the tool to support additional DBMS or custom storage solutions.

## Supported Database
* MSSQL: Commonly used in Microsoft products

## Installation
* Download the Executable: Download the latest release of DatabaseBackupUtility.exe from the Releases page.
* Prepare Configuration file:
  - Modify a MsSqlConfig.json file which can be found inside of folder DbConfig
  - Example of MsSqlConfig.json
`{
  "Server": "xxx.xxx.xxx.xxx",
  "Database": "dbName",
  "UserId": "user id",
  "Password": "uer passwrod",
  "Port": "1433",
  "StorageLocation": "D:\\Backups\\",
  "BackupName": "db.bak" ,
  "RestoreDbName": "NewDbName",
  "RestoreMdfPath": "",
  "RestoreLdfPath": ""
}`
* Run the tool:
  - Open a command line interface and navigate to directory containng DatabaseBackupUtility.Exe
  - Exectue commands to preform backups or restores
# Usage
## Backup
- To create a full backup of your database:
  `DatabaseBackupUtility.exe --provider mssql --action backup --backupType full`
- To create a diffrential backup of your database:
  `DatabaseBackupUtility.exe --provider mssql --action backup --backupType diff`
- To create a incremental backup of your database:
  `DatabaseBackupUtility.exe --provider mssql --action backup --backupType inc`
## Restore
To restore your database from backup(do not forget to populate config file otherwise restore will not be done):
`DatabaseBackupUtility.exe --provider mssql --action restore`
## Next Steps
- Uploading to cloud backup
- Adding other DBMS providers

# AdoNet-Disconnected-CRUD
A professional implementation of ADO.NET's disconnected model with SqlDataAdapter, DataSet, and full CRUD operations.

# 🏗️ ADO.NET Disconnected CRUD Implementation

![Demo Screenshot](.docs/screenshot.png) 

practices:
- ✅ **CRUD operations** (Create, Read, Update, Delete)
- ✅ **Secure parameterized queries** (prevents SQL injection)
- ✅ **Optimistic concurrency** (handles offline changes)
- ✅ **Efficient connection management** (minimizes DB overhead)

## 🛠️ Technologies Used
- Microsoft.Data.SqlClient
- DataSet / SqlDataAdapter
- WinForms (for UI demo)

## 🚀 Features
| Feature               | Description                                                                 |
|-----------------------|-----------------------------------------------------------------------------|
| **Disconnected Mode** | Data loaded into `DataSet`, edits made offline, and batched to the database |
| **Parameterized SQL** | Safe from SQL injection via `SqlParameter`                                  |
| **UI Integration**    | Seamless binding with `DataGridView`                                        |

## 🏁 Getting Started

### Prerequisites  
- SQL Server (Express/LocalDB)  
- Visual Studio 2022
  
### Setup
1. **Clone the repo**:
   ```bash
   git clone https://github.com/Reemolotfy/AdoNet-Disconnected-CRUD.git

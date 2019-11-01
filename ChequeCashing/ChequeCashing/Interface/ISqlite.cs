using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChequeCashing.Interface
{
    public interface ISqlite
    {
        SQLiteConnection GetConnection();
    }
}

Imports MySql.Data.MySqlClient
Module myModule
    Public connect As New MySqlConnection(My.Settings.con)
    Public mda As New MySqlDataAdapter("", connect)
    Public comm As New MySqlCommand("", connect)
    Public dreader As MySqlDataReader

End Module
